   M S B A M L   `   `   `  ����F  B22_Банк, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_22_Банк_22_Банк  5   	   ?$clr-namespace:_22_Банк.viewModel_22_Банк.viewModel  6.       _22_Банк.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_22_Банк     5   	   :	viewmodel$clr-namespace:_22_Банк.viewModel     6.     � Title$
  Main��5   	   $	��720��6   $	��850��6#    � DataContext 5	      *  $_22_Банк.viewModel.MainViewModel  5
   
   .��5      � .+�5   
   �� ��5      �� 5       �� ImageSource$ .\img\2.jpg��6   .+�5      �� $��
Логин��6   $��28(�6%   $
��Bold"�63   ���#000 �� TextAlignment$
 Left=�6W   $	��640��6l   $��
0,160,0,10q�6x   �� 5      $	��640��6   $��40��6]   $��5,5,0,5q�6i   ���#000$��0,5,0,15q�6�   $��22(�6�   ��6"   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Пароль��6   $��28(�6&   $
��Bold"�64   ���#000$
 Left=�6X   $	��640��6m   $��0,0,0,10q�6y   �� 5      $	��640��6U   $��40��6a   $��5,5,0,5q�6m   ���#000$��0,5,0,15q�6�   $��22(�6�   ��6   �� *
Password+$ PropertyChanged=�6�   �� 5      $|�False��6   $	��200��6'   $��40��63   $��
Войти��6?   $��22(�6O   ���#4b6584���#fff��6�   �� *	LoginIn+5      5      5      