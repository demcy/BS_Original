using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace BattleShip_Web.Pages_Games
{
    public class EditModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public EditModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public string Winner { get; set; }
        

        public async Task<IActionResult> OnGetAsync(int? id, int? uid)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games
                .Include(u=>u.Player1)
                .Include(v=>v.Player2)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (Game.Player1.UserId == uid)
            {
                Winner = "Player1 wins";
            }
            else
            {
                Winner = "Player2 wins";
            }
            
           
            

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.GameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
