using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        public string ContentText { get; set; }
        public DateTime ContentDate { get; set; }
        public bool isActive { get; set; }

        //Relationship
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
