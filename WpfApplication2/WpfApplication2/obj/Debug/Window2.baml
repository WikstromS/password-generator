   M S B A M L   `   `   `  ����Q  MPassword generator GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	       WpfApplication2.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	     � Title$  Encryption and Decryption��5   	   $	��300��6+   $	��350��68   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FFD31616��6   $ 1Q�61   5      .+�5   
   �� -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��	25,93,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��184��6�   6�   �� 5   
   -   5         ��Name$ button��5      $��Decrypt��6!   $
��Left=�63   $��
244,96,0,0q�6N   $	��Top=�6b   $��75��6z   {�6�   ��  �� ElementName$ textBox��	 �� Path$	 Text.Length��� 5   
   -   5        
 ��Name$
 richTextBox��5      $
��Left=�6+   $��54��6F   $��
25,182,0,0q�6R   $	��Top=�6f   $	��119��6~    �� 
IsReadOnly . . �5      /� .T�5      J� .*�6   .*�5      �� $� ��6   5      5      5      �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
24,153,0,0q�6B   $
��Wrap=�6V   $%��Here is your decrypted password��6j   $	��Top=�6�   $��24��6�   $	��185��6�   ���	#FFF1EEEE6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��	25,48,0,0q�6C   $
��Wrap=�6V   $?��9Enter the encrypted password and press the Decrypt button��6j   $	��Top=�6�   ���	#FFEEEBEB$	��274��6�   �� 5   
   -   5        $ button1��5      $��Paste��6"   $
��Left=�62   $��
25,128,0,0q�6M   $	��Top=�6a   $��75��6y   6�   5      5      