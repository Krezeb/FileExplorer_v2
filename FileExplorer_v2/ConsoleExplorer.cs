using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer_v2
{
    internal class ConsoleExplorer
    {

        public ConsoleExplorer()
        {
            DataStore _dataStore = new DataStore();
            DataStore.CurrentDir = DataStore.InstallPath;
            DataStore.PrintListPosition = 0;
            DataStore.DebugMode = false;
        }

        public void Run()
        {
            DataStore.CurrentViewState = ViewState.List;
            while (true)
            {
                if (DataStore.CurrentViewState == ViewState.List)
                {
                    ShowFolder();
                }

                else if (DataStore.CurrentViewState == ViewState.FileView)
                {
                    ShowFileContent();
                }

                else if (DataStore.CurrentViewState == ViewState.CreateFile)
                {
                    FolderView _folderView = new FolderView(); _folderView.CreateFile();
                }
            }
        }

        public void ShowFolder()
        {
            Console.Clear();
            FolderView _folderView = new FolderView();
            _folderView.PrintList();

            if (DataStore.DebugMode == true)
            {
                Console.WriteLine();
                Console.WriteLine($"PrintListPosition: \n{DataStore.PrintListPosition}\n");
                Console.WriteLine();
                Console.WriteLine($"InstallPath: \n{DataStore.InstallPath}\n");
                Console.WriteLine($"ParentPath: \n{DataStore.ParentPath}\n");
                Console.WriteLine($"CurrentDir: \n{DataStore.CurrentDir}\n");
                Console.WriteLine($"SelectedDir: \n{DataStore.SelectedDirPath}\n");
                Console.WriteLine();
                Console.WriteLine($"SelectedFileName: \n{DataStore.SelectedFileName}\n");
                Console.WriteLine($"SelectedFile: \n{DataStore.SelectedFilePath}\n");
            }

            Navigation();
        }

        public void Navigation()
        {
            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.UpArrow: //Decreases Index and moves selector UP
                    {
                        SubtractFromIndex();
                        return;
                    }
                case ConsoleKey.DownArrow: //Increses Index and moves selector DOWN
                    {
                        AddToIndex();
                        return;
                    }
                case ConsoleKey.Enter: //Enters SelectedDir
                    {
                        Forward();
                        return;
                    }
                case ConsoleKey.Backspace: //Enters ParentDir
                    {
                        Back();
                        return;
                    }
                case ConsoleKey.Spacebar: //Opens SelectedFile and prints contents
                    {
                        DataStore.CurrentViewState = ViewState.FileView;
                        return;
                    }
                case ConsoleKey.D: //Deletes SelectedFile
                    {
                        FolderView _folderView = new FolderView(); _folderView.DeleteFile();
                        return;
                    }
                case ConsoleKey.C: //Creates new .txt file in CurrentDir
                    {
                        DataStore.CurrentViewState = ViewState.CreateFile;
                        return;
                    }
                case ConsoleKey.Home:
                    {
                        DebugModeToggle();
                        return;
                    }
            }

        }

        public void AddToIndex() //Increses Index and moves selector DOWN (Pressing DOWN)
        {
            if (DataStore.PrintListPosition <= DataStore.DirEntryList.Length - 2)
                DataStore.PrintListPosition++;
            else if (DataStore.PrintListPosition > DataStore.DirEntryList.Length - 2)
                DataStore.PrintListPosition = 0;
        }

        public void SubtractFromIndex() //Decreases Index and moves selector UP (Pressing UP)
        {
            if (DataStore.PrintListPosition > 0)
                DataStore.PrintListPosition--;
            else if (DataStore.PrintListPosition <= 0)
                DataStore.PrintListPosition = DataStore.DirEntryList.Length - 1;
        }

        public void Forward() //Enters SelectedDir
        {
            if (Directory.Exists(DataStore.SelectedDirName))
            {
                DataStore.CurrentDir = DataStore.SelectedDirPath;
            }
        }

        public void Back() //Enters ParentPath
        {
            DataStore.CurrentDir = DataStore.ParentPath;
        }

        private void ShowFileContent() //Opens SelectedFile and prints contents to Console (Pressing SPACE)
        {
            if (File.Exists(DataStore.SelectedFileName))
            {
                Console.Clear();
                Console.WriteLine($"{DataStore.BreakLine}");
                Console.WriteLine($"{DataStore.SelectedFileName}");
                Console.WriteLine(DataStore.SelectedFilePath);
                Console.WriteLine($"{DataStore.BreakLine}\n");

                while (true)
                {
                    using (StreamReader sr = new StreamReader(Path.GetFullPath(DataStore.SelectedFilePath)))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    Console.WriteLine("\nPress any key to return to Folder View...");
                    Console.ReadKey();
                    break;
                }
            }
            DataStore.CurrentViewState = ViewState.List;
            return;
        }

        public void DebugModeToggle() //Super secret program info
        {
            DataStore.DebugMode = !DataStore.DebugMode;
        }
    }
}
