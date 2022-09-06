using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Junior_Backend_Test
{
    internal class CheckSite
    {
        public string CheckSite1(string url)
        {
            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return "Не доступен!";
            }
            return "Доступен!";
        }
    }
}
