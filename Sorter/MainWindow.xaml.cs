﻿using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Sorter
{
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            InitializeComponent();
        }

        public void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == true)
            {
                imagePicture.Source = new BitmapImage(new Uri(openDialog.FileName));
            }
            
            string baseName = openDialog.FileName;
            int lastIndex = baseName.LastIndexOf("\\") + 1 ;
            fileNameDisplay.Text = baseName.Remove(0, lastIndex);

        }

    }
}
