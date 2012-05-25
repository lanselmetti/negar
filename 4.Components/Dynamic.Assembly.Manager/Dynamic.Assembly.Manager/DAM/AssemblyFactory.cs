#region using
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;
#endregion

namespace Negar.DAM
{
    /// <summary>
    /// كلاسی برای تولید كد از فایل اسمبلی دات نت
    /// </summary>
    internal class AssemblyFactory
    {

        #region Fields
        private CompilerErrorCollection _CompilerErrors;
        #endregion

        #region Properties

        #region CompilerErrorCollection CompilerErrors
        /// <summary>
        /// لیست خطاهای كامپایلر - تهی برای وضعیت بدون خطا
        /// </summary>
        public CompilerErrorCollection CompilerErrors
        {
            get { return _CompilerErrors; }
        }
        #endregion

        #endregion

        #region Methods

        #region public Assembly CreateAssembly(String TheFileName)
        /// <summary>
        /// تولید اسمبلی از آدرس فایل
        /// </summary>
        /// <param name="TheFileName">نام فایل پایه</param>
        /// <returns>اسمبلی تولید شده</returns>
        public Assembly CreateAssembly(String TheFileName)
        {
            return CreateAssembly(TheFileName, new ArrayList());
        }
        #endregion

        #region public Assembly CreateAssembly(String TheFileName, IList References)
        /// <summary>
        /// Generates an Assembly from a script TheFileName
        /// </summary>
        /// <param name="TheFileName">The filename of the script</param>
        /// <param name="References">Assembly references for the script</param>
        /// <returns>The generated assembly</returns>
        public Assembly CreateAssembly(String TheFileName, IList References)
        {
            // ensure that _CompilerErrors is null
            _CompilerErrors = null;

            String extension = Path.GetExtension(TheFileName);

            // Select the correct CodeDomProvider based on script file extension
            CodeDomProvider codeProvider;
            switch (extension)
            {
                case ".cs":
                    codeProvider = new CSharpCodeProvider();
                    break;
                case ".vb":
                    codeProvider = new CSharpCodeProvider();
                    break;
                default:
                    throw new InvalidOperationException(
                        "Script files must have a .cs or .vb extension, for C# or Visual Basic.NET respectively.");
            }

#pragma warning disable 618,612
            ICodeCompiler compiler = codeProvider.CreateCompiler();
#pragma warning restore 618,612

            // Set compiler parameters
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;

            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");

            // Add custom References
            foreach (String reference in References)
                if (!compilerParams.ReferencedAssemblies.Contains(reference))
                    compilerParams.ReferencedAssemblies.Add(reference);

            // Do the compilation
            CompilerResults results = compiler.CompileAssemblyFromFile(compilerParams, TheFileName);

            //Do we have any compiler errors
            if (results.Errors.Count > 0)
            {
                _CompilerErrors = results.Errors;
                throw new Exception("Compiler error(s) encountered and saved to AssemblyFactory.CompilerErrors");
            }

            Assembly createdAssembly = results.CompiledAssembly;
            return createdAssembly;
        }
        #endregion

        #region public Assembly CreateAssembly(IList filenames)
        /// <summary>
        /// Generates an Assembly from a list of script filenames
        /// </summary>
        /// <param name="filenames">The filenames of the scripts</param>
        /// <returns>The generated assembly</returns>
        public Assembly CreateAssembly(IList filenames)
        {
            return CreateAssembly(filenames, new ArrayList());
        }
        #endregion

        #region public Assembly CreateAssembly(IList filenames, IList references)
        /// <summary>
        /// Generates an Assembly from a list of script filenames
        /// </summary>
        /// <param name="filenames">The filenames of the scripts</param>
        /// <param name="references">Assembly references for the script</param>
        /// <returns>The generated assembly</returns>
        public Assembly CreateAssembly(IList filenames, IList references)
        {
            String fileType = null;
            foreach (String filename in filenames)
            {
                String extension = Path.GetExtension(filename);
                if (fileType == null)
                {
                    fileType = extension;
                }
                else if (fileType != extension)
                {
                    throw new ArgumentException("All files in the file list must be of the same type.");
                }
            }

            // ensure that _CompilerErrors is null
            _CompilerErrors = null;

            // Select the correct CodeDomProvider based on script file extension
            CodeDomProvider codeProvider;
            switch (fileType)
            {
                case ".cs": codeProvider = new CSharpCodeProvider(); break;
                case ".vb": codeProvider = new CSharpCodeProvider(); break;
                default: throw new InvalidOperationException(
                    "Script files must have a .cs or .vb extension, for C# or Visual Basic.NET respectively.");
            }

#pragma warning disable 618,612
            ICodeCompiler compiler = codeProvider.CreateCompiler();
#pragma warning restore 618,612

            // Set compiler parameters
            var compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;

            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");

            // Add custom references
            foreach (String reference in references)
            {
                if (!compilerParams.ReferencedAssemblies.Contains(reference))
                {
                    compilerParams.ReferencedAssemblies.Add(reference);
                }
            }

            // Do the compilation
            CompilerResults results = compiler.CompileAssemblyFromFileBatch(
                compilerParams, (String[])ArrayList.Adapter(filenames).ToArray(typeof(String)));

            // Do we have any compiler errors
            if (results.Errors.Count > 0)
            {
                _CompilerErrors = results.Errors;
                throw new Exception(
                    "Compiler error(s) encountered and saved to AssemblyFactory.CompilerErrors");
            }

            Assembly createdAssembly = results.CompiledAssembly;
            return createdAssembly;
        }
        #endregion

        #endregion

    }
}