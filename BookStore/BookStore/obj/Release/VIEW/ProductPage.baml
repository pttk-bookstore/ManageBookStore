   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter       BookStore.VIEW.ProductPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     <	converter&clr-namespace:BookStore.VIEW.Converter     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    ProductPageVM � DataContext# [  N� Title$ ProductPage�� � 	Resources  �� 
TargetType  ReportStyle �� Property	 �� Value=  7BookStore.VIEW.Converter.PromotionToVisibilityConverter " PromotionToVisibilityConverter��%T   &	       &	 ;     �� " ��.���  � ��$	 15(���  � ��
	 �����  .  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��auto ��� .+�� $��1�� K� ZIndex$ 1��$��40��$��40��$��Center=�$��Center=� % !MaterialDesignCircularProgressBar#��[  � Value$ 0Q� � IsIndeterminate �� *IsIndeterminate+� $��0��.+���    MaterialDesignTitleTextBlock#���  $��18(�$��Center=�$��Center=�$��10,5,0,0q�@>Chọn sách sau đó bấm vào giỏ hàng để thanh toán�� 
���  ��$��2q�$��0,5,50,0q����#FF6347$��40��$	��160��$��Right=����� *makeBillCommand+.����  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$
 Cart=�
�������$��25��$��25���� $��Giỏ hàng��$��5,0,0,0q�
�������$��Center=�$��15(���  �� Padding$ 3,0,3,0q�
���   �$��15(�$��10,0,0,0q�
��� ���$��Center=����� *NumberProduct+� $��1�� �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��.+�#	  MaterialDesignThemes.Wpf.Card	  $��	10,5,10,3q�$
��1150��$
��Left=�$��Bottom=�.���� $ 
Horizontal=�$
��auto��.+��� $ 
Horizontal=�$��0��$��10,0,0,0q�$
��Left=�$��Center=�.+��� $	��270��$��15(�$��35��)
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Tìm kiếm������ *FilterString+ �� UpdateSourceTrigger$ PropertyChanged=��� ���#00BFFF$��35����Z� ���� *searchCommand+.��  $��30��$��30��$��Center=�$��Center=�$ Magnify=�
��������� $ 
Horizontal=�$��10,0,0,0q�$
��auto��   
labelStyle��%�   '��       &	 @     �� " ��.���  � ��$	 5,0,5,0q���  � ��$
	 auto���� " ��.���  � ��$	 15(���  � ��	 �#2d3436��  � ��$	 	Underline{�.+��� .+��� $��Center=�.���� $��Thể loại��#��[ �� $ 
Tất cả��$��Center=����� *ListCategory+ �� SelectedItem �� *SelectedItemCategory+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *CategorySelectionChanged+�� .+��� $��Center=�.���� $��Chủ đề��#��[ �� $ 
Tất cả��$��Center=����� *ListSubCategory+ �� *SelectedItemSubCategory+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *SubCategorySelectionChanged+�� .+��� $��Center=�.���� $��
Tác giả��#��[ ��  �� 
IsEditable . $ 
Tất cả��$��Center=����� *
ListAuthor+ �� *SelectedItemAuthor+
   $ SelectionChanged��.    �� *AuthorSelectionChanged+�� .+��� $��Center=�.���� $��Nhà xuất bản��#��[ �� $ 
Tất cả��$��Center=����� *ListCompany+ �� *SelectedItemCompany+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *CompanySelectionChanged+�� .+��� $��Center=�.���� $��Giá tiền��#��[ �� $ 
Tất cả��$��Center=����� *	ListPrice+ �� *SelectedItemPrice+
   $ SelectionChanged��.    �� *PriceSelectionChanged+� $��1��.+��� $��Không tìm thấy sách��$��Center=�$	��Top=�$��30(�$��Medium"�$��0,40,0,0q�y��� *MessTextVisibility+�� $	��580��$	��Top=�$��0,5,0,0q����� *
ListBook+ �� *ListSelectedItem+���� " �� �� Triggers P�  P� Property �@J�IsKeyboardFocusWithin P� Value . . ���  �@��
IsSelected	 . ���� .R�A�  A� Columns$ 4������ .R�� $	��335��$��0,0,0,0q�$	��240��.+��� $ Vertical=�.+��� $	��200��$	��150��$	��Top=�$
��Left=�$��	15,15,0,0q����� *Image+� $��20,5,0,0q� � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��.+��� $��0,0,0,0q�$��WrapWithOverflow=�$	��170��$
��Left=�$��Regular"�$��15(����� *Name+�� $��Light"�$��0,4,0,0q�$��13(����� *Author+�� $ 
Horizontal=�.+��� $��Strikethrough{�$��Black"�$��0,4,0,0q����� *Price+ �� StringFormat$ 0,0đ��y��� *	Promotion+ �� 	Converter# [ �� $��Black"�$��5,4,0,0q����� *PricePromotion+$ 0,0đ���� $ 
Horizontal=�.+��� $��Lượt mua: ��$��0,4,0,0q��� $��0,4,0,0q����� *Sole+$	 0,0���� $ 
Horizontal=�.+��� $��Còn: ��$��0,4,0,0q����#e74c3c$��Medium"��� $��Medium"����#e74c3c$��0,4,0,0q����� *	Inventory+$	 0,0���� $��1�����#3498db���#3498db  � ToolTip$  Thêm vào giỏ��$	��Top=�$��0,0,0,0q�$
��Left=����� ! �� Path$#! DataContext.addProductCommand�" �� RelativeSource" �� *FindAncestor+# �� AncestorType"# ������ .��  $ CartPlus=�$��20��$��20���� $��2��$��Bottom=�$��Center=�$ 
Horizontal=�.+��� $��5,0,5,0q� 0	 ,MaterialDesignFloatingActionMiniAccentButton#��[	 $  Trang trước�����#FFF���#00BFFF$��30��$��30������ *PreviousPageCommand+.��  $ ArrowLeftThick=��� $��5,0,5,0q�#��[	 $  Trang hiện tại�����#FFF���#00BFFF$��30��$��30������ *CurrentPage+$ �� FallbackValue$$ 1���� $��5,0,5,0q�#��[	 $  
Trang kế�����#FFF���#00BFFF$��30��$��30������ *NextPageCommand+.��  $ ArrowRightThick=�