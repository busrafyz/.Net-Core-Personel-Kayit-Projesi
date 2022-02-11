using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorePersonel.Models
{
    public class Birim
    {
        [Key]
        public int BirimId { get; set; }
        public string BirimAd { get; set; }
        public IList<Personel> Personels { get; set; }
    }
}
