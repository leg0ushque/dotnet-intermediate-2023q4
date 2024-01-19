namespace Gof.ManagingState.FeedManagerApplication.Models.Validation
{
    public class ValidationResult
    {
        public static ValidationResult CreateSuccessful()
        {
            return new ValidationResult();
        }

        public static ValidationResult CreateFailed(params string[] errorMessages)
        {
            if (errorMessages is null || !errorMessages.Any())
            {
                throw new ArgumentException(nameof(errorMessages));
            }

            var validationResult = new ValidationResult();
            Array.ForEach(errorMessages, validationResult.AddError);

            return validationResult;
        }

        private readonly List<string> _errorMessages;

        public bool IsValid => !_errorMessages.Any();

        public IReadOnlyCollection<string> ErrorMessages => _errorMessages.AsReadOnly();

        private ValidationResult()
        {
            _errorMessages = new List<string>();
        }

        public void AddError(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage) || _errorMessages.Contains(errorMessage))
            {
                throw new ArgumentNullException(nameof(errorMessage));
            }

            _errorMessages.Add(errorMessage);
        }
    }
}
