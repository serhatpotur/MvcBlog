using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string Description { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
