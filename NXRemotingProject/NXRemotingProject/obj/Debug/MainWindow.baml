   M S B A M L   `   `   `  ����L  HNXRemotingProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NXRemotingProjectNXRemotingProject  5   	   "    NXRemotingProject.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:NXRemotingProject     5   	     � Title$  
MainWindow��5   	   $��275.692��6   $	��455��6-   .��5	      � $��0,0,2,0q�6   .+�5
   
   �� -   5         ��Name$ browseButton��5
      $��	Browse...��6'   $
��Left=�6;   $��
354,48,0,0q�6V   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5         ��Name$ 
titleLabel��5      $��NX AIRFOIL EXTRUDER��6$   $
��Left=�6B   $��	104,0,0,0q�6]   $	��Top=�6p   $��22(�6�   �� 5   
   -   5        $ labelSelectAirfoil��5      $��1. Select Airfoil:��6,   $
��Left=�6I   $��	10,45,0,0q�6d   $	��Top=�6w   $	��102��6�   �� 5   
   -   5         ��Name$ filePath��5      $
��Left=�6$   $��23��6?   $��
112,48,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��224��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ labelExtrudeLength��5      $��2. Extrude Length (mm):��6,   $
��Left=�6N   $��	10,92,0,0q�6i   $	��Top=�6|   �� 5   
   -   5        $ extrudeLength��5      $
��Left=�6)   $��23��6D   $��
151,95,0,0q�6P   $
 Wrap=�6d   $	��100��6x   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ 
labelScale��5      $��3. Select Scale:��6$   $
��Left=�6?   $��
10,140,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5         ��Name$ slider��5      $
��Left=�6!   $��160,143,0,0q�6<   $	��Top=�6Q   $	��275��6i    � Maximum$ 50Q�6u    � Minimum$ 1Q�6�   �� 5   
   -	   5        $ goLabel��5      $��4. Create NX Part:��6!   $
��Left=�6>   $��
10,195,0,0q�6Y   $	��Top=�6m   �� 5   
   -
   5        $ goButton��5      $��Go��6#   $
��Left=�60   $��118,195,0,0q�6K   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5        $ scaleFactor��5      $
��Left=�6'   $��23��6B   $��102,143,0,0q�6N   $
 Wrap=�6c   $	��Top=�6�   $��51��6�   ��6w   �� 	 �� ElementName$	 slider��
 �� Path$
 Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      