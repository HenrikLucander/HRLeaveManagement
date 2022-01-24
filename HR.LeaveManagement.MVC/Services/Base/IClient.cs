using System.Net.Http;

namespace HR.LeaveManagement.MVC.Services.Base
{
    // partial as ServiceClient NSwag generated code also has partial interface IClient.
    // partial interfaces merge at runtime.
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
