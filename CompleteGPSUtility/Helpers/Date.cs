using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class Date
    {
        private static readonly DateTime y2k = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromY2KTime(long y2kSeconds)
        {
            return y2k.AddSeconds(y2kSeconds);
        }
    }
}
