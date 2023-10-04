using Microsoft.AspNetCore.Mvc.Rendering;
using SoftLineTest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = SoftLineTest.Models.Models.Task;

namespace SoftLineTest.Models.ViewModels
{
    public class TaskVM
    {
        public Task Task { get; set; }
        public IEnumerable<SelectListItem> StatusSelectList { get; set; }
    }
}
