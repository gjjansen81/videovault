using System.Collections.Generic;

namespace VideoVault.Domain.ValidationRules
{
    public class DatabaseValidationRule : ValidationRule
    {
        public List<string> Keys { get; set; }

        public override void Validate(MappingData mappingData, dynamic validationTarget)
        {
            /*if (validationTarget is KeyValuePair<string, dynamic>)
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
            else  if (validationTarget.GetType() == typeof(Dictionary<string, dynamic>))
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
            */
        }

        /*
        private Dictionary<string, Core.ValidationRules> RetrieveRules(ClientInfo clientInfo, Mapper.Models.Mapper mapper)
         {

             // Define dictionary to save all the rules in. Key as property name
             var validations = new Dictionary<string, Core.ValidationRules>();

             var dataMethodsAdapter = new DataMethodsAdapter();

             // Retrieve all rules from db
             var rules = dataMethodsAdapter.grsGetDBRecordset(clientInfo,
                 $@"
                     COLUMN_NAME as Name, 
                     DATA_TYPE as Type, 
                     CHARACTER_MAXIMUM_LENGTH as MaxLength, 
                     COLUMN_DEFAULT as DefaultValue, 
                     (CASE IS_NULLABLE
                         When 'YES' Then 'false'
                         When 'NO' Then 'true' 
                     END) AS Required",
                 "INFORMATION_SCHEMA.COLUMNS",
                 $"TABLE_NAME = '{mapper.ToTable}'");

             // Retrieve all rules from mapper
             var mapperPropertyRules = MapperPropertiesRules(mapper.Properties);

             var index = 0;
             while (rules.RecordCount != index)
             {
                 // Define property name
                 var name = rules.get_Fields("Name").Value.ToString();

                 // Define mapper riles
                 mapperPropertyRules.TryGetValue(name, out var mapperRules);

                 // Get values from db
                 var type = rules.get_Fields("Type").Value?.ToString();
                 var maxLength = rules.get_Fields("MaxLength").Value?.ToString();
                 var defaultValue = rules.get_Fields("DefaultValue").Value?.ToString();
                 var required = rules.get_Fields("Required").Value.ToString();

                 // Use mapper rules or rules found in db
                 var validationRules = mapperRules ?? new Core.ValidationRules();
                 validationRules.Type = validationRules.Type ?? type;
                 validationRules.MaxLength = validationRules.MaxLength ?? (string.IsNullOrEmpty(maxLength) ? 0 : int.Parse(maxLength));
                 validationRules.DefaultValue = validationRules.DefaultValue ?? ExtractValueFromSQLSyntax(defaultValue);
                 validationRules.Required = bool.Parse(required) || validationRules.Required;

                 // Add rules to dictionary
                 validations.Add(name, validationRules);

                 index++;
                 rules.MoveNext();
             }

             // Return dictionary
             return validations;
         }
        */
    }
}