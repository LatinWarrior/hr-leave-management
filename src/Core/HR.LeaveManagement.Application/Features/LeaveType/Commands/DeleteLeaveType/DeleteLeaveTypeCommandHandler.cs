using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _repository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Retrieve domain entity object.
            var leaveTypeToDelete = await _repository.GetByIdAsync(request.Id);

            // Verify that record exists.
            if (leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            // Delete from database.
            await _repository.DeleteAsync(leaveTypeToDelete);

            // Return Unit value.
            return Unit.Value;
        }
    }
}