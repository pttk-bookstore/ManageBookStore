   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      (    "BookStore.VIEW.ChartReportDatePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        ChartReportDatePageVM � DataContext# [ 5       N� Title$ ChartReportDatePage��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadCommand+5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��auto �6   �� 5       $��* �6   .+�5"   
   � $��1��6    K� ZIndex$ 1��6#   $��40��64   $��40��6@   $��Center=�6K   $��Center=�5#       % !MaterialDesignCircularProgressBar#��[ 5$       � Value$ 0Q�5%       � IsIndeterminate 5&      �� *IsIndeterminate+�� 5'   
   $��0��6      MaterialDesignTitleTextBlock#���  6!   $��18(�6X   $	��Top=�5(      $
��Left=�60   $��10,5,0,5q�6K   DBBiều đồ Doanh thu, lợi nhuận và sách bán ra theo ngày5*      #  MaterialDesignThemes.Wpf.Card  5,   
   $��1��6   $	��650��6+   $
��1150��68   $��10,0,0,0q�6E   $
��Left=�5-      .��5.      � 
 5/      �� 50      $
��auto �6$   �� 51      $
��auto �6$   �� 52      $��* �6$   .+�55      � $��0��6   ���#2980b9$��50��69   .+�56      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W    � 	Resources 57       �� 
TargetType  	labelText �� Property �� Value��%  &	       �� 58      " ��6$   .�59   "   ��  � ��$ 16(�6=   �� 5:   "    � ��
 �����6?   �� 5;   "    � ��$ Center=�6F   �� 5<   "    � ��$ Tahoma)�6?   �� 5=   "    � ��$ Medium"�6?   �� 5>   "    � ��$ 5,0,5,0q�6;   5?      5B      .+�5E      �� $'��!Doanh thu các ngày trong tháng��6$   #��[ 6J   �� 5G      
�������$��Medium"�5I   7   $��Tahoma)�6K   $
��auto��5J   $   $��5,0,5,0q�61   $��16(�6B    �� SelectedItem 5G   $   �� *SelectedItemMonth+��5H   $   �� *	ListMonth+ 5K        5L   "   $ SelectionChanged��61   . 5M   &     	 6<   �� *SelectionChangedMonth+5N   #   5P      �� 5R      $
��Năm��6$   #��[ 6/   �� 5T      
�������$��Medium"�5V   7   $��Tahoma)�6K   $
��auto��5W   $   $��5,0,5,0q�61   $��16(�6B    5T   $   �� *SelectedItemYear+��5U   $   �� *
ListYear+ 5X        5Y   "   $ SelectionChanged��61   . 5Z   &     	 6<   �� *SelectionChangedYear+5[   #   5]      5^      5_      � 5a      $��1��6   $��55��6$   .+�5b      �� $ 
Horizontal=�6!   $��10,5,0,0q�6:   $��Center=�6L    5c      ��%  &	       �� 5d      " ��6$   .�5e   "   ��  � ��$ 16(�6=   �� 5f   "    � ��
 �   �6?   �� 5g   "    � ��$ Center=�6F   �� 5h   "    � ��$ Tahoma)�6?   �� 5i   "    � ��$ Medium"�6?   �� 5j   "    � ��$ 5,0,5,0q�6;   5k      5l      .+�5n      �� $��
Từ ngày��6$   #��[ 63   5p      (  "System.Windows.Controls.DatePicker  5r      $	��120��6%   $��5,0,5,0q�5s   %   $��Center=�5t   %      SelectedDate 5r   1   �� *DateBeginSelectedDate+ 5u        5v   "   $ SelectedDateChanged��61   . 5w   &     	 6<   �� *DateBeginSelectedDateChanged+5x   #   5z      �� 5|      $��Đến ngày��6$   $��20,0,0,0q�64   #��[ 5~   $   5�        5�      $	��120��6%   $��5,0,5,0q�5�   %   $��Center=�5�   %    5�   1   �� *DateEndSelectedDate+ 5�        5�   "   $ SelectedDateChanged��61   . 5�   &     	 6<   �� *DateEndSelectedDateChanged+5�   #   5�      5�      �� 5�      $��5,5,0,5q�6    $��Bottom=�61   5�      � 5�      $��2��6   
 5�      �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   $	��280��6(   $
��1100��65   $��Center=�6B   
 5�      �� 5�      $	��250 �6,   �� 5�      $��* �6,   .+�5�      � $��0��6   .+�5�      #  LiveCharts.Wpf.CartesianChart  &	   LiveCharts.Wpf.Charts.Base.Chart 	  LegendLocation$ Right=�6U    	  Series 61   �� *SeriesCollection+ 	  AxisY 5�   &   
  LiveCharts.Wpf.Axis
   
  Title$ 
Giá trị��6/    
  LabelFormatter 6?   �� *
YFormatter+6g    	  AxisX 5�   &   
  $ Ngày��6/   $��0,5,0,0q�6V    
  FontSize$ 14Q�6g    
  Labels 6<   �� *Labels+6w   5�      5�      �� 5�      $+��%Biểu đồ lợi nhuận theo ngày��6$   $��1��6G   $��Tahoma)�5�   $   $��15(�68   $��0,5,0,0q�6F   $��Center=�5�   $   $	��Top=�5�   $   5�      � 5�      $��1��6   $	��230��6(   
 5�      �� 5�      $	��200 �6,   �� 5�      $��* �6,   .+�5�      � $��0��6   $
��1000��6,   .+�5�        $ Right=�6Y    61   �� *BookSeriesCollection+ 5�   &   
  $ 
Giá trị��6/    6?   �� *BookYFormatter+6k    5�   &   
  $ Ngày��6/   $��0,5,0,0q�6Z   $ 14Q�6k    6<   �� *
BookLabels+6{   5�      5�      �� 5�      $+��%Biểu đồ sách bán ra theo ngày��6$   $��1��6I   $��Tahoma)�5�   $   $��15(�68   $��0,5,0,0q�6F   $��Center=�5�   $   $	��Top=�5�   $   5�      5�      5�      5�      5�      5�      