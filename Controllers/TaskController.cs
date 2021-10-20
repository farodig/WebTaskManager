using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTaskManager.Models;

namespace WebTaskManager.Controllers
{
    /// <summary>
    /// Контроллер задач
    /// </summary>
    public class TaskController : Controller
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Инициализация
        /// </summary>
        public TaskController(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Вывести все задачи
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        /// <summary>
        /// Вывести все 
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public async Task<IActionResult> Expiring(int hours = 2)
        {
            // Дата истечения
            var expireDate = DateTime.Now.AddHours(hours);

            return View(await _context.Tasks.Where(a => 
                    // Активные
                    a.ActivityState == TaskActivityStateEnum.Active
                    // Должны быть закрыты в ближайшие 2 часа
                    && a.EndDateTime < expireDate)
                .ToListAsync());
        }
    }
}
