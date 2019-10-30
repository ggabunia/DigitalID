using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigitalID.Models
{
    public class BirthPlace
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string PlaceName { get; set; }
        public virtual ICollection<IdCard> IdCards { get; set; }
    }
}