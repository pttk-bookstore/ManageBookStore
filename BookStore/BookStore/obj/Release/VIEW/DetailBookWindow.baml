   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  %    BookStore.VIEW.DetailBookWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:BookStore.VIEW     8uc)clr-namespace:BookStore.VIEW.UserControls     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���    MaterialDesignPaper#���   � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Title$ DetailsBookWindow��$	��650��$
��1000�� � 	Resources  �� 
TargetType  	nameStyle �� Property �� Value  nameBoldStyle  MaterialDesignTextBox	 �� BasedOn  textboxStyle  MaterialDesignComboBox  comboboxStyle)  #MaterialDesignThemes.Wpf.HintAssist 	 MaterialDesignRaisedButton 
 buttonStyle��%=  &	       &	 =     &	 �     7  &	 �     7  &	
 n    7 	 �� " ��.���  � ��$ 15(���  � ��$ Tahoma)��� " ��.���  � ��$
 14.5(���  � ��$ Tahoma)���  � ��$
 Bold"��� " ��8	   .���  � ��$ 14(���  � ��$ Center=���  � ��$	 180���� " ��8	   .���  �@��
IsEditable .  ��  �@ HintOpacity$	 .26Q���  � ��$	 180����  � ��$ 14(��� " ��8	   .���  � �� �#2c2c54��  � �� �#2c2c54��  � ��$ 30����  � ��$ 70����  � ��$ 5,0,5,0q�.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��auto ��� $��* �.+�,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=� K� ZIndex$ 1��$��0��� $��1�� �� $
��auto ��� $��* �.+�� $��0�����#29B391$��35��.+��� $��Thông tin chi tiết��$��Center=�$��Center=�$��Verdana)�
�������$��18(�$��Medium"��� $��1��$��	10,10,0,0q�.+���  �� Orientation$ 
Horizontal=�.+��� $��
ID sách: ��#��[ �� #��[ ���� *ID+�� $��
30,10,30,0q��� $��Thông tin sách��$��0,5,0,0q�$��17(�$��Center=�#��[ � $��0,10,0,0q�$
��auto�� � ColumnDefinitions �� $	��600 ��� $��* �.+��� .+�� $��0�� ��%2   '��       �� " ��.���  � ��$ 5,5,5,5q�.+��� $ 
Horizontal=�.+��� $��Center=�$��Tên sách: ��#��[ �� #��[    Hint$ 
Tên sách������ *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� $ 
Horizontal=�.+��� $��Center=�$��Tác giả: ��#��[ �� #��[ $ Tên tác giả������ *Author+$ PropertyChanged=��� $ 
Horizontal=�.+��� $��Center=�$��Thể loại: ��#��[ �� #��[ $ Chọn thể loại��$��Center=����� *ListCategory+ �� SelectedItem �� *SelectedItemCategory+���� .R��� ���� *Name+
   $ SelectionChanged��.    �� *CategorySelectionChanged+�� $ 
Horizontal=�.+��� $��Center=�$��Chủ đề: ��#��[ �� #��[ $ Chọn chủ đề��$��Center=����� *ListSubCategory+ �� *SelectedItemSubCategory+���� .R��� ���� *Name+�� $ 
Horizontal=�.+��� $��Center=�$��Nhà xuất bản: ��#��[ �� #��[ $ Chọn nhà xuất bản��$��Center=����� *ListCompany+ �� *SelectedItemCompany+���� .R��� ���� *Name+�� $��
10,10,10,0q��� $��Số lượng sách tồn��#��[ $��Center=�$��0,10,0,5q��� .+��� $ 
Horizontal=�$��Center=�.+��� $��Tổng sách tồn: ��#��[ $��Center=��� $��Center=�$��0,3,0,0q�$��15(����� *	Inventory+�� $��Số lượng bán ra: ��#��[ $��Center=�$��70,0,0,0q��� $��Center=�$��0,3,0,0q�$��15(����� *Sold+ �� StringFormat$	 0,0����   MaterialDesignCheckBox#��[ $��14(�$��	100,0,0,0q�$��Hiển thị tất cả�� d� 	IsChecked �� *	IsChecked+$ PropertyChanged=����� *CheckedCommand+#  MaterialDesignThemes.Wpf.Card  $	��220��$��0,10,0,0q�.���� ���� *ListWarehouse+ �� View �� .P��� $��
Mã nhập�� �� CellTemplate �� .R��� ���� *TransactionID+�� $��Ngày nhập�� �� .R��� ���� *DateTransaction+�� $��Loại nhập�� �� .R��� ���� *TypeTransaction+�� $��Số lượng tồn�� �� .R��� ���� *Count+$	 0,0���� $��Giá nhập�� �� .R��� ���� *Price+$ 0,0.0���� $��
10,10,10,0q��� $��Thông tin giá cả��#��[ $��Center=�$��0,5,0,0q��� $ 
Horizontal=�$��0,10,0,0q� ��%R   '��       7  �� " ��8	   .���  � ��$ 5,0,5,0q���  � ��$	 100��.+��� $��Giá bán gốc: ��#��[ �� -   $ 50000������ *
OutPrice+$ PropertyChanged=�.��
   $ TextChanged��.    �� *OutPriceTextChanged+.���� $��Khuyến mãi: ��#��[ �� $ 50000��$��80������ *	Promotion+$ PropertyChanged=�.��
   $ TextChanged��.    �� *PromotionTextChanged+.���� $��Giá bán ra: ��#��[ �� -   $ 0�� �� 
IsReadOnly . ���� *OutPricePromotion+$ 0,0.0���� $��1��$	��Top=�$
��Left=�.+�  $	��350��$	��350��$	��Top=�$
��Left=�$��10,0,0,0q�.��� .+��� $ 1�����#2ecc71���#2ecc71$��70��$��40��$��Right=�$	��Top=�$��0,5,5,0q����� *imageCommand+.���� $ 
Horizontal=�.+�'	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 
  Kind$ 	ImagePlus=�
�������$��30��$��30��$��Center=��� $ 0������ *
CoverImage+$ PropertyChanged=��� $��40��$	��120�����#00BFFF���#3498db$��
130,20,0,0q�$	��Top=�$
��Left=����� *updateCommand+.���� $��Cập nhật��$��16(�