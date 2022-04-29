using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.ResultModels;

namespace ASMSEntityLayer.ResultModels
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; set; }
      
        public DataResult(T data,bool success):base(success)

        {
            Data = data;
          
        }
        public DataResult(T data,  bool success, string message) : base(success, message)
        {
            Data = data;
           
        }
    }
}
