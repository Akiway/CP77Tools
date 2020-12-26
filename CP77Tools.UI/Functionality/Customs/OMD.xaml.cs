﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlzEx.Theming;
using CP77Tools.UI.Data;
using CP77Tools.UI.Data.Tasks;
using CP77Tools.UI.Views;
using MahApps.Metro.Controls;
using Color = System.Windows.Media.Color;

namespace CP77Tools.UI.Functionality.Customs
{
    /// <summary>
    /// Interaction logic for OMD.xaml
    /// </summary>
    public partial class OMD : MetroWindow
    {

        public enum ForF { File, Folder }
                private void UIFunc_DragWindow(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) this.DragMove(); }
                public Color ForeGroundTextColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFE5D90C");
                private ArchiveData DataReference;
                private General.TaskType CurrentTaskType;
                private SUI sui;

                private Tools tools;
                private General.OMD_Type CurrentOMDType;

        public OMD(Tools _tools,SUI _sui, General.TaskType taskType, General.OMD_Type _OMD_Type)
        {
            tools = _tools;
            sui = _sui; 
            CurrentTaskType = taskType;
            DataReference = sui.archivedata;
            CurrentOMDType = _OMD_Type;
            InitializeComponent();
            InitializeFileSystemObjects();
            ThemeManager.Current.ChangeTheme(this, "Dark.Steel");

        }


        private void InitializeFileSystemObjects()
        {
            var drives = DriveInfo.GetDrives();
            DriveInfo.GetDrives().ToList().ForEach(drive =>
            {
                var fileSystemObject = new FileSystemObjectInfo(drive);
                fileSystemObject.BeforeExplore += FileSystemObject_BeforeExplore;
                fileSystemObject.AfterExplore += FileSystemObject_AfterExplore;
                OMD_FileTreeView.Items.Add(fileSystemObject);
            });
        }
        private void FileSystemObject_AfterExplore(object sender, System.EventArgs e) { Cursor = Cursors.Arrow; }
        private void FileSystemObject_BeforeExplore(object sender, System.EventArgs e) { Cursor = Cursors.Wait; }

        private void OMD_FileTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var q = OMD_FileTreeView.SelectedItem as FileSystemObjectInfo;
                        if (CurrentOMDType == Data.General.OMD_Type.Multi) { OMD_ListboxSelected.Items.Add(q.FileSystemInfo.FullName);}
                        else if (CurrentOMDType == Data.General.OMD_Type.Single) { OMD_ListboxSelected.Items.Clear(); OMD_ListboxSelected.Items.Add(q.FileSystemInfo.FullName); }
        }

        private void OMD_ListboxSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OMD_ListboxSelected.Items.Remove(OMD_ListboxSelected.SelectedItem);
        }

        private void OMD_ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] clist = OMD_ListboxSelected.Items.OfType<string>().ToArray();
                var d = clist.Distinct().ToArray();
                switch (CurrentTaskType)
                {
                    case General.TaskType.Archive:
                        DataReference.Archive_Path = d;
                        tools.ArchiveSelectedInputConceptDropDown.Items.Clear();
                        tools.ArchiveSelectedInputConceptDropDown.ItemsSource = d.ToList();
                        break;
                    //case MainWindow.TaskType.CR2W:
                    //    DataReference.CR2W_Path = d;
                    //    //     app.CR2W_PathIndicatorSelected_UIElement_TextBlock.Text = DataReference.Archive_Path[0];
                    //    app.CR2W_SelectedDropdown_UIElement_ComboBox.Items.Clear();
                    //    app.CR2W_SelectedDropdown_UIElement_ComboBox.ItemsSource = d.ToList();
                    //    break;
                    //case MainWindow.TaskType.Dump:
                    //    DataReference.Dump_Path = d;
                    //    //         app.Dump_PathIndicatorSelected_UIElement_TextBlock.Text = DataReference.Archive_Path[0];
                    //    app.Dump_SelectedDropdown_UIElement_ComboBox.Items.Clear();
                    //    app.Dump_SelectedDropdown_UIElement_ComboBox.ItemsSource = d.ToList();
                    //    break;
                    //case MainWindow.TaskType.Hash:
                    //    break;
                    //case MainWindow.TaskType.Oodle:
                    //    DataReference.Oodle_Path = d;
                    //    //      app.Oodle_PathIndicator_Selected_UIElement_TextBlock.Text = DataReference.Archive_Path[0];
                    //    app.Oodle_SelectedDropdown_UIElement_ComboBox.Items.Clear();
                    //    app.Oodle_SelectedDropdown_UIElement_ComboBox.ItemsSource = d.ToList();
                    //    break;
                    //case MainWindow.TaskType.Repack:
                    //    DataReference.Repack_Path = d;
                    //    //       app.Repack_PathIndicatorSelected_UIElement_TextBlock.Text = DataReference.Archive_Path[0];
                    //    app.Repack_SelectedDropdown_UIElement_ComboBox.Items.Clear();
                    //    app.Repack_SelectedDropdown_UIElement_ComboBox.ItemsSource = d.ToList();
                    //    break;
                }
                this.Close();
            }
            catch { }
        }

        private void OMD_ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }




    [Serializable]
    public abstract class PropertyNotifier : INotifyPropertyChanged
    {
        public PropertyNotifier() : base() { }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
    [Serializable]
    public abstract class BaseObject : PropertyNotifier
    {
        private IDictionary<string, object> m_values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public T GetValue<T>(string key) { var value = GetValue(key); return (value is T) ? (T)value : default(T); }
        private object GetValue(string key) { if (string.IsNullOrEmpty(key)) { return null; } return m_values.ContainsKey(key) ? m_values[key] : null; }
        public void SetValue(string key, object value)
        {
            if (!m_values.ContainsKey(key)) { m_values.Add(key, value); }
            else { m_values[key] = value; }
            OnPropertyChanged(key);
        }
    }
    public static class Interop
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string path,
            uint attributes,
            out ShellFileInfo fileInfo,
            uint size,
            uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyIcon(IntPtr pointer);
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ShellFileInfo
    {
        public IntPtr hIcon; public int iIcon; public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }
    public enum FileAttribute : uint { Directory = 16, File = 256 }
    [Flags]
    public enum ShellAttribute : uint
    {
        LargeIcon = 0, SmallIcon = 1, OpenIcon = 2,
        ShellIconSize = 4, Pidl = 8, UseFileAttributes = 16, AddOverlays = 32, OverlayIndex = 64, Others = 128, Icon = 256, DisplayName = 512, TypeName = 1024, Attributes = 2048, IconLocation = 4096, ExeType = 8192, SystemIconIndex = 16384, LinkOverlay = 32768, Selected = 65536, AttributeSpecified = 131072
    }
    public enum IconSize : short { Small, Large }
    public enum ItemState : short { Undefined, Open, Close }
    public enum ItemType { Drive, Folder, File }
    public class FileSystemObjectInfo : BaseObject
    {
        public FileSystemObjectInfo(DriveInfo drive) : this(drive.RootDirectory) { }
        public FileSystemObjectInfo(FileSystemInfo info)
        {
            if (this is DummyFileSystemObjectInfo) { return; }
            Children = new ObservableCollection<FileSystemObjectInfo>(); FileSystemInfo = info;
            if (info is DirectoryInfo) { ImageSource = FolderManager.GetImageSource(info.FullName, ItemState.Close); AddDummy(); }
            else if (info is FileInfo) { ImageSource = FileManager.GetImageSource(info.FullName); }
            PropertyChanged += new PropertyChangedEventHandler(FileSystemObjectInfo_PropertyChanged);
            void FileSystemObjectInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (FileSystemInfo is DirectoryInfo)
                {
                    if (string.Equals(e.PropertyName, "IsExpanded", StringComparison.CurrentCultureIgnoreCase))
                    {
                        RaiseBeforeExpand();
                        if (IsExpanded)
                        {
                            ImageSource = FolderManager.GetImageSource(FileSystemInfo.FullName, ItemState.Open);
                            if (HasDummy()) { RaiseBeforeExplore(); RemoveDummy(); ExploreDirectories(); ExploreFiles(); RaiseAfterExplore(); }
                        }
                        else { ImageSource = FolderManager.GetImageSource(FileSystemInfo.FullName, ItemState.Close); }
                        RaiseAfterExpand();
                    }
                }
            }
        }
        public event EventHandler BeforeExpand;
        public event EventHandler AfterExpand;
        public event EventHandler BeforeExplore;
        public event EventHandler AfterExplore;
        private void RaiseBeforeExpand() { BeforeExpand?.Invoke(this, EventArgs.Empty); }
        private void RaiseAfterExpand() { AfterExpand?.Invoke(this, EventArgs.Empty); }
        private void RaiseBeforeExplore() { BeforeExplore?.Invoke(this, EventArgs.Empty); }
        private void RaiseAfterExplore() { AfterExplore?.Invoke(this, EventArgs.Empty); }
        public ObservableCollection<FileSystemObjectInfo> Children { get { return base.GetValue<ObservableCollection<FileSystemObjectInfo>>("Children"); } private set { base.SetValue("Children", value); } }
        public ImageSource ImageSource { get { return base.GetValue<ImageSource>("ImageSource"); } private set { base.SetValue("ImageSource", value); } }
        public bool IsExpanded { get { return base.GetValue<bool>("IsExpanded"); } set { base.SetValue("IsExpanded", value); } }
        public FileSystemInfo FileSystemInfo { get { return base.GetValue<FileSystemInfo>("FileSystemInfo"); } private set { base.SetValue("FileSystemInfo", value); } }
        private DriveInfo Drive { get { return base.GetValue<DriveInfo>("Drive"); } set { base.SetValue("Drive", value); } }
        private void AddDummy() { this.Children.Add(new DummyFileSystemObjectInfo()); }
        private bool HasDummy() { return !object.ReferenceEquals(this.GetDummy(), null); }
        private DummyFileSystemObjectInfo GetDummy() { var list = this.Children.OfType<DummyFileSystemObjectInfo>().ToList(); if (list.Count > 0) return list.First(); return null; }
        private void RemoveDummy() { this.Children.Remove(this.GetDummy()); }
        private void ExploreDirectories()
        {
            if (Drive?.IsReady == false) { return; }
            if (FileSystemInfo is DirectoryInfo)
            {
                try
                {
                    var directories = ((DirectoryInfo)FileSystemInfo).GetDirectories();
                    foreach (var directory in directories.OrderBy(d => d.Name))
                    {
                        if ((directory.Attributes & FileAttributes.System) != FileAttributes.System &&
                            (directory.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                        {
                            var fileSystemObject = new FileSystemObjectInfo(directory);
                            fileSystemObject.BeforeExplore += FileSystemObject_BeforeExplore;
                            fileSystemObject.AfterExplore += FileSystemObject_AfterExplore;
                            Children.Add(fileSystemObject);
                        }
                    }
                }
                catch (UnauthorizedAccessException e) { }
            }
        }

        private void FileSystemObject_AfterExplore(object sender, EventArgs e) { RaiseAfterExplore(); }
        private void FileSystemObject_BeforeExplore(object sender, EventArgs e) { RaiseBeforeExplore(); }
        private void ExploreFiles()
        {
            if (Drive?.IsReady == false) { return; }
            if (FileSystemInfo is DirectoryInfo)
            {
                try
                {
                    var files = ((DirectoryInfo)FileSystemInfo).GetFiles();
                    foreach (var file in files.OrderBy(d => d.Name))
                    {
                        if ((file.Attributes & FileAttributes.System) != FileAttributes.System && (file.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden) { Children.Add(new FileSystemObjectInfo(file)); }
                    }
                }
                catch (UnauthorizedAccessException e) { }
            }
        }
    }
    internal class DummyFileSystemObjectInfo : FileSystemObjectInfo { public DummyFileSystemObjectInfo() : base(new DirectoryInfo("DummyFileSystemObjectInfo")) { } }
    public class ShellManager
    {
        public static Icon GetIcon(string path, ItemType type, IconSize iconSize, ItemState state)
        {
            var attributes = (uint)(type == ItemType.Folder ? FileAttribute.Directory : FileAttribute.File);
            var flags = (uint)(ShellAttribute.Icon | ShellAttribute.UseFileAttributes);
            if (type == ItemType.Folder && state == ItemState.Open) { flags = flags | (uint)ShellAttribute.OpenIcon; }
            if (iconSize == IconSize.Small) { flags = flags | (uint)ShellAttribute.SmallIcon; }
            else { flags = flags | (uint)ShellAttribute.LargeIcon; }
            var fileInfo = new ShellFileInfo();
            var size = (uint)Marshal.SizeOf(fileInfo);
            var result = Interop.SHGetFileInfo(path, attributes, out fileInfo, size, flags);
            if (result == IntPtr.Zero) { throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()); }
            try { return (Icon)Icon.FromHandle(fileInfo.hIcon).Clone(); }
            catch { throw; }
            finally { Interop.DestroyIcon(fileInfo.hIcon); }
        }
    }

    public static class FolderManager
    {
        public static ImageSource GetImageSource(string directory, ItemState folderType) { return GetImageSource(directory, new System.Drawing.Size(16, 16), folderType); }
        public static ImageSource GetImageSource(string directory, System.Drawing.Size size, ItemState folderType)
        {
            using (var icon = ShellManager.GetIcon(directory, ItemType.Folder, IconSize.Large, folderType))
            {
                return Imaging.CreateBitmapSourceFromHIcon(icon.Handle,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(size.Width, size.Height));
            }
        }
    }
    public static class FileManager
    {
        public static ImageSource GetImageSource(string filename) { return GetImageSource(filename, new System.Drawing.Size(16, 16)); }
        public static ImageSource GetImageSource(string filename, System.Drawing.Size size)
        {
            using (var icon = ShellManager.GetIcon(System.IO.Path.GetExtension(filename), ItemType.File, IconSize.Small, ItemState.Undefined))
            {
                return Imaging.CreateBitmapSourceFromHIcon(icon.Handle,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(size.Width, size.Height));
            }
        }
    }
}
