   M S B A M L   `   `   `  ���� M  IWslDockerTool.Net5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WslDockerTool.Net5.ControlsWslDockerTool.Net5.Controls  W0clr-namespace:WslDockerTool.Net5.Views.PortProxy"WslDockerTool.Net5.Views.PortProxy  8    2WslDockerTool.Net5.Views.PortProxy.CreatePortProxy   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >controls)clr-namespace:WslDockerTool.Net5.Controls     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  <local0clr-namespace:WslDockerTool.Net5.Views.PortProxy  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True.���    	GridPanel#��[   � RowDefinitions �� $��10 ��� $��* ��� $��* ��� $��* ��� $��50 �.+��� $��1��$
��auto��$	��5,2q�$��Center=� �� Orientation$ 
Horizontal=�.+��� .+���   	FromLable#��[ $��监听IP地址:��*  $HandyControl.Controls.AdornerElement   Instance "  HandyControl.Controls.Poptip     Content$ 监听IP地址��   PlacementType$ TopLeft=���  �� 
IsReadOnly �� *
IsUpdate+���� *ListenAddress+.��   $ 请输入监听IP地址��$ TopLeft=�.���� .+��� $	��100��#��[ $��监听端口:��   $ 监听端口��$ TopLeft=��� $	��100�� �� *
IsUpdate+���� *
ListenPort+.��   $ 请输入监听端口��$ TopLeft=�.���� $��2��$
��auto��$	��5,2q�$��Center=�$ 
Horizontal=�.+��� .+��� #��[ $��转发IP地址:��   $ 转发IP地址��$ TopLeft=��� ���� *ConnectAddress+.��   $ 请输入转发IP地址��$ TopLeft=�.���� .+��� $	��100��#��[ $��转发端口:��   $ 转发端口��$ TopLeft=��� $	��100�� �� *IsPort+���� *ConnectPort+.��   $ 请输入转发端口��$ TopLeft=�.���� $��3��$
��auto��$	��5,2q�$��Center=�$ Vertical=�.+��� #��[ $��WSL IP:��   $ WSL IP:��$ TopLeft=��� $	��380��$��Center=�$��Center=�$
 True������ *Tips+�� $��4��$��1��$��Right=�$ 
Horizontal=�.+��� $
��10,0q�)  #HandyControl.Controls.BorderElement   CornerRadius$ 5��)  #Prism.Services.Dialogs.ButtonResult	   OK#��Z $��确认��	 �� 	IsDefault$
	 True��  ButtonOk#��[ ���� *CloseCommand+�� $
��10,0q�$ 5��
   Cancel#��Z
 $��取消�� �� IsCancel$
 True��  ButtonCancel#��[ ���� *CloseCommand+