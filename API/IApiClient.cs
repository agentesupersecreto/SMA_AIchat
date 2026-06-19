using System.Collections;

namespace DialogInterceptorMod.API
{
    public interface IApiClient
    {
        IEnumerator SendMessage(string userMessage);
    }
}
