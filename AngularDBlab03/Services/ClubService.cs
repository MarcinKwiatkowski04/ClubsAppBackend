using AngularDBlab03.Models;
using AngularDBlab03.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDBlab03.Services
{
    public class ClubService:IClubService
    {
        private readonly IClubRepozitory clubRepozitory;

        public ClubService(IClubRepozitory _clubRepozitory)
        {
            clubRepozitory = _clubRepozitory;
        }

        public async Task<Club> deleteByClubId(Guid clubId)
        {
            var club = await clubRepozitory.getClubById(clubId);

            await clubRepozitory.deleteClub(club);

            return club;
        }

        public async Task<Club> updateClub(Club club)
        {

            var clubb = await clubRepozitory.getClubById(club.ClubId);

            clubb.Name = clubb.Name;
            clubb.Country = clubb.Country;


            await clubRepozitory.saveAll();


            return clubb;
        }
    }
}
