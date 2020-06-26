using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessRules
{
    public class Code
    {
        public int Id { get; set; }

        [Required]
        public int ownerId { get; set; }

        [JsonIgnore]
        [ForeignKey("ownerId")]
        public Enterprise Owner { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
