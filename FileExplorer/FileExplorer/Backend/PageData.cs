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

        public PageData(string URL)
        {
            this.URL = URL;
        }

        /// <summary>
        /// Goes to the current url and gets all of the subfolders in the given folder
        /// </summary>
        public void GetFileDetails(string folderName)
        {

        }

        /// <summary>
        /// Gets all of the files in the current url
        /// </summary>
        public void GetFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(URL);

            Files = directory.GetFiles().ToList();

            foreach(FileInfo f in Files)
            {
                Console.WriteLine(f.Name);
            }
        }

        public void BuildFileDGV(ref DataGridView fileDGV)
        {

        }

    }
}
