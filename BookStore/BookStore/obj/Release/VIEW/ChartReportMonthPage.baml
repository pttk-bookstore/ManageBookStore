   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf )    #BookStore.VIEW.ChartReportMonthPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    CharReportMonthPageVM � DataContext# [  N� Title$ ChartReportMonthPage��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoadCommand+.��� 
 � RowDefinitions
 �� $
��auto ��� $
��auto ��� $��* �.+��� $��0��   MaterialDesignTitleTextBlock#���  $��18(�$	��Top=�$
��Left=�$��10,5,0,5q�(&Biều đồ lợi nhuận các tháng� $��1�����#2980b9$��40��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=� � 	Resources  �� 
TargetType  	labelText �� Property �� Value��%�   &	       �� " ��.���  � ��$ 15(���  � ��
 �������  � ��$ Center=���  � ��$ Tahoma)���  � ��$ Medium"���  � ��$ 5,0,5,0q�.+��� $D��>Biều đồ thể hiện lợi nhuận theo tháng trong năm��#��[ �� 
�������$��Medium"�$��Tahoma)�$
��auto��$��5,0,5,0q�$��16(� �� SelectedItem �� *SelectedItemYear+���� *
ListYear+   $ SelectionChanged��.   	 �� *SelectionChangedYear+� $��2��$	��550��$
��1100��$��Center=�.+�#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�   Series �� *SeriesCollection+   AxisY   LiveCharts.Wpf.Axis     Title$ 
Giá trị��   LabelFormatter �� *
YFormatter+   AxisX   $ Tháng��$��0,5,0,0q�   FontSize$ 14Q�   Labels �� *Labels+