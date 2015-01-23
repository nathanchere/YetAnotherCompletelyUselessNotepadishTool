using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace YACUNT
{
    /// <todo>
    /// Probably move this out to FerretLib
    /// </todo>
    public static class FileAssociationManager
    {

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

            using (var key = ClassesRoot.CreateSubKey(fileExtension))
            {
                key.SetValue("", registryEntryId);
            }

            using (var key = ClassesRoot.CreateSubKey(registryEntryId))
            {
                key.SetValue("", fileTypeDescription);
                key.CreateSubKey("DefaultIcon").SetValue("", "\"" + executablePath + "\",0");

                using (var subKey = key.CreateSubKey("Shell"))
                {
                    subKey.CreateSubKey("edit").CreateSubKey("command").SetValue("", "\"" + executablePath + "\"" + " \"%1\"");
                    subKey.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + executablePath + "\"" + " \"%1\"");
                }
            };

            var regPath = string.Format(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.{0}", fileExtension);
            using (var key = Registry.CurrentUser.OpenSubKey(regPath, true))
            {
                key.DeleteSubKey("UserChoice", false);
            }
        }

        
    }
}
