﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ktrainer.Data;
using Ktrainer.Models;

namespace Ktrainer.Pages.Routines
{
    public class DeleteModel : PageModel
    {
        private readonly Ktrainer.Data.ApplicationDbContext _context;

        public DeleteModel(Ktrainer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Routine Routine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Routine = await _context.Routine.FirstOrDefaultAsync(m => m.ID == id);

            if (Routine == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Routine = await _context.Routine.FindAsync(id);

            if (Routine != null)
            {
                _context.Routine.Remove(Routine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
