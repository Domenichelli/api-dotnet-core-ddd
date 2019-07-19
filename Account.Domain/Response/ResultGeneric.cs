using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Response
{
    public class ResultGeneric<T>
    {
        public ResultGeneric()
        {
            Errors = new List<string>();
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
