using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Logging;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Sorter
{
    public partial class MainWindow : Window
    {
        public string currentFolder = "";
        public string currentFile = "";
        public string[] allElements;
        public string FirstColumnButton_Destination = "";
        public int index = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public string nameFix(string path)
        {
            string result = "";
            int lastIndex = path.LastIndexOf("\\") + 1;
            result = path.Remove(0, lastIndex);
            return result;
        }

        public void NextImage()
        {
            imagePicture.Source = new BitmapImage(new Uri(allElements[index]));
            currentFile = allElements[index];
            fileNameDisplay.Text = nameFix(currentFolder) + "\\" + nameFix(currentFile);
            index++;
        }

        public void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
            WinForms.DialogResult result = dialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                currentFolder = dialog.SelectedPath;
                allElements = Directory.GetFileSystemEntries(currentFolder);
                NextImage();
            }
            else
            {
                WinForms.MessageBox.Show("Invalid directory!");
            }
        }

        public void FirstColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox1.Text = nameFix(dialog.SelectedPath);
                    FirstColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                // currentFile ---> FirstColumnButton_Destination
                //NextImage();
                
            }

        }
    }
    
}
