   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5   	   C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5   	   I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  5      )    #BookStore.VIEW.DetailCustomerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookStore.VIEW     5   	   <	converter&clr-namespace:BookStore.VIEW.Converter     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      2uc)clr-namespace:BookStore.VIEW.UserControls  5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5        MaterialDesignPaper#���  5      $	��700��5      $
��1000��6    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Title$ DetailCustomerWindow��5   	    � 	Resources 5      9  3BookStore.VIEW.Converter.StatusIntToStringConverter  StatusIntToStringConverter=  7BookStore.VIEW.Converter.StatusIntToVisibilityConverter " StatusIntToVisibilityConverter��%:   &	       &	        5   
   6/     5   
   63   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadCommand+5      .��5       � 
 � RowDefinitions
 5!   
   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $��* �6   .+�5&   
   ,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=�6    K� ZIndex$ 1��60   $��0��6A   �� 5(   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5)      ��    MaterialDesignTitleTextBlock#���  6   $��18(�6P   $	��Top=�5*      $
��Left=�60   $��10,5,0,5q�6K   &$Lịch sử thanh toán khách hàng5,      �� 5.      #���  67   $��18(�6n   $	��Top=�5/      $
��Left=�60   $��5,5,0,5q�6K   ��5.      �� *CustomerName+51      52      �� 55   
   $ 
Horizontal=�6   $��1��6.   57      #	  MaterialDesignThemes.Wpf.Card	  58   
   $��2��6   $	��970��6+   $��10,0,0,0q�67   $
��Left=�59      .��5:      � 
 5;      �� 5<      $
��auto �6$   �� 5=      $
��auto �6$   �� 5>      $
��auto �6$   �� 5?      $��* �6$   .+�5B      � $��0��6   ���#29B391$��50��69   .+�5C      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W    5D       �� 
TargetType  	labelText �� Property �� Value��%  &	       �� 5E      " ��6$   .�5F   "   ��  � ��$ 16(�6=   �� 5G   "    � ��
 �����6?   �� 5H   "    � ��$ Center=�6F   �� 5I   "    � ��$ Tahoma)�6?   �� 5J   "    � ��$ Medium"�6?   �� 5K   "    � ��$ 5,0,5,0q�6;   5L      5O      .+�5R      �� $$��Lịch sử thanh toán tháng��6$   #��[ 6D   �� 5T      
�������$��Medium"�5V   7   $��Tahoma)�6K   $
��auto��5W   $   $��5,0,5,0q�61   $��16(�6B    �� SelectedItem 5T   $   �� *SelectedItemMonth+��5U   $   �� *	ListMonth+ 5X        5Y   "   $ SelectionChanged��61   . 5Z   &     	 6<   �� *SelectionChangedMonth+5[   #   5]      �� 5_      $
��Năm��6$   #��[ 6/   �� 5a      
�������$��Medium"�5c   7   $��Tahoma)�6K   $
��auto��5d   $   $��5,0,5,0q�61   $��16(�6B    5a   $   �� *SelectedItemYear+��5b   $   �� *
ListYear+ 5e        5f   "   $ SelectionChanged��61   . 5g   &     	 6<   �� *SelectionChangedYear+5h   #   5j      5k      5l      � 5n      $��1��6   $��55��6$   .+�5o      �� $ 
Horizontal=�6!   $��10,5,0,0q�6:   $��Center=�6L    5p      ��%  &	       �� 5q      " ��6$   .�5r   "   ��  � ��$ 16(�6=   �� 5s   "    � ��
 �   �6?   �� 5t   "    � ��$ Center=�6F   �� 5u   "    � ��$ Tahoma)�6?   �� 5v   "    � ��$ Medium"�6?   �� 5w   "    � ��$ 5,0,5,0q�6;   5x      5y      .+�5{      �� $��
Từ ngày��6$   #��[ 63   5}      (
  "System.Windows.Controls.DatePicker
  5      $	��120��6%   $��5,0,5,0q�5�   %   $��Center=�5�   %    
  SelectedDate 5   1   �� *DateBeginSelectedDate+ 5�        5�   "   $ SelectedDateChanged��61   . 5�   &     	 6<   �� *DateBeginSelectedDateChanged+5�   #   5�      �� 5�      $��Đến ngày��6$   $��20,0,0,0q�64   #��[ 5�   $   5�      
  5�      $	��120��6%   $��5,0,5,0q�5�   %   $��Center=�5�   %    5�   1   �� *DateEndSelectedDate+ 5�        5�   "   $ SelectedDateChanged��61   . 5�   &     	 6<   �� *DateEndSelectedDateChanged+5�   #   5�      5�      �� 5�      $��5,5,0,5q�6    $��Bottom=�61   5�      � 5�      $��2��6   .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $	��230��5�   #   ��5�   #   �� *
ListBill+ 6D   �� *BillSelectedItem+ 5�        5�   "   $ SelectionChanged��61   . 5�   &     	 6<   �� *BillSelectionChanged+5�   #    �� View 5�      �� 5�   "   .P�5�   &   �� $	��Mã��5�       �� CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6P   ��6<   �� *ID+6P   5�   /   5�   '   �� 5�   &   $��Hình thức��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6[   ��6<   �� *TypeBill.Name+6[   5�   /   5�   '   �� 5�   &   $��Tổng sách��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6k   ��6<   �� *
TotalCount+ �� StringFormat$	 0,0��6k   5�   /   5�   '   �� 5�   &   $��Tổng tiền��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6m   ��6<   �� *
TotalMoney+$ 0,0.0��6m   5�   /   5�   '   �� 5�   &   $��Khuyến mãi��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6j   ��6<   �� *	Promotion+$	 0.0��6j   5�   /   5�   '   �� 5�   &   $��Nhân viên��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6\   ��6<   �� *BSalesman.Name+6\   5�   /   5�   '   �� 5�   &   $��Thời gian��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6R   ��6<   �� *Date+6R   5�   /   5�   '   �� 5�   &   $��Trạng thái��5�       5�   *   �� 5�   .   .R�5�   2   �� $��Center=�6�   ��6<   �� *Status+ �� 	Converter# [ 6�   5�   /   5�   '   �� 5�   &    5�   *   �� 5�   .   .R�5�   2   �� ���#c0392b���#c0392b$��40��6d    � ToolTip$ Hoàn tất��5�   5   ��5�   5   ��  �� Path$# DataContext.VerifyBillCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType" ����5�   5   �� y�5�   9   �� *Status+# [ .��5�   6   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ CheckCircleOutline=�6N   
�������$��10��6{   $��10��6�   5�   3   5�   /   5�   '   5�   #   5�      �� 5     $��20,0,0,0q�6%   $��Center=�68   $��Center=�6S   $ Vertical=�6p   .+�5     �� $��0,5,0,5q�6%    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5     $ Trang trước��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *PreviousPageCommand+.��5  "     $ ArrowUpBold=�6:   5     �� 5	     $��0,5,0,5q�6%   #��[ 5
     $ Trang hiện tại��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *CurrentPage+ �� FallbackValue$ 1��5     �� 5     $��0,5,0,5q�6%   #��[ 5     $ 
Trang kế��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *NextPageCommand+.��5  "     $ ArrowDownThick=�6:   5     5     5     �� 5     $��5,0,0,-3q�6    $��Bottom=�62   5     � 5     $��3��6   $��0,10,0,0q�6$    5     ��%  &	       �� 5     " ��6    .�5     ��  � ��$ 16(�69   �� 5      � ��
 �����6;   �� 5       � ��$ Center=�6B   �� 5!      � ��$ Tahoma)�6;   �� 5"      � ��$ Medium"�6;   �� 5#      � ��$ 5,0,5,0q�67   5$     5%     
 5&     �� 5'     $
��auto �6(   �� 5(     $��* �6(   .+�5*     � ���#FF6347$��50��60   $��0��6<   .+�5+     �� $ 
Horizontal=�6%   $��Center=�6>   .+�5,     �� $&�� Thông tin chi tiết hóa đơn��6(   #��[ 6J   �� 5-     #��[ 6@   ��6(   �� *BillID+6@   5.     50     �� 52     $	��230��6B   $��1��6O   ��6   �� *
ListDetail+ 53     �� 54     .P�55  "   �� $��	Mã sách��56      57  &   �� 58  *   .R�59  .   �� $��Center=�6L   ��68   �� *ID+6L   5:  +   5<  #   �� 5>  "   $��
Tên sách��5?      5@  &   �� 5A  *   .R�5B  .   �� $��Center=�6N   $	��200��6i   $
��Wrap=�6x   ��68   �� *Name+6x   5C  +   5E  #   �� 5G  "   $��
Giá gốc��5H      5I  &   �� 5J  *   .R�5K  .   �� $��Center=�6d   ��68   �� *Price+$ 0,0.0��6d   5L  +   5N  #   �� 5P  "   $��Khuyến mãi��5Q      5R  &   �� 5S  *   .R�5T  .   �� $��Center=�6h   ��68   �� *	Promotion+$ 0,0.0��6h   5U  +   5W  #   �� 5Y  "   $��	Giá bán��5Z      5[  &   �� 5\  *   .R�5]  .   �� $��Center=�6k   ��68   �� *PricePromotion+$	 0.0��6k   5^  +   5`  #   �� 5b  "   $��Số lượng��5c      5d  &   �� 5e  *   .R�5f  .   �� $��Center=�6b   ��68   �� *Count+$	 0,0��6b   5g  +   5i  #   �� 5k  "   $��Tổng tiền��5l      5m  &   �� 5n  *   .R�5o  .   �� $��Center=�6i   ��68   �� *
TotalMoney+$ 0,0.0��6i   5p  +   5r  #   5s     5u     5v     5w     5y     5z     5{     