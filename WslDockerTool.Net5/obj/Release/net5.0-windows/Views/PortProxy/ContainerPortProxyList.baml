   M S B A M L   `   `   `  ���� M  IWslDockerTool.Net5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WslDockerTool.Net5.Views.PortProxy"WslDockerTool.Net5.Views.PortProxy  ?    9WslDockerTool.Net5.Views.PortProxy.ContainerPortProxyList   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  <local0clr-namespace:WslDockerTool.Net5.Views.PortProxy  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True.���    	GridPanel#��[   � RowDefinitions �� $��0 ��� $��* ��� $��* ��� $��* ��� $��50 �.+��� $��1��$
��auto��$	��5,2q�$��Center=� �� Orientation$ 
Horizontal=�.+��  �� $��40 ��� $��* �.+��� $
��auto��$��Center=�$ 
Horizontal=�.+��� $
��auto��$��Center=�$��Center=�$ 
Horizontal=�.+��� $��80�� �� 
IsEditable$ False������ *ContainerPortList+ �� SelectedItem �� *SelectedContainerPort+���� .R��� ���� *Name+*  $HandyControl.Controls.AdornerElement   Instance "  HandyControl.Controls.Poptip     Content$ 容器端口��   PlacementType$ TopLeft=�'  !HandyControl.Controls.ButtonGroup  $	��200��$��Center=�$��Center=�.@��� $��刷新��  ButtonDashedSuccess#���  ���� *QueryCommand+�� $��创建��  ButtonDashedInfo#���  ���� *CreateCommand+�� $��移除��#���  ���� *MultipleRemoveCommand+���� *SelectedItems+ �� ElementName$ datagrid��&   System.Windows.Controls.DataGrid  -   	  Name$	 datagrid��$��1��$	��560��$	��280��
   AutoGenerateColumns$
 False��   HeadersVisibility$	 All=�   RowHeaderWidth$ 60Q����� *Items+   RowHeaderTemplate �� .R���  d� 	IsChecked �� *
IsSelected+ �� RelativeSource ��  �� AncestorType DataGridRow   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2*    Header$ 监听地址��   
IsReadOnly$
 True��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *ListenAddress+  $ * $ 监听端口�� �� *
ListenPort+  $ 2* $ 转发地址�� �� *ConnectAddress+  $ * $ 转发端口�� �� *ConnectPort+4
  .System.Windows.Controls.DataGridTemplateColumn
  $ 操作��$
 True�� 
  CellTemplate �� .R��� $��Center=�$��Center=�$ 
Horizontal=�.+�  .@��� $��移除��#���  ���� *DataContext.RemoveCommand+ �� *FindAncestor+"  ���� *.+�� $��3��$
��auto��$	��5,2q�$
��Left=�$ 
Horizontal=�.+���   	FromLable#��[ $��容器名称:��   $ 容器名称:��$	 Top=��� #��[ ���� *ContainerName+   $	 Top=� �� *ContainerName+�� $��4��$��1��$��Right=�$ 
Horizontal=�.+��� $
��10,0q�)  #HandyControl.Controls.BorderElement   CornerRadius$ 5��)  #Prism.Services.Dialogs.ButtonResult	   OK#��Z $��确认�� �� 	IsDefault$
 True��  ButtonOk#��[ ���� *CloseCommand+�� $
��10,0q�$ 5��   Cancel#��Z $��取消�� �� IsCancel$
 True��  ButtonCancel#��[ ���� *CloseCommand+