using System;
using System.Drawing;

namespace API.Helpers
{
    public class ColorHelper
    {
        private static readonly ColorConverter ColorConverter;

        static ColorHelper()
        {
            ColorConverter = new ColorConverter();
        }

        public static Color GetColorFromString(string color)
        {
            try
            {   
                var result = ColorConverter.ConvertFromString(color);
                if (result != null)
                {
                    return (Color)result;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is FormatException)
                {
                    throw new ArgumentException($"{color} is an invalid color");
                }

                throw;
            }

            throw new ArgumentOutOfRangeException(nameof(color));
        }
    }
}