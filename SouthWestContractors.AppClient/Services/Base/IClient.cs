using System.Net.Http;

namespace SouthWestContractors.AppClient.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
