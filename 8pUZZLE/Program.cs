using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pUZZLE
{
  public  class Program
    {
       static int rows, columns;
        bool arrayFlag=false;
       static Random r = new Random();
        static List<int> arraytemp;
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine("Enter Number of rows");
            rows =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Entger number of columns");
            columns = Convert.ToInt32(Console.ReadLine());
            int[,] Orginal = new int[rows, columns];
            int[,] Final = new int[rows, columns];
            Orginal= generateLastMatrix(rows, columns,"Your Matrix");
            Final= generateLastMatrix(rows, columns, "Matrix to get");
            string originalPattern = myMatrixString(Orginal);
            string finalPattern = myMatrixString(Final);
            
            //Console.WriteLine(originalPattern);
            //Console.WriteLine(finalPattern);
            BFS obj = new BFS();
            Console.WriteLine("BFS Search");
            obj.BFSSearch(Orginal,Final);
            Console.WriteLine("DFS Search");
            DFS objDFS = new DFS();
            //objDFS.DFSSearch(Orginal, Final);
        }
        public static int[,] generateLastMatrix(int rows,int columns,string message)
        {
            Console.WriteLine(message);
            int[,] Matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Matrix[i, j] = getrandomNumber();
                }
            }
            printmatrix(Matrix);
            return Matrix;
        }
        public static string myMatrixString(int[,] myMatrix)
        {
            string result=null;
            for (int i = 0; i < myMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < myMatrix.GetLength(1); j++)
                {
                    result += myMatrix[i,j].ToString();
                }
            }
            return result;
        }
        public static void printmatrix(int[,] myAray)
        {
            Console.WriteLine("Your puzzle is a follows");
            for (int i = 0; i < myAray.GetLength(0); i++)
            {
                for (int j = 0; j < myAray.GetLength(1); j++)
                {
                    Console.Write(myAray[i, j] + " ");
                }
                Console.WriteLine();
            }

            //Console.ReadLine();
        }
        
        public static int getrandomNumber()
        {
            int result = 0;
            if (arraytemp == null)
                arraytemp = new List<int>();

            if(arraytemp.Count==rows*columns)
            {
                r = new Random();
                arraytemp = new List<int>();
            }
            if (arraytemp != null)
            {
                try
                {
                    
                    int nextInteger = r.Next(9);
                    if (arraytemp.Contains(nextInteger))
                    {
                        int returns = getrandomNumber();
                        result = returns;

                    }
                    else
                    {
                        arraytemp.Add(nextInteger);
                        result = nextInteger;

                    }
                }
                catch (Exception)
                {
                                       
                }
               
            }
            return result;
                 
        }
    }
}
