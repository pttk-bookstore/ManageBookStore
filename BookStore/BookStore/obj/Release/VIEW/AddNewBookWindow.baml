   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  %    BookStore.VIEW.AddNewBookWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:BookStore.VIEW     8uc)clr-namespace:BookStore.VIEW.UserControls     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���    MaterialDesignPaper#���    AddNewBookWindowVM � DataContext# [  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Title$ AddNewBookWindow��$	��700��$
��1000�� � 	Resources  �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle  MaterialDesignComboBox 	 comboboxStyle)  #MaterialDesignThemes.Wpf.HintAssist 
 MaterialDesignRaisedButton  buttonStyle��%;  &	       &	 =     &	 �     7  &		 �     7  &	 l    7 
 �� " ��.���  � ��$	 15(���  � ��$	 Tahoma)��� " ��.���  � ��$	 15(���  � ��$	 Tahoma)���  � ��$
	 Bold"��� " ��8
   .���  � ��$	 14(���  � ��$	 Center=���  � ��$		 180���� " ��8
   .���  �@��
IsEditable	 .  ��  �@ HintOpacity$		 .26Q���  � ��$		 180����  � ��$	 14(��� " ��8
   .���  � ��	 �#2c2c54��  � ��	 �#2c2c54��  � ��$	 30����  � ��$	 70����  � ��$	 5,0,5,0q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � ColumnDefinitions �� $	��45* ��� $	��79* � � RowDefinitions �� $
��auto ��� $��* �.+�,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=� K� ZIndex$ 1��$��0��$��2��� $��1��$��2�� �� $
��auto ��� $��* �.+�� $��0�����#29B391$��35��.+��� $��Nhập sách mới��$��Center=�$��Center=�$��Verdana)�
�������$��16(�$��Medium"��� $��1��$��	10,10,0,0q�.+���  �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Account=�$��Center=��� $��Người nhập: ��#��[ $��Medium"�$��14(��� #��[ ���� *EmployeeName+�� $��Ngày nhập: ��#��[ $��20,0,0,0q�$��Medium"�$��14(��� #��[ ���� *	DateNow+�� $��
30,10,30,0q��� $��Thông tin sách��$��0,5,0,0q�$��17(�$��Medium"�$��Center=�#��[ � $��0,10,0,0q�$	��173�� �� $	��600 ��� $��* �.+��� .+�� $��0�� ��%2   '��       �� " ��.���  � ��$	 5,5,5,5q�.+��� $ 
Horizontal=�.+��� $��Bottom=�$��Tên sách: ��#��[ $��Medium"�$��14(��� #��[    Hint$ 
Tên sách������ *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� $ 
Horizontal=�$��50,0,0,0q�.+��� $��Bottom=�$��Tác giả: ��#��[ $��Medium"�$��14(��� #��[ $ Tên tác giả������ *Author+$ PropertyChanged=��� $ 
Horizontal=�.+��� $��Bottom=�$��Thể loại: ��#��[ $��Medium"�$��14(��� #��[	 $ Chọn thể loại��$��Center=����� *ListCategory+ �� SelectedItem �� *SelectedItemCategory+���� .R��� ���� *Name+   $ SelectionChanged��.    �� *CategorySelectionChanged+�� $ 
Horizontal=�$��60,0,0,0q�.+��� $��Bottom=�$��Chủ đề: ��#��[ $��Medium"�$��14(��� #��[	 $ Chọn chủ đề��$��Center=����� *ListSubCategory+ �� *SelectedItemSubCategory+���� .R��� ���� *Name+�� $ 
Horizontal=�.+��� $��Bottom=�$��Nhà xuất bản: ��#��[ $��Medium"�$��14(��� #��[	 $ Chọn nhà xuất bản��$��Center=����� *ListCompany+ �� *SelectedItemCompany+���� .R��� ���� *Name+�� $ 
Horizontal=�$��0,10,0,0q� ��%R   '��       7  �� " ��8
   .���  � ��$	 5,0,5,0q���  � ��$		 100��.+��� $��Bottom=�$��Giá nhập: ��#��[ $��Medium"�$��14(�$��5,0,0,0q��� -   $ 50000������ *	InPrice+$ PropertyChanged=�.��   $ TextChanged��.    �� *InPriceTextChange+.���� $��Số lượng: ��$��Bottom=�#��[ $��Medium"�$��14(��� -   $ 50000��$��80������ *WarehouseInventory+$ PropertyChanged=�.��   $ TextChanged��.    �� *CountTextChange+.���� $��Tổng tiền: ��$��Bottom=�#��[ $��Medium"�$��14(��� $ 0�� �� 
IsReadOnly . ���� *
TotalPrice+ �� StringFormat$ 0,0.0��#
  MaterialDesignThemes.Wpf.Card
  $��1��$	��173��$	��200��$	��Top=�$
��Left=�$��10,0,0,0q�.��� .+��� $ 1�����#2ecc71���#2ecc71$��50��$��25��$��Right=�$	��Top=�$��0,5,5,0q����� *imageCommand+.���� $ 
Horizontal=�.+�  $ 	ImagePlus=�
�������$��15��$��Center=��� $ 0��$��0,0,0,10q����� *
CoverImage+$ PropertyChanged=��  �� $
��auto ��� $��* �.+��� $ 
Horizontal=�$��0��.+��� $��Thêm��#��[ ���#00BFFF$��0q����� *addToListCommand+�� $��Sửa��#��[ ���#FFA500$��0q����� *editListCommand+�� $
��Xóa��#��[ ���#FF6347$��0q����� *deleteListCommand+�� #��[ $��Nhập sách��$��0q�$	��100��$��0,0,50,0q�$��Right=����#29B391���� *
addCommand+
  $	��328��$��1��$��0,10,10,-62q�.���� $��0,0,0,10q����� *
ListBook+ �� SelectedIndex �� *ListSelectedIndex+ �� *ListSelectedItem+   $ SelectionChanged��.    �� *ListSelectionChanged+ �� View �� .P��� $��
Tên sách�� �� CellTemplate �� .R��� ���� *Name+�� $��
Tác giả�� �� .R��� ���� *Author+�� $��Thể loại�� �� .R��� ���� *Category.Name+�� $��Chủ đề�� �� .R��� ���� *SubCategory.Name+�� $	��NXB�� �� .R��� ���� *Company.Name+�� $��Số lượng�� �� .R��� ���� *Count+$	 0,0���� $��Giá nhập�� �� .R��� ���� *Price+$ 0,0.0���� $��Tổng tiền�� �� .R��� ���� *
TotalMoney+$ 0,0.0��