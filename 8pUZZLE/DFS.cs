using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8pUZZLE
{
    class DFS
    {
        static int counter = 0;
        string originalPattern, newPatternGlobal, finalPattern;
        string originalpattern2;
        Dictionary<string, int> stateDepth = new Dictionary<string, int>();
        Dictionary<string, string> stateHistory = new Dictionary<string, string>();
        Stack<string> agenda = new Stack<string>();
        public void DFSSearch(int[,] myPattern, int[,] finalpattern)
        {



            foreach (int i in myPattern)
            {
                originalPattern += i.ToString();
            }
            foreach (int i in finalpattern)
            {
                finalPattern += i.ToString();
            }
            add(originalPattern, null);
            Queue<int> traverseOrder = new Queue<int>();
            Queue<int> Q = new Queue<int>();
            for (int i = 0; i < myPattern.GetLength(0); i++)
            {
                for (int j = 0; j < myPattern.GetLength(1); j++)
                {
                    Q.Enqueue(myPattern[i, j]);
                }
            }

            while (agenda.Count() > 0)
            {

                string tempElement = agenda.Pop();
                //Console.Write("*");
                /*using (StreamWriter sw = File.AppendText(@"C:\Users\atulfb1205\Desktop\dataDFS.txt"))
                {
                    sw.WriteLine(tempElement);

                }*/
                up(tempElement);
                down(tempElement);
                right(tempElement);
                left(tempElement);


            }


            Console.ReadLine();


        }
        void add(string newState, string oldState)
        {
            if (!stateDepth.ContainsKey(newState))
            {
               
                int newValue = oldState == null ? 0 : stateDepth[oldState] + 1;
                stateDepth.Add(newState, newValue);
                agenda.Push(newState);
                stateHistory.Add(newState, oldState);
            }
        }
        public void up(string myState)
        {
            int a = myState.IndexOf('0');
            if (a > 2)
            {
                string newp = myState.Substring(0, a - 3) + "0";
                string newPattern = myState.Substring(a - 2, 2) + myState.Substring(a - 3, 1);
                string newPattern1 = myState.Substring(a + 1);
                string nextstate = newp + newPattern + newPattern1;
                MatchMatrix(myState, nextstate);
            }
        }
        public void down(string myState)
        {
            int a = myState.IndexOf('0');
            if (a < 6)
            {
                string temp1 = myState.Substring(0, a);
                string temp2 = myState.Substring(a + 3, 1);
                string temp3 = myState.Substring(a + 1, 2);
                string temp4 = myState.Substring(a, 1) + myState.Substring(a + 4);


                string nextstate = temp1 + temp2 + temp3 + temp4;
                MatchMatrix(myState, nextstate);

            }
        }
        public void right(string myState)
        {
            int a = myState.IndexOf("0");
            if (a != 2 && a != 5 && a != 8)
            {
                string temp1 = myState.Substring(0, a);
                string temp2 = myState.Substring(a + 1, 1);
                string temp3 = myState.Substring(a, 1);// + "0";
                string temp4 = myState.Substring(a + 2);
                string nextState = temp1 + temp2 + temp3 + temp4;
                MatchMatrix(myState, nextState);
            }

        }
        public void left(string myState)
        {
            int a = myState.IndexOf('0');
            if (a != 0 && a != 3 && a != 6)
            {
                string temp1 = myState.Substring(0, a - 1);
                string temp2 = myState.Substring(a, 1);// + "0";
                string temp3 = myState.Substring(a - 1, 1);
                string temp4 = myState.Substring(a + 1);
                string nextState = temp1 + temp2 + temp3 + temp4;
                MatchMatrix(myState, nextState);
            }
        }

        public void MatchMatrix(string oldPattern, string newPattern)
        {
            add(newPattern, oldPattern);
           
            if (newPattern.Trim() == finalPattern.Trim())
            {

                Console.WriteLine("Solution Exists at level" + stateDepth[newPattern]);
                string tracesState = newPattern;
                /*while (tracesState != null)
                {

                    Console.WriteLine("DFS@"+tracesState + " at " + stateDepth[tracesState]);
                    Console.WriteLine();
                    using (StreamWriter sw = File.AppendText(@"C:\Users\atulfb1205\Desktop\dataDFS.txt"))
                    {
                        sw.WriteLine("DFS@" + tracesState + " at " + stateDepth[tracesState]);

                    }
                    tracesState = stateHistory[tracesState];
                }*/
                Thread.Sleep(5000);
            }
            /*  newPatternGlobal = newPattern;

          Console.WriteLine("**************************");
          counter++;
          int p = 1;
          char[] tempArray = newPattern.ToCharArray();

          for (int i = 0; i < tempArray.GetLength(0); i++)
          {


              Console.Write(tempArray[i]+" ");
              if (p % 3 == 0)
              {
                  Console.WriteLine();
              }
              p++;

          }
          if(newPatternGlobal.Trim()==finalPattern.Trim())
          {
              Console.WriteLine("Solution Found");
          }
          if(oldPattern.Trim()==finalPattern.Trim())
          {
              Console.WriteLine("Solution Found");
          }
        */
        }
    }
}

