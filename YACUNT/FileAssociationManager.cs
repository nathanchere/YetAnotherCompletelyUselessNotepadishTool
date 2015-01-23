using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace YACUNT
{
    /// <todo>
    /// Probably move this out to FerretLib
    /// </todo>
    public static class FileAssociationManager
    {
        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath, [Out]StringBuilder lpszShortPath, uint cchBuffer);
        
        private static string ToShortPathName(string longName)
        {
            var result = new StringBuilder(1000);
            GetShortPathName(longName, result, (uint)result.Capacity);
            return result.ToString();
        }

        /// <summary>
        /// Create or update a file association in Windows
        /// </summary>
        /// <param name="fileExtension">The file extension
        ///     <example>txt</example>
        ///     <example>mp3</example>
        /// </param>
        /// <param name="executablePath">The full non-relative path to the executable to associate with te file type</param>
        ///     <example>C:\Program Files (x86)\Super Note</example>
        ///     <example>mp3</example>
        /// <param name="registryEntryId">Generic_TXT</param>
        /// <param name="fileTypeDescription">Generic text file</param>
        /// <param name="isForAllUsers"> Determines whether to install for all users or onyl the current user.
        /// Note that if set to 'true' the applcation must be run with Adminstrator priveleges
        /// on Windows Vista and later, otherwise an Exception will be thrown.
        /// </param>
        public static void SetAssociation(string fileExtension, string executablePath, string registryEntryId, string fileTypeDescription, bool isForAllUsers = false)
        {
            var ClassesRoot = isForAllUsers
                ? Registry.ClassesRoot
                : Registry.CurrentUser.OpenSubKey(@"Software\Classes");
            

            ClassesRoot.CreateSubKey("." + fileExtension).SetValue("", registryEntryId);            
                           
            using (var key = ClassesRoot.CreateSubKey(registryEntryId))
            {
                key.SetValue("", fileTypeDescription);
                key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(executablePath));
                key.CreateSubKey(@"Shell\Open\Command").SetValue("", ToShortPathName(executablePath) + " \"%1\"");
                key.CreateSubKey(@"Shell\Edit\Command").SetValue("", ToShortPathName(executablePath) + " \"%1\"");
            };

            var regPath = string.Format(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.{0}", fileExtension);
            using (var key = Registry.CurrentUser.OpenSubKey(regPath, true))
            {
                if (key != null) key.DeleteSubKey("UserChoice", false);
            }

            //// Sanity check
            //if(!IsAssociated("." + fileExtension)) System.Diagnostics.Debugger.Break();

            //// Possibly use this to include current user entries even when applying to all
            //if (isForAllUsers) SetAssociation(fileExtension, executablePath, registryEntryId, fileTypeDescription, false);
        }
        
        public static bool IsAssociated(string extension)
        {
            return (Registry.ClassesRoot.OpenSubKey(extension, false) != null);
        }

    }
}     
    