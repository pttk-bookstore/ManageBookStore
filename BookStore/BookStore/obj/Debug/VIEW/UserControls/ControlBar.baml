   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BookStore.VIEW.UserControlsBookStore.VIEW.UserControls  5      ,    &BookStore.VIEW.UserControls.ControlBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:BookStore.VIEW.UserControls     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5          >�Name$  ucControlBar��5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveCommand+   CommandParameter 6I   ��  �� ElementName$ ucControlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  
������ .��5      ]� .+�5      �� 	 �� Orientation$	 
Horizontal=�6   $��Right=�66   
 � 	Resources
 5       �� 
TargetType 0 ,MaterialDesignFloatingActionMiniAccentButton �� BasedOn �� Property �� Value��%   '��       7  �� 5      " ��6    8   .�5      ��  � ��$ 20��67   �� 5       � ��$ 20��67   5      5       .+�5!      �� 
�������
�������$��3,2,3,2q�5"   !    � ToolTip$
 Ẩn��5$      $��22��6*   $��22��66   ��5"   2   �� *MinimizeWindowCommand+��5#      �� $ ucControlBar��.��5%      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�5&   !   $��19��5'   !   $��19��5(   !   
���   �6,   5)      �� 5+      
�������
�������$��3,2,3,2q�5,   !   $ Toàn màn hình��5.      $��22��65   $��22��6A   ��5,   3   �� *MaximizeWindowCommand+��5-      �� $ ucControlBar��.��5/        $ 
Fullscreen=�50   !   $��19��51   !   $��19��52   !   
���   �6,   53      �� 55      
�������
�������$��3,2,3,2q�56   !   $��22��62   $��22��6>   $ Thoát��58      ��56   I   �� *CloseWindowCommand+��57      �� $ ucControlBar��.��59        $ WindowClose=�5:   !   $��19��5;   !   $��19��5<   !   
���   �6,   5=      5>      �� 5?      $
��Left=�6   $��Center=�63   5@      5A      5B      5C      5D      