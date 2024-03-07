using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lava.NET.Types
{
    public interface IBase 
    {
        public string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    public static class Statics
    {
        public static string ToString(this IBase @base)
         => JsonSerializer.Serialize(@base);
    }
}
