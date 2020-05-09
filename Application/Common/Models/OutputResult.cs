using System.Collections.Generic;
using System.Linq;

namespace VideoVault.Application.Common.Models
{
    public class OutputResult<T> : Result
    {
        public T Output { get; set; }

        public OutputResult()
        {
            
        }

        public static OutputResult<T> Success(T output)
        {
            return new OutputResult<T>(){ Output = output, Succeeded = true, Errors = new string[] { } };
        }
        public new static OutputResult<T> Failure(IEnumerable<string> errors)
        {
            return new OutputResult<T>(){ Succeeded = false, Errors = errors.ToArray() };
        }
    }
}
