using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Helpers
{
    public static class StatusEnumValues
    {
        public static Array All => Enum.GetValues(typeof(Status));
    }
}
