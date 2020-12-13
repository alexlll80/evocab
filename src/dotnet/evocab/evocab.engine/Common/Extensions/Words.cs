using System;
using System.Collections.Generic;
using System.Text;

namespace evocab.engine.Common.Extensions
{
    public static class Words
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="apostrophePosition"></param>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        public static bool IsContraction(this string text, int apostrophePosition, out int newPosition)
        {
            if (text.Length > apostrophePosition + 2 
                && text[apostrophePosition + 1] == 's' 
                && char.IsWhiteSpace(text[apostrophePosition + 2]))
            {
                newPosition = apostrophePosition + 2;
                return true;
            }

            if (text.Length > apostrophePosition + 2
                && text[apostrophePosition + 1] == 't'   
                && char.IsWhiteSpace(text[apostrophePosition + 2]))
            {
                newPosition = apostrophePosition + 2;
                return true;
            }

            if (text.Length > apostrophePosition + 2   
                && text[apostrophePosition + 1] == 'd' 
                && char.IsWhiteSpace(text[apostrophePosition + 2]))
            {
                newPosition = apostrophePosition + 2;
                return true;
            }
            newPosition = -1;
            return false;
        }
    }
}
