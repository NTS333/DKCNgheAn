   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EasyScadaApp.PagesEasyScadaApp.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5           EasyScadaApp.Pages.ucChart   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyScadaApp.Pages     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        � 	Resources  5
         bvc��%   &	        �� 5   
   65   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��2q�6   
��� � � �� CornerRadius$ 5��69   $��5q�6J   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6B   $��5,0,0,0q�6d   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    d� 	IsChecked 5      �� *EnableDongMNTho1+.��5   X   Dòng máy NThô15      �� 5      $��Center=�6C   $��5,0,0,0q�6e   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    5      �� *EnableDongQHNTho1+.��5   X   Dòng QH NThô15      �� 5      $��Center=�6B   $��5,0,0,0q�6d   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    5      �� *EnableDongMNTho2+.��5   X   Dòng máy NThô25      �� 5       $��Center=�6C   $��5,0,0,0q�6e   $��Times New Roman)�5!      $��14(�68   $
��Bold"�6F    5       �� *EnableDongQHNTho2+.��5!   X   Dòng QH NThô25#      �� 5$      $��Center=�6B   $��5,0,0,0q�6d   $��Times New Roman)�5%      $��14(�68   $
��Bold"�6F    5$      �� *EnableDongMNTinh+.��5%   X   Dòng máy NTinh5'      �� 5(      $��Center=�6C   $��5,0,0,0q�6e   $��Times New Roman)�5)      $��14(�68   $
��Bold"�6F    5(      �� *EnableDongQHNTinh+.��5)   X   Dòng QH NTinh5+      �� 5,      $��Center=�6@   $��5,0,0,0q�6b   $��Times New Roman)�5-      $��14(�68   $
��Bold"�6F    5,      �� *EnableDongMEV1+.��5-   X   Dòng máy EV15/      �� 50      $��Center=�6D   $��5,0,0,0q�6f   $��Times New Roman)�51      $��14(�68   $
��Bold"�6F    50      �� *EnableDongMixerEV1+.��51   X   Dòng mixer EV153      �� 54      $��Center=�6@   $��5,0,0,0q�6b   $��Times New Roman)�55      $��14(�68   $
��Bold"�6F    54      �� *EnableDongMEV2+.��55   X   Dòng máy EV257      �� 6   $��Center=�6P   $��5,0,0,0q�6r   $��Times New Roman)�58      $��14(�68   $
��Bold"�6F    57   '   �� *EnableDongMixerEV2+.��58   X   Dòng mixer EV25:      �� 5<      -   5         ��Name$ btnChart��5<      
��� � �$��	5,10,0,10q�6X   $��Times New Roman)�5=      $��30(�66   $
��Bold"�6D   .��6V   ON/OFF Chart5?      5@      5A      #  LiveCharts.Wpf.CartesianChart  5C   
   -   5          Name$ realTimeChart��5C      $��1��64   $��5q�6A   $��14(�5D      
�������&   LiveCharts.Wpf.Charts.Base.Chart   AnimationsSpeed$ 0:0:0.5h�5E         DisableAnimations . 	   	Hoverable	 .  ���#222E31
   LegendLocation$	
 Top=�5G   2      DataTooltip 5F   /   Z�    AxisX 5V        LiveCharts.Wpf.Axis  -   5          Name$ xLable��5V         
FontFamily$ Times New Roman)�6+      FontSize$ 14Q�6H      
Foreground
 �  ��   LabelsRotation$	 -45Q�5[         Title$ Thời gian��5\         LabelFormatter 5W      �� *DateTimeFormatter+   MaxValue 5X      �� *	AxisMax+   MinValue 5Y      �� *	AxisMin+   Unit 5Z      �� *
AxisUnit+   	Separator 5]        LiveCharts.Wpf.Separator  5^         Step 6(   �� *
AxisStep+   Stroke 5_      �� 5`   "    �� Color$ #404F56��62   5b      5d         AxisY 5h        -   5        $ yLabel��5h      $ Times New Roman)�6+   $ 14Q�6H   
 �  ��$ Values��5i       6+   �� *ValueFormat+ 5j        5k         StrokeThickness$ 2Q�6(      StrokeDashArray$ 2R�6<    5l      �� 5m   "   $ #404F56��62   5o      5q      5s      5t      5u      