   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5   	   I)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  5   	   C&clr-namespace:BookStore.VIEW.ConverterBookStore.VIEW.Converter  5   	   $    BookStore.VIEW.DashboardWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BookStore.VIEW     5   	   8uc)clr-namespace:BookStore.VIEW.UserControls     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   6	converter&clr-namespace:BookStore.VIEW.Converter  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  Window��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     MaterialDesignPaper#���  5   	     DashboardWindowVM � DataContext# [ 5   	    � Title$ DashboardWindow��5   	   $	��780��6!   $
��1250��6.    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5        OpenMenu �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  	CloseMenu4  .BookStore.VIEW.Converter.RoleToEnableConverter  RoleToEnableConverter��%�  &	       &	 �     &	 �    �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5        $
 0��6'   $ 70Q�63     5      $
 0:0:0.5��6'   $	 200Q�69   5      5       �� 5!   
   .��5"      U� $ (FrameworkElement.Width)�6,   $	 GridMenu��6a   .\�5#        $
 0��6'   $	 200Q�63     5$      $
 0:0:0.5��6'   $ 70Q�69   5%      5&        5'   
   6J   5(       � Triggers 5+      :� 5,   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5-      �� #��[ 6   5.      :� 5/   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�50      �� #��[ 6   51      .  (System.Windows.Interactivity.Interaction   Triggers 53      /  )System.Windows.Interactivity.EventTrigger  54   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 55      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadCommand+56      .��59      �  � RowDefinitions 5:   
   �� 5;      $
��Auto �6   �� 5<      $��* �6   .+�5@   
   ,   &BookStore.VIEW.UserControls.ControlBar  $	��Top=�6    K� ZIndex$ 1��60   $��0��6A   � 5A   
   $��1��6    � ColumnDefinitions 5B      �� 5C      $
��auto �6#   �� 5D      $��* �6#   .+�5G      � -   5         �Name$ GridMenu��5G      $��75��6%   $
��Left=�60   $��0��6K   $ 0��6[   
���   � 5I      �� 5J      $��5 �6'   �� 5K      $��* �6'   .+�5M      � $��0��6   $��5��6$   $��70��6.   
�������$	��Top=�6M    � ShowGridLines .  6e   � 5O      $��0��6   .+�5P      � $��5��6   $��70��6%   ���#29B391$	��Top=�6F   ��5Q      �� *GridCursorMargin+6=   5S      �� 5V      $��1��6   .+�5W      � $��70��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�6:   z�5X      V� 5Y      .~�5Z   "   �� �� 5[   "   �� 5\   "   T� 5]   "   5^      .+�5`      �� -   5         ��Name$ ButtonOpenMenu��5`   !   $��60��69   $��60��6E   $��5q�6P   $��Right=�5b      $	��Top=�69    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5c      ���	#FF31577Ey�5a      �� *OpenMenuVisibility+��5d      Z� ��63   Z� ��5e      �� *OpenMenuCommand+.��5f      '	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 
  Kind$
 Menu=�66   $��25��6B   $��25��6M   5g      �� 5h      -   5        $ ButtonCloseMenu��5h   !   $��60��6e   $��60��6q   $��5q�5i      $��Right=�6(   $	��Top=�6D   #��[ 5j      ���	#FF31577Ey�5h   :   �� *CloseMenuVisibility+��5k      Z� ��63   Z� ��5l      �� *CloseMenuCommand+.��5m      	  $ 	ArrowLeft=�66   $��25��6G   $��25��6R   5n      �� 5p      $��80��6    $��Bottom=�6,   5q      �� 5r      $
��Left=�6!    5s       �� 
TargetType $  MaterialDesignRaisedAccentButton �� BasedOn �� Property �� Value��%�   '��       7  �� 5t      " ��6$   8   .�5u   "   ��  � �� 6?   Z� �� 5v   "    � �� 6@   Z� �� 5w   "    � ��$ 60��6;   �� 5x   "    � ��$	 200��6:   �� 5y   "    � ��
 �����6?   5z      5{      .+�5}      ��  � ToolTip$ Thanh toán��6!   ��66   �� *
PayCommand+.��5~      ��   �� Orientation$  
Horizontal=�6)   $��17,0,0,0q�6B   .+�5   "   	  $ CartOutline=�6:   $��25��6M   $��25��6Y   $��-62,10,0,10q�6d   �� 5�   "   $��Thanh toán��6,   $��Center=�6>   $
��Left=�6Y   $��
-5,10,0,10q�6u   5�      5�      �� 5�      $ 	Kho sách��6!   ��64   �� *BookCommand+.��5�      �� $  
Horizontal=�6)   $��2,0,0,0q�6B   .+�5�   "   	  $
 Book=�6:   $��25��6F   $��25��6R   $��-62,10,0,10q�6]   �� 5�   "   $��	Kho sách��6,   $��Center=�6<   $
��Left=�6W   $��
-5,10,0,10q�6s   5�      5�      �� 5�      $ Khuyến mãi��6!   {�5�   !   �� *RoleID+! �� 	Converter#! [ ��5�   !   �� *PromotionCommand+.��5�      �� $  
Horizontal=�6)   $��19,0,0,0q�6B   .+�5�   "   	  $
 Sale=�6:   $��25��6F   $��25��6R   $��-62,10,0,10q�6]   �� 5�   "   $��Khuyến mãi��6,   $��Center=�6>   $
��Left=�6Y   $��
-5,10,0,10q�6u   5�      5�      �� 5�      $ Thống kê��6!   ��64   �� *ChartCommand+{�5�   !   �� *RoleID+#! [ .��5�      �� $  
Horizontal=�6)   $��5,0,0,0q�6B   .+�5�   "   	  $ ChartPie=�6:   $��25��6J   $��25��6V   $��-62,10,0,10q�6a   �� 5�   "   $��Thống kê��6,   $��Center=�6<   $
��Left=�6W   $��
-5,10,0,10q�6s   5�      5�      �� 5�      $ 
Nhân sự��6!   ��63   �� *EmployeeCommand+{�5�   !   �� *RoleID+#! [ .��5�      �� $  
Horizontal=�6)   $��-2,0,0,0q�6B   .+�5�   "   	  $ Worker=�6:   $��25��6H   $��25��6T   $��-62,10,0,10q�6_   �� 5�   "   $��
Nhân sự��6,   $��Center=�6;   $
��Left=�6V   $��
-5,10,0,10q�6r   5�      5�      �� 5�      $ Khách hàng��6!   ��66   �� *CustomerCommand+{�5�   !   �� *RoleID+#! [ .��5�      �� $  
Horizontal=�6)   $��20,0,0,0q�6B   .+�5�   "   	  $ HumanMaleFemale=�6:   $��25��6Q   $��25��6]   $��-62,10,0,10q�6h   �� 5�   "   $��Khách hàng��6,   $��Center=�6>   $
��Left=�6Y   $��
-5,10,0,10q�6u   5�      5�      �� 5�      $ Tài khoản��6!   ��65   �� *AccountCommand+.��5�      �� $  
Horizontal=�6)   $��5,0,0,0q�6B   .+�5�   "   	  $ AccountEdit=�6:   $��25��6M   $��25��6Y   $��-62,10,0,10q�6d   �� 5�   "   $��Tài khoản��6,   $��Center=�6=   $
��Left=�6X   $��
-5,10,0,10q�6t   5�      5�      �� 5�      $ Thoát��6!   ��61   �� *ExitCommand+��6Q   �� " �� ElementName$" Window��.��5�      �� $  
Horizontal=�6)   $��	-19,0,0,0q�6B   .+�5�   "   	  $ 	ExitToApp=�6:   $��25��6K   $��25��6W   $��-62,10,0,10q�6b   �� 5�   "   $��Thoát��6,   $��Center=�69   $
��Left=�6T   $��
-5,10,0,10q�6p   5�      5�      5�      5�      5�      � 5�      $��1��6   .+�5�       � #  � NavigationUIVisibility$# Hidden=�66   ��6   �� *	FramePage+66   5�      5�      5�      5�      