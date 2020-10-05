using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace ResilientGraphSDKRequests.ServiceClients
{
    public interface IMSGraphServiceClientAdaptor
    {
        Task<IEnumerable<string>> GetUsers();
    }
}
