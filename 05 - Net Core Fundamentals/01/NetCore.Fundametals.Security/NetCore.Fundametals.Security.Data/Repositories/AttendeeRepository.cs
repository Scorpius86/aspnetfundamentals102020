using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundamentals.Security.Data.Adapters;
using NetCore.Fundamentals.Security.Data.Context;
using NetCore.Fundamentals.Security.Dtos;

namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly NetcoreFundametalsSecurityDbContext _dbContext;

        public AttendeeRepository(NetcoreFundametalsSecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Add(AttendeeDto attendeeDto)
        {
            var entity = ConferenceAdapter.FromAttendeeDtoToAttendee(attendeeDto);
            _dbContext.Attendees.Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> GetAttendeesTotal(int conferenceId)
        {
            return _dbContext.Attendees.CountAsync(a => a.ConferenceId == conferenceId);
        }
    }
}
