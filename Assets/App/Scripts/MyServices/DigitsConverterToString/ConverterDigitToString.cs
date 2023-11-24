using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyServices
{
    public class ConverterDigitToString : MonoBehaviour
    {
        private static string[] names = new string[30]
        {
        "", "k", "m", "b", "t", "q", "Q", "s", "S", "o",
        "n", "d", "u", "d", "T", "*10^45", "*10^48", "*10^51", "*10^54", "*10^57",
        "*10^60", "*10^63", "*10^66", "*10^69", "*10^72", "*10^75", "*10^78", "*10^81", "*10^84", "*10^??"
        };

        public static string FormatNum(double value)
        {
            if (value < 1000.0)
            {
                return value.ToString();
            }

            int i;
            for (i = 0; i + 1 < names.Length; i++)
            {
                if (!(value >= 1000.0))
                {
                    break;
                }

                value /= 1000.0;
            }

            return value.ToString("0.000") + names[i];
        }
        public static string FormatNum(float value)
        {
            if (value < 1000f)
            {
                return value.ToString();
            }

            int i;
            for (i = 0; i + 1 < names.Length; i++)
            {
                if (!(value >= 1000f))
                {
                    break;
                }

                value /= 1000f;
            }

            return value.ToString("0.000") + names[i];
        }
    }
}
