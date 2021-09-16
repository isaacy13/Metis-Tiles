using ModernWpf.Controls;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        /* Overriding TextProperty */
        // changes dependency property of Profile's textblock
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            "Text",
            typeof(String),
            typeof(Profile),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnTextChanged)
            )
        );

        /* Change color of profile's text */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            foreach (object ob in LogicalTreeHelper.GetChildren(d))
                if (ob is StackPanel)
                {
                    ((TextBlock)(((StackPanel)ob).FindName("ProfileName"))).Text = (String)e.NewValue;
                    break;
                }
        }

        /* Overriding Text */
        // changes text of textblock in Panel Item
        public string Text
        {
            get { return (String)ProfileName.Text; }
            set { ProfileName.Text = value; }
        }

        /* Overriding ProfilePictureProperty */
        // changes dependency property of Profile's pfp
        public static readonly DependencyProperty ProfilePictureProperty =
        DependencyProperty.Register(
            "ProfilePicture",
            typeof(ImageSource),
            typeof(Profile),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnProfilePictureChanged)
            )
        );

        /* Changes pfp */
        // Called BOTH when property changed via XAML AND programatically
        private static void OnProfilePictureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            foreach (object ob in LogicalTreeHelper.GetChildren(d))
                if (ob is PersonPicture)
                {
                    ((PersonPicture)(((StackPanel)ob).FindName("pfp"))).ProfilePicture = (ImageSource)e.NewValue;
                    break;
                }
        }

        /* Overriding ProfilePicture */
        public ImageSource ProfilePicture
        {
            get { return pfp.ProfilePicture; }
            set { pfp.ProfilePicture = value; }
        }

        public Profile()
        {
            InitializeComponent();
        }
    }
}
