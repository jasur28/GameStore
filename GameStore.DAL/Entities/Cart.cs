using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Entities
{
    public class Cart : BaseEntity
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}
