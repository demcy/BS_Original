using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class PlayGame
    {
        private readonly DAL.AppDbContext _context;

        public int _id { get; set; }

        public PlayGame(DAL.AppDbContext context, int? id)
        {
            _context = context;
            _id = id ?? default(int);
        }

        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        List<int[]> shiploc = new List<int[]>();
        public Random Rand = new Random();
        public int Row;
        public int Col;
            
        
        
        public void ShootBoard(string aim)
        {
            
            Game game = _context.Games
                .Include(u=>u.Player1).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player1).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .Include(u=>u.Player2).ThenInclude(b=>b.SelfBoard).ThenInclude(r=>r.RowNodes).ThenInclude(n=>n.Nodes)
                .Include(v=>v.Player2).ThenInclude(p=>p.OppenentBoard).ThenInclude(t=>t.RowNodes).ThenInclude(m=>m.Nodes)
                .FirstOrDefault(m => m.GameId == _id);
             
            string letter = aim.Substring(0,1).ToUpper();
            int numer = -1;
            if (aim.Length == 2)
            {
                numer = int.Parse(aim.Substring(1, 1)) - 1;
            }
            else
            {
                numer = int.Parse(aim.Substring(1, 2)) - 1;
            }

            int c = alpha.IndexOf(letter);


            if (game.Player2.SelfBoard.RowNodes[numer].Nodes[c].NodeValue == "\x25A8")
            {
                game.Player2.SelfBoard.RowNodes[numer].Nodes[c].NodeValue = "\xD83D\xDD25";
                game.Player1.OppenentBoard.RowNodes[numer].Nodes[c].NodeValue = "\xD83D\xDD25";
                game.Player1.Score += 1;
                
                shiploc.Clear();
                if (allfinder(game.Player2, numer, c))
                {
                    shiploc.Clear();
                    hinting(game.Player1, game.Player2, numer, c);
                }
            }
            else if (game.Player2.SelfBoard.RowNodes[numer].Nodes[c].NodeValue == "\x25A2")
            {
                game.Player1.OppenentBoard.RowNodes[numer].Nodes[c].NodeValue = "\x26DE";
                OpponentShoot(game);
            }
            else
            {
                
            }
            _context.SaveChangesAsync();
        }
        
        public void hinting(User user, User cuser, int r, int c)
        {
            for (int i = r - 1; i < r + 2; i++)
            {
                for (int j = c - 1; j < c + 2; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10  && !shiploc.Any(p => p.SequenceEqual(new int[]{i,j})))
                    {
                        if (cuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\xD83D\xDD25" 
                            || cuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\x25A2")
                        {
                            if (cuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\xD83D\xDD25")
                            {
                                shiploc.Add(new int[]{i,j});
                                hinting(user, cuser, i, j);
                            }
                            else
                            {
                                user.OppenentBoard.RowNodes[i].Nodes[j].NodeValue = "\x25A3";
                            }
                        }
                    }

                }
            }
        }
        
        
        public bool allfinder(User anyuser, int r, int c)
        {
            bool allinfire = true;
            for (int i = r - 1; i < r + 2; i++)
            {
                for (int j = c - 1; j < c + 2; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10  && !shiploc.Any(p => p.SequenceEqual(new int[]{i,j})))
                    {
                        if (anyuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\xD83D\xDD25" ||
                            anyuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\x25A2")
                        {
                            if (anyuser.SelfBoard.RowNodes[i].Nodes[j].NodeValue == "\xD83D\xDD25")
                            {
                                shiploc.Add(new int[]{i,j});
                                allfinder(anyuser, i, j);
                            }
                        }
                        else
                        {
                            allinfire = false;
                            return false;
                        }
                    }
                }
            }

            return allinfire;
        }

        public void OpponentShoot(Game game)
        {
            do
            {
                Row = Rand.Next(10);
                Col = Rand.Next(10);
            } while (hitt(game, Row, Col));
        }

        public bool hitt(Game game, int r, int c)
        {
            if (game.Player1.SelfBoard.RowNodes[r].Nodes[c].NodeValue == "\x25A8")
            {
                game.Player1.SelfBoard.RowNodes[r].Nodes[c].NodeValue = "\xD83D\xDD25";
                game.Player2.OppenentBoard.RowNodes[r].Nodes[c].NodeValue = "\xD83D\xDD25";
                game.Player2.Score += 1;
                
                shiploc.Clear();
                if (allfinder(game.Player1, r, c))
                {
                    shiploc.Clear();
                    hinting(game.Player2, game.Player1, r, c);
                }

                return true;
            }
            else if (game.Player1.SelfBoard.RowNodes[r].Nodes[c].NodeValue == "\x25A2")
            {
                game.Player2.OppenentBoard.RowNodes[r].Nodes[c].NodeValue = "\x26DE";
                return false;
            }
            else
            {
                return true;
            }
        }
            
            
            
            
            
            
            
            
            
            
            
        
    }
}