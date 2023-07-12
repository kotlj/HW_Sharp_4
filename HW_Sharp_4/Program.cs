using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sharp_4
{
    internal class Program
    {
        class Matrix
        {
            public int[][] Add(int[][] first, int[][] second)
            {
                if (first.Length == second.Length && first[0].Length == second[0].Length)
                {
                    int[][] temp = new int[first.Length][];
                    for (int i = 0; i < first.Length; i++)
                    {
                        temp[i] = new int[first[0].Length];
                    }
                    for (int i = 0; i < first.Length; i++)
                    {
                        for (int y = 0; y < first[0].Length; y++)
                        {
                            temp[i][y] = first[i][y] + second[i][y];
                        }
                    }
                    return temp;
                }
                throw new Exception("ERROR OPTIONS");
            }
            public int[][] MultByNumber(int[][] matrix, int number)
            {
                int[][] temp = new int[matrix.Length][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    temp[i] = new int[matrix[0].Length];
                }
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int y = 0;y < matrix[0].Length; y++)
                    {
                        temp[i][y] = matrix[i][y] * number;
                    }
                }
                return temp;
            }
            public int[][] MultMatrix(int[][] first, int[][] second)
            {
                if (first.Length == second[0].Length && first[0].Length == second.Length)
                {
                    int[][] temp = new int[first.Length][];
                    for (int i = 0; i < first.Length; i++)
                    {
                        temp[i] = new int[second.Length];
                    }
                    for(int i = 0; i < first.Length; i++)
                    {
                        for(int y = 0; y < second.Length; y++)
                        {
                            for(int z = 0; z < first.Length; z++)
                            {
                                temp[i][y] += first[i][z] * second[z][i];
                            }
                        }
                    }
                    return temp;
                }
                throw new Exception("ERROR OPTIONS");
            }
            public void Fill(out int[][] matrix, int size_0, int size_1)
            {
                Random r = new Random(2);
                matrix = new int[size_0][];
                for (int i = 0; i < size_0; i++)
                {
                    matrix[i] = new int[size_1];
                    for (int y = 0; y  < size_1; y++)
                    {
                        matrix[i][y] = r.Next(2);
                    }
                }
            }
        }

        class TextEditor
        {
            public string AfterPoint(string Text)
            {
                bool Up = true;
                string temp = "";
                for (int i = 0; i < Text.Length; i++)
                {
                    if (Text[i] == '.' || Text[i] == '!' || Text[i] == '?')
                    {
                        Up = true;
                    }
                    if (Up && Text[i] > 64 && Text[i] < 91 || Up && Text[i] > 96 && Text[i] < 123 ||
                        Up && Text[i] > 127 && Text[i] < 176 || Up && Text[i] > 223 && Text[i] < 287)
                    {
                        temp += Char.ToUpper(Text[i]);
                        Up = false;
                    }
                    else
                    {
                        temp += Text[i];
                    }
                }
                return temp;
            }
        }
        static void Main(string[] args)
        {

            //Matrix test

            Matrix testing = new Matrix();
            int standart = 5;
            int[][] matx_0;
            int[][] matx_1;
            testing.Fill(out matx_0, standart, standart);
            testing.Fill(out matx_1, standart, standart);
            for (int Total = 0; Total < 2; Total++)
            {
                Console.WriteLine($"Matrix {Total}:");
                for (int line = 0; line < standart; line++)
                {
                    Console.Write($"Line {line}: ");
                    for (int column = 0; column < 5; column++)
                    {
                        Console.Write($"{(Total == 1 ? matx_0[line][column] : matx_1[line][column])}, ");
                    }
                    Console.Write('\n');
                }
            }
            int[][] res = testing.Add(matx_1, matx_0);
            Console.WriteLine("Result: ");
            for (int line = 0; line < standart; line++)
            {
                Console.Write($"Line {line}: ");
                for (int column = 0; column < 5; column++)
                {
                    Console.Write($"{res[line][column]}, ");
                }
                Console.Write('\n');
            }

            //Text test

            TextEditor test = new TextEditor();
            String str = "Just some texting massege. point test";
            String result = test.AfterPoint(str);
            Console.WriteLine(result);
        }
    }
}
