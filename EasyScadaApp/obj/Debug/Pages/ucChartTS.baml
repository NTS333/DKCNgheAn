   M S B A M L   `   `   `  ����G  CEasyScadaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:EasyScadaApp.PagesEasyScadaApp.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      "    EasyScadaApp.Pages.ucChartTS   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:EasyScadaApp.Pages     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        � 	Resources  5
         bvc��%   &	        �� 5   
   65   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��2q�6   
��� � � �� CornerRadius$ 5��69   $��5q�6J   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    d� 	IsChecked 5      �� *EnableNTho1+.��5   X   Tần số NThô15      �� 5      $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    5      �� *EnableNTho2+.��5   X   Tần số NThô25      �� 5      $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5      $��14(�68   $
��Bold"�6F    5      �� *EnableNTinh+.��5   X   Tần số NTinh5      �� 5       $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5!      $��14(�68   $
��Bold"�6F    5       �� *EnableA1EV1+.��5!   X   Tần số A1 EV15#      �� 5$      $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5%      $��14(�68   $
��Bold"�6F    5$      �� *EnableA2EV1+.��5%   X   Tần số A2 EV15'      �� 5(      $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5)      $��14(�68   $
��Bold"�6F    5(      �� *EnableA1EV2+.��5)   X   Tần số A1 EV25+      �� 5,      $��Center=�6=   $��5,0,0,0q�6_   $��Times New Roman)�5-      $��14(�68   $
��Bold"�6F    5,      �� *EnableA2EV2+.��5-   X   Tần số A2 EV25/      �� 51      -   5         ��Name$ btnChart��51      
��� � �$��	5,10,0,10q�6X   $��Times New Roman)�52      $��30(�66   $
��Bold"�6D   .��6V   ON/OFF Chart54      55      56      #  LiveCharts.Wpf.CartesianChart  58   
   -   5          Name$ realTimeChart��58      $��1��64   $��5q�6A   $��14(�59      
�������&   LiveCharts.Wpf.Charts.Base.Chart   AnimationsSpeed$ 0:0:0.5h�5:         DisableAnimations . 	   	Hoverable	 .  ���#222E31
   LegendLocation$	
 Top=�5<   2      DataTooltip 5;   /   Z�    AxisX 5K        LiveCharts.Wpf.Axis  -   5          Name$ xLable��5K         
FontFamily$ Times New Roman)�6+      FontSize$ 14Q�6H      
Foreground
 �  ��   LabelsRotation$	 -45Q�5P         Title$ Thời gian��5Q         LabelFormatter 5L      �� *DateTimeFormatter+   MaxValue 5M      �� *	AxisMax+   MinValue 5N      �� *	AxisMin+   Unit 5O      �� *
AxisUnit+   	Separator 5R        LiveCharts.Wpf.Separator  5S         Step 6(   �� *
AxisStep+   Stroke 5T      �� 5U   "    �� Color$ #404F56��62   5W      5Y         AxisY 5]        -   5        $ yLabel��5]      $ Times New Roman)�6+   $ 14Q�6H   
 �  ��$ Values��5^       6+   �� *ValueFormat+ 5_        5`         StrokeThickness$ 2Q�6(      StrokeDashArray$ 2R�6<    5a      �� 5b   "   $ #404F56��62   5d      5f      5h      5i      5j      