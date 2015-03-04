using System;
using System.Linq;
using System.Reflection;

namespace AlarmingTrafficWP8.Helpers
{
    public static class VersionExtensions
    {
        public static string GetVersion()
        {
            string versionNumber = ParseVersionNumber(Assembly.GetExecutingAssembly()).ToString();
            return versionNumber;
        }

        private static Version ParseVersionNumber(Assembly assembly)
        {
            AssemblyName assemblyName = new AssemblyName(assembly.FullName);
            return assemblyName.Version;
        }
    }
}
