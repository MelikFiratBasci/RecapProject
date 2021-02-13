﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message ) : base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data; 
        }
        public DataResult(bool success,string message ):base(success,message)
        {

        }
        public DataResult(bool success):base(success)
        {

        }

        public T Data { get; }
    }
}
