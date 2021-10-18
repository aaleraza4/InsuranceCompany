using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENUM.UserRole
{
    public enum  UserRole 
    {
        [Description("superadmin")]
        superadmin = 1,
        [Description("User")]
        User
    }
}
