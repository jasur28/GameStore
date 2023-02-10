using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    public class BaseEntity
    {
        public Guid Id { get;set; }
    }
}
