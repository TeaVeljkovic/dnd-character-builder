namespace DnDCharacterBuilder.Web.CustomMiddleware
{
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ContentSecurityPolicyMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Response.Headers.ContainsKey("Content-Security-Policy"))
            {
                context.Response.Headers.Add("Content-Security-Policy",
                    "default-src 'self';" +
                    "object-src 'self';" +
                    "connect-src 'self' http://localhost:60223;" +
                    "style-src 'self' https://fonts.googleapis.com https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css;" +
                    "font-src 'self' https://fonts.gstatic.com https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/fonts/fontawesome-webfont.woff2?v=4.7.0;" +
                    "script-src 'self' 'unsafe-inline' https://code.jquery.com/jquery-3.6.0.min.js https://localhost:7288;" +
                    "img-src 'self';");
            }
            await requestDelegate(context);
        }
    }
}
