using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTaskManager.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        /// 
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Не указано название задачи")]
        public string Name { get; set; }

        /// <summary>
        /// Дата и время начала
        /// </summary>
        /// 
        [Display(Name = "Дата и время начала")]
        [Required(ErrorMessage = "Не указана дата и время начала задачи")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Дата и время окончания
        /// </summary>
        [Display(Name = "Дата и время окончания")]
        [Required(ErrorMessage = "Не указана дата и время окончания задачи")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Статус активности
        /// 1 - активная
        /// 0 - не активна
        /// </summary>
        [Display(Name = "Статус активности")]
        [Required]
        [Range(0, 1, ErrorMessage = "Статус активности задачи имеет недопустимое значение")]
        public TaskActivityStateEnum ActivityState { get; set; }

        #region Альтернативная реализация
        /// <summary>
        /// Время выполнения задачи
        /// </summary>
        //public int ExpiresSec { get; set; }
        #endregion
    }
}
