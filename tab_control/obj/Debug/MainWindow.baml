   M S B A M L   `   `   `  ����F  Btab_control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:tab_controltab_control  5   	       tab_control.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1userControlclr-namespace:tab_control     5   	     � Title$  Intermédiaire��5   	   $	��600��6   $
��1000��6,    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5      ]� .+�5   
      tab_control.Menu  $	��Top=�6   62   �� 5   
   -   5        $��optInter��5   5   $��0q�6   $��-2q�6)   $	��Top=�6E   $	��485��6Z    � 	Resources 5	       �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint	 � Color
 � Offset �� Triggers P� Property P� Value��%�  '��       �� 5
      " ��6   .�5      ��  � ��
 �   �6D   �� 5       � �� 5      �� 5      $	 0,1&�62   $	 0,0&�6A   .��5   "   � $	 	#FF250A0A��6/   $
 0Q�6A   � 5   "   $	 	#FF363232��6/   $
 1Q�6A   5      5      �� 5       � ��$ 20q�60   6=   �� 5       � ��
 �����6C    5      P� 5       �@��
IsSelected . . �5      ��  � ��
 ��  �6J   �� 5       � ��
 �   �6K   5      5      5      .@�5      �� -   5        $��
rechercher��5   6   $��
Rechercher��6   $	��240��6*   .��5       �� $��Center=�6   $��	78,0,76,0q�6:   $	��840��6M   .+�5$      �� -   5        $��envoyerDemander��5$      $��Envoyer une demande��64   $��Center=�5%   ;   $��10q�6X   
������ 
���**�� � Cursor$
 Hand��5&   I   6Y   &   System.Windows.Controls.DataGrid  5'      -   5          Name$ DBSearch��5'   7   $	��900��6   $��15q�6+      CanUserResizeColumns .     AutoGenerateColumns .     Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *Nom+  5+      $ Prénom��61   $	 120 6A    6M   �� *Prenom+  5,      $ email��61   $	 200 6@    6L   �� *Email+  5-      $
 tel.��61   $	 120 6?    6K   �� *Gsm+  5.      $ Date dispo.��61   $	 140 6F    6R   �� *	DateDispo+  5/      $ Date dispo.��61   $	 140 6F    6R   �� *DateFinDispo+51      52      53      �� 54      $��Demandes��6   $	��242��6(   .��55      �� $��Center=�6   .+�56      � $��Center=�6    .+�57      �� -   5        $��buttonRechercherB��57   �   $	��250��6!   
���   �
��� ���$��10q�6T   $��Rechercher Babysitter��6a   {�.  6�   59        5:      -   5        $��requetes��5:       . 5<      5=      5>      �� 5?      $
��Mail��6   $	��242��6$   .��5@         tab_control.Mail  6%   5A      �� 5B      $	��260��6   $��Center=�6"   ��5C      �� 5D      ��6    ��  �� Path$	 Nom�6<   .��5F         tab_control.UserControl1  $
��1000��6+   6:   5G      5H      	   tab_control.Notification	  5I   
   $��0, 10, 0, 0q�6#   
���   �$��
0, 2, 0, 0q�6L   $��Bottom=�6i   $	��200��6�   6�   5J      5L      