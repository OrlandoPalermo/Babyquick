﻿#pragma checksum "..\..\Admin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FF42CD66AA6909008479641923802389"
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
        
        
        #line 35 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SuprimerMembre;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl bddAdmin;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ParentsBDD;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nonActif;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tousBaby;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BabysitterBDD;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid IntermediaireBDD;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock headerIden;
        
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
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 35 "..\..\Admin.xaml"
            this.SuprimerMembre.Click += new System.Windows.RoutedEventHandler(this.SuprimerMembre_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bddAdmin = ((System.Windows.Controls.TabControl)(target));
            return;
            case 3:
            
            #line 44 "..\..\Admin.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TabItem_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ParentsBDD = ((System.Windows.Controls.DataGrid)(target));
            
            #line 47 "..\..\Admin.xaml"
            this.ParentsBDD.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionItem_Click);
            
            #line default
            #line hidden
            
            #line 48 "..\..\Admin.xaml"
            this.ParentsBDD.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.ParentsBDD_CellEditEnding_1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 64 "..\..\Admin.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TabItem_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nonActif = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\Admin.xaml"
            this.nonActif.Click += new System.Windows.RoutedEventHandler(this.nonActif_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tousBaby = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Admin.xaml"
            this.tousBaby.Click += new System.Windows.RoutedEventHandler(this.tousBaby_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BabysitterBDD = ((System.Windows.Controls.DataGrid)(target));
            
            #line 83 "..\..\Admin.xaml"
            this.BabysitterBDD.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BabysitterBDD_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 84 "..\..\Admin.xaml"
            this.BabysitterBDD.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.BabysitterBDD_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 100 "..\..\Admin.xaml"
            ((System.Windows.Controls.TabItem)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TabItem_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.IntermediaireBDD = ((System.Windows.Controls.DataGrid)(target));
            
            #line 104 "..\..\Admin.xaml"
            this.IntermediaireBDD.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.IntermediaireBDD_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 105 "..\..\Admin.xaml"
            this.IntermediaireBDD.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.IntermediaireBDD_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 11:
            this.headerIden = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

