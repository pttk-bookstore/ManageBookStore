   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  %    BookStore.VIEW.EmployeeInfoPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    EmployeeInfoPageVM � DataContext# [  N� Title$ EmployeeInfoPage��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoadCommand+.��� 
 � RowDefinitions
 �� $
��auto ��� $��* �.+�� $��0��
�������
 �� $
��auto ��� $
��auto �.+���  �� Orientation$ 
Horizontal=�$��0��$	��Top=�$
��Left=�$��10,0,0,0q� � 	Resources  �� 
TargetType $  MaterialDesignRaisedAccentButton �� BasedOn �� Property �� Value+  %MaterialDesignThemes.Wpf.RippleAssist��%�   '��       7  �� " ��8   .���  � �� Z� ��  � �� Z� ��  �@ Feedback �	#DD000000��  � ��$	 150����  � ��$ 40��.+��� $��Thông tin cá nhân��� $��1��$��5��
�������.+�� $��5�����#29B391$	��150��$
��Left=�$��10,0,0,0q�� $��1�� � ColumnDefinitions �� �� .+�� $��0��.+��� $��	30,20,0,0q�.+�#  MaterialDesignThemes.Wpf.Card  $	��450��$��8q�   UniformCornerRadius$ 6Q�.��� 
 �� �� .+�� $��0�����#29B391$��35��.+��� $��Thông tin cá nhân��$��0,10,0,0q�$��Center=�
�������$��Medium"�$��16(�� $��1��.+��� $��	0,10,0,20q�.+��� $ 
Horizontal=�$��0,10,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ ChartBubble=�$��0,0,5,0q��� $
��Id: ��$��15(�$��Medium"��� $��15(����� *Employee.ID+�� $ 
Horizontal=�$��0,10,0,0q�.+�  $ 	RenameBox=�$��0,0,5,0q��� $��Tên: ��$��15(�$��Medium"��� $��15(����� *Employee.Name+�� $ 
Horizontal=�$��0,10,0,0q�.+�  $ CalendarClock=�$��0,0,5,0q��� $��Ngày sinh: ��$��15(�$��Medium"��� $��15(����� *Employee.DOB+ �� StringFormat$ 
dd-MM-yyyy���� $ 
Horizontal=�$��0,10,0,0q�.+�  $ Phone=�$��0,0,5,0q��� $��Số điện thoại: ��$��15(�$��Medium"��� $��15(����� *Employee.Phone+�� $ 
Horizontal=�$��0,10,0,0q�.+�  $ MapMarkerMultiple=�$��0,0,5,0q��� $��Địa chỉ: ��$��15(�$��Medium"��� $��15(����� *Employee.Address+  $��0,5,0,0q�$	��450��$��8q�$ 6Q�.��� 
 �� �� .+�� $��0�����#29B391$��35��.+��� $"��Tài khoản và bảo mật��$��0,10,0,0q�$��Center=�
�������$��Medium"�$��16(�� $��1��.+��� $��	0,10,0,20q�.+��� $ 
Horizontal=�$��0,10,0,0q�.+�  $ AccountCircle=�$��0,0,5,0q��� $��Tài khoản: ��$��15(�$��Medium"��� $��15(����� *Employee.Acount.User+�� $ 
Horizontal=�$��0,10,0,0q�.+�  $ Lastpass=�$��0,0,5,0q�$��Center=��� $��Mật khẩu: ��$��15(�$��Medium"�$��Center=�G�  G� Password$ J4M-TEAM��$��15(�$��0,0,0,0q� J� IsHitTestVisible .  �� $��Thay đổi��$��25��$��	120,0,0,0q����#FF6347���#FF6347���� *ChangePassCommand+� $��1��.+��� $��	0,20,30,0q�.+�  $��0,0,0,0q�$	��450��$��8q�$ 6Q�.��� 
 �� �� .+�� $��0�����#29B391$��35��.+��� $��Thông tin chức vụ��$��0,10,0,0q�$��Center=�
�������$��Medium"�$��16(�� $��1�� �� $
��150* ��� $	��67* �.+��� $��2��$��	0,10,0,20q�.+��� $ 
Horizontal=�$��0,10,0,0q�.+�  $ AccountCircle=�$��0,0,5,0q��� $��Vị trí công việc: ��$��15(�$��Medium"��� $��15(����� *Employee.Role.Name+�� $ 
Horizontal=�$��0,10,0,0q�.+�  $
 Coin=�$��0,0,5,0q�$��Center=��� $��Mức lương: ��$��15(�$��Medium"�$��Center=��� $��15(�$��0,0,0,0q����� *Employee.Role.Salary+$ 0,0.0��  $��0,10,0,0q�$	��450��$��8q�$ 6Q�.��� 
 �� �� .+�� $��0�����#29B391$��35��.+��� $��Thông tin công việc��$��0,10,0,0q�$��Center=�
�������$��Medium"�$��16(�� $��1��.+��� $��	0,10,0,20q�.+��� $ 
Horizontal=�$��0,10,0,0q�.+�  $ Calendar=�$��0,0,5,0q��� $&�� Ngày bắt đầu làm việc: ��$��15(�$��Medium"��� $��15(����� *Employee.FirstDate+$ 
dd-MM-yyyy���� $ 
Horizontal=�$��0,10,0,0q�.+�  $ Coffee=�$��0,0,5,0q�$��Center=��� $��Tổng ngày đã làm: ��$��15(�$��Medium"�$��Center=��� $��15(�$��0,0,0,0q����� *Employee.SumDate+$	 0,0���� $ 
Horizontal=�$��0,10,0,0q�.+�  $ CoffeeOutline=�$��0,0,5,0q�$��Center=��� $+��%Tổng ngày làm trong tháng này: ��$��15(�$��Medium"�$��Center=��� $��15(�$��0,0,0,0q����� *Employee.SumDate+$	 0,0���� $ 
Horizontal=�$��0,10,0,0q�.+�  $ 
CreditCard=�$��0,0,5,0q�$��Center=��� $��Lương tháng này: ��$��15(�$��Medium"�$��Center=��� $��15(�$��0,0,0,0q����� *Employee.MonthSalary+$ 0,0.0��