using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Common
{
    public class ResponseList<T> where T : new()
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<T> data { get; set; }
    }
}
