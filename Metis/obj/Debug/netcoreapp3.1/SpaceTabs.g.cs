#pragma checksum "..\..\..\SpaceTabs.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0D22C700F5458B01F4F5E362D850719D2BCB3287"
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
    /// SpaceTabs
    /// </summary>
    public partial class SpaceTabs : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\SpaceTabs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border backgrnd;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SpaceTabs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TintOverlay;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\SpaceTabs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SpaceName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\SpaceTabs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewSpaceName;
        
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
            System.Uri resourceLocater = new System.Uri("/Metis;component/spacetabs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SpaceTabs.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 9 "..\..\..\SpaceTabs.xaml"
            ((Metis.SpaceTabs)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SpaceTabs_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backgrnd = ((System.Windows.Controls.Border)(target));
            
            #line 13 "..\..\..\SpaceTabs.xaml"
            this.backgrnd.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MouseEnter);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\SpaceTabs.xaml"
            this.backgrnd.MouseLeave += new System.Windows.Input.MouseEventHandler(this.MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TintOverlay = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            
            #line 36 "..\..\..\SpaceTabs.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeIcon);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SpaceName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 55 "..\..\..\SpaceTabs.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RenameSpaceTab);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 56 "..\..\..\SpaceTabs.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteSpaceTab);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NewSpaceName = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

