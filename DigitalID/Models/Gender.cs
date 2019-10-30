using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalID.Models
{
    public class Gender
    {
        public int ID { get; set; }
        public string GenderName { get; set; }
        public virtual ICollection<IdCard> IdCards { get; set; }
    }
}