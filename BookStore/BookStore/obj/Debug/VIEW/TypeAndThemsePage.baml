   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5      &     BookStore.VIEW.TypeAndThemsePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      >myConverter&clr-namespace:BookStore.VIEW.Converter     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        TypeAndThemePageVM � DataContext# [ 5       N� Title$ TypeAndThemePage��5       � 	Resources 5       �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle8   2BookStore.VIEW.Converter.BoolToVisibilityConverter  BoolToVisibilityConverter?   9BookStore.VIEW.Converter.RestoreBoolToVisibilityConverter $	  RestoreBoolToVisibilityConverter��%&  &	       &	 p     &	     7  &	 �    &		 �    �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   �� 5        � ��$
	 Bold"�6+   5!      �� 5#   
   " ��6   8
   .�5$      ��  � ��$	 14(�6)   �� 5%       � ��$	 Center=�62   �� 5&       � ��$		 330��6)   �� 5'       � ��$	 0,0,10,0q�6'   5(        5*   
   60     5+   
   67   5,      .  (System.Windows.Interactivity.Interaction   Triggers 5.      /  )System.Windows.Interactivity.EventTrigger  5/   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 50      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+51      .��54      �  � RowDefinitions 55   
   �� 56      $
��Auto �6   �� 57      $��* �6   .+�5;   
   �� $��0��6     
 MaterialDesignTitleTextBlock#��� 
 6!   $��18(�6X   $	��Top=�5<      $
��Left=�60   $��10,5,0,5q�6K   *(Cài đặt thể loại và chủ đề5>      � 5@   
   $��1��6   $��10,0,0,0q�6    � ColumnDefinitions 5A      �� 5B      $
��auto �6#   �� 5C      $��* �6#   .+�5F      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $	��550��62   .��5G      �  5H      �� 5I      $
��auto �6(   �� 5J      $
��auto �6(   �� 5K      $��* �6(   .+�5M      � $��0��6   ���#29B391$��30��6=   .+�5N      �� $��Danh sách thể loại��6$   $��Center=�6>   #��[ 5O   $   $��Center=�6K   
�������6h   5P      �� 5S       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��	10,10,0,5q�6G   $
��Left=�6Z   $��Center=�6u   .+�5U      �� $	��300��6"   $��15(�6.   $��35��6<   $��10,0,0,0q�6H   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Tên thể loại��5V   %   ��6S   �� *CategoryName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5Y      ���#00BFFF$��Thêm��66   $��35��5Z   <   ��6%   Z� ��6H   �� *addTypeCommand+5\      5_      �� 5b      $��2��6!   .+�5c      &
   System.Windows.Controls.DataGrid
  $
��Left=�6#   $��0 0 0 0q�5d      $	��500��5e       
  CanUserSortColumns .  
  CanUserAddRows .   
  AutoGenerateColumns .  $	��550��5j      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5k         ColumnHeaderPadding$ 8q�5l      ��5f      �� *ListCategory+ �� SelectedItem 5m      �� *SelectedItemCategory+ 5n        5o   "   $ SelectionChanged��61   . 5p   &      6<   �� *CategorySelectionChanged+5q   #    5s      !   BookStore.VIEW.BindingProxy 	 proxy   Data��%&   &	         5t   "    6C   �� 5u       
  Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5w   "   ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��5y   !      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5{   !      MinWidth$ 80Q�6,   1  +System.Windows.Controls.DataGridBoundColumn    Binding  5x   !   �� *ID+5|   #   9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5~   "   $ Tên thể loại��5�   !   $	 130 5�   !   $	 130Q�5�   !    .   5 1MaterialDesignDataGridTextColumnPopupEditingStyle!   EditingElementStyle#! [ 5�   !     5   !   �� *Name+$ PropertyChanged=�"   ElementStyle" 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$
	 Wrap=�6W   5�   +   5�   #     5�   "   $ Đầu sách��5�   !   $	 100 5�   !   $	 100Q�5�   !    .   5�   !   �� *Count+# �� StringFormat$	# 0,0��5�   #   4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   $   
Visibility$ 69   �� *Data.EditColumnVisibility+% �� Source#% [ &   CellTemplate& 5�   &   �� 5�   *   .R�5�   .   �� ' ��Name$' 
ButtonEdit��65   ���#3498db���#3498db$��45��5�   d   ( � ToolTip$( Cập nhật��5�   9   y�5�   I   �� *	IsExist+) �� 	Converter#) [ {�5�   L   �� *IsTrueValue+��5�   -   �� * �� Path$!* DataContext.editTypeCommand�+ �� RelativeSource+ �� *FindAncestor+, �� AncestorType", 
 ��5�   -   �� .��5�   2   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]-   Kind$- Pencil=�6J   
�������$��15��6k   $��15��6w   5�   /   5�   +   5�   #     5�   "   $ 69   �� *Data.EditColumnVisibility+#% [ & 5�   &   �� 5�   *   .R�5�   .   �� $' ButtonDelete��65   ���#c0392b���#c0392b$��45��5�   d   $
( Xóa��5�   9   y�5�   K   �� *	IsExist+#) [ ��5�   -   �� $#* DataContext.deleteTypeCommand�+ �� *FindAncestor+", 
 ��5�   -   �� .��5�   2     $- DeleteForever=�6J   
�������$��15��6r   $��15��6~   5�   /   5�   +   5�   #   5�      5�      5�      5�        5�      $��1��6"   $	��550��62   .��5�      �  5�      �� 5�      $
��auto �6(   �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   ���#29B391$��30��6F   .+�5�      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5�      �� $1��+Danh sách chủ đề thuộc thể loại��6(   $��Center=�6O   #��[ 5�   $   $��Center=�6K   
�������6h   �� 5�      $��5,0,0,0q�6E   $��Center=�6V   #��[ 5�   (   $��Center=�6O   
���������5�   (   �� *CurrentType+5�   l   5�      5�      �� 5�      $ 
Horizontal=�6!   $��1��6:   $��	10,10,0,5q�6G   $
��Left=�6Z   $��Center=�6u   .+�5�      �� $	��300��6"   $��15(�6.   $��35��6<   $��10,0,0,0q�6H   $ Tên thể loại��5�   %   ��6S   �� *SubCategoryName+$ PropertyChanged=��� 5�      ���#00BFFF$��Thêm��66   $��35��5�   <   ��6%   Z� ��6H   �� *addThemeCommand+5�      5�      �� 5�      $��2��6!   .+�5�      
  $
��Left=�6#   $��0 0 0 0q�5�      $	��500��5�       .  .   .  $	��550��5�      $ 13 8 8 8q�5�      $ 8q�5�      ��5�      �� *ListSubCategory+ 5�      �� *SelectedItemSubCategory+ 5�      ��%&   &	         5�   "    6C   �� 5�       5�        5�   "   $	 Mã��5�   !    . $ 80 5�   !   $ 80Q�6,     5�   !   �� *ID+5�   #     5�   "   $ Tên chủ đề��5�   !   $	 130 5�   !   $	 130Q�5�   !    .  #! [ 5�   !     5�   !   �� *Name+$ PropertyChanged=�" 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$
	 Wrap=�6W   5�   +   5�   #     5   "   $ Đầu sách��5  !   $	 100 5  !   $	 100Q�5  !    .   5  !   �� *Count+$	# 0,0��5  #     5  "   $ 69   �� *Data.EditColumnVisibility+#% [ & 5	  &   �� 5
  *   .R�5  .   �� $' 
ButtonEdit��65   ���#3498db���#3498db$��45��5  d   $( Cập nhật��5  9   y�5  I   �� *	IsExist+#) [ {�5  L   �� *IsTrueValue+��5  -   �� $"* DataContext.editThemeCommand�+ �� *FindAncestor+", 
 ��5  -   �� .��5  2     $- Pencil=�6J   
�������$��15��6k   $��15��6w   5  /   5  +   5  #     5  "   $ 69   �� *Data.EditColumnVisibility+#% [ & 5  &   �� 5  *   .R�5  .   �� $' ButtonDelete��65   ���#c0392b���#c0392b$��45��5  d   $
( Xóa��5  9   y�5  K   �� *	IsExist+#) [ ��5  -   �� $$* DataContext.deleteThemeCommand�+ �� *FindAncestor+", 
 ��5  -   �� .��5  2     $- DeleteForever=�6J   
�������$��15��6r   $��15��6~   5  /   5   +   5"  #   5&     5(     5)     5*     5,     5.     5/     