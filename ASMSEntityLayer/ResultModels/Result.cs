using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ResultModels
{
    public class Result : IResult
    {//field
     //prop

        //public bool IsSuccess { get; set; }
        //public string Message { get; set; }
        //public T Data { get; set; }
        //public int TotalCount { get; set; }
        //ctor
        //public Result(bool isSuccess, string message, T data, int totalCount)
        //{
        //    IsSuccess = isSuccess;
        //    Message = message;
        //    Data = data;
        //    TotalCount = totalCount;

        //}//4 parametreli
        //public Result(bool isSuccess, string message, T data)
        // : this(isSuccess, message, data, 0)
        //{ 

        //}//3 parametreli

        //public Result(bool isSuccess,string message)
        //    :this(isSuccess,message,default(T))
        //{

        //}
        //
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Result(bool success)
        {
            IsSuccess = success;
        }
        public Result (bool success,string message):this (success)
        {
            Message = message;
        }
        public interface IDataResult<T>:IResult
        {
            T Data { get; set; }
            int TotalCount{ get; set; }
        }




    }
}
