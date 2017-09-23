using System;
using System.Windows;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace BF_Launcher
{
    class Checker
    {
        int os = 0;
        string DirPath = Directory.GetCurrentDirectory() + "\\Redist\\cd-key\\";

        #region/* OS bit */
        void OS()
        {
            try
            {
                if (Environment.Is64BitOperatingSystem) os = 64;
                else os = 32;
            }
            catch
            {
                MessageBox.Show("OS error");
            }
        }

        #endregion

        #region /* KeyChecker */
        public void KeyChecker()
        {
            OS();
            if (os == 32)
            {
                try
                {
                    RegistryKey readKey32 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\EA Games\\Battlefield 2\\ergc");
                    string loadString32 = (string)readKey32.GetValue("");
                    readKey32.Close();
                }
                catch
                {
                    Run_BF2KeyMan();
                }
            }
            else if (os == 64)
            {
                try
                {
                    RegistryKey readKey64 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\EA Games\\Battlefield 2\\ergc");
                    string loadString64 = (string)readKey64.GetValue("");
                    readKey64.Close();
                }
                catch
                {
                    Run_BF2KeyMan();
                }
            }
        }

        #endregion

        #region /*Run KeyMan*/

        private void Run_BF2KeyMan()
        {
            if (File.Exists(DirPath + "//BF2KeyMan.exe"))
            {
                ProcessStartInfo runBF2KeyMan = new ProcessStartInfo();
                runBF2KeyMan.FileName = DirPath + "BF2KeyMan.exe";
                Process.Start(runBF2KeyMan);
            }
            else
            {
                //MessageBox.Show("Файл bf2.exe не найден!");
                MessageBox.Show("File bf2.exe not found!");
            }
        }

        #endregion
    }
}
