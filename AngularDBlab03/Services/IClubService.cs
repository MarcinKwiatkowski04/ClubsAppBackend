using AngularDBlab03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDBlab03.Services
{
    public interface IClubService
    {
        public Task<Club> updateClub(Club club);
        public Task<Club> deleteByClubId(Guid clubId);
    }
}
