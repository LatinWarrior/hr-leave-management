using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _repository;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;

        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database.
            var leaveTypes = await _repository.GetAsync();

            // Convert data objects to DTO objects.
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // Return list of DTO objects.
            return data;
        }
    }
}