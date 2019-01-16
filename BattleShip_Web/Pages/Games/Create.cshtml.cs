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
            
            
            /*Board board = ng.DefaultBoard();
            ng.RandomBoard(board);
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();*/
            
            Game.Player1.SelfBoard = ng.DefaultBoard(false);//_context.Boards.FirstOrDefault(i => i.BoardId == b.BoardId);//b;
            //string a = Game.Player1.SelfBoard.RowNodes[0].Nodes[3].NodeValue;
            Game.Player1.OppenentBoard = ng.DefaultBoard(true);
            Game.Player2.SelfBoard = ng.DefaultBoard(false);
            Game.Player2.OppenentBoard = ng.DefaultBoard(true);
            
            //Game.Player1.OppenentBoard.RowNodes[0].Nodes[0].NodeValue = "a";

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();
           
            /*for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Game.Player1.SelfBoard.RowNodes[i].Nodes[j].NodeValue = board.RowNodes[i].Nodes[j].NodeValue;
                }
            }

            await _context.SaveChangesAsync();*/
            
            //ng.RandomBoard(Game.Player1.SelfBoard);
            //ng.RandomBoard(Game.Player2.SelfBoard);
            //await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}