   M S B A M L   `   `   `  ����M  IWslDockerTool.Net5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WslDockerTool.Net5.Views.PortProxy"WslDockerTool.Net5.Views.PortProxy  5      ?    9WslDockerTool.Net5.Views.PortProxy.ContainerPortProxyList   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      <local0clr-namespace:WslDockerTool.Net5.Views.PortProxy  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5
      .��5      �    	GridPanel#��[  6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��1��5      $
��auto��5      $	��5,2q�5      $��Center=�5       �� Orientation$ 
Horizontal=�5      .+�5      �  5      �� 5      $��40 �6$   �� 5      $��* �6$   .+�5      �� $
��auto��5       $��Center=�5!      $ 
Horizontal=�5"      .+�5$      �� $
��auto��5%      $��Center=�5&      $��Center=�5'      $ 
Horizontal=�5(      .+�5+      �� $��80��5,       �� 
IsEditable$ False��5-      ��5.      �� *ContainerPortList+ �� SelectedItem 5/      �� *SelectedContainerPort+��51      �� 52   "   .R�53   &   �� ��60   �� *Name+54   #   *  $HandyControl.Controls.AdornerElement   Instance 56      "  HandyControl.Controls.Poptip  57   "      Content$ 容器端口��6,      PlacementType$ TopLeft=�6;   59      5:      '  !HandyControl.Controls.ButtonGroup  5<      $	��200��5=      $��Center=�5>      $��Center=�5?      .@�5@      �� $��刷新��5B        ButtonDashedSuccess#���  5C      ��5A      �� *QueryCommand+5C      �� 5D      $��创建��5F        ButtonDashedInfo#���  5G      ��5E      �� *CreateCommand+5G      �� 5H      $��移除��5K      #���  5L      ��5I      �� *MultipleRemoveCommand+��5J      �� *SelectedItems+ �� ElementName$ datagrid��5L      5M      5N      &   System.Windows.Controls.DataGrid  5O      -   5        	  Name$	 datagrid��5P      $��1��5Q      $	��560��5R      $	��280��5S      
   AutoGenerateColumns$
 False��5T         HeadersVisibility$	 All=�5U         RowHeaderWidth$ 60Q�5W      ��5V      �� *Items+   RowHeaderTemplate 5X      �� 5Y      .R�5Z      ��  d� 	IsChecked 6'   �� *
IsSelected+ �� RelativeSource ��  �� AncestorType DataGridRow5[         Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 5_         Header$ 监听地址��5a         
IsReadOnly$
 True��5b      1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5`      �� *ListenAddress+5b        5c      $ * 5d      $ 监听端口��5f       5e      �� *
ListenPort+5f        5g      $ 2* 5h      $ 转发地址��5j       5i      �� *ConnectAddress+5j        5k      $ * 5l      $ 转发端口��5n       5m      �� *ConnectPort+5n      4
  .System.Windows.Controls.DataGridTemplateColumn
  5o      $ 操作��61   $
 True��6=    
  CellTemplate 5p      �� 5q   "   .R�5r   &   �� $��Center=�5s   )   $��Center=�5t   )   $ 
Horizontal=�5u   )   .+�5v   *     .@�5x   .   �� $��移除��5{   1   #���  5|   1   ��5y   1   �� *DataContext.RemoveCommand+ �� *FindAncestor+"  ��5z   1   �� *.+5|   1   5}   +   5~   '   5   #   5�      5�      5�      5�      �� 5�   
   $��3��5�      $
��auto��5�      $	��5,2q�5�      $
��Left=�5�      $ 
Horizontal=�5�      .+�5�      ��   	FromLable#��[ 6   $��容器名称:��6;    5�        5�      $ 容器名称:��6    $	 Top=�60   5�      �� 5�      #��[ 6   ��6;   �� *ContainerName+ 5�        5�      $	 Top=�6B    6    �� *ContainerName+6B   5�      5�      �� 5�   
   $��4��5�      $��1��5�      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� $
��10,0q�5�      )  #HandyControl.Controls.BorderElement   CornerRadius$ 5��5�      )  #Prism.Services.Dialogs.ButtonResult	   OK#��Z 5�      $��确认��5�       �� 	IsDefault$
 True��5�        ButtonOk#��[ 5�      ��5�      �� *CloseCommand+5�      �� 5�      $
��10,0q�5�      $ 5��5�         Cancel#��Z 5�      $��取消��5�       �� IsCancel$
 True��5�        ButtonCancel#��[ 5�      ��5�      �� *CloseCommand+5�      5�      5�      5�      