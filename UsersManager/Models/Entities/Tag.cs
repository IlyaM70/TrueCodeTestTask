using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager.Models.Entities
{
    public class Tag
    {
        public Guid TagId { get; set; }

        [Required]
        public string Value { get; set; } = default!;
        
    }

}
