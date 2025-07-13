using Diabetic.Models.Helpers;

namespace Diabetic.Models.DTOs
{
    public class ErrorPageDto
    {
        public string Title { get; set; } = HelperErrorMessages.PlErrorMessageTitle;
        public string Body { get; set; }
    }
}
