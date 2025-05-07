using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static OperationResult<T> Success(T value)
            => new OperationResult<T> { IsSuccess = true, Data = value };

        public static OperationResult<T> Failure(params string[] errors)
            => new OperationResult<T> { IsSuccess = false, Errors = errors.ToList() };
    }
}
