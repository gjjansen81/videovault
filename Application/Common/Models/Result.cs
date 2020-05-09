using System.Collections.Generic;
using System.Linq;

namespace VideoVault.Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static Result Success()
        {
            return new Result(){ Succeeded = true, Errors = new string[] { }};
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result() {Succeeded = false, Errors = errors.ToArray() };
        }
    }
}
