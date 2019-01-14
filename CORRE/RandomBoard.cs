using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

//
//namespace CORRE
//{
//    public class RandomBoard
//    {
//        public NodesList[] NodesLists { get; set; }
//        public Random Rand = new Random();
//        public int Row;
//        public int Col;
//        
//
//        public RandomBoard(NodesList[] nodesLists)
//        {
//            NodesLists = nodesLists;
//        }
//        public void RandomLocation()
//        {
//            for (int k = 0; k <= 5; k++)
//            {
//                shiploc.Clear();
//                for (int i = 0; i < k; i++)
//                {
//                    do
//                    {
//                        Row = Rand.Next(10);
//                        Col = Rand.Next(10);
//                    } while (!localization(Row, Col));
//                }
//            }
//        }
//        
//        public bool localization(int r, int c)
//        {
//            bool b = false;
//            if (shiploc.Count > 0 && !shiploc.Any(p => p.SequenceEqual(new int[]{r,c})))
//            {      
//                foreach (int[] sh in shiploc)
//                {
//                    if ((r == sh[0] + 1 && c == sh[1]) || (r == sh[0] - 1 && c == sh[1]) ||
//                        (r == sh[0] && c == sh[1] + 1) || (r == sh[0] && c == sh[1] - 1))
//                    {
//                        b = true;
//                        for (int i = r - 1; i < r + 2; i++)
//                        {
//                            for (int j = c - 1; j < c + 2; j++)
//                            {
//                                if (i >= 0 && i < 10 && j >= 0 && j < 10 && !shiploc.Any(p => p.SequenceEqual(new int[]{i,j})))
//                                { 
//                                    if (NodesLists[i].Nodes[j].NodeValue != "\x25A2")
//                                    {
//                                        b = false;
//                                    }
//                                }
//                            }
//                        }
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                b = true;
//                for (int i = r - 1; i < r + 2; i++)
//                {
//                    for (int j = c - 1; j < c + 2; j++)
//                    {
//                        if (i >= 0 && i < 10 && j >= 0 && j < 10 )
//                        {
//                            if (NodesLists[i].Nodes[j].NodeValue != "\x25A2" )
//                            {
//                                b = false;
//                            }
//                        }
//                    }
//                }
//            }
//
//            if (b)
//            {
//                shiploc.Add(new int[]{r,c});
//                NodesLists[r].Nodes[c].NodeValue = "\x25A8";
//            }
//
//            return b;
//        }
//    }
//}