   M S B A M L   `   `   `  ����=  9CP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CP.OtherCP.Other  5   	   -clr-namespace:CP.ConvertersCP.Converters  5   	       CP.Views.Registration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   "validclr-namespace:CP.Other  5   	   ,
convertersclr-namespace:CP.Converters  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	      MaterialDesignBody#���   5	   	     MaterialDesignPaper#���  5
   	     � Title$  Moder��5   	   $	��700��6   $	��500��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowStyle$
 None=�6k    � AllowsTransparency .  � 	Resources 5      #  CP.Converters.SimpleConverter  convert��%   &	         5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ._�5      � .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ MouseLeftButtonDown��6%   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 5      �� *BorderDragCommand+   CommandParameter 5      ��  �� RelativeSource ��  �� AncestorType" �5       .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  ���#d42b2b.��5#      �� $��Right=�6!   .+�5$      �� +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�6�   $��30��6�   $��30��6�   $��0q�6�   ���#d42b2b���#d42b2b��6!   �� *CloseWindowCommand+��6H   ��  �� " �.��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=�66   $��30��6J   $��30��6V   6c   5&      5'      5(      5)      5*      � 5,   
   $��1��6   .+�5-      �� $��Center=�6   .+�5.      �� $��Регистрация��6   $��35(�6/   $��Center=�6>   $��Center=�6[   $��10q�6v   ���#d42b2b6�   5/      50      � 51   
   $��2��6   .+�52      ��  �� Orientation$ Vertical=�6   .+�54      �� $ 
Horizontal=�6   $��0,50,0,0q�66   .+�55        $ Account=�6.   $��Bottom=�56   .   $��	40,0,10,0q�6I   $��50��6\   $��50��6g   ��55   =   ��  �� ElementName$
 name�� �� Path$ BorderBrush�56   u   �� 57      -   5         ��Name$
 name��57      $	��350��6,   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Никнейм��68    	  
IsFloating . $��20(�6�   .��6�   ��58      �� 59      $
 Name�6'    �� UpdateSourceTrigger$ PropertyChanged=�64    �� ValidationRules 5:   "   %
  CP.Other.NotEmptyValidationRule
  5;   &   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6F   5=      .��5>   (   5?      5@      �� 5A      $ 
Horizontal=�6   $��Center=�66   $��	50,20,0,0q�6S   .+�5B      �� -   5        $ surname��5B      $	��350��60   $ Фамилия��6<    . $��20(�6�   .��6�   ��5C      �� 5D      $ SurName�6'   $ PropertyChanged=�67    5E   "   
  5F   &    . 6F   5H      .��5I   (   5J      5K      �� 5M      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5N        $
 Lock=�6.   $��Bottom=�5O   .   $��	40,0,10,0q�6I   $��50��6\   $��50��6g   ��5N   :   �� $ password��$ BorderBrush�5Q      G� 5R      -   5         G�Name$ password��5R   "   $	��350��64   $ Пароль��6@    G� 	MaxLength$ 8��6h    . $��20(�6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . 5S       5T      �� 5U      $ 
Horizontal=�6   $��Center=�66   $��	50,20,0,0q�6S   .+�5V      G� -   5        $ repeatpassword��5V   "   $	��350��6:   $% Повторите пароль��6F   $ 8��6x    . $��20(�6�    . 6�   5W      �� 5X      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5Y        $
 Mail=�6.   $��Bottom=�6t   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��6:   �� $
 mail��$ BorderBrush�6�   �� 5Z      -   5        $
 mail��5Z      $	��350��6-   $ 
Почта��69    . $��20(�6�   .��6�   ��5[      �� 5\      $
 Mail�6'   $ PropertyChanged=�64    5]   "   
  5^   &    . 6F   5`      .��5a   (   5b      5c      �� 5d      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5e        $ Phone=�6.   $��Bottom=�6w   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��6;   �� $ number��$ BorderBrush�6�   �� 5f      -   5        $ number��5f      $	��350��6.   $ Телефон��6:    . $��20(�6�   .��6�   ��5g      �� 5h      $ Phone�6'   $ PropertyChanged=�65    5i   "   
  5j   &    . 6F   5l      .��5m   (   5n      5o      �� 5p      $��РЕГИСТРАЦИЯ��6A   ���	#FFFFFFFF$��	0,40,0,40q�6n   $	��200��6�   $��50��6�   $��Center=�6�   $��20(�6�   ��6   �� *RegistrationCommand+��6�   Z� ��5q      `� 5r       `� 	Converter# [ 6'   .1�5s      ��  6&   �� " ��� 5t      $ password��6&   �� 5u      $ repeatpassword��6&   5v      5x      5z      5{      5}      5~      