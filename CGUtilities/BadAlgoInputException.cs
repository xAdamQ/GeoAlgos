using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGUtilities
{
    public class BadAlgoInputException : Exception
    {
        public BadAlgoInputException(string msg):base(msg)
        {

        }
    }
    public class SpecialCaseInput : Exception
    {
        public SpecialCaseInput(string msg) : base(msg)
        {

        }
    }
}
