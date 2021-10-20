using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTaskManager.Models;

namespace WebTaskManager
{
    /// <summary>
    /// Инициализатор базы данных
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Инициировать значения
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ApplicationContext context)
        {
            // Пересоздать базу данных (для простоты)
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Проверить наличие задач в базе данных
            if (context.Tasks.Any())
            {
                return;
            }

            var rnd = new Random();

            // Количество задач
            var taskSize = 240;

            // Дата истечения
            var expireDate = DateTime.Now.AddHours(2);

            for (int i = 1; i <= taskSize; i++)
            {
                context.Tasks.Add(new TaskModel
                {
                    // Название задачи
                    Name = "Задача №" + i,

                    // Дата и время начала
                    StartDateTime = expireDate.AddMinutes(-(taskSize + i)),

                    // Дата и время окончания
                    EndDateTime = expireDate.AddMinutes(taskSize / 2 - i),

                    // Статус активности
                    ActivityState = rnd.Next(0, 2) > 0 ? TaskActivityStateEnum.Active : TaskActivityStateEnum.InActive
                });
            }

            context.SaveChanges();
        }
    }
}
