   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5      &     BookStore.VIEW.TypePromotionPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      6	converter&clr-namespace:BookStore.VIEW.Converter  5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        TypePromotionPageVM � DataContext# [ 5       N� Title$ TypePromotionPage��5       � 	Resources 5       �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle��%�  &	       &	 p     &	     7  �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   �� 5        � ��$
	 Bold"�6+   5!      �� 5#   
   " ��6   8
   .�5$      ��  � ��$	 14(�6)   �� 5%       � ��$	 Center=�62   �� 5&       � ��$		 330��6)   �� 5'       � ��$	 0,0,10,0q�6'   5(      5)      .  (System.Windows.Interactivity.Interaction   Triggers 5+      /  )System.Windows.Interactivity.EventTrigger  5,   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5.      .��51      �  � RowDefinitions 52   
   �� 53      $
��Auto �6   �� 54      $��* �6   .+�58   
   �� $��0��6      MaterialDesignTitleTextBlock#���  6!   $��18(�6X   $	��Top=�59      $
��Left=�60   $��10,5,0,5q�6K   " Cài đặt loại khuyến mãi5;      � 5=   
   $��1��6   $��10,0,0,0q�6    � ColumnDefinitions 5>      �� 5?      $
��auto �6#   �� 5@      $��* �6#   .+�5B      �� .+�5C      #  MaterialDesignThemes.Wpf.Card  .��5D      �  5E      �� 5F      $
��auto �6,   �� 5G      $
��auto �6,   �� 5H      $��* �6,   .+�5J      � $��0��6   ���#29B391$��30��6A   .+�5K      �� $%��Danh sách loại khuyến mãi��6(   $��Center=�6I   #��[ 5L   $   $��Center=�6K   
�������6h   5M      �� 5P       �� Orientation$ 
Horizontal=�6%   $��1��6>   $��	10,10,0,5q�6K   $
��Left=�6^   $��Center=�6y   .+�5R      �� $	��300��6&   $��15(�62   $��35��6@   $��10,0,0,0q�6L   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��5S   %   ��6O   �� *FilterString+ �� UpdateSourceTrigger$ PropertyChanged=��� 5V      ���#00BFFF$��35��6Q   ��6:   Z� ��6]   �� *searchCommand+.��5W   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��30��6:   $��30��6F   $��Center=�6Q   $��Center=�6n   �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Magnify=�5X      
�������6$   5Y      5Z      �� 5]      $��2��6%   .+�5^      &
   System.Windows.Controls.DataGrid
  $
��Left=�6'   $��0 0 0 0q�5_      $	��500��5`       
  CanUserSortColumns .  
  CanUserAddRows .   
  AutoGenerateColumns .  $	��730��5e      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5f         ColumnHeaderPadding$ 8q�5g      ��5a      �� *
ListType+ �� SelectedItem 5h      �� *SelectedItem+ 5i   "   !   BookStore.VIEW.BindingProxy 		 proxy   Data��%&   &		         5j   &    6G   �� 5k   #    
  Columns 5m   "   0  *System.Windows.Controls.DataGridTextColumn  5n   &   ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��5p   !      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5r   !       MinWidth$  80Q�6,   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 5o   !   �� *ID+5s   '   9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5u   &   $
 Tên��5w   !   $	 130 5x   !   $	  130Q�5y   !    5
 1MaterialDesignDataGridTextColumnPopupEditingStyle"   EditingElementStyle#" [
 5{   !   ! 5v   !   �� *Name+$ PropertyChanged=�#   ElementStyle# 5}   *   �� 5~   .   " ��64   .�5   2   ��  � ��$
	 Wrap=�6[   5�   /   5�   '     5�   &   $ Số lượng sách��5�   !   $	  110Q�5�   !   $	 110 5�   !   #" [
 5�   !   ! 5�   !   �� *
MinCount+$ PropertyChanged=�# 5�   *   �� 5�   .   " ��64   .�5�   2   ��  � ��$
	 Wrap=�6[   5�   /   5�   '     5�   &   $ Khuyến mãi��5�   !   $	  100Q�5�   !   $	 100 5�   !    0 ,MaterialDesignDataGridTextColumnEditingStyle#" [ 5�   !   ! 5�   !   �� *	Promotion+$ PropertyChanged=�# 5�   *   �� 5�   .   " ��64   .�5�   2   ��  � ��$
	 Wrap=�6[   5�   /   5�   '     5�   &    . $ Mã áp dụng��5�   !   $	  100Q�5�   !   $	 100 60   ! 5�   !   �� *Count+$ �� StringFormat$	$ 0,0��5�   '   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   %   CellTemplate% 5�   *   �� 5�   .   .R�5�   2   �� & ��Name$& 
ButtonEdit��69   ���#3498db���#3498db$��45��5�   d   ' � ToolTip$' Cập nhật��5�   9   {�6L   �� *IsTrueValue+��5�   -   �� ( �� Path$( DataContext.editCommand�) �� RelativeSource) �� *FindAncestor+* �� AncestorType"* 
 ��5�   -   �� .��5�   6     $ Pencil=�6N   
�������$��15��6o   $��15��6{   5�   3   5�   /   5�   '     5�   &   % 5�   *   �� 5�   .   .R�5�   2   �� $& ButtonDelete��69   ���#c0392b���#c0392b$��45��5�   d   $
' Xóa��5�   9   ��5�   -   �� $( DataContext.deleteCommand�) �� *FindAncestor+"* 
 ��5�   -   �� .��5�   6     $ DeleteForever=�6N   
�������$��15��6v   $��15��6�   5�   3   5�   /   5�   '   5�      5�      5�      5�      �� 5�      $��2��6   $��Bottom=�6*   $��Center=�6E   $ 
Horizontal=�6b   $��0,10,0,0q�6{   .+�5�      �� $��5,0,5,0q�6    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5�      $' Trang trước��5�      ���#FFF���#00BFFF$��30��5�      $��30��6!   ��6,   �� *PreviousPageCommand+.��5�        $ ArrowLeftThick=�62   5�      �� 5�      $��5,0,5,0q�6   $' Trang hiện tại��5�      #��[ 5�      ���#FFF���#00BFFF$��30��5�      $��30��6!   ��6,   �� *CurrentPage++ �� FallbackValue$+ 1��5�      �� 5�      $��5,0,5,0q�6   #��[ 5�      $' 
Trang kế��5�      ���#FFF���#00BFFF$��30��5�      $��30��6!   ��6,   �� *NextPageCommand+.��5�        $ ArrowRightThick=�62   5�      5�      5�        5�      $��1��6"   $��10,0,0,0q�62   $	��410��5�   "   $
��Left=�6.   $
��auto��6I   $	��Top=�6W   .��5�      � $	��Top=�6    5�      �� 5�      �� 5�      .+�5�      � $��0��6   ���#29B391$��30��5�   0   $��Stretch=�6<   .+�5�      �� $��Thêm loại mới��6$   $��Center=�69   #��[ 5�   $   $��Center=�6K   
�������6h   5�      �� 5�      $��1��6!    5�      ��%W   '��       �� 5�      " ��6$   .�5�   "   ��  � ��$	 5,5,5,5q�6;   5�      5�      .+�5�      �� $��
Thông tin��6$   $��0,10,0,0q�65   #��[ 5�   $   $��Center=�6K   �� 5�      $��5,0,5,0q�6$   
���   �   MaterialDesignLightSeparator#��[ 5�   $   �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Tên loại: ��6(   #��[ 6:   �� 5�      #��[ 6&   ��6L   �� *Name+$ PropertyChanged=�5�      �� 5     $ 
Horizontal=�6%   .+�5     �� $��Số lượng sách: ��6(   #��[ 6?   �� 5     #��[ 6&   ��6L   �� *Count+$ PropertyChanged=�5     �� 5     $ 
Horizontal=�6%   .+�5     �� $��Khuyến mãi: ��6(   #��[ 6<   �� 5     #��[ 6&   ��6L   �� *	Promotion+$ PropertyChanged=�5	     �� 5     $��5,0,5,0q�6$   
���   �#��[ 5  $   �� 5     $��Thêm��6!   ���#00BFFF���#00BFFF$	��100��5  L   $��	0,10,0,20q�6X   ��5  0   �� *
addCommand+5     5     5     5     5     5     5     