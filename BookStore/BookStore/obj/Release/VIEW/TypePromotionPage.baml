   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  &     BookStore.VIEW.TypePromotionPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6	converter&clr-namespace:BookStore.VIEW.Converter     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    TypePromotionPageVM � DataContext# [  N� Title$ TypePromotionPage�� � 	Resources  �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle��%)  &	       &	 =     &	 �     7  �� " ��.���  � ��$	 15(���  � ��$	 Tahoma)��� " ��.���  � ��$	 15(���  � ��$	 Tahoma)���  � ��$
	 Bold"��� " ��8
   .���  � ��$	 14(���  � ��$	 Center=���  � ��$		 330����  � ��$	 0,0,10,0q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0��   MaterialDesignTitleTextBlock#���  $��18(�$	��Top=�$
��Left=�$��10,5,0,5q�" Cài đặt loại khuyến mãi� $��1��$��10,0,0,0q� � ColumnDefinitions �� $
��auto ��� $��* �.+��� .+�#  MaterialDesignThemes.Wpf.Card  .���  �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�����#29B391$��30��.+��� $%��Danh sách loại khuyến mãi��$��Center=�#��[ $��Center=�
���������  �� Orientation$ 
Horizontal=�$��1��$��	10,10,0,5q�$
��Left=�$��Center=�.+��� $	��300��$��15(�$��35��$��10,0,0,0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm������ *FilterString+ �� UpdateSourceTrigger$ PropertyChanged=��� ���#00BFFF$��35����Z� ���� *searchCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��Center=�$��Center=��	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Magnify=�
��������� $��2��.+�&
   System.Windows.Controls.DataGrid
  $
��Left=�$��0 0 0 0q�$	��500�� 
  CanUserSortColumns .  
  CanUserAddRows .   
  AutoGenerateColumns .  $	��730��-  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�   ColumnHeaderPadding$ 8q����� *
ListType+ �� SelectedItem �� *SelectedItem+ !   BookStore.VIEW.BindingProxy 		 proxy   Data��%   &		          ��  
  Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80     MinWidth$  80Q�1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� *ID+9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  $
 Tên��$	 130 $	  130Q� 5
 1MaterialDesignDataGridTextColumnPopupEditingStyle"   EditingElementStyle#" [
 ! �� *Name+$ PropertyChanged=�#   ElementStyle# �� " ��.���  � ��$
	 Wrap=�  $ Số lượng sách��$	  110Q�$	 110 #" [
 ! �� *
MinCount+$ PropertyChanged=�# �� " ��.���  � ��$
	 Wrap=�  $ Khuyến mãi��$	  100Q�$	 100  0 ,MaterialDesignDataGridTextColumnEditingStyle#" [ ! �� *	Promotion+$ PropertyChanged=�# �� " ��.���  � ��$
	 Wrap=�   . $ Mã áp dụng��$	  100Q�$	 100 ! �� *Count+$ �� StringFormat$	$ 0,0��4  .System.Windows.Controls.DataGridTemplateColumn  %   CellTemplate% �� .R��� & ��Name$& 
ButtonEdit�����#3498db���#3498db$��45��' � ToolTip$' Cập nhật��{��� *IsTrueValue+���� ( �� Path$( DataContext.editCommand�) �� RelativeSource) �� *FindAncestor+* �� AncestorType"* 
 ���� .��  $ Pencil=�
�������$��15��$��15��  % �� .R��� $& ButtonDelete�����#c0392b���#c0392b$��45��$
' Xóa������ $( DataContext.deleteCommand�) �� *FindAncestor+"* 
 ���� .��  $ DeleteForever=�
�������$��15��$��15���� $��2��$��Bottom=�$��Center=�$ 
Horizontal=�$��0,10,0,0q�.+��� $��5,0,5,0q� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $' Trang trước�����#FFF���#00BFFF$��30��$��30������ *PreviousPageCommand+.��  $ ArrowLeftThick=��� $��5,0,5,0q�$' Trang hiện tại��#��[ ���#FFF���#00BFFF$��30��$��30������ *CurrentPage++ �� FallbackValue$+ 1���� $��5,0,5,0q�#��[ $' 
Trang kế�����#FFF���#00BFFF$��30��$��30������ *NextPageCommand+.��  $ ArrowRightThick=�  $��1��$��10,0,0,0q�$	��410��$
��Left=�$
��auto��$	��Top=�.��� $	��Top=� �� �� .+�� $��0�����#29B391$��30��$��Stretch=�.+��� $��Thêm loại mới��$��Center=�#��[ $��Center=�
��������� $��1�� ��%2   '��       �� " ��.���  � ��$	 5,5,5,5q�.+��� $��
Thông tin��$��0,10,0,0q�#��[ $��Center=��� $��5,0,5,0q�
���   �   MaterialDesignLightSeparator#��[ �� $ 
Horizontal=�.+��� $��Tên loại: ��#��[ �� #��[ ���� *Name+$ PropertyChanged=��� $ 
Horizontal=�.+��� $��Số lượng sách: ��#��[ �� #��[ ���� *Count+$ PropertyChanged=��� $ 
Horizontal=�.+��� $��Khuyến mãi: ��#��[ �� #��[ ���� *	Promotion+$ PropertyChanged=��� $��5,0,5,0q�
���   �#��[ �� $��Thêm�����#00BFFF���#00BFFF$	��100��$��	0,10,0,20q����� *
addCommand+