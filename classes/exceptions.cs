using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.classes
{
    class ExceptionDoesNotExist : Exception
    {
        public ExceptionDoesNotExist(string message)
            : base(message)
        { }
    }


    class ExceptionAlreadyExist : Exception
    {
        public ExceptionAlreadyExist(string message)
            : base(message)
        { }
    }



}
