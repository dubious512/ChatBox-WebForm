using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ManageUser Admin { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
