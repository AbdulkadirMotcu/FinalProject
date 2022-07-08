using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message):base(success,message)//resultdaki birdaha yazmamak için base
        {
            Data = data; //T data set edilir 
        }

        public DataResult(T data,bool success):base(success)
        {
            Data = data;//data set edildi
        }

        public T Data { get; }
    }
}
