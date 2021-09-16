using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Metis
{
    /// <summary>
    /// Interaction logic for PopupConfirm.xaml
    /// </summary>
    public partial class PopupConfirm : UserControl
    {
        public SpaceTabs SpaceTabParent { get; set; }

        public string PopupText { 
            get => PromptText.Text;
            set { PromptText.Text = value; }
        }

        public string PopupHeader
        {
            get => PromptHeader.Text;
            set { PromptHeader.Text = value; }
        }

        public PopupConfirm(string popupHeader, string popupText)
        {
            InitializeComponent();
            PopupHeader = popupHeader;
            PopupText = popupText;
        }

        /* PopupHeader */
        // dependency property
        public static readonly DependencyProperty PopupHeaderProperty =
        DependencyProperty.Register(
            "PopupHeader",
            typeof(String),
            typeof(PopupConfirm),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnPopupHeaderChanged)
            )
        );

        /* On PopupHeader change */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnPopupHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PopupConfirm)d).PopupHeader = (String)e.NewValue;
        }

        /* PopupText */
        // dependency property
        public static readonly DependencyProperty PopupTextProperty =
        DependencyProperty.Register(
            "PopupText",
            typeof(String),
            typeof(PopupConfirm),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnPopupTextChanged)
            )
        );

        /* On PopupText change */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnPopupTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PopupConfirm)d).PopupText = (String)e.NewValue;
        }

        private void Close_Click(object sender, RoutedEventArgs e) { ((MainWindow)((SpaceTabs)this.SpaceTabParent).Owner).MainGrid.Children.Remove(this); }

        private void Confirm_Click(object sender, RoutedEventArgs e) { 
            // delete from db
            SpaceTabParent.DBDeleteSpaceTab(this, null);
            // close prompt
            Close_Click(null, null);
            // update spaces tabs
            ((MainWindow)((SpaceTabs)this.SpaceTabParent).Owner).loadSpaces();
        }
    }
}
