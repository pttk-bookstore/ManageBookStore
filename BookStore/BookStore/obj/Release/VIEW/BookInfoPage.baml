   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  !    BookStore.VIEW.BookInfoPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6	converter&clr-namespace:BookStore.VIEW.Converter     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    BookInfoPageVM � DataContext# [  N� Title$ BookInfoPage�� � 	Resources 4  .BookStore.VIEW.Converter.RoleToEnableConverter  RoleToEnableConverter/  )BookStore.VIEW.Converter.RoleToVisibility  RoleToVisibility �� 
TargetType  ReportStyle �� Property	 �� Value��%c   &	       &	      &	 
         �� " ��.���  � ��$	 15(���  � ��
	 �����.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��auto ��� $��* �.+�� $��0��$��90�� � ColumnDefinitions �� $	��850 ��� $��* �.+�� .+���    MaterialDesignTitleTextBlock#���  $��18(�$	��Top=�$
��Left=�$��10,5,0,0q�Thông tin kho sách#  MaterialDesignThemes.Wpf.Card  $��10,5,0,0q�$	��840��$
��Left=�$��Bottom=�.����  �� Orientation$ 
Horizontal=�$
��auto��.+��� $ 
Horizontal=�$��0��$��10,0,0,0q�$
��Left=�$��Center=�.+��� $	��170��$��15(�$��35��)	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Tìm kiếm������ *FilterString+�� ���#0984e3$��35����Z� ���� *searchCommand+.��'
  !MaterialDesignThemes.Wpf.PackIcon
  $��30��$��30��$��Center=�$��Center=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�
��������� $ 
Horizontal=�$��10,0,0,0q�   
labelStyle��%�   '��       &	 @     �� " ��.���  � ��$	 5,0,5,0q���  � ��$
	 auto���� " ��.���  � ��$	 15(���  � ��	 �#2d3436��  � ��$	 	Underline{�.+��� .+��� $��Center=�.���� $��Thể loại��#��[ �� $ 
Tất cả��$��Center=����� *ListCategory+ �� SelectedItem �� *SelectedItemCategory+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *CategorySelectionChanged+�� .+��� $��Center=�.���� $��Chủ đề��#��[ �� $ 
Tất cả��$��Center=����� *ListSubCategory+ �� *SelectedItemSubCategory+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *SubCategorySelectionChanged+�� .+��� $��Center=�.���� $��
Tác giả��#��[ �� $ 
Tất cả��$��Center=����� *
ListAuthor+ �� *SelectedItemAuthor+
   $ SelectionChanged��.    �� *AuthorSelectionChanged+�� .+��� $��Center=�.���� $��Nhà xuất bản��#��[ �� $ 
Tất cả��$��Center=����� *ListCompany+ �� *SelectedItemCompany+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *CompanySelectionChanged+�� .+��� $��Center=�.���� $��Sắp xếp theo��#��[ �� $ 
Tất cả��$��Center=����� *
ListSortBy+ �� *SelectedItemSortBy+
   $ SelectionChanged��.    �� *SortBySelectionChanged+� $��1��$
��Left=�$��5,0,0,0q�.+�  $
��Left=����#29B391$��Bottom=�$��0,0,0,0q�$	��300��$��8q�   UniformCornerRadius$ 6Q�.���� .+��� $��Tổng sách trong kho��#��[ $��Center=���  	 MaterialDesignDarkSeparator#��[	 
��������� $ 
Horizontal=�$��Center=�.+��� #��[ ���� *	SumNumber+ �� StringFormat$	 0,0���� $��Cuốn��$��5,0,0,0q�#��[ � $��1�� �� $	��850 ��� $��* �.+��� $��0��$
��Left=�$	��Top=�$��10,5,0,0q�.+�  $
��auto��$
��auto��.���� $	��560��$	��840��
����  �4   .BookStore.VIEW.GridViewColumnVisibilityManager   Enabled . ���� *
ListBook+ �� *ListSelectedItem+ !   BookStore.VIEW.BindingProxy 	
 proxy   Data  	WrapStyle �� BasedOn��%�   &	
       &	      '�� J     7��'�� w     7��   �� �� " ��.���  � ��$
	 Wrap=���  � ��$		 120���� " ��8   .���  � ��$	 Stretch=��� " ��8   .���  � ��$	 Center=���  � ��$	 Center=����� " �� �� Triggers P�  P� Property �@J�IsKeyboardFocusWithin P� Value . . ���  �@��
IsSelected	 . 
   $ SelectionChanged��.    �� *ListSelectionChanged+ �� View �� .P��� $	��Mã�� �� CellTemplate �� .R��� ���� *ID+�� $��
Tên sách�� �� .R��� #��[ ���� *Name+�� $��Thể loại�� �� .R��� #��[ ���� *Category.Name+�� $��Chủ đề�� �� .R��� #��[ ���� *SubCategory.Name+�� $��	Tồn kho�� �� .R��� ���� *	Inventory+$	 0,0���� $��	Giá bán�� �� .R��� ���� *PricePromotion+$ 0,0.0���� $��	Đã bán�� �� .R��� ���� *Sole+��    	IsVisible �� *Data.RoleID+ �� 	Converter# [   �� Source#  [
  �� .R��� ���#3498db���#3498db$��45��! � ToolTip$! 
Chi tiết������ " �� Path$!" DataContext.editBookCommand�# �� RelativeSource# �� *FindAncestor+$ �� AncestorType"$ ������ .��
  $ Pencil=�
�������$��15��$��15����  �� *Data.RoleID+# [ #  [
  �� .R��� ���#c0392b���#c0392b$��45��$
! Xóa������ $#" DataContext.deleteBookCommand�# �� *FindAncestor+"$ ������ .��
  $ DeleteForever=�
�������$��15��$��15����  �� *Data.RoleID+# [ #  [
  �� .R�]� $��Center=�.+��� % d� 	IsChecked% �� *	IsChecked+
   $ Checked��.    �� $" DataContext.checkedBook�# �� *FindAncestor+"$ ��&   CommandParameter& ��   $ 	Unchecked��.    �� $" DataContext.uncheckedBook�# �� *FindAncestor+"$ ��& �� �� $��2��$��Bottom=�$��Center=�$ 
Horizontal=�.+��� $��5,0,5,0q� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $! Trang trước�����	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *PreviousPageCommand+.��
  $ ArrowLeftThick=��� $��5,0,5,0q�#��[ $! Trang hiện tại�����	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *CurrentPage+' �� FallbackValue$' 1���� $��5,0,5,0q�#��[ $! 
Trang kế�����	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *NextPageCommand+.��
  $ ArrowRightThick=��� $��1��$
��Left=�$��5,5,0,0q�.+�  $	��300��$	��300��.��� .+��� $��
Ảnh bìa��( K� ZIndex$( 1��
�������$��Medium"�$��15(�$	��0.5�����#FF8C00) �� Padding$) 45,6,0,0q�$$��-37.279,23.989,206.858,245.011q�* J� RenderTransformOrigin$* 0.5,0.5&�z�V� .~��� �� �� + �� Angle$+ -51.104Q�T� �� $��Stretch=����� *
CoverImage+  ���#29B391$��Bottom=�$��0,5,0,0q�$	��300��$��8q�$ 6Q�.���� .+��� $ 
Horizontal=�$��Center=�.+��� $��0,0,3,0q����#0984e3{��� *RoleID+# [ ��Z� ���� *addNewBookCommand+.���� $ 
Horizontal=�.+�
  $ PlusBoxOutline=��� $��Sách mới���� 
����  ��� $��3,0,0,0q����#FF6347{��� *RoleID+# [ ��Z� ���� *increaseBookCommand+.���� $ 
Horizontal=�.+�
  $ PlusBox=��� $��Sách tồn��  ���#29B391$��Bottom=�$��0,5,0,0q�$	��300��$��8q�$ 6Q�$	��162��.���� .+��� $#��Lần nhập kho gần nhất��#��[ $��Center=�$��0,10,0,0q��� #��[	 �� $ 
Horizontal=�.+�
  $ CalendarText=�
�������$��0,0,3,0q��� $��Ngày nhập: ��#��[ $��14(��� #��[ $��14(����� *
LastDate+�� $ 
Horizontal=�$��0,10,0,0q�.+�
  $ LibraryBooks=�
�������$��0,0,3,0q��� $��Tổng sách nhập: ��#��[ $��14(��� #��[ $��14(����� *LastNumberBook+$	 0,0���� $ 
Horizontal=�$��0,10,0,0q�.+�
  $
 Coin=�
�������$��0,0,3,0q��� $��Tổng tiền: ��#��[ $��14(��� #��[ $��14(����� *LastTotalMoney+$ 0,0.0��