   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EasyScadaAppEasyScadaApp  5   	   7 clr-namespace:EasyScadaApp.PagesEasyScadaApp.Pages  5   	       EasyScadaApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EasyScadaApp     5   	   2Pages clr-namespace:EasyScadaApp.Pages     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5   	   $
��1080��6   $
��1920��6*    � WindowStyle$
 None=�67    � WindowState$ 	Maximized=�6J    � WindowStartupLocation$ CenterScreen=�5       � Icon$ LogoIco.ico��6*    � 
ResizeMode$ CanMinimize=�6=   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��49* �6#   �� 5      $
��760* �6#   �� 5      $
��121* �6#   .+�5      � 
���   �.+�5      �� $��0��6   $	��100��6(   $��/Image/Logo.png��64   $
��Fill=�6M   $
��Left=�6\   5      � 5!      
���   �$��2��6&   $��	101,0,0,0q�6:    5"      �� 5#      $��0* �6'   �� 5$      .+�5&      �� $F��@NHÀ MÁY VIÊN NÉN NĂNG LƯỢNG BẢO CHÂU PHÚ YÊN - MAIN��6   $��40(�5'      $��Times New Roman)�6&   $
��Bold"�6C   
������$��Center=�5(      $��Center=�65   $��2��6P   $��154,27,67,27q�6d   $��46��6z   $
��1348��6�   5)      � 5+      $��2��6   
�������.+�5,      �� $	��242��6   $��/Image/logoPQ.jpg��6$   $
��Fill=�6?   $��Right=�6N   5-      5.      � 5/   
   $��1��6   
�������.+�51      (   "EasyScadaApp.Pages.ucNghienThoTinh  -   5          Name$ 	NghienTho��51   $   $y�Visible=�67   /   )EasyScadaApp.Pages.ucKhoNghienTinh_GiuBui  52      -   5        	  Name$	 KhoNghienTinhGiuBui��52   +   $y�Hidden=�6H   !   EasyScadaApp.Pages.ucReport  53      -   5        
  Name$
 Report��53      $y�Hidden=�6-   56      � 58   
   $��2��6   
���   � 59      �� 5:      $
��auto �6#   �� 5;      $��* �6#   �� 5<      $
��auto �6#   .+�5?      �� -   5         ��Name$ labThoiGian��5?      $��10,0,0,0q�6)   $��Right=�5@      $��dd/MM/yyyy HH:mm:ss��5A      $��Right=�5B      $��Center=�5C      $��20(�5D      $��Times New Roman)�6"   $
��Bold"�6?   
�������6Q   �� 5G      $��2��6    �� Orientation$ 
Horizontal=�6)   .+�5H      �� -   5         ��Name$ btnMayNghien��5H      $��8 0 0 0q�6/   $��Trang 1��6@   $	��130��6m   $��20(�6y   $��50��6�   $	��Top=�6�   �� 5I      -   5        $ btnKhoNghienTinhGiuBui��5I      $��8 0 0 0q�69   $��Trang 2��6J   $	��130��6\   $��20(�6h   6v   �� 5J      -   5        $ 	btnReport��5J      $��8 0 0 0q�6,   $��	Báo cáo��6=   $	��130��6O   $��20(�6[   6i   �� 5K      -   5        $ btnChart��5K      $��8 0 0 0q�6+   $��Biểu đồ dòng��6<   $	��130��6S   $��20(�6_   6m   �� 5L      -	   5        $ 
btnChartTS��5L      $��8 0 0 0q�6-   $��Biểu đồ tần số��6>   $	��130��6W   $��20(�6c   6q   �� 5M      -
   5        $ btnExit��5M      $��8 0 0 0q�6*   $��Thoát��6;   $	��100��6L   $��20(�6X   6f   5N      5O      5Q      5R      