﻿#pragma checksum "..\..\Admin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A6741D0C21D4D0E0F1850D2A81E9EA34"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using tab_control;


namespace tab_control {
    
    
    /// <summary>
    /// Admin
    /// </summary>
    public partial class Admin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SuprimerMembre;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ParentsBDD;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BabysitterBDD;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/tab_control;component/admin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Admin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SuprimerMembre = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Admin.xaml"
            this.SuprimerMembre.Click += new System.Windows.RoutedEventHandler(this.SuprimerMembre_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ParentsBDD = ((System.Windows.Controls.DataGrid)(target));
            
            #line 45 "..\..\Admin.xaml"
            this.ParentsBDD.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionItem_Click);
            
            #line default
            #line hidden
            
            #line 46 "..\..\Admin.xaml"
            this.ParentsBDD.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.ParentsBDD_CellEditEnding_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BabysitterBDD = ((System.Windows.Controls.DataGrid)(target));
            
            #line 66 "..\..\Admin.xaml"
            this.BabysitterBDD.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BabysitterBDD_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 67 "..\..\Admin.xaml"
            this.BabysitterBDD.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.BabysitterBDD_CellEditEnding);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

