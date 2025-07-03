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
        public double CarbsPer100g { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Sugar { get; set; }
        public double Fibre { get; set; }
        public int Gi { get; set; }
        public int CategoryId { get; set; }
        public int? GramsPerPortion { get; set; } = null;
        public Category Category { get; set; }

    }
}
