using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class DecimalExtentions
    {
        /// <summary>
        /// Returns decimal as string formatted as percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimal_count"></param>
        /// <returns></returns>
        public static string ToPercentage(this decimal value, int decimal_count = 3)
        {
            return value.ToString("P" + decimal_count.ToString());
        }

        /// <summary>
        /// Returns decimal as string formatted as a dollar value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimal_count"></param>
        /// <returns></returns>
        public static string ToDollarValue(this decimal value, int decimal_count = 2)
        {
            return value.ToString("N" + decimal_count.ToString());
        }

        /// <summary>
        /// Returns decimal as string formatted as percentage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimal_count"></param>
        /// <returns></returns>
        public static string ToPercentage(this decimal? value, int decimal_count = 3)
        {
            if (value == null)
            {
                return String.Empty;
            }
            decimal convered_value = Convert.ToDecimal(value);
            return convered_value.ToPercentage(decimal_count);
        }

        /// <summary>
        ///  Returns decimal as string formatted as a dollar value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimal_count"></param>
        /// <returns></returns>
        public static string ToDollarValue(this decimal? value, int decimal_count = 2)
        {
            if(value == null)
            {
                return String.Empty;
            }
            decimal convered_value = Convert.ToDecimal(value);
            return convered_value.ToDollarValue(decimal_count);
        }
    }
}
