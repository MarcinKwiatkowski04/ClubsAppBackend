using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDBlab03.DTO
{
    public class ClubPutDTO
    {
        [Key]
        public Guid ClubId { get; set; }
        
        public string Name { get; set; }
       
        public string Country { get; set; }

        public string ImagePath { get; set; }
    }
}
