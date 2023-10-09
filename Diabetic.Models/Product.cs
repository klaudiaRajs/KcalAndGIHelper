using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KcalPer100g { get; set; }
        public int GI { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
