#pragma checksum "..\..\..\WrapPanelItemResizeOverlay.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EA22AE829DFE34DD844B3338A6F55ADE513EC632"
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
    /// WrapPanelItemResizeOverlay
    /// </summary>
    public partial class WrapPanelItemResizeOverlay : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\WrapPanelItemResizeOverlay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SquareButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\WrapPanelItemResizeOverlay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HorziontalRectangleButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\WrapPanelItemResizeOverlay.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VerticalRectangleButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Metis;V1.0.0.0;component/wrappanelitemresizeoverlay.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WrapPanelItemResizeOverlay.xaml"
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
            this.SquareButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\WrapPanelItemResizeOverlay.xaml"
            this.SquareButton.Click += new System.Windows.RoutedEventHandler(this.OnClicktoSquare);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HorziontalRectangleButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\WrapPanelItemResizeOverlay.xaml"
            this.HorziontalRectangleButton.Click += new System.Windows.RoutedEventHandler(this.OnClicktoHorizontalRectangle);
            
            #line default
            #line hidden
            return;
            case 3:
            this.VerticalRectangleButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\WrapPanelItemResizeOverlay.xaml"
            this.VerticalRectangleButton.Click += new System.Windows.RoutedEventHandler(this.OnClicktoVerticalRectangle);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

