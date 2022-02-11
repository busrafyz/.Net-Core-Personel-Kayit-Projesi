using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorePersonel.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirimId { get; set; }
        public Birim Birim { get; set; }
    }
}
