#region

using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

#endregion

namespace Kombit.Samples.Common
{
    /// <summary>
    ///     A json formatter that can help make Web API returns Json with correct content type:
    ///     http://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome
    /// </summary>
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        /// <summary>
        ///     Creates an instance of this class
        /// </summary>
        public BrowserJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SerializerSettings.Formatting = Formatting.Indented;
        }

        /// <summary>
        ///     Sets default content header to application/json
        /// </summary>
        /// <param name="type"></param>
        /// <param name="headers"></param>
        /// <param name="mediaType"></param>
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers,
            MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}