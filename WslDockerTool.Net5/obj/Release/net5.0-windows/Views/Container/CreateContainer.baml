   M S B A M L   `   `   `  ���� M  IWslDockerTool.Net5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WslDockerTool.Net5.ControlsWslDockerTool.Net5.Controls  W0clr-namespace:WslDockerTool.Net5.Views.Container"WslDockerTool.Net5.Views.Container  8    2WslDockerTool.Net5.Views.Container.CreateContainer   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >controls)clr-namespace:WslDockerTool.Net5.Controls     @d2http://schemas.microsoft.com/expression/blend/2008     S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  <local0clr-namespace:WslDockerTool.Net5.Views.Container  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True.���    	GridPanel#��[   � RowDefinitions �� $��10 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��50 �.+��� $��1��$
��auto��$	��5,2q�$
��Left=� �� Orientation$ Vertical=�.+���   	FromLable#��[ $��镜像名称:��*  $HandyControl.Controls.AdornerElement   Instance "  HandyControl.Controls.Poptip     Content$ 镜像名称��   PlacementType$ TopLeft=���  �� 
IsEditable$ False��{��� *IsDialogParametersNull+���� *	ImageList+ �� SelectedItem �� *SelectedImage+���� .R��� ���� *Name+   $ 请选择镜像名称��$ TopLeft=��� $��2��$
��auto��$	��5,2q�$
��Left=�$ Vertical=�.+��� #��[ $��容器名称:��   $ 容器名称��$ TopLeft=��� ���� *ContainerName+.��   $ 请输入容器名称��$ TopLeft=�.���� $��3��$
��auto��$	��5,2q�$
��Left=�$ Vertical=�.+��� #��[ $��端口设置:��   $] W主机端口:容器端口(例 3306:3306)
多个请用'|'分割(例 3306:3306|3308:3306)��$ TopLeft=��� ���� *Ports+.��   $] W主机端口:容器端口(例 3306:3306)
多个请用'|'分割(例 3306:3306|3308:3306)��$ TopLeft=�.���� $��4��$
��auto��$	��5,2q�$
��Left=�$ Vertical=�.+��� #��[ $��
数据卷:��   $� �主机目录:容器目录(例 /my/custom:/etc/mysql/conf.d)
多个请用'|'分割(例  /my/custom:/etc/mysql/conf.d|/my/own/datadir:/var/lib/mysql)��$ TopLeft=��� ���� *	Volumes+.��   $� �主机目录:容器目录(例 /my/custom:/etc/mysql/conf.d)
多个请用'|'分割(例  /my/custom:/etc/mysql/conf.d|/my/own/datadir:/var/lib/mysql)��$ TopLeft=�.���� $��5��$
��auto��$	��5,2q�$
��Left=�$ Vertical=�.+��� #��[ $��环境变量:��   $� �环境变量=对应值(例 MYSQL_ROOT_PASSWORD=123456)
多个请用'|'分割(例  MYSQL_ROOT_PASSWORD=123456|MARIADB_USER=example-user)��$ TopLeft=��� ���� *Envs+.��   $� �环境变量=对应值(例 MYSQL_ROOT_PASSWORD=123456)
多个请用'|'分割(例  MYSQL_ROOT_PASSWORD=123456|MARIADB_USER=example-user)��$ TopLeft=�.���� $��6��$��1��$��Right=�$ 
Horizontal=�.+��� $
��10,0q�)  #HandyControl.Controls.BorderElement   CornerRadius$ 5��)  #Prism.Services.Dialogs.ButtonResult		   OK#��Z	 $��确认��
 �� 	IsDefault$

 True��  ButtonOk#��[ ���� *CloseCommand+�� $
��10,0q�$ 5��   Cancel#��Z $��取消�� �� IsCancel$
 True��  ButtonCancel#��[ ���� *CloseCommand+