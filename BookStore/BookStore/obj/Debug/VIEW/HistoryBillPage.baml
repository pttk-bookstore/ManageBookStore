   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5      $    BookStore.VIEW.HistoryBillPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      <	converter&clr-namespace:BookStore.VIEW.Converter     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        HistoryBillPageVM � DataContext# [ 5       N� Title$ HistoryBillPage��5       � 	Resources 5      9  3BookStore.VIEW.Converter.StatusIntToStringConverter  StatusIntToStringConverter=  7BookStore.VIEW.Converter.StatusIntToVisibilityConverter " StatusIntToVisibilityConverter��%:   &	       &	        5   
   6/     5   
   63   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadCommand+5      .��5!      �  � RowDefinitions 5"   
   �� 5#      $
��auto �6   �� 5$      $��* �6   .+�5'   
   �� $��0��6      MaterialDesignTitleTextBlock#���  6!   $��18(�6X   $	��Top=�5(      $
��Left=�60   $��10,5,0,5q�6K   Lịch sử thanh toán5*      �� 5+   
    �� Orientation$ 
Horizontal=�6   $��1��6.   5-      #  MaterialDesignThemes.Wpf.Card  5.   
   $��1��6   $
��1100��6+   $��10,0,0,0q�68   $
��Left=�5/      .��50      �  51      �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $��* �6$   .+�58      � $��0��6   ���#29B391$��50��69   .+�59      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W    5:       �� 
TargetType  	labelText �� Property �� Value��%  &	       �� 5;      " ��6$   .�5<   "   ��  � ��$ 16(�6=   �� 5=   "    � ��
 �����6?   �� 5>   "    � ��$ Center=�6F   �� 5?   "    � ��$ Tahoma)�6?   �� 5@   "    � ��$ Medium"�6?   �� 5A   "    � ��$ 5,0,5,0q�6;   5B      5E      .+�5H      �� $$��Lịch sử thanh toán tháng��6$   #��[ 6D   �� 5J      
�������$��Medium"�5L   7   $��Tahoma)�6K   $
��auto��5M   $   $��5,0,5,0q�61   $��16(�6B    �� SelectedItem 5J   $   �� *SelectedItemMonth+��5K   $   �� *	ListMonth+ 5N        5O   "   $ SelectionChanged��61   .	 5P   &     
 6<   �� *SelectionChangedMonth+5Q   #   5S      �� 5U      $
��Năm��6$   #��[ 6/   �� 5W      
�������$��Medium"�5Y   7   $��Tahoma)�6K   $
��auto��5Z   $   $��5,0,5,0q�61   $��16(�6B    5W   $   �� *SelectedItemYear+��5X   $   �� *
ListYear+ 5[        5\   "   $ SelectionChanged��61   .	 5]   &     
 6<   �� *SelectionChangedYear+5^   #   5`      5a      5b      � 5d      $��1��6   $��55��6$   .+�5e      �� $ 
Horizontal=�6!   $��10,5,0,0q�6:   $��Center=�6L    5f      ��%  &	       �� 5g      " ��6$   .�5h   "   ��  � ��$ 16(�6=   �� 5i   "    � ��
 �   �6?   �� 5j   "    � ��$ Center=�6F   �� 5k   "    � ��$ Tahoma)�6?   �� 5l   "    � ��$ Medium"�6?   �� 5m   "    � ��$ 5,0,5,0q�6;   5n      5o      .+�5q      �� $��
Từ ngày��6$   #��[ 63   5s      (	  "System.Windows.Controls.DatePicker	  5u      $	��120��6%   $��5,0,5,0q�5v   %   $��Center=�5w   %    	  SelectedDate 5u   1   �� *DateBeginSelectedDate+ 5x        5y   "   $ SelectedDateChanged��61   .	 5z   &     
 6<   �� *DateBeginSelectedDateChanged+5{   #   5}      �� 5      $��Đến ngày��6$   $��20,0,0,0q�64   #��[ 5�   $   5�      	  5�      $	��120��6%   $��5,0,5,0q�5�   %   $��Center=�5�   %    5�   1   �� *DateEndSelectedDate+ 5�        5�   "   $ SelectedDateChanged��61   .	 5�   &     
 6<   �� *DateEndSelectedDateChanged+5�   #   5�      5�      �� 5�      $��5,5,0,5q�6    $��Bottom=�61   5�      � 5�      $��2��6   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $	��250��5�   #   ��5�   #   �� *
ListBill+ 6D   �� *BillSelectedItem+ 5�        5�   "   $ SelectionChanged��61   .	 5�   &     
 6<   �� *BillSelectionChanged+5�   #    �� View 5�      �� 5�   "   .P�5�   &   �� $	��Mã��5�       �� CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6P   ��6<   �� *ID+6P   5�   /   5�   '   �� 5�   &   $��Khách hàng��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6\   ��6<   �� *BCustomer.Name+6\   5�   /   5�   '   �� 5�   &   $��Hình thức��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6[   ��6<   �� *TypeBill.Name+6[   5�   /   5�   '   �� 5�   &   $��Tổng sách��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6k   ��6<   �� *
TotalCount+ �� StringFormat$	 0,0��6k   5�   /   5�   '   �� 5�   &   $��Tổng tiền��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6m   ��6<   �� *
TotalMoney+$ 0,0.0��6m   5�   /   5�   '   �� 5�   &   $��Khuyến mãi��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6j   ��6<   �� *	Promotion+$	 0.0��6j   5�   /   5�   '   �� 5�   &   $��Nhân viên��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6\   ��6<   �� *BSalesman.Name+6\   5�   /   5�   '   �� 5�   &   $��Thời gian��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6R   ��6<   �� *Date+6R   5�   /   5�   '   �� 5�   &   $��Trạng thái��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6�   ��6<   �� *Status+ �� 	Converter# [ 6�   5�   /   5�   '   �� 5�   &    5�   *   �� 5�   .   .R�5�   2   �� ���#c0392b���#c0392b$��40��6d    � ToolTip$ Hoàn tất��5�   5   ��5�   5   ��  �� Path$# DataContext.VerifyBillCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType" ����5�   5   �� y�5�   9   �� *Status+# [ .��5�   6   '
  !MaterialDesignThemes.Wpf.PackIcon
  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ CheckCircleOutline=�6N   
�������$��10��6{   $��10��6�   5�   3   5�   /   5�   '   5�   #   5�      �� 5      $��20,0,0,0q�6%   $��Center=�68   $��Center=�6S   $ Vertical=�6p   .+�5     �� $��0,5,0,5q�6%    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5     $ Trang trước��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *PreviousPageCommand+.��5  "   
  $ ArrowUpBold=�6:   5     �� 5     $��0,5,0,5q�6%   #��[ 5	     $ Trang hiện tại��5
     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *CurrentPage+ �� FallbackValue$ 1��5     �� 5     $��0,5,0,5q�6%   #��[ 5     $ 
Trang kế��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *NextPageCommand+.��5  "   
  $ ArrowDownThick=�6:   5     5     5     �� 5     $��5,0,0,-3q�6    $��Bottom=�62   5     � 5     $��3��6   $��0,10,0,0q�6$    5     ��%  &	       �� 5     " ��6    .�5     ��  � ��$ 16(�69   �� 5      � ��
 �����6;   �� 5      � ��$ Center=�6B   �� 5       � ��$ Tahoma)�6;   �� 5!      � ��$ Medium"�6;   �� 5"      � ��$ 5,0,5,0q�67   5#     5$      5%     �� 5&     $
��auto �6(   �� 5'     $��* �6(   .+�5)     � ���#FF6347$��50��60   $��0��6<   .+�5*     �� $ 
Horizontal=�6%   $��Center=�6>   .+�5+     �� $&�� Thông tin chi tiết hóa đơn��6(   #��[ 6J   �� 5,     #��[ 6@   ��6(   �� *BillID+6@   5-     5/     �� 51     $	��230��6B   $��1��6O   ��6   �� *
ListDetail+ 52     �� 53     .P�54  "   �� $��	Mã sách��55      56  &   �� 57  *   .R�58  .   �� $��Center=�6L   ��68   �� *ID+6L   59  +   5;  #   �� 5=  "   $��
Tên sách��5>      5?  &   �� 5@  *   .R�5A  .   �� $��Center=�6N   $	��200��6i   $
��Wrap=�6x   ��68   �� *Name+6x   5B  +   5D  #   �� 5F  "   $��
Giá gốc��5G      5H  &   �� 5I  *   .R�5J  .   �� $��Center=�6d   ��68   �� *Price+$ 0,0.0��6d   5K  +   5M  #   �� 5O  "   $��Khuyến mãi��5P      5Q  &   �� 5R  *   .R�5S  .   �� $��Center=�6h   ��68   �� *	Promotion+$ 0,0.0��6h   5T  +   5V  #   �� 5X  "   $��	Giá bán��5Y      5Z  &   �� 5[  *   .R�5\  .   �� $��Center=�6k   ��68   �� *PricePromotion+$	 0.0��6k   5]  +   5_  #   �� 5a  "   $��Số lượng��5b      5c  &   �� 5d  *   .R�5e  .   �� $��Center=�6b   ��68   �� *Count+$	 0,0��6b   5f  +   5h  #   �� 5j  "   $��Tổng tiền��5k      5l  &   �� 5m  *   .R�5n  .   �� $��Center=�6i   ��68   �� *
TotalMoney+$ 0,0.0��6i   5o  +   5q  #   5r     5t     5u     5v     5x     5y     5z     