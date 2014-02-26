using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows;

namespace KnightsOfCSharpiaWPF.Music
{
    class Music
    {
        private static string command;
        private static bool isOpen;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        const string Path = @"..\..\Music\Combat.mp3";
        public static Thread musicThread;

        static Music() // A static constructor to load the game music when the method class is first used
        {
            try
            {
                Open(Path);
                musicThread = new Thread(new ThreadStart(Play));

            }
            catch (TypeInitializationException)
            {
                MessageBox.Show("The music file is corrupted (is not in the correct format)! The music will be disabled!", "The music is corrupted?!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!", "The music file path is empty?!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!", "The music file path is empty?!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(string.Format("The file {0} was not found! The music will be disabled!", (Path)), "File not found!");
            }
            catch (FileLoadException)
            {
                MessageBox.Show(string.Format("The file {0} cannot be loaded! The music will be disabled!", (Path)), "File cannot be loaded!");
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0} ! The music will
be disabled!", (Path)), "Input Output error!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will
be disabled!", (Path)), "You don't have permission to access this file");
            }
            catch (SecurityException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will
be disabled!", (Path + "Combat.mp3")), "You don't have permission to access this file");
            }

        }

        public static void Close()
        {
            command = "close MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        public static void Open(string sFileName)
        {
            command = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
            mciSendString(command, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        public static void Play()
        {
            if (isOpen)
            {
                command = "play MediaFile";
                    command += " REPEAT";
                mciSendString(command, null, 0, IntPtr.Zero);
            }
        }
    }
}
