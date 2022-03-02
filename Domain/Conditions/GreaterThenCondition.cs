using System;
using VideoVault.Domain.Conditions.Interfaces;
using VideoVault.Domain.Mapper;

namespace VideoVault.Domain.Conditions
{
    public class GreaterThenCondition : ICondition
    {
        public MappingNode Left{ get; set; }
        public MappingNode Right { get; set; }
        public bool Evaluate(MappingData mappingData, dynamic evaluationData)
        {
            var resultLeft = Left.Resolve(mappingData);
            var resultRight = Right.Resolve(mappingData);

            if(resultLeft == null)
                return false;
            if (resultRight == null)
                return true;

            if (IsNumericType(resultLeft) && IsNumericType(resultRight))
                return ExecuteConditionCheck(resultLeft, resultRight);

            if (resultLeft.GetType() == resultRight.GetType())
                return ExecuteConditionCheck(resultLeft, resultRight);

            return false;
        }

        public bool IsNumericType(object value)
        {
            if (value == null)
                return false;

            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        private bool ExecuteConditionCheck(dynamic value1, dynamic value2)
        {
            return value1 > value2;
        }
    }
}