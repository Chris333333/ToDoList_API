using Data.Entities.ToDoListDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    internal class UserRetriveDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Login { get; set; } = null!;

        public LocationRetriveDTO Location { get; set; } = null!;

        public  WorkPositionRetriveDTO WorkPosition { get; set; } = null!;
    }
}
