   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5           BookStore.VIEW.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      <	converter&clr-namespace:BookStore.VIEW.Converter     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        ProductPageVM � DataContext# [ 5       N� Title$ ProductPage��5       � 	Resources 5       �� 
TargetType  ReportStyle �� Property	 �� Value=  7BookStore.VIEW.Converter.PromotionToVisibilityConverter " PromotionToVisibilityConverter��%�   &	       &	 n     �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��
	 �����6+   5        5   
   63   5      .  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��auto �6   �� 5%      .+�5'   
   � $��1��6    K� ZIndex$ 1��6#   $��40��64   $��40��6@   $��Center=�6K   $��Center=�5(       % !MaterialDesignCircularProgressBar#��[ 5)       � Value$ 0Q�5*       � IsIndeterminate 5+      �� *IsIndeterminate+� 5,   
   $��0��6   .+�5.      ��    MaterialDesignTitleTextBlock#���  5/      $��18(�6H   $��Center=�50      $��Center=�63   $��10,5,0,0q�6P   @>Chọn sách sau đó bấm vào giỏ hàng để thanh toán52      �� 55      
���  ��$��2q�6'   $��0,5,50,0q�56      ���#FF6347$��40��57      $	��160��6!   $��Right=�6-   ��55   ;   �� *makeBillCommand+.��58      ��  �� Orientation$ 
Horizontal=�6   .+�59      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$
 Cart=�6.   
�������$��25��6M   $��25��6X   �� 5:      $��Giỏ hàng��6    $��5,0,0,0q�60   
�������$��Center=�6T   $��15(�6o   �� 5;       �� Padding$ 3,0,3,0q�6?   
���   �$��15(�6d   $��10,0,0,0q�5<   $   
��� ���$��Center=�6J   ��5;       �� *NumberProduct+5<   J   5=      5>      5@      � 5A   
   $��1��6    5B      �� 5C      $
��auto �6    �� 5D      $��* �6    �� 5E      $
��auto �6    .+�5G      �� $��0��6   .+�5I      #	  MaterialDesignThemes.Wpf.Card	  $��	10,5,10,3q�6&   $
��1150��69   $
��Left=�6F   $��Bottom=�6a   .��5J      �� $ 
Horizontal=�6!   $
��auto��6:   .+�5M      �� $ 
Horizontal=�6%   $��0��6>   $��10,0,0,0q�6K   $
��Left=�6]   $��Center=�6x   .+�5O      �� $	��270��6&   $��15(�62   $��35��6@   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Tìm kiếm��5P   %   ��6O   �� *FilterString+ �� UpdateSourceTrigger$ PropertyChanged=��� 5S      ���#00BFFF$��35��6Q   ��6:   Z� ��6]   �� *searchCommand+.��5T   "     $��30��6:   $��30��6F   $��Center=�6Q   $��Center=�6n   $ Magnify=�5U      
�������6$   5V      5W      �� 5Z      $ 
Horizontal=�6%   $��10,0,0,0q�6>   $
��auto��6P    5[        
labelStyle��%$  '��       &	 s     �� 5\   "   " ��6(   .�5]   &   ��  � ��$	 5,0,5,0q�6?   �� 5^   &    � ��$
	 auto��6>   5_   #   �� 5`   "   " ��6(   .�5a   &   ��  � ��$	 15(�6A   �� 5b   &    � ��	 �#2d34366C   �� 5c   &    � ��$	 	Underline{�6H   5d   #   5e      .+�5f      �� .+�5g   "   �� $��Center=�6)   .��5h   &   �� $��Thể loại��60   #��[ 6@   5i   #   �� 5j   "   $ 
Tất cả��5l   +   $��Center=�6S   ��5j   +   �� *ListCategory+ �� SelectedItem 5k   +   �� *SelectedItemCategory+��5m   &   �� 5n   *   .R�5o   .   �� ��68   �� *Name+5p   +   
 5r   &     5s   *   $ SelectionChanged��69   . 5t   .      6D   �� *CategorySelectionChanged+5u   +   5w   #   5x      �� 5z      .+�5{   "   �� $��Center=�6)   .��5|   &   �� $��Chủ đề��60   #��[ 6>   5}   #   �� 5~   "   $ 
Tất cả��5�   +   $��Center=�6S   ��5~   +   �� *ListSubCategory+ 5   +   �� *SelectedItemSubCategory+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *Name+5�   +   
 5�   &     5�   *   $ SelectionChanged��69   . 5�   .      6D   �� *SubCategorySelectionChanged+5�   +   5�   #   5�      �� 5�      .+�5�   "   �� $��Center=�6)   .��5�   &   �� $��
Tác giả��60   #��[ 6?   5�   #   �� 5�   "    �� 
IsEditable . $ 
Tất cả��5�   +   $��Center=�6S   ��5�   +   �� *
ListAuthor+ 5�   +   �� *SelectedItemAuthor+
 5�   &     5�   *   $ SelectionChanged��69   . 5�   .      6D   �� *AuthorSelectionChanged+5�   +   5�   #   5�      �� 5�      .+�5�   "   �� $��Center=�6)   .��5�   &   �� $��Nhà xuất bản��60   #��[ 6D   5�   #   �� 5�   "   $ 
Tất cả��5�   +   $��Center=�6S   ��5�   +   �� *ListCompany+ 5�   +   �� *SelectedItemCompany+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *Name+5�   +   
 5�   &     5�   *   $ SelectionChanged��69   . 5�   .      6D   �� *CompanySelectionChanged+5�   +   5�   #   5�      �� 5�      .+�5�   "   �� $��Center=�6)   .��5�   &   �� $��Giá tiền��60   #��[ 6@   5�   #   �� 5�   "   $ 
Tất cả��5�   +   $��Center=�6S   ��5�   +   �� *	ListPrice+ 5�   +   �� *SelectedItemPrice+
 5�   &     5�   *   $ SelectionChanged��69   . 5�   .      6D   �� *PriceSelectionChanged+5�   +   5�   #   5�      5�      5�      5�      5�      � 5�      $��1��6   .+�5�      �� $��Không tìm thấy sách��6   $��Center=�67   $	��Top=�5�      $��30(�60   $��Medium"�6>   $��0,40,0,0q�6R   y�6d   �� *MessTextVisibility+�� 5�      $	��580��5�      $	��Top=�6+   $��0,5,0,0q�5�      ��5�      �� *
ListBook+ 5�   ,   �� *ListSelectedItem+��5�      �� 5�      " ��6     �� Triggers 5�      P� 5�   "    P� Property �@J�IsKeyboardFocusWithin P� Value . . �5�   &   ��  �@��
IsSelected	 . 6C   5�   #   5�      ��5�      �� 5�      .R�5�      A�  A� Columns$ 4��6*   5�      ��5�      �� 5�      .R�5�      � $	��335��6#   $��0,0,0,0q�60   $	��240��6A   .+�5�   "   �� $ Vertical=�6-   .+�5�   &   �� $	��200��6E   $	��150��6R   $	��Top=�6^   $
��Left=�6v   $��	15,15,0,0q�6�   ��6,   �� *Image+6�   � 5�   &   $��20,5,0,0q�6+    � ColumnDefinitions 5�   *   �� 5�   .   $
��auto �6?   �� 5�   .   $��* �6?   .+�5�   *   �� $��0��65   .+�5�   .   �� $��0,0,0,0q�5�   4   $��WrapWithOverflow=�6E   $	��170��6e   $
��Left=�6q   $��Regular"�6�   $��15(�6�   ��5�   8   �� *Name+5�   /   �� 5�   .   $��Light"�6P   $��0,4,0,0q�6c   $��13(�6t   ��68   �� *Author+6t   �� 5�   .   $ 
Horizontal=�69   .+�5�   2   �� $��Strikethrough{�6�   $��Black"�6�   $��0,4,0,0q�6�   ��6<   �� *Price+ �� StringFormat$ 0,0đ��y�6g   �� *	Promotion+ �� 	Converter# [ 6�   �� 5�   2   $��Black"�6q   $��5,4,0,0q�6�   ��6<   �� *PricePromotion+$ 0,0đ��6�   5�   /   �� 5�   .   $ 
Horizontal=�69   .+�5�   2   �� $��Lượt mua: ��6<   $��0,4,0,0q�6N   �� 5�   2   $��0,4,0,0q�6e   ��6<   �� *Sole+$	 0,0��6e   5�   /   �� 5�   .   $ 
Horizontal=�69   .+�5�   2   �� $��Còn: ��6<   $��0,4,0,0q�6I   ���#e74c3c$��Medium"�6o   �� 5�   2   $��Medium"�6j   ���#e74c3c$��0,4,0,0q�6�   ��6<   �� *	Inventory+$	 0,0��6�   5�   /   5  +   �� 5  *   $��1��61   ���#3498db���#3498db  � ToolTip$  Thêm vào giỏ��5  1   $	��Top=�5  1   $��0,0,0,0q�6I   $
��Left=�6Z   ��5  1   �� ! �� Path$#! DataContext.addProductCommand�" �� RelativeSource" �� *FindAncestor+# �� AncestorType"# ����5  1   �� .��5  .     $ CartPlus=�6F   $��20��6V   $��20��6b   5  +   5
  '   5  #   5     5     5     5     �� 5     $��2��6   $��Bottom=�6&   $��Center=�6A   $ 
Horizontal=�6^   .+�5     �� $��5,0,5,0q�6    0	 ,MaterialDesignFloatingActionMiniAccentButton#��[	 5     $  Trang trước��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *PreviousPageCommand+.��5       $ ArrowLeftThick=�6.   5     �� 5     $��5,0,5,0q�6   #��[	 5     $  Trang hiện tại��5     ���#FFF���#00BFFF$��30��5     $��30��6!   ��6,   �� *CurrentPage+$ �� FallbackValue$$ 1��5      �� 5!     $��5,0,5,0q�6   #��[	 5"     $  
Trang kế��5#     ���#FFF���#00BFFF$��30��5%     $��30��6!   ��6,   �� *NextPageCommand+.��5&       $ ArrowRightThick=�6.   5'     5(     5)     5*     5+     