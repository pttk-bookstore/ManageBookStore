   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      )    #BookStore.VIEW.ChartReportMonthPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        CharReportMonthPageVM � DataContext# [ 5       N� Title$ ChartReportMonthPage��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadCommand+5      .��5      � 
 � RowDefinitions
 5   
   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $��* �6   .+�5%   
   �� $��0��6      MaterialDesignTitleTextBlock#���  6!   $��18(�6X   $	��Top=�5&      $
��Left=�60   $��10,5,0,5q�6K   (&Biều đồ lợi nhuận các tháng5(      � 5*   
   $��1��6   ���#2980b9$��40��61   .+�5+      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O    � 	Resources 5,       �� 
TargetType  	labelText �� Property �� Value��%  &	       �� 5-      " ��6   .�5.      ��  � ��$ 15(�65   �� 5/       � ��
 �����67   �� 50       � ��$ Center=�6>   �� 51       � ��$ Tahoma)�67   �� 52       � ��$ Medium"�67   �� 53       � ��$ 5,0,5,0q�63   54      55      .+�57      �� $D��>Biều đồ thể hiện lợi nhuận theo tháng trong năm��6   #��[ 6S   �� 59      
�������$��Medium"�5;   7   $��Tahoma)�6K   $
��auto��5<   $   $��5,0,5,0q�61   $��16(�6B    �� SelectedItem 59      �� *SelectedItemYear+��5:   $   �� *
ListYear+ 5=        5>      $ SelectionChanged��6)   . 5?        	 64   �� *SelectionChangedYear+5@      5B      5C      5D      � 5F   
   $��2��6   $	��550��6   $
��1100��6)   $��Center=�66   .+�5G      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6E      Series 6!   �� *SeriesCollection+   AxisY 5I        LiveCharts.Wpf.Axis     Title$ 
Giá trị��6      LabelFormatter 6/   �� *
YFormatter+6W      AxisX 5L        $ Tháng��6   $��0,5,0,0q�6G      FontSize$ 14Q�6X      Labels 6-   �� *Labels+6h   5N      5O      5Q      5R      