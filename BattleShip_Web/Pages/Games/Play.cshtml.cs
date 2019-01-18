using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore.Internal;

namespace BattleShip_Web.Pages_Games
{
    public class PlayModel : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public PlayModel(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games
                .Include(u=>u.Player1).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player1).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .Include(u=>u.Player2).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player2).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                
                .FirstOrDefaultAsync(m => m.GameId == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PlayGame pg = new PlayGame(_context, id);
            pg.ShootBoard(Game.GMove);

            Game = await _context.Games
                .Include(u=>u.Player1).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player1).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .Include(u=>u.Player2).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player2).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                
                .FirstOrDefaultAsync(m => m.GameId == id);




            if (Game.Player1.Score >= 15 | Game.Player2.Score >= 15)
            {
                return RedirectToPage("./Edit", new{id = id, uid = Game.Player1.UserId});
            }
            else
            {
                return RedirectToPage("./Play", new {id = id});
                
            }
        }
        
        
    }
}
