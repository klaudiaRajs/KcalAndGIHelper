namespace Diabetic.Models.DTOs
{
    public class BaseDto
    {
        protected static int MaxGreenGi { get; set; } = 39;
        protected static int MaxOrangeGi { get; set; } = 55;
        protected int MaxGreenLg { get; set; } = 10;
        protected int MaxOrangeLg { get; set; } = 19;
        private static int MaxDayGreenGl { get; set; } = 79;
        private static int MaxDayOrangeGl { get; set; } = 119;
        public static string GetGiRating(int gi, bool showGreen = true)
        {
            if (gi > MaxGreenGi && gi <= MaxOrangeGi)
            {
                return "table-warning";
            }
            if (gi <= MaxGreenGi & showGreen)
            {
                return "table-success";
            }
            if (gi > MaxOrangeGi)
            {
                return "table-danger";
            }
            return "";
        }

        public static string GetDayGlRating(double dayGl)
        {
            if (dayGl > MaxDayGreenGl && dayGl <= MaxDayOrangeGl)
            {
                return "table-warning";
            }
            if (dayGl <= MaxDayGreenGl)
            {
                return "table-success";
            }
            if (dayGl > MaxDayOrangeGl)
            {
                return "table-danger";
            }
            return "";

        }

    }
}
