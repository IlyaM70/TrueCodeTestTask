using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager.Models.Entities
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Domain { get; set; } = default!;
    }

}
