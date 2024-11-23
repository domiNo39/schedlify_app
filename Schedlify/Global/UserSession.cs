using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Models;

namespace Schedlify.Global
{
    public static class UserSession
    {
        public static User currentUser { get; set; }
        public static University currentUniversity { get; set; }
        public static Department currentDepartment { get; set; }
        public static Group currentGroup { get; set; }
    }
}
