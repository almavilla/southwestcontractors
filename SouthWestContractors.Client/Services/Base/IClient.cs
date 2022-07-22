using System.Net.Http;

namespace SouthWestContractors.Client.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}
