using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer_v2
{
    internal class DataStore
    {

        public static string CurrentDir = "";
        public static string SelectedDirPath = "";
        public static string SelectedDirName = "";
        public static string SelectedFilePath = "";
        public static string SelectedFileName = "";
        public static int PrintListPosition = -1;
        public static string[]? DirEntryList;
        public static ViewState CurrentViewState;
        public static bool DebugMode;
        public static readonly string BreakLine = new string('-', 30);

        public static string InstallPath { get { return Path.GetFullPath("."); } }
        public static string ParentPath { get { return Convert.ToString(Directory.GetParent(CurrentDir)); } }
        public static string CurrentDirName { get { DirectoryInfo di = new DirectoryInfo(CurrentDir); return di.Name; } }

        public DataStore() { }
    }
}
