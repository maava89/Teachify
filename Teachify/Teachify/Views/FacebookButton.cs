using Plugin.Share.Abstractions;

namespace Teachify.Views
{
    internal class FacebookButton : ShareMessage
    {
        public object Uri { get; set; }
    }
}