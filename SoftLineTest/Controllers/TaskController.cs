using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftLineTest.DAL;
using SoftLineTest.Models.Models;
using SoftLineTest.Models.ViewModels;
using Task = SoftLineTest.Models.Models.Task;

namespace SoftLineTest.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var tasks = _context.Task;

            if (tasks == null)
            {
                return View();
            }

            var listOfTasks = tasks.ToList();
            for (int i = 0; i < listOfTasks.Count; i++)
            {
                listOfTasks[i].Status = _context.Status.FirstOrDefault(u => u.StatusID == listOfTasks[i].StatusId);
            }

            return View(listOfTasks);
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            TaskVM taskVM = new TaskVM()
            {
                Task = new Task(),
                StatusSelectList = _context.Status.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusID.ToString()
                })
            };

            return View(taskVM);
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskVM taskVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskVM.Task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            taskVM = new TaskVM()
            {
                Task = new Task(),
                StatusSelectList = _context.Status.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusID.ToString()
                })
            };
            return View(taskVM);
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskVM taskVM = new TaskVM()
            {
                Task = new Task(),
                StatusSelectList = _context.Status.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusID.ToString()
                })
            };


            taskVM.Task = _context.Task.FirstOrDefault(u => u.Id == id);
            if (taskVM.Task == null)
            {
                return NotFound();
            }
            taskVM.Task.Status = _context.Status.FirstOrDefault(u => u.StatusID == taskVM.Task.StatusId);
            return View(taskVM);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskVM taskVM)
        {
            if (id != taskVM.Task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskVM.Task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(taskVM.Task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            taskVM.Task.Status = _context.Status.FirstOrDefault(u => u.StatusID == taskVM.Task.StatusId);
            return View(taskVM);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Task.FindAsync(id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
