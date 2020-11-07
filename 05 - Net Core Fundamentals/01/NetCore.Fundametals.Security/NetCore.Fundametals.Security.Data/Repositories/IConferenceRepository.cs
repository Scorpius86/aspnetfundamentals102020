using NetCore.Fundamentals.Security.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public interface IConferenceRepository
    {
        Task<int> Add(ConferenceDto conferenceDto);
        Task<List<ConferenceDto>> GetAll();
        Task<ConferenceDto> GetById(int conferenceId);
    }
}