#region using

using System;
using Microsoft.Win32;

#endregion

namespace DotNetRemoting
{
    public class GACInstaller
    {
        #region void Install(String AssembPath)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssembPath"></param>
        public void Install(String AssembPath)
        {
            AssemblyCache.InstallAssembly(AssembPath, null, AssemblyCommitFlags.Force);
        }
        #endregion

        #region void RemoveAssembly(String AssemblyName)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssemblyName"></param>
        public void RemoveAssembly(String AssemblyName)
        {
            RemoveAssembly(AssemblyName, null);
        }
        #endregion

        #region void RemoveAssembly(String ShortAssemblyName, String PublicToken)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShortAssemblyName"></param>
        /// <param name="PublicToken"></param>
        public void RemoveAssembly(String ShortAssemblyName, String PublicToken)
        {
            var AssembCache = new AssemblyCacheEnum(null);
            String FullAssembName = null;
            for (; ; )
            {
                String AssembNameLoc = AssembCache.GetNextAssembly();
                if (AssembNameLoc == null) break;
                String Pt;
                String ShortName = GetAssemblyShortName(AssembNameLoc, out Pt);

                if (ShortAssemblyName == ShortName)
                {
                    if (PublicToken != null)
                    {
                        PublicToken = PublicToken.Trim().ToLower();
                        if (Pt == null) { FullAssembName = AssembNameLoc; break; }
                        Pt = Pt.ToLower().Trim();
                        if (PublicToken == Pt) { FullAssembName = AssembNameLoc; break; }
                    }
                    else { FullAssembName = AssembNameLoc; break; }
                }
            }
            String Stoken = "null";
            if (PublicToken != null) Stoken = PublicToken;

            if (FullAssembName == null) throw new Exception(
                "Assembly=" + ShortAssemblyName + ",PublicToken=" + Stoken + " not found in GAC");

            AssemblyCacheUninstallDisposition UninstDisp;
            ClearRegKey(ShortAssemblyName, Registry.CurrentUser);
            ClearRegKey(ShortAssemblyName, Registry.LocalMachine);
            AssemblyCache.UninstallAssembly(FullAssembName, null, out UninstDisp);
        }
        #endregion

        #region static String GetAssemblyShortName(String FullName, out String PublicToken)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FullName"></param>
        /// <param name="PublicToken"></param>
        /// <returns></returns>
        private static String GetAssemblyShortName(String FullName, out String PublicToken)
        {
            PublicToken = null;
            if (FullName == null) return null;
            String[] Strings = FullName.Split(',');
            foreach (String ss in Strings)
            {
                int index = ss.IndexOf("PublicKeyToken");
                if (index != -1)
                {
                    index = ss.IndexOf("=");
                    if (index != -1)
                    {
                        PublicToken = ss.Substring(index + 1);
                        PublicToken = PublicToken.Trim();
                        break;
                    }
                }
            }

            String Sout = Strings[0];
            return Sout;
        }
        #endregion

        #region static void ClearRegKey(String AssemblyShortName, RegistryKey BaseKey)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssemblyShortName"></param>
        /// <param name="BaseKey"></param>
        private static void ClearRegKey(String AssemblyShortName, RegistryKey BaseKey)
        {
            RegistryKey key = BaseKey.OpenSubKey(@"Software\Microsoft\Installer\Assemblies\Global", true);
            if (key != null)
            {
                String[] names = key.GetValueNames();
                foreach (string Name in names)
                {
                    String[] Words = Name.Split(',');
                    String nn = Words[0];
                    if (AssemblyShortName == nn)
                    {
                        key.SetValue(Name, "", RegistryValueKind.String);
                        key.Close();
                        return;
                    }
                }
            }
        }
        #endregion
    }
}