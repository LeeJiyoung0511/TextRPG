using System.ComponentModel;
using System.Reflection;

namespace TextRPG
{
    internal class TextPrintManager
    {
        static public void ColorWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static public void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Enum의 Description불러오기
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static public string GetDescription(Enum e)
        {
            FieldInfo field = e.GetType().GetField(e.ToString());

            if (field != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return e.ToString();
        }
    }
}
