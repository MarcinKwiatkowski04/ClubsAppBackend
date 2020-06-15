using AngularDBlab03.DTO;
using AngularDBlab03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDBlab03.Repository
{
    public class ClubRepozitory: IClubRepozitory
    {
        private readonly ClubContext clubContext;

        public ClubRepozitory(ClubContext _context)
        {
            clubContext = _context;
        }

        public async Task<Guid> addClub(ClubPostDTO clubPostDTO)
        {
            Club club = new Club()
            {
                ClubId = Guid.NewGuid(),
                Name = clubPostDTO.Name,
                Country = clubPostDTO.Country,
                ImagePath = clubPostDTO.ImagePath
            };

            await clubContext.Clubs.AddAsync(club);
            await saveAll();
            return club.ClubId;

        }
        public async Task<bool> deleteClub(Club club)
        {

            clubContext.Clubs.Remove(club);
            await saveAll();
            return true;

        }

        public async Task<IEnumerable<Club>> getAllClubs()
        {
            return await clubContext.Clubs.ToListAsync();
        }


        public async Task<Club> getClubById(Guid id)
        {

            var club = await clubContext.Clubs.FirstOrDefaultAsync(x => x.ClubId == id);
            return club;
        }
        public async Task<Boolean> saveAll()
        {
            return await clubContext.SaveChangesAsync() > 0;
        }
        
    }
}
