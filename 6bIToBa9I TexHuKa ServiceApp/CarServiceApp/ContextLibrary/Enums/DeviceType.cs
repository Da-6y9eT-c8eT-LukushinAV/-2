using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceApp.ContextLibrary.Enums
{
    /// <summary>
    /// Тип техники
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// Холодильник
        /// </summary>
        [Description("Холодильник")]
        Refrigerator,

        /// <summary>
        /// Стиральная машина
        /// </summary>
        [Description("Стиральная машина")]
        WashingMachine,

        /// <summary>
        /// Телевизор
        /// </summary>
        [Description("Телевизор")]
        Television,

        /// <summary>
        /// Микроволновая печь
        /// </summary>
        [Description("Микроволновая печь")]
        Microwave,

        /// <summary>
        /// Посудомоечная машина
        /// </summary>
        [Description("Посудомоечная машина")]
        Dishwasher
    }
}
