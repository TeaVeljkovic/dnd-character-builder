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
                    "connect-src 'self' http://localhost:60223 wss://localhost:44360 ws://localhost:60223;" +
                    "style-src 'self' https://fonts.googleapis.com;" +
                    "font-src 'self' https://fonts.gstatic.com;" +
                    "script-src 'self' 'unsafe-inline' https://code.jquery.com/jquery-3.6.0.min.js https://localhost:7288;" +
                    "img-src 'self';");
            }
            await requestDelegate(context);
        }
    }
}
