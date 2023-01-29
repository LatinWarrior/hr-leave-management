using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    // public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    // {

    // }

    // A Record, as opposed to a Class, is immutable
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    {

    }
}