using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrHelperBack.DTOs
{
    public class UsersDiseasesReadDTO
    {
        public int idUsersDiseases { get; set; }
        public int idUser { get; set; }
        public int idDisease { get; set; }
        public DateTime occurrenceDate { get; set; }
        public string description { get; set; }
    }
}
