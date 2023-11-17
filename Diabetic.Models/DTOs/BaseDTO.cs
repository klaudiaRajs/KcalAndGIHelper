using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class BaseDTO
    {
        public int _maxGreenGI { get; set; } = 39;
        public int _maxOrangeGI { get; set; } = 55;
        public int _maxGreenLG { get; set; } = 10;
        public int _maxOrangeLG { get; set; } = 19;
    }
}
