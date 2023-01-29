using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _repository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data.

            // Convert to domain entity object.
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            // Add to database.
            await _repository.CreateAsync(leaveTypeToCreate);

            // Return record Id.
            return Unit;
        }
    }
}