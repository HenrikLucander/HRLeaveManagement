using System.Net.Http;

namespace HR.LeaveManagement.MVC.Services.Base
{
    // partial as ServiceClient NSwag generated code also has partial class Client.
    // partial classes merge at runtime.
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
