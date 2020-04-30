using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class Parser
    {
        public static bool Bool(string input)
        {
            bool result;
            if (bool.TryParse(input, out result))
                return result;
            return default(bool);
        }

        public static decimal Decimal(string input)
        {
            decimal result;
            if (decimal.TryParse(input, out result))
                return result;
            return default(decimal);
        }
    }
}
