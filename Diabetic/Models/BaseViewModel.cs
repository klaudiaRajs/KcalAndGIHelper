namespace Diabetic.Models
{
    public class BaseViewModel
    {

        public bool Green { get; set; }
        public bool Orange { get; set; }
        public bool Red { get; set; }
        public int MaxGreen { get; set; } = 39;
        public int MaxOrange { get; set; } = 55;
        public int MaxGreenLg { get; set; } = 10;
        public int MaxOrangeLg { get; set; } = 19; 
        public bool IsGreenGi(int gI)
        {
            return gI <= MaxGreen;
        }

        public bool IsOrangeGi(int gI)
        {
            return (gI > MaxGreen && gI <= MaxOrange);
        }

        public bool IsRedGi(int gI)
        {
            return gI > MaxOrange;
        }

        public bool IsGreenGl(double gI)
        {
            return gI <= MaxGreenLg;
        }

        public bool IsOrangeGl(double gI)
        {
            return (gI > MaxGreenLg && gI <= MaxOrangeLg);
        }

        public bool IsRedGl(double gI)
        {
            return gI > MaxOrangeLg;
        }
    }
}
