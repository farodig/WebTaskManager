using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTaskManager.Models
{
    /// <summary>
    /// Статус задачи
    /// </summary>
    public enum TaskActivityStateEnum
    {
        /// <summary>
        /// Неактивна
        /// </summary>
        InActive = 0,

        /// <summary>
        /// Активна
        /// </summary>
        Active = 1
    }
}
