   M S B A M L   `   `   `  ����L  HMyPasswordManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MyPasswordManager.ControlsMyPasswordManager.Controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35ZAclr-namespace:System.Windows.Shell;assembly=PresentationFrameworkSystem.Windows.Shell 5   	   /    )MyPasswordManager.Controls.FeedbackWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:MyPasswordManager.Controls     5   	   SshellAclr-namespace:System.Windows.Shell;assembly=PresentationFramework     5   	   -   5          � Title$  Feedback��5	   	   $��145.656��6   $��288.671��6+   $��Center=�6;    � 
ResizeMode$ NoResize=�6o   $��0q�6�   
������� � WindowStyle$
 None=�6�   ��5
      �� 5   
    �� 
TargetType" �6   .�5      �� '  !System.Windows.Shell.WindowChrome �� Property �@ WindowChrome �� Value 5        5      5      �� 5       � �� 5      �� 5       �� 
TargetType" �6&   .R�5      � .+�5      �� 
������� �� CornerRadius 5   %   ��  �� Path$ TitleBarBorderRadius�	 �� Mode$	 OneWay=�
 �� RelativeSource
 ��  �� AncestorType$ WindowL���5   %   �� $ TitleBarColor�$	 OneWay=�
 �� $ WindowL���5   %   �� $ TitleBarBorderThickness�$	 OneWay=�
 �� $ WindowL�5      �� 5      #��z  6$   $��Segoe Print)�6�   $��16(�6�   $
��Bold"�6�   $��Center=�6�   ��6F   �� $ TitleBarTextColor�$	 OneWay=�
 �� $ WindowL�6�   �� 5      #��z��6/   5      5      5       5!      .��5#      �    IsHitTestVisibleInChrome . .+�5$   
   �� -   5         ��Name$ FeedbackLbl��5$      $��
10,10,10,0q�6%   $��88��69   $	��Top=�6E   $��Center=�6]   $��Center=�6   $��Tempus Sans ITC)�6�   $��16(�6�   $��SemiBold"�6�   $��	Condensed&�6�   .��5%      �� -   5         ��Name$ FeedbackTxtBx��5%      $�� ��6/   $
��Wrap=�67    �� TextAlignment$ Center=�6K   5&      �� 5'   
   -   5         ��Name$ FeedbackBtn��5'      $��OK��6&   $��	0,70,0,15q�63   $��Bottom=�6F   $��75��6a   ���	#FFDCE0DC . $��Kristen ITC)�6�   $��16(�6�   $��2q�6�   5(      5)      