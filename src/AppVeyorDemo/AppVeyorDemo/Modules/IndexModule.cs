namespace AppVeyorDemo.Modules
{
    using System.Configuration;
    using AppVeyorDemo.Models;
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                var model = new IndexViewModel
                {
                    HelloName = "Leeds#",
                    ServerName = ConfigurationManager.AppSettings["Server_Name"]
                };

                return View["index", model];
            };
        }
    }
}
