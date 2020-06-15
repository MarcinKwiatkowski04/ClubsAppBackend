using AngularDBlab03.DTO;
using AngularDBlab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDBlab03.Repository
{
    public interface IClubRepozitory
    {
        Task<IEnumerable<Club>> getAllClubs();

        Task<Guid> addClub(ClubPostDTO clubPostDTO);
        Task<Club> getClubById(Guid userId);

        Task<Boolean> saveAll();

        Task<Boolean> deleteClub(Club club);
    }
}


