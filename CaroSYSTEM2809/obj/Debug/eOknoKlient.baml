   M S B A M L   `   `   `  ����I  ECaroSYSTEM2809, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CaroSYSTEM2809CaroSYSTEM2809  5   	        CaroSYSTEM2809.eOknoKlient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CaroSYSTEM2809     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  eOknoKlient��5
   	   $	��450��6   $	��500��6*   .��5      � .+�5   
   � .+�5      � 
������� � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��90 �6$   .+�5      �� -   5        $��e_poleNazwaKlienta��5      $��0��66   $��2��6D   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ nazwa klienta��6X    %  !MaterialDesignFloatingHintTextBox#��[  6�   $
��10,0q�6�   �� 5      -   5        $��e_poleAdresKlienta��5      $��1��64   $��0��6A   $ adres klienta��6R   #��[  6�   $
��10,0q�6�   $��2��6�   �� 5"      -   5        $��e_poletelefon��5"      $��2��6/   $��0��6<   $ telefon��6M   #��[  6w   $
��10,0q�6�   �� 5#      -   5        $��
e_poleMail��5#      $��2��6,   $��1��69   $
 mail��6I   #��[  6p   $
��10,0q�6�   �� 5$      -   5        $��e_poleOsobaDecyzyjna��5$      $��3��66   $��0��6C   $ osoba decyzyjna��6S   #��[  6�   $
��10,0q�6�   �� 5%      -   5        $��e_poleOcenaKlienta��5%      $��3��65   $��1��6B   $ ocena klienta��6S    & "MaterialDesignFloatingHintComboBox#��[ 6�   $��Bottom=�6�   $
��10,0q�6�   .@�5&      �� .��6#   15(      �� 5)      .��6#   25+      �� 5,      .��6#   35.      �� 5/      .��6#   451      �� 52      .��6#   554      56      �� 58      -   5        $��	e_poleNip��58      $��4��6+   $��0��68   $	 nip��6H   #��[  6n   $
��10,0q�6�   (  "System.Windows.Controls.DatePicker  59      -   5        $��e_dataWazna��59   ;    � Language$ pl-PL�6   $��4��6.   $��1��6N   $ ważna data dla klienta��6_   $
��10,0q�6�   $��Bottom=�6�   �� 5:      -	   5        $��e_poleNotatka��5:      $��5��6/   $��0��6<   $��2��6L   $ notatka��6`   #��[  6�   $
��10,0q�6�   �� 5=       �� Orientation$ 
Horizontal=�6   $��0��66   $��7��6F   $
��20,0q�6S   $��2��6a   .+�5@      �� -
   5        $��dodajDoBazyKlient��5@      $��0��66   $��7��6F   $��
100,0,20,0q�6S    , (MaterialDesignFloatingActionAccentButton#��[ 5A       � ToolTip$ Dodaj klienta do bazy��5B      $��Right=�6#   .��5C      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 plus=�64   $��24��6B   $��24��6P   5D      �� 5F      -   5        $��edytujKlientBaza��5F      $��0��66   $��7��6F   ���	#FFC1FF54$
��20,0q�6j   #��[ 5G      $ edytuj wpis klienta��5H      $��Right=�6!   ���	#FFB3F081.��5I        $
 Edit=�64   $��24��6B   $��24��6P   5J      �� 5N      -   5        $��zerujFormularzKlient��5N   *   $��7��6    & "MaterialDesignFloatingActionButton#��[ 5O      $ Resetuj formularz��5P      $��Right=�6   $
��20,0q�6;   .��5Q        $ Refresh=�64   $��24��6E   $��24��6S   5R      �� 5S      -   5         ��Name$ usuńKlient��5S      #��[ 5T      $ Usuń z bazy��5U      $��Right=�6   $��20,17q�65   
���  ��
���  ��.��5V        $ Close=�64   $��24��6C   $��24��6Q   5W      5Z      5\      5]      5^      5_      