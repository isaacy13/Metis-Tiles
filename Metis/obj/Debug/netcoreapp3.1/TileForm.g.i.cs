﻿#pragma checksum "..\..\..\TileForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DF1BE591A48BFBA60A8450FC497010625243C25"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Metis;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
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


namespace Metis {
    
    
    /// <summary>
    /// TileForm
    /// </summary>
    public partial class TileForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\TileForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskName;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\TileForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DueDate;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\TileForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Notes;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\TileForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Metis.WrapPanelItem TilePreview;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Metis;component/tileform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TileForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TaskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DueDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Notes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TilePreview = ((Metis.WrapPanelItem)(target));
            return;
            case 5:
            
            #line 88 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 92 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 96 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 100 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 104 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 108 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 112 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 116 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 120 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 124 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 135 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 146 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 157 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 168 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 179 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 190 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 201 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 212 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.StackPanel)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UpdateTilePreview);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 245 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 249 "..\..\..\TileForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FinishClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

