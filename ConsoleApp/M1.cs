using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    public class M1
    {
        private static readonly DbContextOptionsBuilder<AppDbContext> _dbOptions = 
           new DbContextOptionsBuilder<AppDbContext>()
              .UseMySQL("server=alpha.akaver.com;database=student2018_andreskaver_BattleShipDataBase34;user=student2018;password=student2018");

        List<Game> Games = new List<Game>();
        public void DisplayM1()
        {
            
            Console.Clear();
            Console.WriteLine("Saved Games:");
            using (var _context = new AppDbContext(_dbOptions.Options))
            {
                Games = _context.Games
                    .Include(u => u.Player1)
                    .Include(v => v.Player2)
                    .ToList();
                int count = 1;
                foreach (var g in Games)
                {
                    Console.WriteLine(count++ +") " + g.GameName);
                }
                Console.WriteLine(count++ + ") " + "Create Game");
                Console.WriteLine(count + ") " + "End Game");
                Console.WriteLine("Please choose the game");
                string ch = Console.ReadLine();
                M1navigation(ch, count, _context);
            }


        }

        public void M1navigation(string c, int count, AppDbContext _context)
        {
            if (int.Parse(c) == count-1)
            {
                Game Game = new Game();
                Game.GameName = "ConsoleGame";
                NewGame ng = new NewGame(_context);
                Game.Player1.SelfBoard = ng.DefaultBoard(false);//_context.Boards.FirstOrDefault(i => i.BoardId == b.BoardId);//b;
                Game.Player1.OppenentBoard = ng.DefaultBoard(true);
                Game.Player2.SelfBoard = ng.DefaultBoard(false);
                Game.Player2.OppenentBoard = ng.DefaultBoard(true);
                _context.Games.Add(Game);
                _context.SaveChangesAsync();
                DisplayM1();
            }
            else if (count == int.Parse(c))
            {
                
            }
            else
            {
                
                M2 m2 = new M2();
                m2.DisplayM2(Games[int.Parse(c)-1].GameId, _context);
            }
        }
    }
}