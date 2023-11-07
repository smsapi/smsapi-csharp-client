using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace smsapiTests.Unit.Helper;

public static class DictionaryToStreamHelper
{
    public static Task<Stream> ToHttpEntityStreamTask(this Dictionary<string, dynamic> dictionary)
    {
        var json = JsonConvert.SerializeObject(dictionary);
        var bytes = Encoding.ASCII.GetBytes(json);
        
        return Task.FromResult(new MemoryStream(bytes) as Stream);
    }
}
