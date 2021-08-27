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
    }
}
