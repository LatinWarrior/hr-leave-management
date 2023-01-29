using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _repository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database.
            var leaveType = await _repository.GetByIdAsync(request.Id);

            // Verify that record exists.
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            // Convert data objects to DTO objects.
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

            // Return list of DTO objects.
            return data;
        }
    }
}