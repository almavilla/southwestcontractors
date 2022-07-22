using System.Net.Http;

namespace SouthWestContractors.BlazorClient.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
