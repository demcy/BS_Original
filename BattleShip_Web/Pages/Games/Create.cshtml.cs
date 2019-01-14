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
            
            NewGame ng = new NewGame();
            Game.Player1.SelfBoard = ng.DefaultBoard();
            Game.Player1.OppenentBoard = ng.DefaultBoard();
            Game.Player2.SelfBoard = ng.DefaultBoard();
            Game.Player2.OppenentBoard = ng.DefaultBoard();
            ng.RandomBoard(Game.Player1.SelfBoard);
            ng.RandomBoard(Game.Player2.SelfBoard);
            Game.Player1.OppenentBoard.RowNodes[0].Nodes[0].NodeValue = "a";

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}