using System.Net.Http;

namespace SouthWestContractors.ClientApp.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
