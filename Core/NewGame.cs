using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DAL;
using Domain;

namespace Core
{
    public class NewGame
    {
        /*private readonly DAL.AppDbContext _context;

        public NewGame(DAL.AppDbContext context)
        {
            _context = context;
        }*/
        
        
        public Random Rand = new Random();
        public int Row;
        public int Col;
        List<int[]> shiplock = new List<int[]>();
        
        
        //public List<RowNode> RowNodes { get; set; }

        public Board DefaultBoard()
        {
            Board board = new Board();
            for (int i = 0; i < 10; i++)
            {
                RowNode rowNode = new RowNode();
                for (int j = 0; j < 10; j++)
                {
                    rowNode.Nodes.Add(new Node());
                }
                board.RowNodes.Add(rowNode);
            }

            return board;
        }
        
        public void RandomBoard(Board _board)
        {
            //Create 5 types of Ships
            for (int i = 0; i <= 5; i++)
            {
                shiplock.Clear();
                for (int j = 0; j < i; j++)
                {
                    do
                    {
                        Row = Rand.Next(10);
                        Col = Rand.Next(10);
                    } while (!localization(_board, Row, Col));
                }
            }
            
        }
        
        
        
        public bool localization(Board _board, int r, int c)
        {
            bool b = false;
            if (shiplock.Count > 0 && !shiplock.Any(p => p.SequenceEqual(new int[]{r,c})))
            {      
                foreach (int[] sh in shiplock)
                {
                    if ((r == sh[0] + 1 && c == sh[1]) || (r == sh[0] - 1 && c == sh[1]) ||
                        (r == sh[0] && c == sh[1] + 1) || (r == sh[0] && c == sh[1] - 1))
                    {
                        b = true;
                        for (int i = r - 1; i < r + 2; i++)
                        {
                            for (int j = c - 1; j < c + 2; j++)
                            {
                                if (i >= 0 && i < 10 && j >= 0 && j < 10 && !shiplock.Any(p => p.SequenceEqual(new int[]{i,j})))
                                { 
                                    if (_board.RowNodes[i].Nodes[j].NodeValue != "\x25A2")
                                    {
                                        b = false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            //IF SHIPLOCK IS EMPTY or r and c not are shiplock coordinates
            else
            {
                b = true;
                for (int i = r - 1; i < r + 2; i++)
                {
                    for (int j = c - 1; j < c + 2; j++)
                    {
                        if (i >= 0 && i < 10 && j >= 0 && j < 10 )
                        {
                            if (_board.RowNodes[i].Nodes[j].NodeValue != "\x25A2" )
                            {
                                b = false;
                            }
                        }
                    }
                }
            }

            if (b)
            {
                shiplock.Add(new int[] {r, c});
                _board.RowNodes[r].Nodes[c].NodeValue = "\x25A8";
            }

            return b;
        }
    }
}