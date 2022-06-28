using System.Net.Http;

namespace SouthWestContractors.ClientApp.Services
{
    public partial class Client : IClient
    {
        //HttpClient _httpClient = new HttpClient();
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
