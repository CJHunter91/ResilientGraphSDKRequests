using Microsoft.Graph;
using Microsoft.Graph.Auth;
using ResilientGraphSDKRequests.Policies;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ResilientGraphSDKRequests.ServiceClients
{

    public class MSGraphServiceClientAdaptor : IMSGraphServiceClientAdaptor
    {
        private readonly IGraphServiceClient _graphServiceClient;

        public MSGraphServiceClientAdaptor(ClientCredentialProvider authProvider, IHttpClientFactory httpClientFactory)
        {
            _graphServiceClient = new GraphServiceClient(httpClientFactory.CreateClient(PolicyNames.GraphHttpClient)) { AuthenticationProvider = authProvider };
        }
        public async Task<IEnumerable<string>> GetUsers()
        {
            var usersPage = await _graphServiceClient.Users.Request().GetAsync();
            return usersPage.CurrentPage.Select(user => user.UserPrincipalName);
        }
    }

}
