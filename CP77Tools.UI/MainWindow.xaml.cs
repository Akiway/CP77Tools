﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CP77Tools.UI.Data.Caching;
using CP77Tools;
using WolvenKit.Common.Tools.DDS;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Catel.IoC;
using WolvenKit.Common.Services;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using CP77Tools.UI.Functionality;
using CP77.Common.Services;
using System.Runtime.InteropServices;

namespace CP77Tools.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Archive - Cr2w - Repack (EndUser)
    /// All options (Dev)
    /// </summary>
    public partial class MainWindow : Window
    {

        [DllImport("lib/kraken.dll")]
        static extern int Kraken_Decompress(byte[] buffer, long bufferSize, byte[] outputBuffer, long outputBufferSize);

        [DllImport("lib/kraken.dll")]
        static extern int Kraken_Compress(byte[] buffer, long bufferSize, byte[] outputBuffer);

        //Other
        public ILoggerService UI_Logger;
        public Functionality.Logging log;
        public Functionality.UI ui;
        public Data.General data;
        public string[] InputFileTypes = { "Archives (*.archive)|*.archive" };

        public enum TaskType { Archive, Dump, CR2W, Hash, Oodle, Repack, }

        public Color ForeGroundTextColor = (Color)ColorConverter.ConvertFromString("#FFE5D90C");




        public MainWindow()
        {

            InitializeComponent();
            ServiceLocator.Default.RegisterType<IMainController, MainController>();
            ServiceLocator.Default.RegisterType<ILoggerService, LoggerService>();
            UI_Logger = ServiceLocator.Default.ResolveType<ILoggerService>();


            log = new Functionality.Logging(this);
            ui = new Functionality.UI(this);
            data = new Data.General();

            ui.SetToolTips();

            UI_Logger.PropertyChanged += log.UI_Logger_PropertyChanged;
            UI_Logger.OnStringLogged += log.UI_Logger_OnStringLogged;
            UI_Logger.PropertyChanging += log.UI_Logger_PropertyChanging;


        }


        private void UIFunc_DragWindow(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) this.DragMove(); }

        // General Events
        private void UIElement_CloseButton_MouseEnter(object sender, MouseEventArgs e) { Main_CloseApp_UIElement_Image.Source = ImageCache.CloseSelected; }
        private void UIElement_CloseButton_MouseLeave(object sender, MouseEventArgs e) { Main_CloseApp_UIElement_Image.Source = ImageCache.Close; }
        private void UIElement_MinimizeButton_MouseEnter(object sender, MouseEventArgs e) { Main_MinimizeApp_UIElement_Image.Source = ImageCache.MinimizeSelected; }
        private void UIElement_MinimizeButton_MouseLeave(object sender, MouseEventArgs e) { Main_MinimizeApp_UIElement_Image.Source = ImageCache.Minimize; }
        private void UIElement_PreviousItems_MouseEnter(object sender, MouseEventArgs e) { Main_PreviousItems_UIElement_Image.Source = ImageCache.PageMoveSelected; }
        private void UIElement_PreviousItems_MouseLeave(object sender, MouseEventArgs e) { Main_PreviousItems_UIElement_Image.Source = ImageCache.PageMove; }
        private void UIElement_Button_NextItems_MouseEnter(object sender, MouseEventArgs e) { Main_NextItems_UIElement_Button.Opacity = 0.75; }
        private void UIElement_Button_NextItems_MouseLeave(object sender, MouseEventArgs e) { Main_NextItems_UIElement_Button.Opacity = 0.9; }
        private void UIElement_Button_NextItems_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) { Main_NextItems_UIElement_Button.Opacity = 0.9; }
        private void UIElement_Button_PreviousItems_MouseEnter(object sender, MouseEventArgs e) { Main_PreviousItems_UIElement_Button.Opacity = 0.75; }
        private void UIElement_Button_PreviousItems_MouseLeave(object sender, MouseEventArgs e) { Main_PreviousItems_UIElement_Button.Opacity = 0.9; }
        private void UIElement_Button_PreviousItems_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) { Main_PreviousItems_UIElement_Button.Opacity = 0.9; }

        // OnExit
        private void UIElement_CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { System.Windows.Application.Current.Shutdown(); }

        // Minimize
        private void UIElement_MinimizeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { this.WindowState = WindowState.Minimized; }

        // Prev/Next Items Click events
        private void UIElement_Button_PreviousItems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { ui.PreviousItemsInView(); }
        private void UIElement_Button_NextItems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { ui.NextItemsInView(); }
        private void UIElement_PreviousItems_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { ui.GoToFirstItemInView(); }




        //Archive events
        private void UIElement_Button_ArchiveSelectArchive_Click(object sender, RoutedEventArgs e) { ui.OpenFile(0); }
        private void UIElement_Button_ArchiveSelectOutputPath_Click(object sender, RoutedEventArgs e) { ui.OpenFolder(0); }
        private void UIElement_Checkbox_ArchiveExtract_Checked(object sender, RoutedEventArgs e) { data.Archive_Extract = true; }
        private void UIElement_Checkbox_ArchiveDump_Checked(object sender, RoutedEventArgs e) { data.Archive_Dump = true; }
        private void UIElement_Checkbox_ArchiveList_Checked(object sender, RoutedEventArgs e) { data.Archive_List = true; }
        private void UIElement_Checkbox_ArchiveUncook_Checked(object sender, RoutedEventArgs e) { data.Archive_Uncook = true; }
        private void UIElement_Checkbox_ArchiveUncook_Unchecked(object sender, RoutedEventArgs e) { data.Archive_Uncook = false; }
        private void UIElement_Checkbox_ArchiveList_Unchecked(object sender, RoutedEventArgs e) { data.Archive_List = false; }
        private void UIElement_Checkbox_ArchiveExtract_Unchecked(object sender, RoutedEventArgs e) { data.Archive_Extract = false; }
        private void UIElement_Checkbox_ArchiveDump_Unchecked(object sender, RoutedEventArgs e) { data.Archive_Dump = false; }
        private void UIElement_Button_ArchiveStart_Click(object sender, RoutedEventArgs e) { ui.ThreadedTaskSender(0); Main_OutputBox_UIElement_ComboBox.Items.Clear(); }

        private void UIElement_TextBox_ArchiveHash_TextChanged(object sender, TextChangedEventArgs e) { if (UIElement_TextBox_ArchiveHash.Text != null && data != null) { try { data.Archive_Hash = Convert.ToUInt64(UIElement_TextBox_ArchiveHash.Text); } catch { } } }

        private void UIElement_Button_ArchiveSelectArchive_MouseEnter(object sender, MouseEventArgs e) { UIElement_Button_ArchiveSelectArchive.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_ArchiveSelectArchive_MouseLeave(object sender, MouseEventArgs e) { UIElement_Button_ArchiveSelectArchive.Foreground = new SolidColorBrush(ForeGroundTextColor); }
        private void UIElement_Button_ArchiveSelectOutputPath_MouseEnter(object sender, MouseEventArgs e) { UIElement_Button_ArchiveSelectOutputPath.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_ArchiveSelectOutputPath_MouseLeave(object sender, MouseEventArgs e) { UIElement_Button_ArchiveSelectOutputPath.Foreground = new SolidColorBrush(ForeGroundTextColor); }
        private void UIElement_Button_ArchiveStart_MouseEnter(object sender, MouseEventArgs e) { UIElement_Button_ArchiveStart.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_ArchiveStart_MouseLeave(object sender, MouseEventArgs e) { UIElement_Button_ArchiveStart.Foreground = new SolidColorBrush(ForeGroundTextColor); }
        private void UIElement_RadioButton_ArchiveJPG_Checked(object sender, RoutedEventArgs e) { data.Archive_UncookFileType = EUncookExtension.jpg; }
        private void UIElement_RadioButton_ArchiveBMP_Checked(object sender, RoutedEventArgs e) { data.Archive_UncookFileType = EUncookExtension.bmp; }
        private void UIElement_RadioButton_ArchiveJPEG_Checked(object sender, RoutedEventArgs e) { data.Archive_UncookFileType = EUncookExtension.jpeg; }
        private void UIElement_RadioButton_ArchivePNG_Checked(object sender, RoutedEventArgs e) { data.Archive_UncookFileType = EUncookExtension.png; }
        private void UIElement_RadioButton_ArchiveDDS_Checked(object sender, RoutedEventArgs e) { data.Archive_UncookFileType = EUncookExtension.dds; }
        private void UIElement_RadioButton_ArchiveTGA_Checked(object sender, RoutedEventArgs e) { if (data != null) data.Archive_UncookFileType = EUncookExtension.tga; }

        //Dump Events (DEV ONLY)
        private void UIElement_Button_DumpSelectArchiveOrDir_MouseEnter(object sender, MouseEventArgs e) { Dump_SelectArchiveOrDirectory_UIElement_Button.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_DumpSelectArchiveOrDir_MouseLeave(object sender, MouseEventArgs e) { Dump_SelectArchiveOrDirectory_UIElement_Button.Foreground = new SolidColorBrush(ForeGroundTextColor); }
        private void UIElement_Button_DumpSelectOutputPath_MouseEnter(object sender, MouseEventArgs e) { Dump_SelectOutputPath_UIElement_Button.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_DumpSelectOutputPath_MouseLeave(object sender, MouseEventArgs e) { Dump_SelectOutputPath_UIElement_Button.Foreground = new SolidColorBrush(ForeGroundTextColor); }
        private void UIElement_Checkbox_DumpImports_Checked(object sender, RoutedEventArgs e) { data.Dump_Imports = true; }
        private void UIElement_Checkbox_DumpImports_Unchecked(object sender, RoutedEventArgs e) { data.Dump_Imports = false; }
        private void UIElement_Checkbox_DumpMissingHashes_Checked(object sender, RoutedEventArgs e) { data.Dump_MissingHashes = true; }
        private void UIElement_Checkbox_DumpMissingHashes_Unchecked(object sender, RoutedEventArgs e) { data.Dump_MissingHashes = false; }
        private void UIElement_Checkbox_DumpInfo_Checked(object sender, RoutedEventArgs e) { data.Dump_Info = true; }
        private void UIElement_Checkbox_DumpInfo_Unchecked(object sender, RoutedEventArgs e) { data.Dump_Info = false; }
        private void UIElement_Button_DumpStart_MouseEnter(object sender, MouseEventArgs e) { Dump_Start_UIElement_Button.Foreground = new SolidColorBrush(Colors.Black); }
        private void UIElement_Button_DumpStart_MouseLeave(object sender, MouseEventArgs e) { Dump_Start_UIElement_Button.Foreground = new SolidColorBrush(ForeGroundTextColor); }

    }

    public static class StringExt
    {
        public static string ReverseTruncate(this string value, int maxLength)
        {
            var a = value.Length - maxLength;
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(a, maxLength);
        }
    }

}
