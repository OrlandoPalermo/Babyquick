   M S B A M L   `   `   `  ����F  Btab_control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:tab_controltab_control  5   	       tab_control.Admin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   1userControlclr-namespace:tab_control     5   	     � Title$  Administrateur��5   	   $	��600��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_   .��5      ]� .+�5   
      tab_control.Menu  $	��Top=�6   62   �� 5   
   $��-2q�6   $��
0, 0, 0, 0q�6!   $	��Top=�6>   $	��485��6S    � 	Resources 5	       �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint	 � Color
 � Offset �� Triggers P� Property P� Value��%�  '��       �� 5
      " ��6   .�5      ��  � ��$ 1q�68   6D   �� 5       � ��
 �   �6D   �� 5       � �� 5      �� 5      $	 0,1&�62   $	 0,0&�6A   .��5   "   � $	 	#FF250A0A��6/   $
 0Q�6A   � 5   "   $	 	#FF363232��6/   $
 1Q�6A   5      5      �� 5       � ��
 �����6C   �� 5       � ��$ 20q�60   6=    5      P� 5       �@��
IsSelected . . �5      ��  � ��
 �   �6K   5      5      5      .@�5      �� $��Gérer utilisateurs��6   $	��353��62   .��5       �� .+�5"      � $��Center=�6    $��0, 10, 0, 10q�6=   .+�5#      �� -   5        $��SuprimerMembre��5#   !   $��	Supprimer��67   $��10q�6K   
���Gc��
�������6�   5$      �� 5%      -   5        $��bddAdmin��5%   -   $	��900��6!    5&      ��%V   '��       �� 5'      " ��6$   .�5(   "   ��  � ��$ 0q�6D   6P   5*      5+      .@�5,      �� -   5        $��Parents��5,   "   $	��294��63   .��5-      &   System.Windows.Controls.DataGrid  -   5        $��
ParentsBDD��5.   '   $	��800��5-   '   $��0, 20, 0, 0q�63      AutoGenerateColumns .  $��Visible=�51   '   ��. $��Visible=�53   '   $	��600��54   '      Columns 57   "   0  *System.Windows.Controls.DataGridTextColumn  58   &   ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Nom+6`     59   &   $ Prenom��69    6I   �� *Prenom+6f     5:   &   $	 Gsm��69    6F   �� *Gsm+6`     5;   &   $ Nb. enfants��69    6N   �� *	NbEnfants+6n   5>      5?      �� 5@      -   5        $��
Babysitter��5@   "   $	��294��66   .��5A      �� .+�5B   "   � $��center=�6,   .+�5C   "   �� -   5        $��nonActif��5D   )   $��	Non Actif��5C   )    � ToolTip$. (Affiche les babysitter pas encore actifs��5E   )   $��Center=�5F   )   $	��120��6F   $��30��6R   
���**��
�������5H   B   �� 5I   &   -   5        $��tousBaby��5J   -   $��Tous les babysitters��5I   -   $- 'Affiche les babysitter actifs/non actif��5K   -   $��Center=�5L   -   $	��120��6J   $��30��6V   
���**��
�������5N   F   5P   #     5Q   "   -   5        $��BabysitterBDD��5R   '   $	��800��5Q   +   $��0, 20, 0, 0q�67    .  $��Visible=�5U   '   ��. $��Visible=�5W   '   $	��600��5X   '    5Z   "     5[   &   $	 Nom��69    6F   �� *Nom+6`     5\   &   $ Prenom��69    6I   �� *Prenom+6f     5]   &   $	 Gsm��69    6F   �� *Gsm+6`     5^   *   $ 
Date dispo��6=    6Q   �� *	DateDispo+6q     5_   *   $ Date fin dispo��6=    6U   �� *DateFinDispo+6x   4  .System.Windows.Controls.DataGridCheckBoxColumn  5`   &   $ Actif?��6=    6M   �� *	Confirm+6k   5b      5c      5d      �� 5e      -	   5        $��Intermédiaire��5e   "   $	��300��69   .��5f        -
   5        $��IntermediaireBDD��5h   '   $	��800��5f   '   $��0, 20, 0, 0q�63    .  $��Visible=�5k   '   ��. $��Visible=�5m   '   $	��600��5n   '    5o   "     5p   &   $	 Nom��69    6F   �� *Nom+6`     5q   &   $ Prenom��69    6I   �� *Prenom+6f     5r   &   $	 Gsm��69    6F   �� *Gsm+6`   5t      5u      5v      5x      5y      �� 5z      $
��Mail��6   $	��340��6$   .��5{         tab_control.Mail  6%   5|      �� 5}      $	��291��6   ��5~      �� 5      -   5        $��
headerIden��5   :   ��6    ��  �� Path$	 Nom�6N   .��5�         tab_control.UserControl1  6-   5�      5�      	   tab_control.Notification	  5�      $��0, 10, 0, 0q�6'   
���   �$��
0, 2, 0, 0q�6P   $��Bottom=�6m   6�   5�      5�      