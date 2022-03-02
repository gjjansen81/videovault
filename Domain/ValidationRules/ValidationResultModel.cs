namespace VideoVault.Domain.ValidationRules
{
    public class ValidationResultModel
    {
        public string ValidationTarget { get; set; }
        public IValidationRule Rule { get; set; }
        public string Message { get; set; }
    }
}