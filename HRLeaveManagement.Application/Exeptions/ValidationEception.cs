using FluentValidation.Results;


namespace HRLeaveManagement.Application.Exeptions
{
    public class ValidationEception : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationEception(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }

        }
    }
}
