   M S B A M L   `   `   `  ����J  FPOEFinalPartWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POEFinalPartWPFPOEFinalPartWPF  5   	   #    POEFinalPartWPF.TaskAssistant   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POEFinalPartWPF     5   	   -   5          � Title$  ChatBot��5	   	   $	��800��6   $
��1568��6&    � Icon$ OIP.JPG��63   $��Center=�6B   $��Center=�6_    � WindowState$ 	Maximized=�6z   .��5
      � 
���   �$��0,0,10,0q�6   .+�5   
   r� -   5         r�Name$ mediaElement��5       r� Stretch$
 Fill=�6-    r� LoadedBehavior$ Manual=�5       r� Source$j dC:\\Users\\lab_services_student\\Documents\\GitHub\\PROG6221FinalPOE\\POEFinalPartWPF\\voicemail.wav?�6+   �� 5   
   -   5        $��ChatBotReply��5   ~   $W��QWelcome user, review, add, mark task or remove a task? Can also view Log Activity��6    �� 
IsReadOnly . $
��20px(�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   ��. 
�������
����  �$
��10pxq�6  $��Center=�6.  $��Center=�6R  $��Center=�6t  $��	0,528,0,0q�6�  $	��Top=�6�  $	��216��6�  $	��896��6�  �� 5   
   $��Center=�6   $	��308��6-   $��0,10,0,0q�6:   $	��Top=�6L   $	��604��6d   $��	/Logo.jpg��6p   �� 5   
   -   5        $��btnClear��5   "   $��Clear��6   $
��50px(�6F   
�������
����  �$
��10pxq�6�   $
��Left=�6�   $��
34,374,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��232��6�   �� 5   
   -   5        $��
btnRespond��5   $   $��Respond��6   $
��50px(�6L   
�������
����  �$
��10pxq�6�   $
��Left=�6�   $��
34,586,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��232��6�   �� 5   
   -   5        $��btnMiniGame��5   %   $��	Mini Game��6   $
��40px(�6O   
�������
����  �$
��10pxq�6�   $
��Left=�6�   $��1293,374,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��224��6�   	 J� RenderTransformOrigin$	 0.011,-0.226&�6  �� 5   
   -   5        $��btnHome��5       $
��Home��6   $
��50px(�6B   
�������
����  �$
��10pxq�6|   $
��Left=�6�   $��1293,586,0,0q�6�   $	��Top=�6�   $	��100��6�   $	��224��6�   $	 -0.002,0.52&�6�   �� 5   
   -   5        $��	userInput��5      $
��30px(�69   
���������. 
����  �$
��10pxq�6�   
 �� TextAlignment$
 Center=�6�   $��Center=�6�   $��	0,350,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��
Enter Here��6
  $	��Top=�6  $	��896��64  $	��148��6@  �� 5   
   $��	Assistant��6   
�������
����  �$
��10pxq�6O   $��Center=�6f   $��100px(�6�   $
��Left=�6�   $��1086,48,0,0q�6�   $	��Top=�6�   $	��226��6�   $	��431��6�   �� 5   
   $
��Task��6   
�������
����  �$
��10pxq�6J   $��Center=�6a   $��150px(�6�   $
��Left=�6�   $��	10,48,0,0q�6�   $	��Top=�6�   $	��226��6�   $	��459��6�   5      5      