using System;
using System.Linq;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    public class M2
    {
        
        
        
        
        public void DisplayM2(int id, AppDbContext context)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            
            Game game = context.Games
                .Include(u=>u.Player1).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player1).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .Include(u=>u.Player2).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player2).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .FirstOrDefault(m => m.GameId == id);
                
            
            Console.WriteLine("SelfBoard");
            foreach (var item in game.Player1.SelfBoard.RowNodes)
            {

                foreach (var i in item.Nodes)
                {
                    Console.Write(i.NodeValue.PadRight(3));
                }
                Console.WriteLine("\u200B");

            }
            
            Console.WriteLine("OpponentBoard");
            foreach (var item in game.Player1.OppenentBoard.RowNodes)
            {

                foreach (var i in item.Nodes)
                {
                    Console.Write(i.NodeValue.PadRight(3));
                }
                Console.WriteLine("\u200B");

            }
            
            
            
            Console.WriteLine("Your Move or exit(x)");
            string move = Console.ReadLine();
            M2Navigation(move);




        }


        public void M2Navigation(string m)
        {
            if (m == "x")
            {
                //nothing
            }
            else if (m.Length!=0)
            {
                
            
                int v;
                int.TryParse(m.Substring(1), out v);
                if ((m.Length == 2 || m.Length == 3) &&
                    ((int) m.ToUpper()[0] >= 65 && (int) m.ToUpper()[0] < 75) &&
                    (v >= 1 && v < 11))
                {
                    ///nextmove = true;
                }
                else
                {
                    Output.DisplayPrompt("Please enter location like A1");
                    value = ReadLocation();
                }
            }
            else
            {
                Output.DisplayPrompt("Please enter location like A1");
                value = ReadLocation();
            }
        }
    }
}