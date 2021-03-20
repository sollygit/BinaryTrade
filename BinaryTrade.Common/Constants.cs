using System.Collections.Generic;

namespace BinaryTrade.Common
{
    public class Constants
    {
        public static readonly List<KeyValuePair<int, string>> DIRECTIONS = new List<KeyValuePair<int, string>> 
        {
            new KeyValuePair<int, string>(1, "UP"),
    		new KeyValuePair<int, string>(2, "DOWN")
        };

        public static readonly List<KeyValuePair<int, string>> EXPIRIES = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string> ( 1, "1 Hour"),
            new KeyValuePair<int, string> ( 1, "6 Hours"),
            new KeyValuePair<int, string> ( 2, "12 Hours"),
            new KeyValuePair<int, string> ( 3, "24 Hours")
        };
    }
}
