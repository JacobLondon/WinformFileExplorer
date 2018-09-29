using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer.Backend
{
    /// <summary>
    /// All of the relevant information about a page is defined here
    /// </summary>
    class PageData
    {
        // the url of the current location
        public string URL { get; set; }

        // the absolute paths of all subfolders of the selected folder to be shown on the right
        public List<string> FileDetail { get; set; }

        // all of the files shown in the current location
        public List<FileInfo> Files { get; set; }
        public List<DirectoryInfo> Directories { get; set; }

        public PageData(string URL)
        {
            this.URL = URL;
        }

        public override string ToString()
        {
            string info = "";

            foreach (DirectoryInfo d in Directories)
            {
                info += d.Name + "\n";
            }

            foreach (FileInfo f in Files)
            {
                info += f.Name + "\n";
            }

            return info;
        }

        /// <summary>
        /// Goes to the current url and gets all of the subfolders in the given folder
        /// </summary>
        public void GetFileDetails(string folderName)
        {
            // check if the folder appended to the URL is a directory
            //string path = URL + @"\" + folderName;
            FileAttributes attr = File.GetAttributes(folderName);

            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                DirectoryInfo directory = new DirectoryInfo(folderName);

                // get details if it is a directory
                try
                {
                    FileDetail = directory.GetFiles().ToList().Select(d => d.Name).ToList();

                }
                catch
                {
                    FileDetail = new List<string>();
                }
            }
        }

        /// <summary>
        /// Gets all of the files in the current url
        /// </summary>
        public void GetFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(URL);

            Files = directory.GetFiles().ToList();
            Directories = directory.GetDirectories().ToList();
            
        }

        public void BuildFileDGV(ref DataGridView fileDGV)
        {
            // remove all current items
            fileDGV.Rows.Clear();
            
            // put all the directories in first
            foreach (DirectoryInfo d in Directories)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(fileDGV);

                // add values to each column
                row.Cells[0].Value = d.Name.ToString();
                row.Cells[1].Value = d.LastWriteTimeUtc.ToString(Backend.Constants.TIME_FORMAT);
                row.Cells[2].Value = "File Folder";
                row.Cells[3].Value = GetDirectorySize(URL + "/" + d.Name) / 1000;

                fileDGV.Rows.Add(row);
            }

            // put in all files next
            foreach (FileInfo f in Files)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(fileDGV);

                // add values to each column
                row.Cells[0].Value = f.Name.ToString();
                row.Cells[1].Value = f.LastWriteTimeUtc.ToString(Backend.Constants.TIME_FORMAT);
                row.Cells[2].Value = f.Extension.ToString();
                row.Cells[3].Value = f.Length / 1000;

                fileDGV.Rows.Add(row);
            }

            // update the dgv
            fileDGV.Refresh();
        }

        public static long GetDirectorySize(string url)
        {
            // Get array of all file names.
            string[] allFiles = { };

            try
            {
                allFiles = Directory.GetFiles(url, "*.*");
            }
            // the program has no permission to access
            catch
            {
                return 0;
            }
            
            // Calculate total bytes of all files
            long size = 0;
            foreach (string name in allFiles)
            {
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }
            // Return total size
            return size;
        }

    }
}
