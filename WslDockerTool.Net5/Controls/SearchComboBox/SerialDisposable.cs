using System;

namespace WslDockerTool.Net5.Controls
{
    internal sealed class SerialDisposable
        : IDisposable
    {
        private IDisposable content;

        public IDisposable Content
        {
            get { return content; }
            set
            {
                if (content != null)
                {
                    content.Dispose();
                }

                content = value;
            }
        }

        public void Dispose()
        {
            Content = null;
        }
    }
}