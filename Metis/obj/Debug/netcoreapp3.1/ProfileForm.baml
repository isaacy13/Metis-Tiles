   M S B A M L   `   `   `  ����@  <Metis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MetisMetis  5   	       Metis.ProfileForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Metis     5   	   D @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   -   5          ModernWpf.ThemeManager    RequestedTheme$  Light=�5	   	   $��Light"�5
   	    � Title$ ProfileForm��5   	   $	��500��6   $	��400��6*   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��1* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $��0.45* �6   �� 5      $��0.05* �6   �� 5      $
��0.2* �6   �� 5      $��0.05* �6   �� 5      $��1* �6   �� 5      $��0.25* �6   .+�5%   
   �� $
��32px(�6   $��1��5&      $��1��5'      
���   ���5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � �� �� Value$ Center=�6<   �� 5,       � ��$ Center=�6:   5-      $��Create a New Profile��51      52      �� 54   
   $��3��6   $��1��6"   .+�55      �� -   5        $��newProfileName��55      
���   �
�������
���   �$��1q�59      $��0 5 0 10q�5:      $��18(�5;      .��6$   	Profile5=      �� 5>      -   5        
����� �.��5?   0   Submit68   5@      �� 5B   
   $
��32px(�6   $��5��6$   $��1��61   ��5C      �� 5D      " ��6   .�5E      ��  � ��$ Center=�6<   �� 5F       � ��$ Center=�6:   �� 5G       � ��
 �   �63   5H      $��Edit Profile(s)��5L      5M      �� 5O   
   $��7��6   $��1��6$   .��5P      �� -   5         ��Name$ ProfileEditListView��5P      $��16(�5Q      5R      �� 5S   
   -   5        $��8��5S      $��1��6   
���\\��.��5U   $   Remove Selected Profile(s)6@   5V      5W      