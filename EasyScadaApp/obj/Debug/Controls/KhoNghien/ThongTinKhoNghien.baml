   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EasyScadaAppEasyScadaApp  5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5      $    EasyScadaApp.ThongTinKhoNghien   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EasyScadaApp     5      YcontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5      -   5          >�Name$
  host��5      $	��250��5
      $	��190��6   .��5      (� .��5   
   ��  �� Padding$ 4q�6   
�������._�5      �  �� Left$	 127��6   
 �� Top$ 20��6%   
������� � ShowGridLines .   � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      � $��0��6   $��Stretch=�6$   
����·�$��2q�6W   .+�5      �� -   5         ��Name$ lbHeader��5      $��KHO NGHIỀN THÔ��5      $��Center=�5      $��Center=�6<   $��15(�5       $��Times New Roman)�6&   $
��Bold"�6C   
���   �5!      5"      � 5%      $��1��6   $��Stretch=�6$   
�������$��2q�6U   .+�5&      �� $
��AUTO��6   $��Center=�5'      $��Center=�6@   $��15(�5(      $��Times New Roman)�6&   $
��Bold"�6C   
���   ���5)      �� 5*       �� 
TargetType" ��6$   .�5+   "   ��  �� Property � ��	 �� Value
	 �����6?   
 �� Triggers
 5,   "   �� 5-   &    �� Binding 62   ��  �� ElementName$
 host�� �� Path$
 Auto� �� Value 16a   .a�5.   *   ��  � ��
	 � � �6G   5/   '   �� 51   &    62   �� $
 host��$
 Auto� 06a   .a�52   *   ��  � ��
	 �����6G   53   '   55      57      58      � 59      $��2��6   $��Stretch=�6$   
�������$��2q�6U   .+�5:      �� $��MANUAL��6   $��Center=�5;      $��Center=�6A   $��15(�5<      $��Times New Roman)�6&   $
��Bold"�6C   
���   ���5=      �� 5>      " ��6$   .�5?   "   ��  � ��
	 �����6?   
 5@   "   �� 5A   &    62   �� $
 host��$ Manual� 16c   .a�5B   *   ��  � ��
	 � � �6G   5C   '   �� 5E   &    62   �� $
 host��$ Manual� 06c   .a�5F   *   ��  � ��
	 �����6G   5G   '   5I      5K      5M      � 5N      $��3��6   $��Stretch=�6$   
�������$��2q�6U   .+�5O      �� $��CHẾ ĐỘ 3��6   $��Center=�5P      $��Center=�6@   $��15(�5Q      $��Times New Roman)�6&   $
��Bold"�6C   
���   ���5R      �� 5S      " ��6$   .�5T   "   ��  � ��
	 �����6?   
 5U   "   �� 5V   &    62   �� $
 host��$ CheDo3� 16c   .a�5W   *   ��  � ��
	 � � �6G   5X   '   �� 5Z   &    62   �� $
 host��$ CheDo3� 06c   .a�5[   *   ��  � ��
	 �����6G   5\   '   5^      5`      5a      5b      5c      5d      5e      