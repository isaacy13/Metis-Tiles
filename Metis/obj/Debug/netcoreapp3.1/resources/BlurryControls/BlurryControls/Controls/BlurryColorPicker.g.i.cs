﻿#pragma checksum "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C160ED156BC4430DF29EB89DB5C387132BF9CC2F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace BlurryControls.Controls {
    
    
    /// <summary>
    /// BlurryColorPicker
    /// </summary>
    public partial class BlurryColorPicker : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image RgbMatrixImage;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas RgbMatrixCanvas;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line YLine;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line XLine;
        
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
            System.Uri resourceLocater = new System.Uri("/Metis;V1.0.0.0;component/resources/blurrycontrols/blurrycontrols/controls/blurry" +
                    "colorpicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
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
            this.RgbMatrixImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.RgbMatrixCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 13 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
            this.RgbMatrixCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RgbMatrixCanvas_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
            this.RgbMatrixCanvas.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.RgbMatrixCanvas_MouseUp);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
            this.RgbMatrixCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.RgbMatrixCanvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
            this.RgbMatrixCanvas.MouseEnter += new System.Windows.Input.MouseEventHandler(this.RgbMatrixCanvas_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\..\..\..\resources\BlurryControls\BlurryControls\Controls\BlurryColorPicker.xaml"
            this.RgbMatrixCanvas.MouseLeave += new System.Windows.Input.MouseEventHandler(this.RgbMatrixCanvas_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YLine = ((System.Windows.Shapes.Line)(target));
            return;
            case 4:
            this.XLine = ((System.Windows.Shapes.Line)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

