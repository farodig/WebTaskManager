using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTaskManager.Models
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Задачи
        /// </summary>
        public DbSet<TaskModel> Tasks { get; set; }

        /// <summary>
        /// Инициализация контекста
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
