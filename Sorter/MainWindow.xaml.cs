using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.Logging;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Navigation;

namespace Sorter
{
    public partial class MainWindow : Window
    {
        public string currentFolder = "";
        public string currentFile = "";
        public string[] allElements;
        public string FirstColumnButton_Destination = "";
        public string SecondColumnButton_Destination = "";
        public string ThirdColumnButton_Destination = "";
        public string FourthColumnButton_Destination = "";
        public string FifthColumnButton_Destination = "";
        public string SixthColumnButton_Destination = "";
        public string SeventhColumnButton_Destination = "";
        public string EighthColumnButton_Destination = "";
        public string NinthColumnButton_Destination = "";
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
            string[] pngFiles = Directory.GetFiles(currentFolder, "*.png");

            if (pngFiles.Length == 0)
            {
                WinForms.MessageBox.Show("There are no PNGs left.");
            }
            else
            {
                File.Copy(allElements[index], tempFolderPath + "\\tempfile" + index + ".png");
                imagePicture.Source = new BitmapImage(new Uri(tempFolderPath + "\\tempfile" + index + ".png"));
                currentFile = allElements[index];
                fileNameDisplay.Text = nameFix(currentFolder) + "\\" + nameFix(currentFile);
                index++;
            }
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
        public void SecondColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if(SecondColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox2.Text = nameFix(dialog.SelectedPath);
                    SecondColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, SecondColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void ThirdColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (ThirdColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox3.Text = nameFix(dialog.SelectedPath);
                    ThirdColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, ThirdColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void FourthColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (FourthColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox4.Text = nameFix(dialog.SelectedPath);
                    FourthColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, FourthColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void FifthColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (FifthColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox5.Text = nameFix(dialog.SelectedPath);
                    FifthColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, FifthColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }

        public void SixthColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (SixthColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox6.Text = nameFix(dialog.SelectedPath);
                    SixthColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, SixthColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void SeventhColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (SeventhColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox7.Text = nameFix(dialog.SelectedPath);
                    SeventhColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, SeventhColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void EighthColumnButton_Click(object sender, RoutedEventArgs e)  
        {
            if (EighthColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox8.Text = nameFix(dialog.SelectedPath);
                    EighthColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, EighthColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void NinthColumnButton_Click(object sender, RoutedEventArgs e)
        {
            if (NinthColumnButton_Destination == "")
            {
                WinForms.FolderBrowserDialog dialog = new WinForms.FolderBrowserDialog();
                WinForms.DialogResult result = dialog.ShowDialog();

                if (result == WinForms.DialogResult.OK)
                {
                    ButtonTextBox9.Text = nameFix(dialog.SelectedPath);
                    NinthColumnButton_Destination = dialog.SelectedPath;
                }
                else
                {
                    WinForms.MessageBox.Show("Invalid directory!");
                }
            }
            else
            {
                File.Move(currentFile, NinthColumnButton_Destination + "\\" + nameFix(currentFile));
                NextImage();
            }
        }
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            WinForms.DialogResult result = WinForms.MessageBox.Show("  Are you sure?", "Delete status", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == WinForms.DialogResult.Yes)
            {
                File.Delete(currentFile);
                NextImage();
            }
        }

        public void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            //string newName;
            //newName = Interaction.InputBox("Rename file", "Rename file", nameFix(currentFile));
            //int cut = currentFile.Length - nameFix(currentFile).Length;

            //currentFile = currentFile.Substring(0, cut) + "\\" + newName;
            
        }


    }
}