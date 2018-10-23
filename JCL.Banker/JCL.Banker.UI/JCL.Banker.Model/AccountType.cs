using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Model
{
    [FlagsAttribute]
    public enum AccountType : int
    {
        Free = 1,
        Basic = 2,
        Premium = 3
    }
}