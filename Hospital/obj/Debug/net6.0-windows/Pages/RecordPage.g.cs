﻿#pragma checksum "..\..\..\..\Pages\RecordPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "567B582E9E05684D68EE2DB18B4EB751262D22A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Hospital.Pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Hospital.Pages {
    
    
    /// <summary>
    /// RecordPage
    /// </summary>
    public partial class RecordPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Pages\RecordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\RecordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDoctors;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\RecordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtp;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\RecordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSchedule;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Pages\RecordPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Hospital;component/pages/recordpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\RecordPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 32 "..\..\..\..\Pages\RecordPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Search);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbDoctors = ((System.Windows.Controls.ComboBox)(target));
            
            #line 59 "..\..\..\..\Pages\RecordPage.xaml"
            this.cmbDoctors.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbDoctors_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtp = ((System.Windows.Controls.DatePicker)(target));
            
            #line 76 "..\..\..\..\Pages\RecordPage.xaml"
            this.dtp.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dtp_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbSchedule = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 97 "..\..\..\..\Pages\RecordPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClickAdd);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 103 "..\..\..\..\Pages\RecordPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClickCancel);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dtg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 108 "..\..\..\..\Pages\RecordPage.xaml"
            this.dtg.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtg_Selected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

