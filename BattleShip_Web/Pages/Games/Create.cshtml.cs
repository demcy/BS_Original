using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace BattleShip_Web.Pages_Games
{
    public class CreateModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public CreateModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NewGame ng = new NewGame(_context);
            Game.Player1.SelfBoard = ng.DefaultBoard(false);//_context.Boards.FirstOrDefault(i => i.BoardId == b.BoardId);//b;
            Game.Player1.OppenentBoard = ng.DefaultBoard(true);
            Game.Player2.SelfBoard = ng.DefaultBoard(false);
            Game.Player2.OppenentBoard = ng.DefaultBoard(true);
            _context.Games.Add(Game);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}