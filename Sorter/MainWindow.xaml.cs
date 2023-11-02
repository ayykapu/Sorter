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
        public string tempFolderPath = "";
        public int index = 0;
        public MainWindow()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            InitializeComponent();
            tempFolderPath = Path.Combine(desktopPath, "SorterTemp");

            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }
            else
            {
                string[] files = Directory.GetFiles(tempFolderPath);

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
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
            File.Copy(allElements[index], tempFolderPath + "\\tempfile" + index + ".png");
            imagePicture.Source = new BitmapImage(new Uri(tempFolderPath + "\\tempfile" + index + ".png"));
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
                File.Move(currentFile, FirstColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }











        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            File.Move(currentFile, tempFolderPath + "\\tempfile" + index + ".png");
            NextImage();
        }
    }

}
