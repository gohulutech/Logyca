using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessRules
{
    public class Enterprise
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public long? Nit { get; set; }
        public long GIn { get; set; }

        public ICollection<Code> Codes { get; set; }
    }
}
