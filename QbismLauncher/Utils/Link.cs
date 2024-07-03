using System.Diagnostics;

namespace QbismLauncher.Utils
{
    static class Link
    {
        static void Open(string link)
        {
            Process.Start(link);
        }
    }
}