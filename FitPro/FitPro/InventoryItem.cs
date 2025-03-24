using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPro
{
    public class InventoryItem
    {
        public string Article { get; set; }        // Артикул инвентаря
        public string Name { get; set; }           // Название инвентаря
        public string Type { get; set; }           // Тип инвентаря
        public string Description { get; set; }    // Описание инвентаря
        public DateTime IssueDate { get; set; }    // Дата выдачи инвентаря
        public DateTime ReturnDate { get; set; }   // Дата возврата инвентаря
        public string Status { get; set; }         // Статус наличия инвентаря
        public string User { get; set; }           // Пользователь инвентаря
    }
}
