   M S B A M L   `   `   `  ����=  9CP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CP.ViewsCP.Views  5   	   -clr-namespace:CP.ViewModelsCP.ViewModels  5   	   -clr-namespace:CP.ConvertersCP.Converters  5   	   #clr-namespace:CP.OtherCP.Other  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       CP.Views.Authorization   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:CP.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $vmclr-namespace:CP.ViewModels  5   	   ,
convertersclr-namespace:CP.Converters  5   	   "validclr-namespace:CP.Other  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	      MaterialDesignBody#���   5	   	     MaterialDesignPaper#���  5
   	   $	��700��5   	   $	��500��6     � 
ResizeMode$  	CanResize=�6"    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$
 None=�6_    � AllowsTransparency .  � DataContext 5      *  $CP.ViewModels.AuthorizationViewModel  5   
   5       � 	Resources 5      #  CP.Converters.SimpleConverter  convert��%   &	         5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .  (System.Windows.Interactivity.Interaction   Triggers 5       /  )System.Windows.Interactivity.EventTrigger  5!         	EventName$ MouseLeftButtonDown��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5"      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 5#      �� *BorderDragCommand+   CommandParameter 5$      ��  �� RelativeSource ��  �� AncestorType" �5%      ._�5'      � .+�5(      (  "MaterialDesignThemes.Wpf.ColorZone  ���#d42b2b.��5)      �� $��Right=�6!   .+�5*      �� +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6H   $��30��6y   $��30��6�   $��0q�6�   ���#d42b2b���#d42b2b��6!   �� *CloseWindowCommand+.��5+      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ WindowClose=�66   $��30��6J   $��30��6V   6c   5,      5-      5.      5/      50      � 52   
   $��1��6   .+�53      ��  �� Orientation$ 
Horizontal=�6   ���#d42b2b$��Center=�6G   .+�54      	  $ Airplane=�6*   $��80��6:   $��80��6E   
�������$��145,10,0,10q�6d    J� RenderTransformOrigin$ 0.5,0.5&�6y   z�55      V� 56      .~�57      �� �� 58      �� 59       �� Angle$ 45Q�6.   T� 5:      5;      5=      �� 5>      $��
Air Flight��6   $��35(�6.   $
��Left=�6<   $��Center=�6W   $��10q�6r   ���	#DDFFFFFF6~   5?      5@      � 5A   
   $��2��6   .+�5B      �� $ Vertical=�6   .+�5D      �� $ 
Horizontal=�6   $��	0,120,0,0q�66   .+�5E      	  $ Account=�6.   $��Bottom=�5F   .   $��	40,0,10,0q�6I   $��50��6\   $��50��6g   ��5E   =   ��  �� ElementName$
 name�� �� Path$ BorderBrush�5F   u   �� 5G      -   5         ��Name$
 name��5G      $	��350��6,   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Никнейм��68    
  
IsFloating . $��20(�6�   .��6�   ��5H      �� 5I      $
 Name�6'    �� UpdateSourceTrigger$ PropertyChanged=�64    �� ValidationRules 5J   "   %  CP.Other.NotEmptyValidationRule  5K   &   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6F   5M      .��5N   (   5O      5P      �� 5R      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5S      	  $
 Lock=�6.   $��Bottom=�6x   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��6:   �� $ password��$ BorderBrush�6�   G� 5T      -   5         G�Name$ password��5T   "   $	��350��64    G� 	MaxLength$ 8��6@   $ Пароль��6N    . $��20(�6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . 5U   "   5V      �� 5X      $��
ВОЙТИ��5Y      ���	#FFFFFFFF$��	0,80,0,40q�6B   $	��200��6l   $��50��6x   $��Center=�6�   $��20(�6�   ��5X      �� *AuthorizationCommand+��5Y   U   Z� ��5Z      `� 5[       `� 	Converter# [ 6'   .1�5\      ��  6&   �� " ��� 5]      $ password��6&   5^      5`      �� 5b      $ 
Horizontal=�6!   $��Center=�6:   $��0,0,0,0q�6W   .+�5c      �� �� 6!   
�������$��22(�5d   �    �� Command 5c   +   �� *RegistrationCommand+  �� CommandParameter  5d      ��  �� " �.�6�   Регистрация6�   6�   5e      5f      5g      5i      5j      