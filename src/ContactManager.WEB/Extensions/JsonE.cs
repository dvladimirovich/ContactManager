using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactManager.WEB.Extensions
{
    public static class JsonE
    {
        public static JsonResult ToJsonResult<T>(this T model)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            jss.Formatting = Formatting.None;

            return new JsonResult(model, jss);
        }
    }
}
