   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EasyScadaAppEasyScadaApp  5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5      !    EasyScadaApp.GiuBuiTrungTam   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EasyScadaApp     5      YcontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5      -   5          >�Name$
  host��5      $	��250��5
      $	��160��6   .��5      ��  �� Padding$ 4q�6   
�������._�5   
   �  �� Left$
 1597��6   
 �� Top$	 174��6"    � ShowGridLines .   � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      � $��0��6   $��Stretch=�6    $��2��6>   
����·�$��2q�6g   .+�5      �� $��GIŨ BỤI TRUNG TÂM��6   $��Center=�64   $��Center=�5      $��15(�5      $��Times New Roman)�6&   $
��Bold"�6C   
���   �$��0,0,0,-5q�6h   5       5!      � 5$      $��1��6   $��0��6    $��Right=�60   
�������$	��100��6_   $��2q�6k   .+�5%      �� $
��AUTO��6   $��Stretch=�6'   $��Stretch=�6E   $��Center=�6a   $��Center=�6�   $��15(�5&      $��Times New Roman)�6&   $
��Bold"�6C   
���   ���5'      �� 5(       �� 
TargetType" ��6    .�5)      ��  �� Property � ��	 �� Value
	 �����6;   
 �� Triggers
 5*      �� 5+   "    �� Binding 6.   ��  �� ElementName$
 host�� �� Path$
 Auto� �� Value 16]   .a�5,   &   ��  � ��
	 � � �6C   5-   #   �� 5/   "    6.   �� $
 host��$
 Auto� 06]   .a�50   &   ��  � ��
	 �����6C   51   #   53      55      56      � 57      $��1��6   $��1��6    $��Center=�60   
�������$	��100��6`   $��2q�6l   .+�58      �� $��MANUAL��6   $��Stretch=�6)   $��Stretch=�6G   $��Center=�6c   $��Center=�6�   $��15(�59      $��Times New Roman)�6&   $
��Bold"�6C   ��5:      �� 5;      " ��6    .�5<      ��  � ��
	 �����6;   
 5=      �� 5>   "    6.   �� $
 host��$ Manual� 16_   .a�5?   &   ��  � ��
	 � � �6C   5@   #   �� 5B   "    6.   �� $
 host��$ Manual� 06_   .a�5C   &   ��  � ��
	 �����6C   5D   #   5F      5H      5J      � 5M      $��2��6   $��0��6    $
��Left=�60   $��2q�6K   .+�5N      �� $��Motor quạt hút��6   $��Center=�61   $��Center=�6U   $��15(�5O      $��Times New Roman)�6&   $
��Bold"�6C   
���   �5Q      5R      � 5S      $��2��6   $��1��6    $��Right=�60   
���   �$	��100��6_   $��2q�6k   .+�5T      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5U      &   EasyScada.Wpf.Controls.EasyLabel  -   5          Name$ motorQuatHut��5U   )   $��0��6?   $��Right=�6K   $��Center=�6h   $��Center=�6�   $��15(�5V   )   $��Times New Roman)�67   $
��Bold"�6T   
���  ��5X      �� 5Y      $��A��6   $��Right=�6(   $��Center=�6D   $��Center=�6h   $��15(�5Z      $��Times New Roman)�6*   $
��Bold"�6G   
���  ��5\      5]      5_      5`      5b      5c      