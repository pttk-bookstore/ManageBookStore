   M S B A M L   `   `   `  ���� D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  %    BookStore.VIEW.CustomerInfoPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BookStore.VIEW     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignFont N� 
FontFamily# �    MaterialDesignPaper N� 
Background# �    CustomerInfoPageVM � DataContext# [  N� Title$ CustomerInfoPage��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoadCommand+.��� 
 � RowDefinitions
 �� $
��Auto ��� $��* �.+��� $��0��   MaterialDesignTitleTextBlock#���  $��18(�$	��Top=�$
��Left=�$��10,5,0,5q�Danh sách khách hàng�� $��1��$��0,10,0,0q�$
��1100��$
��Left=�.+���  �� Orientation$ 
Horizontal=�$��0��$��20,0,0,0q�$
��Left=�$��Center=�.+��� $	��400��$��15(�$��35��$��10,0,0,0q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Tên / Số điện thoại������ *FilterString+ �� UpdateSourceTrigger$ PropertyChanged=��� ���#0984e3$��35����Z� ���� *searchCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��Center=�$��Center=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Magnify=�
�������#	  MaterialDesignThemes.Wpf.Card	  $	��500��$
��1100��$��
20,10,10,0q�$
��Left=�.���� $	��500��
����  �$
��Left=�$
��1100������ *ListCustomer+ �� SelectedItem �� *ListCustomerSelectedItem+ � 	Resources  �� 
TargetType  	WrapStyle �� Property �� Value��%F   &	       �� " ��.���  � ��$
 Wrap=���  � ��$	 120�� �� View �� .P��� $	��Mã�� �� CellTemplate �� .R��� ���� *ID+�� $
��Tên�� �� .R��� #��[ ���� *Name+�� $��Số điện thoại�� �� .R��� ���� *Phone+�� $��Địa chỉ�� �� .R��� #��[ ���� *	Address+�� $��Email�� �� .R��� #��[ ���� *Email+�� $��Tổng sách đã mua�� �� .R��� ���� *
NumberBook+ �� StringFormat$	 0,0���� $��Tổng tiền đã trả�� �� .R��� ���� *	MoneyPaid+$ 0,0.00���� $��Ngày mua cuối�� �� .R��� ���� *LastTransaction+��  �� .R��� ���#3498db���#3498db$��45�� � ToolTip$ 
Chi tiết������  �� Path$  DataContext.detailCustomer� �� RelativeSource �� *FindAncestor+ �� AncestorType" ������ .��  $ AlertCircleOutline=�
�������$��15��$��15���� $��2��$��Bottom=�$��Center=�$ 
Horizontal=�.+��� $��5,0,5,0q� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $ Trang trước�����	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *PreviousPageCommand+.��  $ ArrowLeftThick=��� $��5,0,5,0q�$ Trang hiện tại��#��[ ���	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *CurrentPage+ �� FallbackValue$ 1���� $��5,0,5,0q�#��[ $ 
Trang kế�����	#FF3EA0C3���	#FF3EA0C3$��30��$��30������ *NextPageCommand+.��  $ ArrowRightThick=�