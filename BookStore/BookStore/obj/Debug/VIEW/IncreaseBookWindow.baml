   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5   	   I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  5   	   '    !BookStore.VIEW.IncreaseBookWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookStore.VIEW     5   	   8uc)clr-namespace:BookStore.VIEW.UserControls     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     MaterialDesignPaper#���  5   	     IncreaseBookWindowVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Title$ IncreaseBookWindow��5   	   $	��590��6$   $
��1090��61    � 	Resources 5       �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle  MaterialDesignComboBox 	 comboboxStyle)  #MaterialDesignThemes.Wpf.HintAssist 
 MaterialDesignRaisedButton  buttonStyle��%�  &	       &	 p     &	     7  &		 �    7  &	 p    7 
 �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$	 15(�6)   �� 5       � ��$	 Tahoma)�6+   �� 5        � ��$
	 Bold"�6+   5!      �� 5#   
   " ��6   8
   .�5$      ��  � ��$	 14(�6)   �� 5%       � ��$	 Center=�62   �� 5&       � ��$		 150��6)   5'      �� 5)   
   " ��6   8
   .�5*      ��  �@��
IsEditable	 . 6+   �� 5+       �@ HintOpacity$		 .26Q�6G   �� 5,       � ��$		 180��6)   �� 5-       � ��$	 14(�6)   5.      �� 50   
   " ��6   8
   .�51      ��  � ��	 �#2c2c546+   �� 52       � ��	 �#2c2c546,   �� 53       � ��$	 30��6'   �� 54       � ��$	 70��6&   �� 55       � ��$	 5,0,5,0q�6'   56      58      .  (System.Windows.Interactivity.Interaction   Triggers 5:      /  )System.Windows.Interactivity.EventTrigger  5;   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5<      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5=      .��5?      �  � RowDefinitions 5@   
   �� 5A      $
��auto �6   �� 5B      $��* �6   .+�5F   
   ,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=�6    K� ZIndex$ 1��60   $��0��6A   � 5G   
   $��1��6    5H      �� 5I      $
��auto �6    �� 5J      $
��auto �6    �� 5K      $��* �6    .+�5O      � $��0��6   ���#2c2c54$��35��65   .+�5P      �� $��Center=�6   $��Center=�68    �� Orientation$ 
Horizontal=�6U   .+�5Q      '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ PlusBox=�6.   $��Center=�6=   $��0,0,10,0q�6X   
�������$��25��5R   A   $��25��6L   �� 5S      $��Nhập thêm sách��6    $��Center=�5T      $��Center=�5U      $��Verdana)�67   
�������$��18(�6_   $��Medium"�6m   5V      5X      �� 5Z      $��1��6   $��	10,10,0,0q�6&   .+�5]      �� $ 
Horizontal=�6   .+�5^        $ Account=�6.   $��Center=�6=   �� 5_      $��Người nhập: ��6    #��[ 65   �� 5`      #��[ 6>   ��6    �� *EmployeeName+6>   �� 5a      $��Ngày nhập: ��6    #��[ 63   $��20,0,0,0q�6Z   �� 5b      #��[ 69   ��6    �� *	DateNow+69   5d      �� 5e      $��
30,10,30,0q�6   � 5f       � ColumnDefinitions 5g      �� 5h      $
��auto �6+   �� 5i      $��* �6+   .+�5l      �� $��0��6!   $��	10,10,0,0q�61   .+�5n      �� $��Danh sách nhập��6$   $��0,0,0,5q�6:   #��[ 6K   $��Center=�6r   #
  MaterialDesignThemes.Wpf.Card
  5q      $
��auto��6.   $
��auto��6<   .��5r      &   System.Windows.Controls.DataGrid  $
��Left=�6'   $��0 0 0 0q�5s      $	��430��5t         CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  $	��765��5y      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5z         ColumnHeaderPadding$ 8q�5{      ��5u      �� *
ListBook+ �� SelectedIndex 5|      �� *ListBookSelectedIndex+ �� SelectedItem 5}      �� *ListBookSelectedItem+ 5~   "     5   &   $ SelectionChanged��65   . 5�   *      6@   �� *ListBookSelectionChanged+5�   '      Columns 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��5�   (      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5�   (      MinWidth$ 80Q�63   1  +System.Windows.Controls.DataGridBoundColumn    Binding  5�   (   �� *ID+5�   '   9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5�   &   $ 
Tên sách��5�   (   $	 130 5�   (   $	 130Q�5�   (    .   5�   (   �� *Name+!   ElementStyle! 5�   *   �� 5�   .   " ��64   .�5�   2   ��  � ��$
	 Wrap=�6[   5�   /   5�   '     5�   &   $ 	Tồn kho��5�   (   $ 80 5�   (   $ 80Q�5�   (    .   5�   (   �� *	Inventory+" �� StringFormat$	" 0,0��5�   '     5�   &   $ Giá nhập��5�   (    5 1MaterialDesignDataGridTextColumnPopupEditingStyle#   EditingElementStyle## [ 5�   )   $	 120 5�   (   $	 120Q�5�   (     5�   (   �� *Price+$" 0,0.0��5�   '     5�   &   $ Số lượng��5�   (   $ 80 5�   (   $ 80Q�5�   (    .  ## [ 5�   (     5�   (   �� *Count+$" 0��$ �� UpdateSourceTrigger$$ PropertyChanged=�5�   '     5�   &   $ Tổng tiền��5�   (   $	 120 5�   (   $	 120Q�5�   (    .   5�   (   �� *
TotalMoney+$" 0,0.0��5�   '   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   %   CellTemplate% 5�   *   �� 5�   .   .R�5�   2   �� & ��Name$& 
ButtonEdit��69   ���#3498db���#3498db$��45��5�   d   ' � ToolTip$' Cập nhật��5�   9   {�6L   �� *IsTrueValue+��5�   -   �� ( �� Path$( DataContext.editCommand�) �� RelativeSource) �� *FindAncestor+* �� AncestorType"*  ��5�   -   �� .��5�   6     $ Pencil=�6N   
�������$��15��6o   $��15��6{   5�   3   5�   /   5�   '     5�   &   % 5�   *   �� 5�   .   .R�5�   2   �� $& ButtonDelete��69   ���#c0392b���#c0392b$��45��5�   d   $
' Xóa��5�   9   ��5�   -   �� $( DataContext.deleteCommand�) �� *FindAncestor+"*  ��5�   -   �� .��5�   6     $ DeleteForever=�6N   
�������$��15��6v   $��15��6�   5�   3   5�   /   5�   '   5�      5�      5�      � 5�      $��1��6   $��	10,33,0,0q�6+   .+�5�      �� $ Vertical=�6%   .+�5�      
  $	��Top=�62   $	��250��6J   $	��250��6V   .��5�   "   �� $��Stretch=�6F   ��6(   �� *
CoverImage+6F   5�      
  5�      $	��178��5�   .   $	��250��6;   $��Center=�5�   .   $��0,3,0,0q�6K   .��5�   "   �� $��0,0,0,0q�6-   .+�5�   &   � $��50��6+   ���#2c2c545�   '   �� 5�   &   $��Tổng tiền��60   $��0,5,0,0q�6A   #��[ 5�   ,   $��Center=�6S   �� 5�   &   $��0,10,0,0q�6a   #��[ 5�   ,   $��Center=�6O   ��5�   0   �� *
TotalPrice+$" 0,0.0��5�   O   �� 5�   &   $��	10,5,10,0q�60   �� 5�   &   $��Nhập sách��6-   $��Center=�6A   $��0,30,0,0q�6^   #��[ 5�   )   $	��120��6N   ��5�   p   �� *
addCommand+5�   N   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      