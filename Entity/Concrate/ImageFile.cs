using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrate
{
    public class ImageFile
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
