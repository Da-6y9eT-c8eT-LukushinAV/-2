   M S B A M L   `   `   `  ����
  FitPro    FitPro.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Учет инвентаря��5   	   $	��450��6    $	��800��6-   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5q�6a   �� 5      -   5         ��Name$ FilterComboBox��5      $	��150��6/   $��5q�6n   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ InventoryDataGrid��5      $��1��6.      AutoGenerateColumns$ False��6;   $��10q�6W      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *	Article+  5      $ Название��6%   	 67   �� *Name+  5      $ Тип��6%   	 62   �� *Type+  5      $ Описание��6%   	 67   �� *Description+  5      $ Дата выдачи��6%   	 6:   �� *	IssueDate+
 �� StringFormat$
 d��  5      $ Дата возврата��6%   	 6<   �� *
ReturnDate+$
 d��  5      $ Статус��6%   	 65   �� *Status+  5      $ Пользователь��6%   	 6;   �� *User+5      �� 5!   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5"      �� -   5        $��Добавить��5"      $��5q�6C   �� 5#      -   5        $ ��Редактировать��5#      $��5q�6I   �� 5$      -   5        $��Удалить��5$      $��5q�6E   5%      5&      5'      