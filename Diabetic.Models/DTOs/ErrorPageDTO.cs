using Diabetic.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Diabetic.Models.DTOs
{
    public class ErrorPageDTO
    {
        public string Title { get; set; } = HelperErrorMessages.PL_ERROR_MESSAGE_TITLE;
        public string Body { get; set; }
    }
}
