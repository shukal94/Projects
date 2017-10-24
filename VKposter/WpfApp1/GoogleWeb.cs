using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using mshtml;
using System.Collections;

namespace WpfApp1
{
    class GoogleWeb : Parser
    {
        static protected string htmlText;
        static public ArrayList arrayUrlPictures;//массив со всеми url изображений
        static public void LoadPage(string searchText, ref WebBrowser web)
        {
            string url = @"https://www.google.com/search?hl=ru&tbm=isch&sa=1&q=" + searchText;
            web.Navigate(url);
        }
        static public void GetSourcePage(ref WebBrowser web)
        {
            //получение кода страницы через поток в исходной кодировке
            Stream stream = web.DocumentStream;
            StreamReader sr = new StreamReader(stream, Encoding.Default);
            htmlText = sr.ReadToEnd();
            stream.Close();
            StreamWriter html = new StreamWriter("html.txt");
            html.WriteLine(htmlText);
            //освобождение ресурсов и выделение новой памяти. Не так растет потребление ресурсов
        }
        //взятие всех url по тегу
        static public string ParsePictures(string teg)
        {
            string url = "";
            Parser.GetClass(ref htmlText);
            url = Parser.ParseContentTeg(teg);
            return url;
        }
        static public void GetAllUrl()
        {
            arrayUrlPictures = new ArrayList();
            while(htmlText.LastIndexOf("class=\"rg_meta notranslate\"") != htmlText.IndexOf("class=\"rg_meta notranslate\""))
            {
                arrayUrlPictures.Add(ParsePictures("ou"));
            }
        }
        //проверкана формат
        static public bool IsTrueFormat(string url)
        {
            bool checkFormat = false;
            if (url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                checkFormat = true;
            return checkFormat;
        }
    }
}
