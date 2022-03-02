using System.Collections.Generic;

namespace VideoVault.Domain.ValidationRules
{
    public class RequiredRule : ValidationRule
    {
        public List<string> Keys { get; set; }
       // public CreateDictionaryNode DictionaryNode { get; set; }

        public override void Validate(MappingData mappingData, dynamic validationTarget)
        {
            ValidateEx(mappingData, validationTarget);
        }

        protected void ValidateEx(MappingData mappingData, dynamic validationTarget)
        {
            if (validationTarget is KeyValuePair<string, dynamic>)
            {
                var typedValue = (KeyValuePair<string, dynamic>)validationTarget;
                foreach (var key in Keys)
                {
                    if (IsEmpty(typedValue.Value, key))
                    {
                        HandleValidationResults(mappingData, $"{key} is empty", typedValue);
                    }
                }
            }
            else if (validationTarget == null)
            {
                HandleValidationResults(mappingData, $"Validation target is empty. Keys: {string.Join(",", Keys)}", null);
            }
            else if (validationTarget.GetType() == typeof(List<Dictionary<string, dynamic>>))
            {
                if(((List<Dictionary<string, dynamic>>)validationTarget).Count == 0)
                    HandleValidationResults(mappingData, $"Validation target is empty. Keys: {string.Join(",", Keys)}", null);
            }
            else if (validationTarget.GetType() == typeof(Dictionary<string, dynamic>))
            {
                var typedValue = (Dictionary<string, dynamic>)validationTarget;
                foreach (var key in Keys)
                {
                    if (IsEmpty(typedValue, key))
                    {
                        HandleValidationResults(mappingData, $"{key} is empty", typedValue);
                    }
                }
            }
        }

        private bool IsEmpty(dynamic typedValue, string key)
        {
            if (typedValue == null)
                return true;
            
            if (typedValue is string)
                return string.IsNullOrWhiteSpace(typedValue);

            if(typedValue is Dictionary<string, dynamic>)
            {
                if (!typedValue.ContainsKey(key))
                    return true;

                if (!typedValue.TryGetValue(key, out dynamic value))
                    return true;

                if (value is string)
                {
                    return string.IsNullOrWhiteSpace(value);
                }

                if (value is List<dynamic>)
                {
                    return value.Count <= 0;
                }

                return value == null;
            }

            return false;
        }
    }
}