   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BookStore.VIEWBookStore.VIEW  5      &     BookStore.VIEW.PromotionMenuPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BookStore.VIEW     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont N� 
FontFamily# �  5        MaterialDesignPaper N� 
Background# �  5        PromotionMenuPageVM � DataContext# [ 5       N� Title$ PromotionMenuPage��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadCommand+5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!   
   � $��0��6   
�������
 5"      �� 5#      $
��auto �6    �� 5$      $
��auto �6    .+�5(      ��  �� Orientation$ 
Horizontal=�6   $��0��5)      $	��Top=�6"   $
��Left=�6:   $��10,0,0,0q�5*       � 	Resources 5+       �� 
TargetType $  MaterialDesignRaisedAccentButton �� BasedOn �� Property �� Value+  %MaterialDesignThemes.Wpf.RippleAssist��%�   '��       7  �� 5,      " ��6   8   .�5-      ��  � �� 67   Z� �� 5.       � �� 68   Z� �� 5/       �@ Feedback �	#DD0000006Q   �� 50       � ��$	 150��62   �� 51       � ��$ 40��63   52      53      .+�55      �� $��Mã khuyến mãi��6   ��61   �� *CodePromotionCommand+57      �� 59      $��Loại khuyến mãi��6   ��63   �� *TypePromotionCommand+5;      5=      � 5@      $��1��6   $��5��6    
�������.+�5A      � $��5��6   ���#29B391$	��150��67   $
��Left=�5B      ��62   �� *GridCursorMargin+5C      5E       � 5H   
   $��1��6     � NavigationUIVisibility$ Hidden=�6;   ��6   �� *	FramePage+6;   5J      5K      