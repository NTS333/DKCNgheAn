   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EasyScadaAppEasyScadaApp  5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5          EasyScadaApp.ThongTinCan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EasyScadaApp     5      YcontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5      $	��100��5      $	��250��6   .��5      ��   �� Padding$  4q�6   
�������._�5   
   �  � ShowGridLines .   � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      � $��0��6   $��0��6    $��Stretch=�60   $��2��6N   
����·�$��2q�6w   .+�5      �� -   5         ��Name$ lbHeader��5      $��KHỐI LƯỢNG CÂN��5      $��Center=�5      $��15(�5      $��Times New Roman)�6&   $
��Bold"�6C   
���   �6U   5      � 5"      $��1��6   $��0��6    $��2q�60   .+�5#      �� $��Cân 1��6   $��15(�5$      $��Times New Roman)�6&   $
��Bold"�6C   
���   �6U   5&      � 5'      $��1��6   $��1��6    
���   �$��2q�6C   .+�5(      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5)      &   EasyScada.Wpf.Controls.EasyLabel  -   5          Name$ klCan1��5)   )   $��0��69   $��Right=�6E   $��15(�5*   )   $��Times New Roman)�67   $
��Bold"�6T   
���  ��5,      �� 5-      $��Kg��6   $��Right=�6)   $��15(�5.      $��Times New Roman)�6*   $
��Bold"�6G   
���  ��50      51      52      � 55      $��2��6   $��0��6    $��2q�60   .+�56      �� $��Cân 2��6   $��15(�57      $��Times New Roman)�6&   $
��Bold"�6C   
���   �6U   59      � 5:      $��2��6   $��1��6    
���   �$��2q�6C   .+�5;      �� $ 
Horizontal=�6   $��Right=�66   .+�5<        -   5        $ klCan2��5<   )   $��0��69   $��Right=�6E   $��15(�5=   )   $��Times New Roman)�67   $
��Bold"�6T   
���  ��5?      �� 5@      $��Kg��6   $��Right=�6)   $��15(�5A      $��Times New Roman)�6*   $
��Bold"�6G   
���  ��5C      5D      5E      5F      5H      5I      