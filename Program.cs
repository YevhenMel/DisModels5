using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisModels5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IsoGraph isoGraph = new IsoGraph();
            isoGraph.CheckIsomorphism();
        }
    }

    public class IsoGraph
    {
        private const string FilePath1 = "C:/Users/admin/Desktop/DM/files/dm2.txt";
        private const string FilePath2 = "C:/Users/admin/Desktop/DM/files/dm4.txt";

        public void CheckIsomorphism()
        {
            try
            {
                var matrix1 = ReadMatrix(FilePath1);
                var matrix2 = ReadMatrix(FilePath2);

                if (IsIsomorphic(matrix1, matrix2))
                {
                    Console.WriteLine("Two matrices are isomorphic.");
                }
                else
                {
                    Console.WriteLine("Two matrices are not isomorphic.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int[,] ReadMatrix(string filePath)
        {
            int[,] matrix;

            using (StreamReader reader = new StreamReader(filePath))
            {
                int dimension = int.Parse(reader.ReadLine());
                matrix = new int[dimension, dimension];

                for (int i = 0; i < dimension; i++)
                {
                    string[] values = reader.ReadLine().Split(' ');
                    for (int j = 0; j < dimension; j++)
                    {
                        matrix[i, j] = int.Parse(values[j]);
                    }
                }
            }

            return matrix;
        }

        private bool IsIsomorphic(int[,] matrix1, int[,] matrix2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            int dimension = matrix1.GetLength(0);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    list1.Add(matrix1[i, j]);
                    list2.Add(matrix2[i, j]);
                }
            }

            list1.Sort();
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}