using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.ContextLibrary.Enums
{
    /// <summary>
    /// Этап выполнения заявки
    /// </summary>
    public enum RequestStage
    {
        [Description("Ожидание запчастей")]
        WaitingForParts,

        [Description("В процессе ремонта")]
        InProcess,

        [Description("Готово к выдаче")]
        ReadyForPickup
    }
}
