using System;
using System.ComponentModel.DataAnnotations;
using VideoVault.Domain.Enums;

namespace VideoVault.Domain.ValidationRules
{
    public abstract class ValidationRule : IValidationRule
    {
        public string Message { get; set; }
        public ValidationLevels Level { get; set; }
        
        public abstract void Validate(MappingData mappingData, dynamic validationTarget);

        protected void HandleValidationResults(MappingData mappingData, string message = null, dynamic validationTarget = null)
        {
            var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(validationTarget);
            
            var logMessage = Message;
            if (!string.IsNullOrWhiteSpace(message))
            {
                logMessage += $". {message}";
            }
            /*
            mappingData.ValidationResults.Add(new ValidationResultModel()
            {
                Rule = this,
                ValidationTarget = validationTarget?.ToString(),
                Message = logMessage,
            });
            */
            if (Level == ValidationLevels.Fatal)
            {
                mappingData.Log.LogError(ErrorCodes.ValidationError, logMessage, inputData: jsonObject);
                throw new ValidationException(logMessage);
            }

            mappingData.Log.LogDebug($"Validation warning: {logMessage}", inputData: jsonObject);
        }
    }
}
