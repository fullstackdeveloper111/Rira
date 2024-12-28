using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using RiragRPCAPI;

namespace RiraApiClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        public GetUsersResponse Get(GetUsersRequest request)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5093");
            var client = new UserService.UserServiceClient(channel);
            var res = client.GetUsers(request);
            return res;
        }
        
        [HttpGet(Name = "AddUser")]
        public CreateUserResponse AddUser(CreateUserRequest request)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5093");
            var client = new UserCreateService.UserCreateServiceClient(channel);
            var res = client.CreateUser(request);
            return res;
        }
        [HttpGet(Name = "RemoveUser")]
        public RemoveserResponse RemoveUser(RemoveUserRequest request)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5093");
            var client = new UserRemoveService.UserRemoveServiceClient(channel);
            var res = client.RemoveUser(request);
            return res;
        }
        
        [HttpGet(Name = "RemoveUser")]
        public UpdateserResponse RemoveUser(UpdateUserRequest request)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5093");
            var client = new UserUpdateService.UserUpdateServiceClient(channel);
            var res = client.UpdateUser(request);
            return res;
        }
    }
}
