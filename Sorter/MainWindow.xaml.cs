using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Logging;
using System.Security.Policy;

namespace Sorter
{
    public partial class MainWindow : Window
    {
        public string currentFolder = "";
        public string currentFile = "";
        public string[] allElements;
        public string FirstColumnButton_Destination = "";

        public string nameFix(string path)
        {
            string result = "";
            int lastIndex = path.LastIndexOf("\\") + 1;
            result = path.Remove(0, lastIndex);
            return result;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            //    OpenFileDialog openDialog = new OpenFileDialog();

            //    if (openDialog.ShowDialog() == true)
            //    {
            //        imagePicture.Source = new BitmapImage(new Uri(openDialog.FileName));
            //    }

            //    string baseName = openDialog.FileName;
            //    int lastIndex = baseName.LastIndexOf("\\") + 1 ;
            //    fileNameDisplay.Text = baseName.Remove(0, lastIndex);
            //}

            WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
            WinForms.DialogResult result = dialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                currentFolder = dialog.SelectedPath;
                allElements = Directory.GetFileSystemEntries(currentFolder);

            }
            else
            {
                WinForms.MessageBox.Show("Invalid directory!");
            }

            for (int i = 0; i < allElements.Length; i++)
            {
                imagePicture.Source = new BitmapImage(new Uri(allElements[i]));
                WinForms.MessageBox.Show("Click");
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
                WinForms.MessageBox.Show("Transition");
                // currentFile ---> FirstColumnButton_Destination
            }

        }
    }
    
}
