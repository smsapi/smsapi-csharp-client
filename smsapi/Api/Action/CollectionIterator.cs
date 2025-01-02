using System.Collections;
using System.Collections.Generic;
using SMSApi.Api.Response;

namespace SMSApi.Api.Action;

public sealed class CollectionIterator<T> : IEnumerable<T>
{
    private readonly Action<BasicCollection<T>> _action;
    private readonly uint _limit;

    public CollectionIterator(Action<BasicCollection<T>> action, uint limit)
    {
        _action = action;
        _limit = limit;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ActionCollectionEnumerator<T>(_action, _limit);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class ActionCollectionEnumerator<T> : IEnumerator<T>
    {
        private readonly uint _limit;
        private readonly Action<BasicCollection<T>> _action;
        private List<T> _currentBatch = new();
        private int _internalCollectionOffset;
        private int _apiCollectionSize;
        private uint _offset;
        private uint _overallOffset;

        public ActionCollectionEnumerator(Action<BasicCollection<T>> action, uint limit)
        {
            _action = action;
            _limit = limit;
        }

        public bool MoveNext()
        {
            if (_internalCollectionOffset >= _currentBatch.Count)
            {
                FetchNextFromApi();
                _internalCollectionOffset = 0;

                if (_currentBatch.Count == 0 || _overallOffset >= _apiCollectionSize) return false;
            }

            Current = _currentBatch[_internalCollectionOffset++];
            _overallOffset++;

            return true;
        }

        public void Reset()
        {
            _internalCollectionOffset = 0;
            _offset = 0;
            _currentBatch = new();
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _currentBatch = new();
        }

        private void FetchNextFromApi()
        {
            (_action as IPaginable)!.Limit = _limit;
            (_action as IPaginable)!.Offset = _offset;

            var apiResult = _action.Execute();
            _apiCollectionSize = apiResult.Size;
            _currentBatch = apiResult.Collection;

            _offset += _limit;
        }
    }
}

public static class ActionIteratorExtensions
{
    public static CollectionIterator<T> ToIterator<T>(this Action<BasicCollection<T>> action, uint limit = 25)
    {
        return new CollectionIterator<T>(action, limit);
    }
}
