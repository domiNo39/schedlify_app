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
        public static User CurrentUser { get; set; }
    }
}
