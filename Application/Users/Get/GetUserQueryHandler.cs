using Domain;
using Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Create;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IList<GetUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public GetUserQueryHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IList<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return _userRepository.Get(u =>
        {
            if (!string.IsNullOrEmpty(request.Name))
                u.Where(x=>x.Name.Contains(request.Name));
            if (!string.IsNullOrEmpty(request.Family))
                u.Where(x => x.Family.Contains(request.Family));
            if (!string.IsNullOrEmpty(request.NationalCode))
                u.Where(x => x.NationalCode.Contains(request.NationalCode));
            if (request.FromDateOfBirth.HasValue)
                u.Where(x => x.DateOfBirth <= request.FromDateOfBirth);
            if (request.ToDateOfBirth.HasValue)
                u.Where(x => x.DateOfBirth >= request.ToDateOfBirth);
            return u;
        })
            .Select(x => new GetUserResponse(x.UserId.Value, x.Name, x.Family, x.NationalCode, x.DateOfBirth))
            .ToList();        
    }
}
