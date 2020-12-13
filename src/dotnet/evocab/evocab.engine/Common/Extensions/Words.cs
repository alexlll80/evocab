using System;
using System.Collections.Generic;

namespace evocab.engine.Common.Extensions
{
    public static class Words
    {
        private static IEnumerable<string> _Contractions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constractions"></param>
        public static void Init(IEnumerable<string> contractions)
        {
            _Contractions = contractions;
        }
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


            if (_Contractions != null)
            {                                            
                foreach(var contraction in _Contractions)
                {
                    if (Words.IsContraction(text, apostrophePosition, contraction))
                    {
                        newPosition = apostrophePosition + contraction.Length;
                        return true;
                    }
                }
            }

            newPosition = -1;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="apostrophePosition"></param>
        /// <param name="contraction"></param>
        /// <returns></returns>
        public static bool IsContraction(this string text,int apostrophePosition,string contraction)
        {
            if (text.Length > apostrophePosition + contraction.Length)
            {
               for(int i = 0; i< contraction.Length; i++)
               {    
                    if (text[apostrophePosition + 1 + i] != contraction[i])
                    {
                        return false;
                    }
               }

                return true;
            }

            return false;
        }
    }
}
