using System;
using DAL;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp
{
    class Program
    {
       
        private static readonly DbContextOptionsBuilder<AppDbContext> _dbOptions = 
            new DbContextOptionsBuilder<AppDbContext>()
                .UseMySQL("server=alpha.akaver.com;database=student2018_andreskaver_BattleShipDataBase31;user=student2018;password=student2018");
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Live");
            using (var ctx = new AppDbContext(_dbOptions.Options))
            {
                
                foreach (var game in ctx.Games)
                {
                    Console.WriteLine(game.GameName);
                }
                
            }



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