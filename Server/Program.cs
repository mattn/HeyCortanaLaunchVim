using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();
            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;

                if (req.RawUrl == "/vim")
                {
                    Process.Start("gvim");
                    res.StatusCode = 200;
                }
                else
                {
                    res.StatusCode = 404;
                }
                res.Close();
            }
        }
    }
}
