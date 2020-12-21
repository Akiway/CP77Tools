﻿using CP77Tools.Tasks;
using CP77Tools.UI.Functionality.Customs;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CP77Tools.UI.Functionality
{
    public class UI
    {
        private MainWindow app;
        public UI(MainWindow mainWindow) { this.app = mainWindow; }



        // Creates Tasks based on Taskindex.
        private void TaskManager(int taskindex)
        {
            switch (taskindex)
            {
                case 0:
                    if (app.data.Archive_Path.Length > 0)
                    {
                        Task task = new Task(() => ConsoleFunctions.ArchiveTask(app.data.Archive_Path, app.data.Archive_OutPath, app.data.Archive_Extract, app.data.Archive_Dump, app.data.Archive_List, app.data.Archive_Uncook, app.data.Archive_UncookFileType, app.data.Archive_Hash, app.data.Archive_Pattern, app.data.Archive_Regex));
                        task.Start(); task.Wait(); app.log.TaskFinished(MainWindow.TaskType.Archive);
                    }
                    break;

                case 1:
                    if (app.data.CR2W_Path.Length > 0)
                    {
                        Task task = new Task(() => ConsoleFunctions.Cr2wTask(app.data.CR2W_Path, app.data.CR2W_OutPath, app.data.CR2W_All, app.data.CR2W_Chunks));
                        task.Start(); task.Wait(); app.log.TaskFinished(MainWindow.TaskType.CR2W);
                    }
                    break;

                case 2: if (app.data.CR2W_Path.Length > 0)
                    { } 
                    break;


                case 3: ConsoleFunctions.HashTask(app.data.Hash_Input, app.data.Hash_Missing); break;

                case 4: break;
                    // if (CR2W_Path != "" && CR2W_OutPath != "") { ConsoleFunctions.OodleTask(Oodle_Path, Oodle_OutPath, Oodle_Decompress); } 
            }
        }



        // Creates Thread and sends TaskIndicator to taskmanager to run task on thread.
        public void ThreadedTaskSender(int item) { Thread worker = new Thread(() => TaskManager(item)); worker.IsBackground = true; worker.Start(); }

        // Open file dialog with filter based on typeindicator.
        public void OpenFile(int TypeIndicator)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); openFileDialog.Multiselect = true;

            if (TypeIndicator == 0) { string FileFilter = app.InputFileTypes[TypeIndicator]; openFileDialog.Filter = FileFilter; }

            var result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                switch (TypeIndicator)
                {
                    case 0: // Archive
                        app.Archive_PathIndicator_Selected_UIElement_TextBlock.Text = openFileDialog.SafeFileName;
                        Array.Resize(ref app.data.Archive_Path, app.data.Archive_Path.Length + 1); app.data.Archive_Path[app.data.Archive_Path.Length - 1] = openFileDialog.FileName;
                        break;
                    case 1: // CR2W
                        app.CR2W_PathIndicatorSelected_UIElement_TextBlock.Text = openFileDialog.SafeFileName;
                        app.data.CR2W_Path = openFileDialog.FileName;
                        break;
                    case 2: // REPACK
                        break;
                    case 3: // Dump
                        break;
                    case 4: // Hash
                        break;
                    case 5: // Oodle
                        break;
                }
            }
        }





        public void NextItemsInView()
        {
            app.Main_NextItems_UIElement_Button.Opacity = 0.6;
            app.Main_ItemList_UIElement_ListBox.ScrollIntoView(app.Main_ItemList_UIElement_ListBox.Items[app.ui.Pagehandler(true)]);
        }
        public void PreviousItemsInView()
        {
            app.Main_PreviousItems_UIElement_Button.Opacity = 0.6;
            if (app.ui.CurrentPageIndex > 0)
            {
                app.Main_ItemList_UIElement_ListBox.ScrollIntoView(app.Main_ItemList_UIElement_ListBox.Items[app.ui.Pagehandler(false)]);
            }
        }
        public void GoToFirstItemInView()
        {
            app.Main_ItemList_UIElement_ListBox.ScrollIntoView(app.Main_ItemList_UIElement_ListBox.Items[0]);
        }


        // TopKek
        public int CurrentPageIndex = 0;
        public int Pagehandler(bool plus)
        {
            var EnabledCount = 0;
            var lowest = 0;
            foreach (Control item in app.Main_ItemList_UIElement_ListBox.Items) { if (item.IsEnabled) { EnabledCount++; } }
            if (plus)
            {
                if (CurrentPageIndex <= EnabledCount)
                {
                    CurrentPageIndex += 2;
                    CurrentPageIndex = CurrentPageIndex switch
                    {
                        <= 1 => 1,
                        <= 3 => 3,
                        <= 5 => 5,
                        <= 7 => 7,
                        <= 9 => 9,
                        _ => CurrentPageIndex
                    };
                }
            }
            if (!plus)
            {
                if (CurrentPageIndex > lowest)
                {
                    CurrentPageIndex -= 2;
                    if (CurrentPageIndex == 1) { CurrentPageIndex = 0; }
                    if (CurrentPageIndex == 3) { CurrentPageIndex = 2; }
                    if (CurrentPageIndex == 5) { CurrentPageIndex = 4; }
                    if (CurrentPageIndex == 7) { CurrentPageIndex = 6; }
                    if (CurrentPageIndex == 9) { CurrentPageIndex = 8; }
                }
            }
            if (CurrentPageIndex > EnabledCount) { CurrentPageIndex = EnabledCount; }
            if (CurrentPageIndex < 0) { CurrentPageIndex = 0; }
            return CurrentPageIndex;
        }

        // Open Folder Dialog, change UI based on typeindicator.
        public void OpenFolder(int TypeIndicator)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog(); dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                switch (TypeIndicator)
                {
                    case 0:
                        var dialog1 = new OpenFileDialog();
                        dialog1.ValidateNames = false;
                        dialog1.CheckFileExists = false;
                        dialog1.CheckPathExists = true;
                        dialog1.FileName = "Folder Selection.";
                        dialog1.ShowDialog(); // will allow both files and folders to be selected

                        app.Archive_PathIndicator_Output_UIElement_TextBlock.Text = dialog.FileName.ReverseTruncate(34);
                        app.data.Archive_OutPath = dialog.FileName;
                        break;
                    case 1: // CR2W
                        app.CR2W_PathIndicator_UIElement_TextBlock.Text = dialog.FileName.ReverseTruncate(34);
                        app.data.CR2W_OutPath = dialog.FileName;
                        break;
                    case 2: // REPACK
                        break;
                    case 3: // Dump
                        break;
                    case 4: // Hash
                        break;
                    case 5: // Oodle
                        break;



                }
            }
        }



        public void OpenF(MainWindow.TaskType taskType)
        {
            OpenMultiDialog OMD_Selector = new Functionality.Customs.OpenMultiDialog(app.data, taskType);
            OMD_Selector.Show();
        }

        // TooltipsSetter
        public void SetToolTips()
        {
            //Archive
            app.Archive_SelectArchive_UIElement_Button.ToolTip = app.data.ToolTipArchive_Path;
            app.Archive_SelectOutputPath_UIElement_Button.ToolTip = app.data.ToolTipArchive_OutputPath;
            app.Archive_Dump_UIElement_Checkbox.ToolTip = app.data.ToolTipArchive_Dump;
            app.Archive_Extract_UIElement_Checkbox.ToolTip = app.data.ToolTipArchive_Extract;
            app.Archive_List_UIElement_Checkbox.ToolTip = app.data.ToolTipArchive_List;
            app.Archive_Uncook_UIElement_Checkbox.ToolTip = app.data.ToolTipArchive_Uncook;
            app.Archive_Hash_UIElement_TextBox.ToolTip = app.data.ToolTipArchive_Hash;
            app.Archive_Start_UIElement_Button.ToolTip = app.data.ToolTipArchive;
            //Dump
            app.Dump_PathIndicatorSelected_UIElement_TextBlock.ToolTip = app.data.ToolTipDump_Path;
            app.Dump_Imports_UIElement_CheckBox.ToolTip = app.data.ToolTipDump_Imports;
            app.Dump_MissingHashes_UIElement_CheckBox.ToolTip = app.data.ToolTipDump_MissingHashes;
            app.Dump_Info_UIElement_CheckBox.ToolTip = app.data.ToolTipDump_Info;
            //CR2W
            //Hash
            //Oodle
        }










    }
}
