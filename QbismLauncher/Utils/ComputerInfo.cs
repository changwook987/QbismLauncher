using System.Runtime.InteropServices;

namespace QbismLauncher.Utils
{
    static partial class ComputerInfo
    {
        public static long Memory
        {
            get
            {
                if (GetPhysicallyInstalledSystemMemory(out long memory))
                {
                    return memory / 1024;
                }
                else
                {
                    return 0;
                }
            }
        }

        #region library impoart
        [LibraryImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool GetPhysicallyInstalledSystemMemory(out long mem);
        #endregion
    }

}