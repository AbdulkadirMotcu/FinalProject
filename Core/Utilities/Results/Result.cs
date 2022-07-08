using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{   //Cıplak class kalmıcak tekrar
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success)//:this(****)bu class'da çalıştır...
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }//get readonly'dir ctor içinde set edilebilir DİKKAT...

        public string Message { get; }
    }
}
