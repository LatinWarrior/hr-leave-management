using System.Security.Cryptography;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _repository;

        public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data.

            // Convert to domain entity object.
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            // Add to database.
            await _repository.UpdateAsync(leaveTypeToUpdate);

            // Return Unit value.
            return Unit.Value;
        }
    }
}