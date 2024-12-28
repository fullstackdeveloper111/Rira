using Grpc.Core;
using RiragRPCAPI;
namespace RiraAPI.gRPCServices;

public class UserService : RiragRPCAPI.UserService.UserServiceBase
{
    public async override Task<GetUsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
    {
        //return base.GetUsers(request, context);
        return new GetUsersResponse
        {
            DateOfBirth = "test",
            Family = "test",
            Name = "test",
            NationalCode = "test"
        };
    }
}
