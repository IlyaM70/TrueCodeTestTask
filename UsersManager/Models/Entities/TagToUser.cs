using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager.Models.Entities
{
    public class TagToUser
    {
        [Key]
        public Guid EntityId { get; set; }
        public Guid UserId { get; set; }
        public Guid TagId { get; set; }


        public User? User { get; set; }
        public Tag? Tag { get; set; }
    }

}
