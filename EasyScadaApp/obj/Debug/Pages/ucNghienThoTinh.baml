   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EasyScadaAppEasyScadaApp  5      7 clr-namespace:EasyScadaApp.PagesEasyScadaApp.Pages  5      I EWPFUserControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:WPFUserControl;assembly=WPFUserControlWPFUserControl 5      (    "EasyScadaApp.Pages.ucNghienThoTinh   5      +EasyScadaAppclr-namespace:EasyScadaApp  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyScadaApp.Pages     5      OWPFUserControl4clr-namespace:WPFUserControl;assembly=WPFUserControl     5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      .��5      �� .+�5   
   �� 6   �� 5   
   -   5        $��labMayNghienTho1��5      $��MÁY NGHIỀN THÔ 1��5      $��Center=�5      $��Center=�5      $��20(�5      $��Times New Roman)�6   $
��Bold"�6;   
���   �
 �� Top$ 10��6`   �� 5   
   -   5        $��labMayNghienTho3��5      $	 280��6(   $��MÁY NGHIỀN THÔ 3��5      $��Right=�5      $��Center=�5      $��20(�5      $��Times New Roman)�6   $
��Bold"�6;   
���   �6M   �� 5   
   -   5        $��labMayNghienTho2��5      $��MÁY NGHIỀN THÔ 2��5       $��Center=�5!      $��Center=�5"      $��20(�5#      $��Times New Roman)�6   $
��Bold"�6;   
���   �$ 11��6`    �� Left$	 445��6p   �� 5%   
   -   5        $��labMayNghienTho4��5%      $	 280��6(   $	 445��69   $��MÁY NGHIỀN THÔ 4��5&      $��Right=�5'      $��Center=�5(      $��20(�5)      $��Times New Roman)�6   $
��Bold"�6;   
���   �5+      �� 5-   
   -   5        $��labKhoNghienTho��5-      $
 1033��6'   $��KHO NGHIỀN THÔ��5.      $��Center=�5/      $��Center=�50      $��20(�51      $��Times New Roman)�6   $
��Bold"�6;   
���   � J� RenderTransformOrigin$ 0.916,0.788&�6`   $	 248��6�    K� ZIndex$ 1��52      
�������53      �� 55   
   -   5        $��labKhoSauSay��55      $
 1498��6$   $��KHO SAU SẤY��56      $��Center=�57      $��Center=�58      $��20(�59      $��Times New Roman)�6   $
��Bold"�6;   
���   �$ 0.916,0.788&�6`   $	 262��6�   
�������$ 1��5;      !  WPFUserControl.MayNghienTho  5?   
   -   5          Name$ 
nghienTho1��5?   &   $	��283��5@   &   $	��269��63   $ 2��6?   $	 176��6N     5B   
   -   5        $ 
nghienTho2��5B   &   $	��283��5C   &   $	��269��63   $ 2��6?   $	 640��6N     5E   
   -	   5        $ 
nghienTho3��5E   &   $	��283��5F   &   $	��269��63   $	 271��6?   $	 176��6P     5H   
   -
   5        $ 
nghienTho4��5H   &   $	��283��5I   &   $	��269��63   $	 271��6?   $	 640��6P     WPFUserControl.KhoSauSay  5L   
   -   5          Name$ 	khoSauSay��5L   #   $	��379��5M   &   $	��633��63   $
 1284��6?   $ 19��6R   !  WPFUserControl.KhoNghienTho  5P   
   -   5          Name$ khoNghienTho��5P   &   $	��390��5Q   &   $	��632��63   $	 823��6?   $ -2��6Q     WPFUserControl.LoDot  5S   
   -   5        	  Name$	 loDot1��5S      $	��234��5T   &   $	��398��63   $ 10��6?   $	 600��6P   '   !EasyScadaApp.ThongTinMayNghienTho  5d   
   -   5        
  Name$
 thongTinMayNghienTho1��5d   ,   $ 34��6K   $ 5��6[   $	��240��6k   $	��159��6x     5e   
   -   5        $
 thongTinMayNghienTho2��5e   ,   $ 34��6K   $	 476��6[   $	��240��6m   $	��159��6z     5i   
   -   5        $
 thongTinMayNghienTho3��5i   ,   $	 303��6K   $ 5��6\   $	��238��6l   $	��159��6y     5j   
   -   5        $
 thongTinMayNghienTho4��5j   ,   $	 303��6K   $	 476��6\   $	��238��6n   $	��159��6{   $   EasyScadaApp.ThongTinKhoNghien  5l   
   -   5          Name$ thongTinKhoNghienTho��5l   )   $
 1284��6G   $ 13��6Z   $	��113��6j   $	��139��6w     5m   
   -   5        $ thongTinKhoSauSay��5m   )   $
 1734��6D   $ 19��6W   $	��113��6g   $	��139��6t     5n   
   -   5        $	 loDot1_Copy��5n      $	��234��5o      $	��398��6   $	 449��6&   $	 600��68     WPFUserControl.MaySay  5q   
   -   5          Name$ maySay��5q       $ 1��60   $	 852��6A   $	 365��6S   $
��1050��6d   $	��547��6q   5u      5v      