   M S B A M L   `   `   `  ����=  9CP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CP.ViewsCP.Views  5      -clr-namespace:CP.ViewModelsCP.ViewModels  5      #clr-namespace:CP.OtherCP.Other  5      -clr-namespace:CP.ConvertersCP.Converters  5          CP.Views.AccountPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CP.Views     5      *vmclr-namespace:CP.ViewModels     5      (validclr-namespace:CP.Other     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      ,
convertersclr-namespace:CP.Converters  5        N� Title$  AccountPage��5       � 	Resources 5      #  CP.Converters.SimpleConverter   convert��%   &	          5   
   6%   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��0,50,0,0q�62   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��Bottom=�5   .   $��	40,0,10,0q�6I   $��50��6\   $��50��6g   ��5   9   ��  �� ElementName$
 name�� �� Path$ BorderBrush�5   u   �� 5      -   5         ��Name$
 name��5      $	��350��6(   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Никнейм��64   	   
IsFloating	 . $��20(�6�   .��6�   ��5      �� 5      $
 Name�6#   
 �� UpdateSourceTrigger$
 PropertyChanged=�60    �� ValidationRules 5      %  CP.Other.NotEmptyValidationRule  5   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6B   5!      .��5"   $   5#      5$      �� 5%      $ 
Horizontal=�6   $
��Left=�62   $��
100,20,0,0q�6M   .+�5&      �� -   5        $ surname��5&      $	��350��6,   $ Фамилия��68   	 . $��20(�6�   .��6�   ��5'      �� 5(      $ Surname�6#   $
 PropertyChanged=�63    5)        5*   "    . 6B   5,      .��5-   $   5.      5/      �� 51      $ 
Horizontal=�6   $��0,50,0,0q�62   $
��Left=�6D   .+�52        $
 Lock=�6*   $��Bottom=�53   .   $��	40,0,10,0q�6I   $��50��6\   $��50��6g   ��52   6   �� $ password��$ BorderBrush�55      G� 56      -   5         G�Name$ password��56      $	��350��60   $ Старый пароль��6<    G� 	MaxLength$ 8��6k   	 . $��20(�6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . 57       58      �� 59      $ 
Horizontal=�6   $
��Left=�62   $��
100,20,0,0q�6M   .+�5:      G� -   5        $ repeatpassword��5:      $	��350��66   $ Новый пароль��6B   $ 8��6p   	 . $��20(�6�    . 6�   5;      �� 5<      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5=        $
 Mail=�6*   $��Bottom=�6p   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��66   �� $
 mail��$ BorderBrush�6�   �� 5>      -   5        $
 mail��5>      $	��350��6)   $ 
Почта��65   	 . $��20(�6�   .��6�   ��5?      �� 5@      $
 Mail�6#   $
 PropertyChanged=�60    5A        5B   "    . 6B   5D      .��5E   $   5F      5G      �� 5H      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5I        $ Phone=�6*   $��Bottom=�6s   $��	40,0,10,0q�6�   $��50��6�   $��50��6�   ��67   �� $ number��$ BorderBrush�6�   �� 5J      -   5        $ number��5J      $	��350��6*   $ Телефон��66   	 . $��20(�6�   .��6�   ��5K      �� 5L      $ Phone�6#   $
 PropertyChanged=�61    5M        5N   "    . 6B   5P      .��5Q   $   5R      5S      5T      �� 5U   
   $��1��6   $��Bottom=�6!   $��Сохранить��5V      ���	#FFFFFFFF$��0,0,0,20q�6=   $	��200��6f   $��50��6r   $��Center=�6~   $��20(�6�   ��5U   <   �� *UpdateAccountCommand+��5V   O   Z� ��5W      `� 5X       `� 	Converter# [  6   .1�5Y      �� $ password��6   �� 5Z      $ repeatpassword��6   5[      5]      5^      5`      