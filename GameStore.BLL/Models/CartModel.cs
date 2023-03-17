using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Models
{
    public class CartModel
    {
        //public Guid Id { get; set; }
        public GameModel Game { get; set; }
        public int Quantity { get; set; }
    }
}
