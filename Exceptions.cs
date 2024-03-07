using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.NET.Exceptions
{
    /// <summary>
    /// Sending error when Lava.ru type is not equals your type
    /// </summary>
    public class TypeException : Exception {
        public TypeException(string? message) : base(message) { }
        public TypeException() : base() { }
        public TypeException(string? message, Exception exception) : base(message, exception) { }
    }
}
