using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace WpfApp1
{
    class VK
    {
        public static VkApi vk = new VkApi();
        public static void Autorith(string pass, string em)
        {
            //сделать двухэтапную аунтификацию
            ulong appID = 6142231;//ИЗМЕНИТЬ appid
            vk.Authorize(new ApiAuthParams
            {
                Login = em,
                Password = pass,
                Settings = Settings.All,
                ApplicationId = appID
            });
        }
    }
}
