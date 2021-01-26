using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using EFDataAccessLibrary.DataAccess;

namespace InnovationSprintProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyAppContext _db;
        private readonly CreateServices cs = new CreateServices();

        public IndexModel(ILogger<IndexModel> logger,MyAppContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            cs.db = _db;
            cs.createMorbidityGroup("test1");
        }
    }
}
