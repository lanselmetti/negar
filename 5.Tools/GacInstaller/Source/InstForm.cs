using System;
using System.IO;

namespace DotNetRemoting
{
    public class InstForm
    {

        #region Fields
        readonly String Func;
        readonly Boolean Error;
        readonly Boolean Processed;
        readonly String PublicToken;
        #endregion

        #region Prop

        #region String PublicToken_
        /// <summary>
        /// 
        /// </summary>
        public String PublicToken_
        {
            get { return PublicToken; }
        }
        #endregion

        #endregion

        #region Ctor
        public InstForm()
        {
            if (Program._args.Length < 2)
            {
                Console.WriteLine("=== Too Few Arguments! ===");
                Console.Read();
                Error = true;
                return;
            }
            Func = Program._args[0];
            try
            {
                if (Error) return;
                GACInstaller _GACInstaller = new GACInstaller();
                if (Processed) return;
                Processed = true;
                if (Program._args.Length == 3) PublicToken = Program._args[2];
                Func = Func.ToLower();
                if (Func == "i")
                {
                    String AssembPath = Program._args[1];
                    _GACInstaller.Install(AssembPath);
                }
                if (Func == "u")
                {
                    String PublicTokens = null;
                    String AssembName = Program._args[1];
                    if (Program._args.Length > 2) PublicTokens = Program._args[2];
                    _GACInstaller.RemoveAssembly(AssembName, PublicTokens);
                }
                Console.WriteLine("### Installation Has Done! ###");
            }
            #region Catch
            catch (Exception ex)
            {
                StreamWriter sw = null;
                try
                {
                    Console.WriteLine("^^ Error Installing Component! ^^");
                    sw = new StreamWriter("GACInstaller.log", true);
                    sw.AutoFlush = true;
                    sw.WriteLine(DateTime.Now + "," + ex.Message);
                    sw.Close();
                }
                catch { if (sw != null)sw.Close(); }
            }
            #endregion
        }
        #endregion

    }
}