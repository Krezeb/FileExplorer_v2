using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer_v2
{
    internal class FolderView
    {

        public void PrintList()
        {
            DataStore.DirEntryList = Directory.GetFileSystemEntries(DataStore.CurrentDir);
            Console.WriteLine($"{DataStore.CurrentDirName}");
            Console.WriteLine($"{DataStore.CurrentDir}");
            Console.WriteLine($"{DataStore.BreakLine}\n");
            if (DataStore.DirEntryList.Length == 0)
            {
                DataStore.PrintListPosition = 0;
                Console.WriteLine($"No Entries found...");
                Console.WriteLine($"{DataStore.BreakLine}\n");
                return;
            }
            for (int i = 0; i < DataStore.DirEntryList.Length; i++)
            {
                FileInfo fi = new FileInfo(DataStore.DirEntryList[i]);
                DirectoryInfo di = new DirectoryInfo(DataStore.DirEntryList[i]);

                if (DataStore.PrintListPosition == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (fi.Exists)
                    {
                        Console.WriteLine($"-- {fi.Name}");
                        DataStore.SelectedDirName = "";
                        DataStore.SelectedDirPath = "";
                        DataStore.SelectedFileName = fi.Name;
                        DataStore.SelectedFilePath = fi.FullName;

                    }
                    else if (di.Exists)
                    {
                        Console.WriteLine($"## {di.Name}");
                        DataStore.SelectedDirName = di.Name;
                        DataStore.SelectedDirPath = di.FullName;
                        DataStore.SelectedFileName = "";
                        DataStore.SelectedFilePath = "";

                    }
                    Console.ResetColor();
                }
                else
                {
                    if (fi.Exists)
                        Console.WriteLine($"-- {fi.Name}");
                    if (di.Exists)
                        Console.WriteLine($"## {di.Name}");
                }
            }
            Console.WriteLine($"{DataStore.BreakLine}\n");
        }

        public void CreateFile()
        {
            Console.Clear();
            Console.WriteLine("Create File");
            Console.WriteLine($"{DataStore.BreakLine}\n");
            string inputFileName = "", newFileName = "";
            while (true)
            {
                Console.Write("File name: ");
                inputFileName = Console.ReadLine();
                if (inputFileName != "") { break; }
                Console.WriteLine("Invalid File Name...");
            }
            newFileName = $"{inputFileName}.txt";
            string newFilePath = Path.Join(DataStore.CurrentDir, newFileName);
            List<String> tempList = new List<string>();
            using (FileStream fs = File.OpenWrite(newFilePath))
            {
                while (true)
                {
                    Console.Write("New Line: ");
                    string newLine = Console.ReadLine();
                    if (newLine == "") { break; }
                    tempList.Add(newLine);
                }
            }
            using (StreamWriter sw = new StreamWriter(newFilePath))
            {
                foreach (string line in tempList)
                {
                    sw.WriteLine(line);
                }
            }
            DataStore.CurrentViewState = ViewState.List;
            return;
        }
        public void DeleteFile()
        {
            Console.Clear();
            Console.WriteLine($"Are you sure you want to Delete:\n");
            Console.WriteLine($"\"{DataStore.SelectedFileName}\"?\n\nY/n\n");
            ConsoleKey confirm = Console.ReadKey().Key;
            if (confirm == ConsoleKey.Y)
            {
                File.Delete(DataStore.SelectedFilePath);
            }
            else
            {
                return;
            }
        }
    }
}
