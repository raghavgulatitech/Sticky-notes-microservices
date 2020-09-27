using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Api.Model
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
