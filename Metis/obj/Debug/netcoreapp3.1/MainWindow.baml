   M S B A M L   `   `   `  ����@  <Metis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MetisMetis  5   	   E AFluentWPF, Version=0.10.0.3, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5   	       Metis.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Metis     5   	   Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5   	   D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   T	 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls 	 5   	   -   5          �Name$  TilesMainWindow��5   	   )  #SourceChord.FluentWPF.AcrylicWindow   Enabled$
 True��5   	      FallbackColor$ DarkSlateGray��5	   	      MaterialDesignBody#���   5
   	     ModernWpf.ThemeManager   RequestedTheme$ Light=�5   	    � Icon$ logo.ico��5   	    � Title$ Tiles��6   $	��600��5   	   $
��1080��6   $	��775��6#   $	��500��62    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   %    5      .��5      � -   5        	 �Name$	 MainGrid��5      
�������
 � DataContext
 61   ��  �� ElementName$ TilesMainWindow�� �� Path$ .� � ColumnDefinitions 5   
   �� 5       $
��2.5* �6   $��200px��6,   $��225px��6>   �� 5"      $��6* �6   $	��400��6*   �� 5#      $��2* �6   $	��200��6*   .+�5(   
   � $��0��6   .+�5)      �� .��5*      �  � RowDefinitions 5,      �� 5-      $��1* �6(   $
��60px��64   �� 5.      $��9* �6(   .+�51      �� $��0��6   6,      Metis.Profile  58      $��0��6$   $��5q�61      Text$ USERNAME��6<   $� 5<      $��1��6-   .+�5>      �  5?      �� 5@   "   $
��0.1* �60   �� 5A   "   $��1* �60   �� 5B   "   $
��0.1* �60   .+�5F      �� $��1��6)   .+�5H   "   �� -   5         ��Name$ ProfileDropDownList��5H   +    " MaterialDesignOutlinedComboBox#���  5J   +   
���   �$��3 3 3 15q�5L   +   $��5q�5M   +   $��16(�5N   +   5O   #   5P      5Q      $� 5U      -   5         $�Name$ SpacesSection��5U   <   $��0q�61   6<   �� 5Y      -   5        $
��24px(�5Y   !   $
��75px��5Z   !   $��Heavy"�5[   !     MaterialDesignFlatButton#���  5]   !   $��7 0 7 0q�5^   !   .��62   +5`      5b      5d      5e      5f      &   System.Windows.Controls.DataGrid  5j   
   -   5          Name$ 	TaskTable��5j      $��1��5l         AutoGenerateColumns$ false��5m      $   HorizontalScrollBarVisibility$ Visible=�5o      "   VerticalScrollBarVisibility$ Visible=�5p      $
��Left=�5q      ��5n      �� *
TaskList+ � ContextMenu 5t      �� 5u      .@�5v      m� -   5        $��
Delete Row��5v      5w      5x         Columns 5z      0  *System.Windows.Controls.DataGridTextColumn  5{      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Task Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5|   )      MinWidth$	 105Q�5}   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5~   )   �� *
TaskName+   ElementStyle 5      �� 5�      .�5�      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5�       �@��Padding$ 5q�6B   �� 5�       � ��$ SemiBold"�6E   5�         EditingElementStyle 5�      �� 5�      .�5�      ��  � ��$
 Wrap=�6G   �� 5�       �@��Padding$ 5q�6B   �� 5�       � ��$ SemiBold"�6E   5�      5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $ Due Date��6)   $ 1* 5�   )   $	 150Q�5�   )     	  CellTemplate  5�      �� 5�      .R�5�      �� ! �� Padding$! 5q�5�   (   ��5�   (   �� *	DueDate+5�   (   5�      " 	  CellEditingTemplate" 5�      �� 5�      .R�5�      +
 	 %MahApps.Metro.Controls.DateTimePicker
  # 
 Name$# DueDatePicker��61   + 	 %MahApps.Metro.Controls.TimePickerBase$   SelectedDateTime$ 5�   1   �� *	DueDate+5�      5�        5�      $ Notes��6%   $ 4* 5�   )   $	 160Q�5�   )    5�   )   �� *Notes+ 5�      �� 5�      .�5�      ��  � ��$
 Wrap=�6G   �� 5�       �@��Padding$ 5q�6B   5�       5�      �� 5�      .�5�      ��  � ��$
 Wrap=�6G   �� 5�       �@��Padding$ 5q�6B   5�      5�      5�      � 5�   
   $��2��6    5�      �� 5�      $
��0.8* �6    $��35��6.   �� 5�      $��9* �6    �� 5�      $
��0.6* �6    .+�5�      �� $��Others in {SpaceName}��6   $��Center=�5�      $��18(�5�      $��5q�5�      �� 5�      $��1��6   $��	15 0 15 0q�6(   $��Visible=�6;   .��5�      �� .@�5�        �� 5�      -   5        $��
➕ Invite��5�      
����  �% � Cursor$
% Hand��5�      $��Right=�5�      5�      5�      5�      �� 5�      -	   5        $��3��5�      $��Bottom=�5�      $��Right=�5�      $��Bottom=�5�      $	��⚙��5�      5�      5�      5�      