using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class BaseDTO
    {
        public static int _maxGreenGI { get; set; } = 39;
        public static int _maxOrangeGI { get; set; } = 55;
        public int _maxGreenLG { get; set; } = 10;
        public int _maxOrangeLG { get; set; } = 19;
        public static int _maxDayGreenLG { get; set; } = 79;
        public static int _maxDayOrangeLG { get; set; } = 119;
        public static string GetGIRating(int GI, bool showGreen = true)
        {
            if (GI > _maxGreenGI && GI <= _maxOrangeGI)
            {
                return "table-warning";
            }
            if (GI <= _maxGreenGI & showGreen)
            {
                return "table-success";
            }
            if (GI > _maxOrangeGI)
            {
                return "table-danger";
            }
            return "";
        }

        public static string GetDayGLRating(double dayGl)
        {
            if (dayGl > _maxDayGreenLG && dayGl <= _maxDayOrangeLG)
            {
                return "table-warning";
            }
            if (dayGl <= _maxDayGreenLG)
            {
                return "table-success";
            }
            if (dayGl > _maxDayOrangeLG)
            {
                return "table-danger";
            }
            return "";

        }

    }
}
