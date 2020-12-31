﻿using CP77Tools.UI.Data;
using CP77Tools.UI.Data.Tasks;
using CP77Tools.UI.Functionality.Customs;
using CP77Tools.UI.Views.Tasks;
using System;
using System.Collections.Generic;
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
using static CP77Tools.UI.Data.General;

namespace CP77Tools.UI.Views.Tabs.Archive
{
    /// <summary>
    /// Interaction logic for DumpTab.xaml
    /// </summary>
    public partial class DumpTab : UserControl
    {
        public DumpTab()
        {
            InitializeComponent(); 
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
        }

        private void ArchiveSelectOutpathButton_Click(object sender, RoutedEventArgs e)
        {
            OMD OutPathSelector = new OMD(TaskType.Archive, OMD_Type.Single, true);
            OutPathSelector.Title = "Select Outpath";
            OutPathSelector.ArchiveDumpTab = this;
            OutPathSelector.archivesubtasktype = ArchiveData.TaskType.Dump;
            OutPathSelector.Show();
        }




        private void ArchiveSelectInputButton_Click(object sender, RoutedEventArgs e)
        {
            OMD InputSelector = new OMD(TaskType.Archive, OMD_Type.Multi, false);
            InputSelector.ArchiveDumpTab = this;
            InputSelector.archivesubtasktype = ArchiveData.TaskType.Dump;
            InputSelector.Show();
        }

        private void ArchiveLaunchTaskButton_Click(object sender, RoutedEventArgs e)
        {
            SUI.sui.archivedata.Archive_Dump = true;

            CreateDumpTaskk();



        }

        private void CreateDumpTaskk()
        {
  
            var sometask = new TaskTemplate(General.TaskType.Archive);



        }

    }
}
