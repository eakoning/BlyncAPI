using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace API.Helpers
{
    public class FlashCommandParser
    {
        public static FlashArguments Parse(string flashCommand)
        {
            string pattern = @"^(?<color>\w+)\s*(?<speed>\d{1,3})$";

            Match match = Regex.Match(flashCommand, pattern);

            if (!match.Success)
            {
                throw new ArgumentException(nameof(flashCommand));
            }

            string parsedColor = match.Groups["color"]?.Value;

            Color? color = parsedColor != null ? ColorHelper.GetColorFromString(parsedColor) : (Color?)null;

            return new FlashArguments
                       {
                           Speed = int.Parse(match.Groups["speed"].Value),
                           Color = color
                       };
        }
    }
}