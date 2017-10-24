using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class Parser
    {
        public static string TempClassHtml { get; private set; }
        public static void GetClass(ref string htmlText)
        {
            TempClassHtml = "";
            int indexRemove = 0;
            for (int i = htmlText.IndexOf("class=\"rg_meta notranslate\""); i < htmlText.Length; i++)
            {
                if (htmlText[i] != '}')
                {
                    TempClassHtml += htmlText[i];
                }
                else
                {
                    indexRemove = i;
                    break;
                }
            }
            htmlText = htmlText.Remove(0, indexRemove+1);
        }
        public static string ParseContentTeg(string teg)
        {
            string url = "";
            for (int i = TempClassHtml.IndexOf(teg)+5; i < TempClassHtml.Length; i++)
            {
                if (TempClassHtml[i] != '"')
                {
                    url += TempClassHtml[i];
                }
                else
                    break;
            }
            return url;
        }
    }
}
