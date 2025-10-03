using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace smsapiTests.Unit.Helper;

public static class StringToStreamHelper
{
    public static Task<Stream> ToHttpEntityStreamTask(this string @string)
    {
        var bytes = Encoding.UTF8.GetBytes(@string);
        var stream = new MemoryStream(bytes);
        
        return Task.FromResult<Stream>(stream);
    }
}
