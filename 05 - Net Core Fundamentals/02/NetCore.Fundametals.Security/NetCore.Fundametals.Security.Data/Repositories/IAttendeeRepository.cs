using NetCore.Fundamentals.Security.Dtos;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public interface IAttendeeRepository
    {
        Task<int> Add(AttendeeDto attendee);
        Task<int> GetAttendeesTotal(int conferenceId);
    }
}