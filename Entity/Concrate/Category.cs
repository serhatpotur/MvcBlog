using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(250)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatüs { get; set; }

        // Relationship
        public ICollection<Heading> Headings { get; set; }
    }
}
