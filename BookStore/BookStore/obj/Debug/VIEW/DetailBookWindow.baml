   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5   	   I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  5   	   %    BookStore.VIEW.DetailBookWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookStore.VIEW     5   	   8uc)clr-namespace:BookStore.VIEW.UserControls     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     MaterialDesignPaper#���  5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6    � Title$ DetailsBookWindow��5   	   $	��650��6#   $
��1000��60    � 	Resources 5       �� 
TargetType  	nameStyle �� Property �� Value  nameBoldStyle  MaterialDesignTextBox	 �� BasedOn  textboxStyle  MaterialDesignComboBox  comboboxStyle)  #MaterialDesignThemes.Wpf.HintAssist 	 MaterialDesignRaisedButton 
 buttonStyle��%�  &	       &	 p     &	     7  &	 �    7  &	
 r    7 	 �� 5   
   " ��6   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ Tahoma)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$
 14.5(�6)   �� 5       � ��$ Tahoma)�6+   �� 5        � ��$
 Bold"�6+   5!      �� 5#   
   " ��6   8	   .�5$      ��  � ��$ 14(�6)   �� 5%       � ��$ Center=�62   �� 5&       � ��$	 180��6)   5'      �� 5)   
   " ��6   8	   .�5*      ��  �@��
IsEditable .  6+   �� 5+       �@ HintOpacity$	 .26Q�6G   �� 5,       � ��$	 180��6)   �� 5-       � ��$ 14(�6)   5.      �� 50   
   " ��6   8	   .�51      ��  � �� �#2c2c546+   �� 52       � �� �#2c2c546,   �� 53       � ��$ 30��6'   �� 54       � ��$ 70��6&   �� 55       � ��$ 5,0,5,0q�6'   56      58      .  (System.Windows.Interactivity.Interaction
   Triggers
 5:      /  )System.Windows.Interactivity.EventTrigger  5;   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5<      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+5=      .��5@      �  � RowDefinitions 5A   
   �� 5B      $
��auto �6   �� 5C      $��* �6   .+�5F   
   ,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=�6    K� ZIndex$ 1��60   $��0��6A   � 5H   
   $��1��6    5I      �� 5J      $
��auto �6    �� 5K      $��* �6    .+�5O      � $��0��6   ���#29B391$��35��65   .+�5P      �� $��Thông tin chi tiết��6   $��Center=�5Q      $��Center=�5R      $��Verdana)�67   
�������$��18(�6_   $��Medium"�6m   5S      �� 5V      $��1��6   $��	10,10,0,0q�6&   .+�5Y      ��  �� Orientation$ 
Horizontal=�6   .+�5Z      �� $��
ID sách: ��6    #��[ 61   �� 5[      #��[ 64   ��6    �� *ID+64   5\      �� 5^      $��
30,10,30,0q�6   �� 5`      $��Thông tin sách��6   $��0,5,0,0q�62   $��17(�6C   $��Center=�5a      #��[ 69   � 5b      $��0,10,0,0q�6   $
��auto��6)    � ColumnDefinitions 5c      �� 5d      $	��600 �6+   �� 5e      $��* �6+   .+�5g      �� .+�5i      � $��0��6$    5j      ��%W   '��       �� 5k   "   " ��6(   .�5l   &   ��  � ��$ 5,5,5,5q�6?   5m   #   5n      .+�5o      �� $ 
Horizontal=�6)   .+�5p   "   �� $��Center=�6,   $��Tên sách: ��6G   #��[ 6Y   �� 5q   "   #��[ 6*      Hint$ 
Tên sách��5r      ��5q   P   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5r      5s      �� 5u      $ 
Horizontal=�6)   .+�5v   "   �� $��Center=�6,   $��Tác giả: ��6G   #��[ 6X   �� 5w   "   #��[ 6*   $ Tên tác giả��5x      ��5w   P   �� *Author+$ PropertyChanged=�5x      5y      �� 5{      $ 
Horizontal=�6)   .+�5|   "   �� $��Center=�6,   $��Thể loại: ��6G   #��[ 6Y   �� 5}   "   #��[ 6+   $ Chọn thể loại��5~   +   $��Center=�5�   +   ��5   +   �� *ListCategory+ �� SelectedItem 5�   +   �� *SelectedItemCategory+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *Name+5�   +   
 5�   &     5�   *   $ SelectionChanged��69   . 5�   .      6D   �� *CategorySelectionChanged+5�   +   5�   #   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Center=�6,   $��Chủ đề: ��6G   #��[ 6W   �� 5�   "   #��[ 6+   $ Chọn chủ đề��5�   +   $��Center=�5�   +   ��5�   +   �� *ListSubCategory+ 5�   +   �� *SelectedItemSubCategory+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *Name+5�   +   5�   #   5�      �� 5�      $ 
Horizontal=�6)   .+�5�   "   �� $��Center=�6,   $��Nhà xuất bản: ��6G   #��[ 6]   �� 5�   "   #��[ 6+   $ Chọn nhà xuất bản��5�   +   $��Center=�5�   +   ��5�   +   �� *ListCompany+ 5�   +   �� *SelectedItemCompany+��5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *Name+5�   +   5�   #   5�      5�      �� 5�      $��
10,10,10,0q�6$   �� 5�      $��Số lượng sách tồn��6$   #��[ 6=   $��Center=�5�   %   $��0,10,0,5q�6B   �� 5�      .+�5�      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� $��Tổng sách tồn: ��6,   #��[ 6C   $��Center=�6j   �� 5�   "   $��Center=�6G   $��0,3,0,0q�6b   $��15(�6s   ��6,   �� *	Inventory+6s   �� 5�   "   $��Số lượng bán ra: ��6,   #��[ 6E   $��Center=�6l   $��70,0,0,0q�6�   �� 5�   "   $��Center=�6U   $��0,3,0,0q�6p   $��15(�6�   ��6,   �� *Sold+ �� StringFormat$	 0,0��6�   �� 5�   "     MaterialDesignCheckBox#��[ 5�   %   $��14(�5�   %   $��	100,0,0,0q�63   $��Hiển thị tất cả��5�   %    d� 	IsChecked 6?   �� *	IsChecked+$ PropertyChanged=���6�   �� *CheckedCommand+5�   #   5�      #  MaterialDesignThemes.Wpf.Card  5�      $	��220��62   $��0,10,0,0q�6?   .��5�   "   �� ��6+   �� *ListWarehouse+ �� View 5�   &   �� 5�   *   .P�5�   .   �� $��
Mã nhập��5�   1    �� CellTemplate 5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *TransactionID+5�   7   5�   /   �� 5�   .   $��Ngày nhập��5�   1    5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *DateTransaction+5�   7   5�   /   �� 5�   .   $��Loại nhập��5�   1    5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *TypeTransaction+5�   7   5�   /   �� 5�   .   $��Số lượng tồn��5�   1    5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *Count+$	 0,0��5�   7   5�   /   �� 5�   .   $��Giá nhập��5�   1    5�   2   �� 5�   6   .R�5�   :   �� ��6D   �� *Price+$ 0,0.0��5�   7   5�   /   5�   +   5�   #   5�      5�      �� 5�      $��
10,10,10,0q�6$   �� 5�      $��Thông tin giá cả��6$   #��[ 6<   $��Center=�6c   $��0,5,0,0q�6�   �� 5�      $ 
Horizontal=�6%   $��0,10,0,0q�6>    5�      ��%�   '��       7  �� 5�   "   " ��6(   8	   .�5�   &   ��  � ��$ 5,0,5,0q�6?   �� 5�   &    � ��$	 100��6A   5   #   5     .+�5     �� $��Giá bán gốc: ��6(   #��[ 6=   �� 5     -   5        $ 50000��5  &   ��5  &   �� *
OutPrice+$ PropertyChanged=�.��6d   
 5  "     5  &   $ TextChanged��65   . 5	  *      6@   �� *OutPriceTextChanged+5
  '   .��5  :   5     �� 5     $��Khuyến mãi: ��6(   #��[ 6<   �� 5     $ 50000��6&   $��80��6M   ��5  &   �� *	Promotion+$ PropertyChanged=�.��6e   
 5  "     5  &   $ TextChanged��65   . 5  *      6@   �� *PromotionTextChanged+5  '   .��5  :   5     �� 5     $��Giá bán ra: ��6(   #��[ 6<   �� 5     -   5        $ 0��5  R    �� 
IsReadOnly . ��6�   �� *OutPricePromotion+$ 0,0.0��5     5     �� 5     $��1��6!   $	��Top=�61   $
��Left=�6I   .+�5       $	��350��6/   $	��350��6<   $	��Top=�6H   $
��Left=�6`   $��10,0,0,0q�6{   .��5     � .+�5   "   �� $ 1��6)   ���#2ecc71���#2ecc71$��70��6e   $��40��6p   $��Right=�5!  %   $	��Top=�6A   $��0,5,5,0q�6Y   ��5"  %   �� *imageCommand+.��5#  &   �� $ 
Horizontal=�61   .+�5$  *   '	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 
  Kind$ 	ImagePlus=�6B   
�������$��30��6f   $��30��6r   $��Center=�6}   5&  '   5(  #   �� 5)  "   $ 0��6j   ��6(   �� *
CoverImage+$ PropertyChanged=�6j   5*     5,     �� 5.     $��40��6!   $	��120��6-   ���#00BFFF���#3498db$��
130,20,0,0q�5/  7   $	��Top=�6m   $
��Left=�6�   ��6K   �� *updateCommand+.��50     �� $��Cập nhật��6(   $��16(�68   51     52     54     55     56     57     58     