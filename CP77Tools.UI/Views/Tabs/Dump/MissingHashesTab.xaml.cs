﻿using System;
using CP77Tools.UI.Data;
using CP77Tools.UI.Data.Tasks;
using CP77Tools.UI.Functionality.Customs;
using CP77Tools.UI.Views.Tasks;
using MahApps.Metro.Controls;
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

namespace CP77Tools.UI.Views.Tabs.Dump
{
    /// <summary>
    /// Interaction logic for MissingHashesTab.xaml
    /// </summary>
    public partial class MissingHashesTab : UserControl
    {
        public MissingHashesTab()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            SUI.sui.dumpdata.Dump_MissingHashes = true;

        }
        private void ArchiveSelectOutpathButton_Click(object sender, RoutedEventArgs e)
        {
            OMD OutPathSelector = new OMD(TaskType.Dump, OMD_Type.Single, true);
            OutPathSelector.Title = "Select Outpath";
            OutPathSelector.DumpMissingTab = this;
            OutPathSelector.dumpsubtasktype = DumpData.DumpTaskType.MissingHashes;
            OutPathSelector.Show();
        }




        private void ArchiveSelectInputButton_Click(object sender, RoutedEventArgs e)
        {
            OMD InputSelector = new OMD(TaskType.Dump, OMD_Type.Multi, false);
            InputSelector.DumpMissingTab = this;
            InputSelector.dumpsubtasktype = DumpData.DumpTaskType.MissingHashes;
            InputSelector.Show();
        }

        private void ArchiveLaunchTaskButton_Click(object sender, RoutedEventArgs e)
        {
            CreateDumpTaskk();



        }

        private void CreateDumpTaskk()
        {
            TabItem NewTask = new TabItem();
            NewTask.Header = "[" + DumpData.DumpTaskType.MissingHashes + " - " + SUI.sui.generaldata.TaskIDGen() + "]";
            var sometask = new TaskTemplate(General.TaskType.Dump);
            sometask.ArchiveTaskConceptGrid.ItemsSource = null; sometask.TaskTitleLabel.Content = "Task : Dump Missing Hashes Task";

            //      sometask.ArchiveTaskConceptGrid.ItemsSource = this.ArchiveTaskConceptGrid.ItemsSource;   // LETS ADD THIS LATER JUST INFO THO 
            sometask.TaskFinalGroup.Header = "Missing Hashes Task Settings";
            sometask.ArchiveSelectedInputConceptDropDown1.ItemsSource = ArchiveSelectedInputConceptDropDown1.ItemsSource;
            NewTask.Content = sometask;
            SUI.sui.generaldata.ToolsInstance.ArchiveSubTab.Items.Add(NewTask);


        }
    }
}
