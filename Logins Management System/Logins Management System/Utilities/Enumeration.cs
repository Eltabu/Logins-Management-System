using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginsManagementSystem.Utilities
{
    public enum Enumeration
    {
        SignInOK,
        SignInFail,
        SignInCancel,
        Nothing
    }

    public enum Score
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5,
        SuperStrong = 6

    }
}
