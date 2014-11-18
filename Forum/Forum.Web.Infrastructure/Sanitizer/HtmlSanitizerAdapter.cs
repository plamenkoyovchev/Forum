namespace Forum.Web.Infrastructure.Sanitizer
{
    using Html;

    public class HtmlSanitizerAdapter:ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedHtml = sanitizer.Sanitize(html);
            return sanitizedHtml;
        }
    }
}
