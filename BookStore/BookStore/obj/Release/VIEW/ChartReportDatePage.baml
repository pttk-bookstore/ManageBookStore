   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf (    "BookStore.VIEW.ChartReportDatePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    ChartReportDatePageVM � DataContext# [  N� Title$ ChartReportDatePage��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoadCommand+.��� 
 � RowDefinitions
 �� $
��auto ��� $��* �.+�� $��1�� K� ZIndex$ 1��$��40��$��40��$��Center=�$��Center=� % !MaterialDesignCircularProgressBar#��[  � Value$ 0Q� � IsIndeterminate �� *IsIndeterminate+�� $��0��   MaterialDesignTitleTextBlock#���  $��18(�$	��Top=�$
��Left=�$��10,5,0,5q�DBBiều đồ Doanh thu, lợi nhuận và sách bán ra theo ngày#  MaterialDesignThemes.Wpf.Card  $��1��$	��650��$
��1150��$��10,0,0,0q�$
��Left=�.��� 
 �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�����#2980b9$��50��.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=� � 	Resources  �� 
TargetType  	labelText �� Property �� Value��%�   &	       �� " ��.���  � ��$ 16(���  � ��
 �������  � ��$ Center=���  � ��$ Tahoma)���  � ��$ Medium"���  � ��$ 5,0,5,0q�.+��� $'��!Doanh thu các ngày trong tháng��#��[ �� 
�������$��Medium"�$��Tahoma)�$
��auto��$��5,0,5,0q�$��16(� �� SelectedItem �� *SelectedItemMonth+���� *	ListMonth+   $ SelectionChanged��.   	 �� *SelectionChangedMonth+�� $
��Năm��#��[ �� 
�������$��Medium"�$��Tahoma)�$
��auto��$��5,0,5,0q�$��16(� �� *SelectedItemYear+���� *
ListYear+   $ SelectionChanged��.   	 �� *SelectionChangedYear+� $��1��$��55��.+��� $ 
Horizontal=�$��10,5,0,0q�$��Center=� ��%�   &	       �� " ��.���  � ��$ 16(���  � ��
 �   ���  � ��$ Center=���  � ��$ Tahoma)���  � ��$ Medium"���  � ��$ 5,0,5,0q�.+��� $��
Từ ngày��#��[ (  "System.Windows.Controls.DatePicker  $	��120��$��5,0,5,0q�$��Center=�   SelectedDate �� *DateBeginSelectedDate+   $ SelectedDateChanged��.   	 �� *DateBeginSelectedDateChanged+�� $��Đến ngày��$��20,0,0,0q�#��[   $	��120��$��5,0,5,0q�$��Center=� �� *DateEndSelectedDate+   $ SelectedDateChanged��.   	 �� *DateEndSelectedDateChanged+�� $��5,5,0,5q�$��Bottom=�� $��2��
 �� $
��auto ��� $��* �.+�� $��0��$	��280��$
��1100��$��Center=�
 �� $	��250 ��� $��* �.+�� $��0��.+�#  LiveCharts.Wpf.CartesianChart  &	   LiveCharts.Wpf.Charts.Base.Chart 	  LegendLocation$ Right=� 	  Series �� *SeriesCollection+ 	  AxisY 
  LiveCharts.Wpf.Axis
   
  Title$ 
Giá trị�� 
  LabelFormatter �� *
YFormatter+ 	  AxisX 
  $ Ngày��$��0,5,0,0q� 
  FontSize$ 14Q� 
  Labels �� *Labels+�� $+��%Biểu đồ lợi nhuận theo ngày��$��1��$��Tahoma)�$��15(�$��0,5,0,0q�$��Center=�$	��Top=�� $��1��$	��230��
 �� $	��200 ��� $��* �.+�� $��0��$
��1000��.+�  $ Right=� �� *BookSeriesCollection+ 
  $ 
Giá trị�� �� *BookYFormatter+ 
  $ Ngày��$��0,5,0,0q�$ 14Q� �� *
BookLabels+�� $+��%Biểu đồ sách bán ra theo ngày��$��1��$��Tahoma)�$��15(�$��0,5,0,0q�$��Center=�$	��Top=�