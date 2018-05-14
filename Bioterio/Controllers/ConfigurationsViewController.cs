using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bioterio.Models;

namespace Bioterio.Controllers
{
    public class ConfigurationsViewController : Controller
    {

        private readonly bd_lesContext _context;

        public ConfigurationsViewController(bd_lesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new ConfigurationsViewModel();
            model.Especies = _context.Especie.ToList();
            model.Familias = _context.Familia.ToList();
            model.Grupos = _context.Grupo.ToList();
            return View(model);
        }

        
    }
}