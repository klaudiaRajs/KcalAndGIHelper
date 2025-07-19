namespace Diabetic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KcalPer100G { get; set; }
        public double CarbsPer100G { get; set; }
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
