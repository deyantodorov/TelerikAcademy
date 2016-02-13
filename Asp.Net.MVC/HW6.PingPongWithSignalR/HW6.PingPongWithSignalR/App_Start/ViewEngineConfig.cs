using System.Web.Mvc;

namespace HW6.PingPongWithSignalR
{
    public class ViewEngineConfig
    {
        public static void Register()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}