namespace Diabetic.Models
{
    public class BaseViewModel
    {

        public bool Green { get; set; }
        public bool Orange { get; set; }
        public bool Red { get; set; }
        public int _maxGreen { get; set; } = 39;
        public int _maxOrange { get; set; } = 55;
        public int _maxGreenLG { get; set; } = 10;
        public int _maxOrangeLG { get; set; } = 19; 
        public bool IsGreenGI(int gI)
        {
            return gI <= _maxGreen;
        }

        public bool IsOrangeGI(int gI)
        {
            return (gI > _maxGreen && gI <= _maxOrange);
        }

        public bool IsRedGI(int gI)
        {
            return gI > _maxOrange;
        }

        public bool IsGreenLG(double gI)
        {
            return gI <= _maxGreenLG;
        }

        public bool IsOrangeLG(double gI)
        {
            return (gI > _maxGreenLG && gI <= _maxOrangeLG);
        }

        public bool IsRedLG(double gI)
        {
            return gI > _maxOrangeLG;
        }
    }
}
