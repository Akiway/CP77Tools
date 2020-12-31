﻿using ControlzEx.Theming;
using CP77Tools.UI.Data;
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

namespace CP77Tools.UI.Views.Tabs.CR2W
{
    /// <summary>
    /// Interaction logic for AllInfoTab.xaml
    /// </summary>
    public partial class AllInfoTab : UserControl
    {
        public AllInfoTab()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            SUI.sui.cr2wdata.CR2W_All = true; ThemeManager.Current.ChangeTheme(this, SUI.sui.generaldata.ThemeFinder());
            SUI.sui.Cr2wAllInfoTab = this;

        }

        private void ArchiveSelectOutpathButton_Click(object sender, RoutedEventArgs e)
        {
            OMD OutPathSelector = new OMD(TaskType.CR2W, OMD_Type.Single, true);
            OutPathSelector.Title = "Select Outpath";
            OutPathSelector.Cr2wAllInfoTab = this;
            OutPathSelector.cr2wsubtasktype = CR2WData.CR2WTaskType.All;
            OutPathSelector.Show();
        }




        private void ArchiveSelectInputButton_Click(object sender, RoutedEventArgs e)
        {
            OMD InputSelector = new OMD(TaskType.CR2W, OMD_Type.Multi, false);
            InputSelector.Cr2wAllInfoTab = this;
            InputSelector.cr2wsubtasktype = CR2WData.CR2WTaskType.All;
            InputSelector.Show();
        }

        private void ArchiveLaunchTaskButton_Click(object sender, RoutedEventArgs e)
        {
            CreateDumpTaskk();



        }

        private void CreateDumpTaskk()
        {
      
            var sometask = new TaskTemplate(General.TaskType.CR2W);
          


        }
    }
}
