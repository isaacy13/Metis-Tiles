   M S B A M L   `   `   `  ����@  <Metis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MetisMetis  5   	       Metis.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Metis     5   	   D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $��LoginRegisterWindow��5   	     ModernWpf.ThemeManager    RequestedTheme$  Light=�5
   	    � Title$ LoginWindow��5   	   $	��500��6   $	��600��6*   $	��600��66   $	��860��6F    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   �� 5      $k epack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PasswordBox.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��500��6   �� 5      $	��560��6    � RowDefinitions 5   
   �� 5      $��1* �6   $	��100��6(   �� 5      $��3* �6   $	��400��6(   �� 5      $��1* �6   $	��100��6(   .+�5    
   �� $��3��6   ��5!      
� 5"       
� GradientOrigin$ -1 -1&�6&   .��5#      �  � Color$ White��6#   	 � Offset$	 0Q�61   � 5$      $ 	SteelBlue��6#   $	 1Q�65   5%      5'      (� 5)   
   $��Center=�6   $��1��5*      $	��250��5+      $	��300��6!   $	��250��5,      $	��300��6"   $��20q�5-      .��5.      �� $��resources/logo.png��6   5/      �� 51   
   $��1��6   $��3��6%   $��Center=�52      
 � DataContext
 53      ��  �� ElementName$ LoginRegisterWindow�� �� Path$ .� 55       �� 
TargetType %  !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value J� Opacity��%W  '��       7   �� 56      " ��6   8   .�57      ��  �@=�ErrorTemplate 58      �� 59      .R�5:   "   �� .+�5;   &   �� 
���  ��$	 0.8Q�5=   $   ��5;   0   �� *ErrorContent+5=   $   �� 5>   &   
���  ��$��1q�6?   ._�5?   *   �� $��AdornedElement��6D   5@   '   5A   #   5B      5D      5E      5G      .+�5I      (� $
��Left=�6   $	��600��5J      $��	25 0 25 0q�5K      .��5L      �� $��Welcome back to Tiles��6   $��	SansSerif)�5M      $��SemiBold"�5N      $��Bottom=�5O      5P      (� 5R      $
��Left=�6   $	��400��5S      $��	25 0 25 0q�5T      .��5U      �� $%��Get back to work by signing in.��6   $��	SansSerif)�5V      5W      �� 5Y       �� Orientation$ 
Horizontal=�6   $��25 20 25 20q�5Z      .+�5[      �� -   5        $��GoogleButton��5\      
�������$	��250��5^      $��50��5_       � Cursor$
 Hand��5`      .��5b      �� $ 
Horizontal=�6!   .+�5c      �� $,��&resources/google_logo_70downscaled.png��6    �� 5d      -   5        $��GoogleButtonText��5d   $   $��LOGIN WITH GOOGLE��5e   $   $��10 0 0 0q�5f   $   $��16(�5g   $   $��Center=�5h   $   5i      5j      �� 5l      -   5        $��AppleButton��5m      $	��250��5n      $��50��5o      $��10 0 0 0q�5p      $
 Hand��5q      $��LOGIN WITH APPLE��5s      ��5t      �� 5u      " ��6    .�5v      ��  � ��
 �   �6;   �� 5w       � �� 5x   "   �� 5y   &    �� 
TargetType" ��66   .R�5z   *   �� #��z��61   
���   �$��1q�6o   ._�5{   .   �� $ 
Horizontal=�69   .+�5|   2   �� $��	AppleLogo��68   $+��%resources/apple_logo_70downscaled.png��6I   �� 5}   2   $��LoginToAppleText��6<   #��z��5~   <   $��16(�5   <   $��5 0 0 0q�5�   <   $��Center=�5�   <   
�������5�   <   5�   /   5�   +    �� Triggers 5�   *   P� 5�   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5�   2   ��  �� 
TargetName$ LoginToAppleText��69    � ��
 �   �6m   �� 5�   2   $ 	AppleLogo��69    � ��$4 .resources/inverted_apple_logo_70downscaled.png��6b   5�   /   5�   '   5�       �� Triggers 5�      P� 5�   "    �@J�IsMouseOver$
 True��6A   . �5�   &   ��  � ��
 �����6C   5�   #   5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��
25 10 0 10q�5�      
 5�      �� $ LoginRegisterWindow��$ .�.+�5�      �� -   5        $��FirstNameTextBox��5�      $y�	Collapsed=�5�      )  #MaterialDesignThemes.Wpf.HintAssist   FloatingScale$	 0.9Q�5�         
IsFloating$
 True��5�         Hint$ 
First Name��5�      
���   �
�������
�������$��1q�5�      $	��250��5�      .��6$   ��5�      �� 5�      $ 	FirstName�6"    �� ValidationRules 5�        Metis.ValidNameRule  5�   "   5�      .��5�   $   5�      �� 5�      -   5        $��LastNameTextBox��5�      $y�	Collapsed=�5�      $	 0.9Q�5�      $
 True��5�      $ 	Last Name��5�      
���   �
�������
�������$��1q�5�      $��10 0 0 0q�5�      $	��250��5�      .��6$   ��5�      �� 5�      $ LastName�6"    5�        5�   "   5�      .��5�   $   5�      5�      �� 5�      $	 0.9Q�5�      $
 True��5�      $ Email��5�      
���   �
�������
�������$
��Left=�5�      $��1q�5�      $��	25 0 0 10q�5�      $	��510��5�      .��6$   ��5�      �� 5�      $ Email�6    5�        Metis.ValidEmailRule  5�      5�      .��5�       5�      �� 5�      -   5        $��PWDBOXBorder��5�      ._�5�      G� -   5        $��PasswordBox��5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      $	 0.9Q�5�      $
 True��5�      $ Password��5�      
���   �
�������
�������$
��Left=�5�      $��1q�5�      $��	25 0 0 10q�5�      $	��510��5�      5�      �� 5�      -	   5        $��PWDConfirmBOXBorder��5�      ._�5�      G� -
   5        $��PasswordConfirmBox��5�      #��[ 5�      $y�	Collapsed=�5�      $	 0.9Q�5�      $
 True��5�      $ Confirm Password��5�      
���   �
�������
�������$
��Left=�5�      $��1q�5�      $��25 0 0 0q�5�      $	��510��5�      5�      �� 5�      -   5        $��LoginRegisterButton��5      $��LOGIN WITH EMAIL��5     
����·�$	��175��5     $��30��5     $��	25 25 0 0q�5     $
 Hand��5     5     �� 5	     -   5        $ ��Don't have an account yet?��5	     
����  �$��	25 10 0 0q�5     $��1��5     $��2��5     $
 Hand��5     ��5     �� 5     " ��6    5     P� 5      �@J�IsMouseOver$
 True��6=   . �5  "   ��  � ��$ 	Underline{�6D   5     5     5     5     5     5     