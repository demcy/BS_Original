using System;
using System.Linq;
using Core;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp
{
    class Program
    {
       
        
        
        
        //private static readonly DbContextOptionsBuilder<AppDbContext> _dbOptions = 
         //   new DbContextOptionsBuilder<AppDbContext>()
          //      .UseMySQL("server=alpha.akaver.com;database=student2018_andreskaver_BattleShipDataBase31;user=student2018;password=student2018");
        
        static void Main(string[] args)
        {
            M1 m1 = new M1();
            m1.DisplayM1();
            //new PageInit().Run();
            
          //  Console.OutputEncoding = System.Text.Encoding.UTF8;
           // Console.WriteLine("Live");
          //  using (var ctx = new AppDbContext(_dbOptions.Options))
          //  {
                //NewGame ng = new NewGame();
                /*Board board = ng.DefaultBoard();
                ng.RandomBoard(board);
                foreach (var r in board.RowNodes)
                {
                    foreach (var n in r.Nodes)
                    {
                        Console.Write(n.NodeValue.PadRight(3));
                    }
                    Console.WriteLine("");
                }

                ctx.Boards.Add(board);
                ctx.SaveChangesAsync();
                Console.WriteLine("Save Sucsessful");*/

                //Board relBoard = ctx.Boards
               //     .Include(r => r.RowNodes).ThenInclude(n => n.Nodes)
               //     .FirstOrDefault(b => b.BoardId == 105);
               // foreach (var r in relBoard.RowNodes)
               // {
               //     foreach (var n in r.Nodes)
               //     {
               //         Console.Write(n.NodeValue.PadRight(3));
               //     }
              //      Console.WriteLine("");
               // }
                   

               
                //Game.Player2.OppenentBoard = ng.DefaultBoard();
            
                //Game.Player1.OppenentBoard.RowNodes[0].Nodes[0].NodeValue = "a";

                //_context.Games.Add(Game);
               // await _context.SaveChangesAsync();
               // Board b = ng.DefaultBoard();
               // _context.Boards.Add(b);
              
                
                
                
                
                
                /*Game game = ctx.Games
                    .Include(u => u.Player1).ThenInclude(b => b.SelfBoard).ThenInclude(r => r.RowNodes).ThenInclude(n=>n.Nodes)
                    .First(g => g.GameName == "Game5");
                Console.WriteLine(game.Player1.SelfBoard.RowNodes[0].Nodes[3].NodeValue);    
                foreach (var r in game.Player1.SelfBoard.RowNodes)
                {
                    foreach (var n in r.Nodes)
                    {
                        Console.Write(n.NodeValue.PadRight(3));
                    }
                    Console.WriteLine();
                }*/
                
            //}



            // Initialize extension method is added in DbInitializer class
            //dbContext.Initialize();

            /*NewGame ng = new NewGame();
            Board b = ng.DefaultBoard();
            ng.RandomBoard(b);
            foreach (var r in b.RowNodes)
            {
                foreach (var n in r.Nodes)
                {
                    Console.Write(n.NodeValue.PadRight(3));
                }
                Console.WriteLine();
            }*/
        }
        
        

       
    }
}