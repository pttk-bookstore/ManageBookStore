   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  &     BookStore.VIEW.TypeAndThemsePage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     >myConverter&clr-namespace:BookStore.VIEW.Converter     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    TypeAndThemePageVM � DataContext# [  N� Title$ TypeAndThemePage�� � 	Resources  �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle8   2BookStore.VIEW.Converter.BoolToVisibilityConverter  BoolToVisibilityConverter?   9BookStore.VIEW.Converter.RestoreBoolToVisibilityConverter $	  RestoreBoolToVisibilityConverter��%G  &	       &	 =     &	 �     7  &	     &		     �� " ��.���  � ��$	 15(���  � ��$	 Tahoma)��� " ��.���  � ��$	 15(���  � ��$	 Tahoma)���  � ��$
	 Bold"��� " ��8
   .���  � ��$	 14(���  � ��$	 Center=���  � ��$		 330����  � ��$	 0,0,10,0q�    .  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0��  
 MaterialDesignTitleTextBlock#��� 
 $��18(�$	��Top=�$
��Left=�$��10,5,0,5q�*(Cài đặt thể loại và chủ đề� $��1��$��10,0,0,0q� � ColumnDefinitions �� $
��auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��$	��550��.���  �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�����#29B391$��30��.+��� $��Danh sách thể loại��$��Center=�#��[ $��Center=�
���������  �� Orientation$ 
Horizontal=�$��1��$��	10,10,0,5q�$
��Left=�$��Center=�.+��� $	��300��$��15(�$��35��$��10,0,0,0q�)	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Tên thể loại������ *CategoryName+ �� UpdateSourceTrigger$ PropertyChanged=��� ���#00BFFF$��Thêm��$��35����Z� ���� *addTypeCommand+�� $��2��.+�&
   System.Windows.Controls.DataGrid
  $
��Left=�$��0 0 0 0q�$	��500�� 
  CanUserSortColumns .  
  CanUserAddRows .   
  AutoGenerateColumns .  $	��550��-  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�   ColumnHeaderPadding$ 8q����� *ListCategory+ �� SelectedItem �� *SelectedItemCategory+   $ SelectionChanged��.    �� *CategorySelectionChanged+ !   BookStore.VIEW.BindingProxy 	 proxy   Data��%   &	          ��  
  Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    MinWidth$ 80Q�1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� *ID+9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  $ Tên thể loại��$	 130 $	 130Q� .   5 1MaterialDesignDataGridTextColumnPopupEditingStyle!   EditingElementStyle#! [   �� *Name+$ PropertyChanged=�"   ElementStyle" �� " ��.���  � ��$
	 Wrap=�  $ Đầu sách��$	 100 $	 100Q� .   �� *Count+# �� StringFormat$	# 0,0��4  .System.Windows.Controls.DataGridTemplateColumn  $   
Visibility$ �� *Data.EditColumnVisibility+% �� Source#% [ &   CellTemplate& �� .R��� ' ��Name$' 
ButtonEdit�����#3498db���#3498db$��45��( � ToolTip$( Cập nhật��y��� *	IsExist+) �� 	Converter#) [ {��� *IsTrueValue+���� * �� Path$!* DataContext.editTypeCommand�+ �� RelativeSource+ �� *FindAncestor+, �� AncestorType", 
 ���� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]-   Kind$- Pencil=�
�������$��15��$��15��  $ �� *Data.EditColumnVisibility+#% [ & �� .R��� $' ButtonDelete�����#c0392b���#c0392b$��45��$
( Xóa��y��� *	IsExist+#) [ ���� $#* DataContext.deleteTypeCommand�+ �� *FindAncestor+", 
 ���� .��  $- DeleteForever=�
�������$��15��$��15��  $��1��$	��550��.���  �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�����#29B391$��30��.+��� $ 
Horizontal=�$��Center=�.+��� $1��+Danh sách chủ đề thuộc thể loại��$��Center=�#��[ $��Center=�
��������� $��5,0,0,0q�$��Center=�#��[ $��Center=�
����������� *CurrentType+�� $ 
Horizontal=�$��1��$��	10,10,0,5q�$
��Left=�$��Center=�.+��� $	��300��$��15(�$��35��$��10,0,0,0q�$ Tên thể loại������ *SubCategoryName+$ PropertyChanged=��� ���#00BFFF$��Thêm��$��35����Z� ���� *addThemeCommand+�� $��2��.+�
  $
��Left=�$��0 0 0 0q�$	��500�� .  .   .  $	��550��$ 13 8 8 8q�$ 8q����� *ListSubCategory+ �� *SelectedItemSubCategory+ ��%   &	          ��    $	 Mã�� . $ 80 $ 80Q�  �� *ID+  $ Tên chủ đề��$	 130 $	 130Q� .  #! [   �� *Name+$ PropertyChanged=�" �� " ��.���  � ��$
	 Wrap=�  $ Đầu sách��$	 100 $	 100Q� .   �� *Count+$	# 0,0��  $ �� *Data.EditColumnVisibility+#% [ & �� .R��� $' 
ButtonEdit�����#3498db���#3498db$��45��$( Cập nhật��y��� *	IsExist+#) [ {��� *IsTrueValue+���� $"* DataContext.editThemeCommand�+ �� *FindAncestor+", 
 ���� .��  $- Pencil=�
�������$��15��$��15��  $ �� *Data.EditColumnVisibility+#% [ & �� .R��� $' ButtonDelete�����#c0392b���#c0392b$��45��$
( Xóa��y��� *	IsExist+#) [ ���� $$* DataContext.deleteThemeCommand�+ �� *FindAncestor+", 
 ���� .��  $- DeleteForever=�
�������$��15��$��15��