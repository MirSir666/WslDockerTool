   M S B A M L   `   `   `  ����M  IWslDockerTool.Net5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:WslDockerTool.Net5.ControlsWslDockerTool.Net5.Controls  5      W0clr-namespace:WslDockerTool.Net5.Views.Container"WslDockerTool.Net5.Views.Container  5      8    2WslDockerTool.Net5.Views.Container.CreateContainer   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >controls)clr-namespace:WslDockerTool.Net5.Controls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5      <local0clr-namespace:WslDockerTool.Net5.Views.Container  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5
      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5      .��5      �    	GridPanel#��[  6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   �� $��1��5      $
��auto��5      $	��5,2q�5      $
��Left=�5       �� Orientation$ Vertical=�5      .+�5      ��   	FromLable#��[ 6   $��镜像名称:��6;   *  $HandyControl.Controls.AdornerElement   Instance 5       "  HandyControl.Controls.Poptip  5!         Content$ 镜像名称��6       PlacementType$ TopLeft=�6/   5#      �� 5$       �� 
IsEditable$ False��5%      {�5&      �� *IsDialogParametersNull+��5'      �� *	ImageList+ �� SelectedItem 5(      �� *SelectedImage+��5)      �� 5*      .R�5+      �� ��6$   �� *Name+5,       5.        5/      $ 请选择镜像名称��6    $ TopLeft=�62   51      52      �� 53   
   $��2��54      $
��auto��55      $	��5,2q�56      $
��Left=�57      $ Vertical=�58      .+�59      �� #��[ 6   $��容器名称:��6;    5:        5;      $ 容器名称��6    $ TopLeft=�6/   5=      �� 5>      ��6   �� *ContainerName+.��65    5?        5@      $ 请输入容器名称��6    $ TopLeft=�62   .��5A   &   5B      5C      �� 5D   
   $��3��5E      $
��auto��5F      $	��5,2q�5G      $
��Left=�5H      $ Vertical=�5I      .+�5J      �� #��[ 6   $��端口设置:��6;    5K        5L      $] W主机端口:容器端口(例 3306:3306)
多个请用'|'分割(例 3306:3306|3308:3306)��6    $ TopLeft=�6g   5O      �� 5P      ��6   �� *Ports+.��6-    5Q        5R      $] W主机端口:容器端口(例 3306:3306)
多个请用'|'分割(例 3306:3306|3308:3306)��6    $ TopLeft=�6g   .��5S   &   5T      5U      �� 5V   
   $��4��5W      $
��auto��5X      $	��5,2q�5Y      $
��Left=�5Z      $ Vertical=�5[      .+�5\      �� #��[ 6   $��
数据卷:��6;    5]        5^      $� �主机目录:容器目录(例 /my/custom:/etc/mysql/conf.d)
多个请用'|'分割(例  /my/custom:/etc/mysql/conf.d|/my/own/datadir:/var/lib/mysql)��6    $ TopLeft=�6�   5`      �� 5a      ��6   �� *	Volumes+.��6/    5b        5c      $� �主机目录:容器目录(例 /my/custom:/etc/mysql/conf.d)
多个请用'|'分割(例  /my/custom:/etc/mysql/conf.d|/my/own/datadir:/var/lib/mysql)��6    $ TopLeft=�6�   .��5d   &   5e      5f      �� 5g   
   $��5��5h      $
��auto��5i      $	��5,2q�5j      $
��Left=�5k      $ Vertical=�5l      .+�5m      �� #��[ 6   $��环境变量:��6;    5n        5o      $� �环境变量=对应值(例 MYSQL_ROOT_PASSWORD=123456)
多个请用'|'分割(例  MYSQL_ROOT_PASSWORD=123456|MARIADB_USER=example-user)��6    $ TopLeft=�6�   5q      �� 5r      ��6   �� *Envs+.��6,    5s        5t      $� �环境变量=对应值(例 MYSQL_ROOT_PASSWORD=123456)
多个请用'|'分割(例  MYSQL_ROOT_PASSWORD=123456|MARIADB_USER=example-user)��6    $ TopLeft=�6�   .��5u   &   5v      5w      �� 5y   
   $��6��5z      $��1��5{      $��Right=�5|      $ 
Horizontal=�5}      .+�5~      �� $
��10,0q�5      )  #HandyControl.Controls.BorderElement   CornerRadius$ 5��5�      )  #Prism.Services.Dialogs.ButtonResult		   OK#��Z	 5�      $��确认��5�      
 �� 	IsDefault$

 True��5�        ButtonOk#��[ 5�      ��5�      �� *CloseCommand+5�      �� 5�      $
��10,0q�5�      $ 5��5�         Cancel#��Z 5�      $��取消��5�       �� IsCancel$
 True��5�        ButtonCancel#��[ 5�      ��5�      �� *CloseCommand+5�      5�      5�      5�      