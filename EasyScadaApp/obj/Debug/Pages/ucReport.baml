   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EasyScadaApp.PagesEasyScadaApp.Pages  5      !    EasyScadaApp.Pages.ucReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyScadaApp.Pages     5      .��5	      � $	��922��6   $
��1912��6   $��5q�6%     � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� 
���   �$��2q�6%    �� CornerRadius$ 10��69   $��10q�6K   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'     5      �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� $#��Chọn dữ liệu truy vấn��6   $��30(�68   $
��Bold"�6F   $��Times New Roman)�6X   
��� d �$��8 0 0 0q�5   /   �� 5       -   5         ��Name$ comboboxChon��5    (   $��1��6   $��30(�6>   $��Times New Roman)�6L   $
��Bold"�6i   $��5q�6{   .@�5!      ��  �� 
IsSelected . .��65   Thời gian máy chạy6I   �� 5"      .��6#   Data6)   �� 5#      .��6#   Khối lượng cân 165   �� 5$      .��6#   Khối lượng cân 265   �� 5%      .��6#   Alarm6*   5&      �� 5(      -   5         ��Name$ labItemName��5(   (   $��1��6   $��Chọn máy��6=   $��30(�6P   $
��Bold"�6^   $��Times New Roman)�6p   
��� d �$��8 0 0 0q�5)   /   $y�Visible=�6@   �� 5*      -   5        $ comboboxTenMay��5*   8   $��1��6   $��1��6+   $��30(�6P   $��Times New Roman)�6^   $
��Bold"�6{   $��5,5,0,5q�6�   $
��Left=�5+      $	��368��66   $y�Visible=�6B   .@�5,      �� .��6#   Nghiền thô 161   �� 5-      .��6#   Nghiền thô 261   �� 5.      .��6#   Nghiền tinh60   �� 5/      .��6#   Ép viên 16.   �� 50      .��6#   Ép viên 26.   �� 51       . .��65   
Tất cả6=   53      �� 56      $��2��6   $��Thời Gian Bắt Đầu��6(   $��30(�6D   $
��Bold"�6R   $��Times New Roman)�6d   
��� d �$��8 0 0 0q�57   /   (  "System.Windows.Controls.DatePicker  58      -   5          Name$ datePickerFormDate��58   :   $��2��6   $��1��6-   $��30(�6V   $
��Bold"�6d   $��Times New Roman)�6v   $��5q�59      �� 5;      $��3��6   $��Thời Gian Kết Thúc��6(   $��30(�6E   $
��Bold"�6S   $��Times New Roman)�6e   
��� d �$��8 0 0 0q�5<   /     5=      -   5        $ datePickerToDate��5=   :   $��3��6   $��1��6-   $��30(�6T   $
��Bold"�6b   $��Times New Roman)�6t   $��5q�5>      �� 5@      -   5         ��Name$ 
btnTruyVan��5@   )   $��4��6   $��
Truy Vấn��6=   $��30(�6P   $
��Bold"�6^   $��Times New Roman)�6p   
��� d �$��	10,5,10,5q�5A   ,   6?   �� 5B      -   5        $ 	btnExport��5B   6   $��4��6   $��1��6)   $��Xuất Excel��6I   $��30(�6^   $
��Bold"�6l   $��Times New Roman)�6~   
��� d �$��	10,5,10,5q�5C   ,   $	��Top=�6W   5D      5E      �� 5G   
   
���   �$��2q�6%   $ 10��69   $��1��6K   $��10q�6X   ._�5H      �� $
��Auto=�6   $��Visible=�5I      $��3��6C   $��
8,22,12,-2q�6W   .��5J      �� $��10q�6   .+�5K      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5K   ;   $
��Left=�6   $	��Top=�6N   
�������	   RowBackground
	 �����
   AlternatingRowBackground

 ��ح�$��4q�5M         CanUserResizeColumns . $   HorizontalScrollBarVisibility$ Visible=�6>   "   VerticalScrollBarVisibility$ Visible=�5N      $��20(�6>   $
��Bold"�6L   5O      5P      5Q      5R      5S      