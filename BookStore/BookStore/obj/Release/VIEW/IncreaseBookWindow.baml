   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  '    !BookStore.VIEW.IncreaseBookWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:BookStore.VIEW     8uc)clr-namespace:BookStore.VIEW.UserControls     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont#���    MaterialDesignPaper#���    IncreaseBookWindowVM � DataContext# [  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Title$ IncreaseBookWindow��$	��590��$
��1090�� � 	Resources  �� 
TargetType  	nameStyle �� Property	 �� Value  nameBoldStyle  MaterialDesignTextBox
 �� BasedOn  textboxStyle  MaterialDesignComboBox 	 comboboxStyle)  #MaterialDesignThemes.Wpf.HintAssist 
 MaterialDesignRaisedButton  buttonStyle��%;  &	       &	 =     &	 �     7  &		 �     7  &	 l    7 
 �� " ��.���  � ��$	 15(���  � ��$	 Tahoma)��� " ��.���  � ��$	 15(���  � ��$	 Tahoma)���  � ��$
	 Bold"��� " ��8
   .���  � ��$	 14(���  � ��$	 Center=���  � ��$		 150���� " ��8
   .���  �@��
IsEditable	 . ��  �@ HintOpacity$		 .26Q���  � ��$		 180����  � ��$	 14(��� " ��8
   .���  � ��	 �#2c2c54��  � ��	 �#2c2c54��  � ��$	 30����  � ��$	 70����  � ��$	 5,0,5,0q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadCommand+.���  � RowDefinitions �� $
��auto ��� $��* �.+�,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=� K� ZIndex$ 1��$��0��� $��1�� �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�����#2c2c54$��35��.+��� $��Center=�$��Center=� �� Orientation$ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ PlusBox=�$��Center=�$��0,0,10,0q�
�������$��25��$��25���� $��Nhập thêm sách��$��Center=�$��Center=�$��Verdana)�
�������$��18(�$��Medium"��� $��1��$��	10,10,0,0q�.+��� $ 
Horizontal=�.+�  $ Account=�$��Center=��� $��Người nhập: ��#��[ �� #��[ ���� *EmployeeName+�� $��Ngày nhập: ��#��[ $��20,0,0,0q��� #��[ ���� *	DateNow+�� $��
30,10,30,0q��  � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��	10,10,0,0q�.+��� $��Danh sách nhập��$��0,0,0,5q�#��[ $��Center=�#
  MaterialDesignThemes.Wpf.Card
  $
��auto��$
��auto��.��&   System.Windows.Controls.DataGrid  $
��Left=�$��0 0 0 0q�$	��430��   CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  $	��765��-  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�   ColumnHeaderPadding$ 8q����� *
ListBook+ �� SelectedIndex �� *ListBookSelectedIndex+ �� SelectedItem �� *ListBookSelectedItem+   $ SelectionChanged��.    �� *ListBookSelectionChanged+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    MinWidth$ 80Q�1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� *ID+9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  $ 
Tên sách��$	 130 $	 130Q� .   �� *Name+!   ElementStyle! �� " ��.���  � ��$
	 Wrap=�  $ 	Tồn kho��$ 80 $ 80Q� .   �� *	Inventory+" �� StringFormat$	" 0,0��  $ Giá nhập�� 5 1MaterialDesignDataGridTextColumnPopupEditingStyle#   EditingElementStyle## [ $	 120 $	 120Q�  �� *Price+$" 0,0.0��  $ Số lượng��$ 80 $ 80Q� .  ## [   �� *Count+$" 0��$ �� UpdateSourceTrigger$$ PropertyChanged=�  $ Tổng tiền��$	 120 $	 120Q� .   �� *
TotalMoney+$" 0,0.0��4  .System.Windows.Controls.DataGridTemplateColumn  %   CellTemplate% �� .R��� & ��Name$& 
ButtonEdit�����#3498db���#3498db$��45��' � ToolTip$' Cập nhật��{��� *IsTrueValue+���� ( �� Path$( DataContext.editCommand�) �� RelativeSource) �� *FindAncestor+* �� AncestorType"*  ���� .��  $ Pencil=�
�������$��15��$��15��  % �� .R��� $& ButtonDelete�����#c0392b���#c0392b$��45��$
' Xóa������ $( DataContext.deleteCommand�) �� *FindAncestor+"*  ���� .��  $ DeleteForever=�
�������$��15��$��15��� $��1��$��	10,33,0,0q�.+��� $ Vertical=�.+�
  $	��Top=�$	��250��$	��250��.���� $��Stretch=����� *
CoverImage+
  $	��178��$	��250��$��Center=�$��0,3,0,0q�.���� $��0,0,0,0q�.+�� $��50�����#2c2c54�� $��Tổng tiền��$��0,5,0,0q�#��[ $��Center=��� $��0,10,0,0q�#��[ $��Center=����� *
TotalPrice+$" 0,0.0���� $��	10,5,10,0q��� $��Nhập sách��$��Center=�$��0,30,0,0q�#��[ $	��120������ *
addCommand+