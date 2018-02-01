using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsgoAPI.Data
{
    public class CsgoItem
    {
        [Key]
        public int Rdef { get; set; }
        public string Name { get; set; }
    }
}
