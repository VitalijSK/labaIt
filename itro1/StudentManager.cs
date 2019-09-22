using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itro1
{
    public class StudentManager
    {
        List<string> category;
        List<string> student;
        Dictionary<string, List<List<int>>> marks;

        public StudentManager(string filename)
        {
            List<string []> data = FileManager.read(filename);

            setData(data);
        }

        public void menu()
        {
            

            bool allow = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Show value");
                Console.WriteLine("2. write in file");
                Console.WriteLine("0. Exit");
                try
                {
                    int menu = int.Parse(Console.ReadLine());
                    allow = true;
                    switch (menu)
                    {
                        case 1:
                            print();
                            Console.ReadLine();
                            break;
                        case 2:
                            write();
                            Console.WriteLine("data was wrote in file");
                            Console.ReadLine();
                            break;
                        case 0:
                            allow = false;
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    allow = true;
                }
            } while (allow);
        }

        void write()
        {
            List<List<string>> str = new List<List<string>>();
            List<string> tmp = new List<string>();
            List<List<double>> averageResult = new List<List<double>>();
            tmp.Add("");
            tmp.AddRange(category);
            str.Add(tmp);
            

            for (int i = 0, n = student.Count; i < n; i++)
            {
                string name = student[i];
                List<string> temp = new List<string>();
                temp.Add(name + " 1");
                List<List<int>> mark = marks[name];
                List<double> average = new List<double>();
                for (int y = 0, m = mark.Count; y < m; y++)
                {
                    if (y != 0)
                    {
                        temp = new List<string>();
                        temp.Add((y + 1) + "");
                    }
                    for (int j = 0, nm = mark[y].Count; j < nm; j++)
                    {
                        temp.Add(mark[y][j] + "");
                        if (average.Count > j)
                        {
                            average[j] += mark[y][j];
                        } else
                        {
                            average.Add(mark[y][j]);
                        }
                        
                    }

                    str.Add(temp);
                }
                temp = new List<string>();
                temp.Add("Average");
                List<double> avTmp = new List<double>();
                double resultAver = 0;
                for (int y = 0, m = average.Count; y < m; y++)
                {
                    temp.Add(average[y] / mark.Count + "");
                    avTmp.Add(average[y] / mark.Count);
                    resultAver += average[y] / mark.Count;
                }
                temp.Add((resultAver / average.Count) + "");
                averageResult.Add(avTmp);
                str.Add(temp);
            }
            List<string> result = new List<string>();
            result.Add("Result");
            List<double> res = new List<double>();
            for (int i = 0; i < averageResult.Count; i++)
            {
                
                for (int y = 0; y < averageResult[i].Count; y++)
                {
                    if (res.Count > y)
                    {
                        res[y] += averageResult[i][y];
                    } else
                    {
                        res.Add(averageResult[i][y]);
                    }
                    
                }
                
            }
            double summAll = 0;
            for(int i = 0; i < res.Count; i++)
            {
                double resultDigit = Math.Round(res[i] / averageResult[0].Count, 2);
                summAll += resultDigit;
                result.Add(resultDigit + "");
            }
            result.Add((summAll / averageResult.Count) + "");
            str.Add(result);

            FileManager.write(@"C:\output.csv", str);
        }

        void print()
        {
            Console.Write("{0, 17} | ", "");
            for (int i = 0, n = category.Count; i < n; i++)
            {
                Console.Write("{0, 11}|", category[i]);
            }
            Console.WriteLine("");
            List<List<double>> averageResult = new List<List<double>>();

            for (int i = 0, n = student.Count; i < n; i++)
            {
                string name = student[i];
                Console.Write("{0, 17} | ", name + " 1");
                List<List<int>> mark = marks[name];
                List<double> average = new List<double>();
                for (int y = 0, m = mark.Count; y < m; y++)
                {
                    if (y != 0)
                    {
                        Console.Write("{0, 17} | ", y + 1);
                    }
                    for (int j = 0, nm = mark[y].Count; j < nm; j++)
                    {
                        Console.Write("{0, 11}|", mark[y][j]);
                        if (average.Count > j)
                        {
                            average[j] += mark[y][j];
                        }
                        else
                        {
                            average.Add(mark[y][j]);
                        }

                    }

                    Console.WriteLine("");
                }

                Console.Write("{0, 17} | ", "Average");
                List<double> avTmp = new List<double>();
                double averTmp = 0;

                for (int y = 0, m = average.Count; y < m; y++)
                {
                    double summ = average[y] / mark.Count;
                    Console.Write("{0, 11}|", Math.Round(summ, 2));
                    averTmp += summ;
                    avTmp.Add(summ);
                }
                Console.Write("{0, 11}|", Math.Round(averTmp / average.Count, 2));
                Console.WriteLine("");
          
                averageResult.Add(avTmp);
            }
            List<string> result = new List<string>();
            Console.Write("{0, 17} | ", "Result");
      
            List<double> res = new List<double>();
            for (int i = 0; i < averageResult.Count; i++)
            {
                for (int y = 0; y < averageResult[i].Count; y++)
                {
                    if (res.Count > y)
                    {
                        res[y] += averageResult[i][y];
                    }
                    else
                    {
                        res.Add(averageResult[i][y]);
                    }
                    
                }
              
            }

            double summAll = 0;
            for (int i = 0; i < res.Count; i++)
            {
                double resultDigit = Math.Round(res[i] / averageResult[0].Count, 2);
                summAll += resultDigit;
                Console.Write("{0, 11}|", resultDigit);
            }

            Console.Write("{0, 11}|", Math.Round(summAll / averageResult.Count, 2));
        }

        void setData(List<string[]> data)
        {
            List<List<int>> part = new List<List<int>>();
            category = new List<string>();
            student = new List<string>();
            marks = new Dictionary<string, List<List<int>>>();
            string name = "none";

            for(int i = 1, n = data[0].Length; i < n; i++)
            {
                category.Add(data[0][i]);
            }
            
            for (int i = 1, count = 1, n = data.Count; i < n; i++)
            {
                List<int> mark = new List<int>();
                for (int y = 1, m = data[i].Length; y < m; y++)
                {
                    mark.Add(int.Parse(data[i][y]));
                }

                if (count == 1)
                {
                    name = data[i][0];
                    student.Add(name);
                }

                part.Add(mark);

                if(count == 4)
                {
                    marks.Add(name, new List<List<int>>(part));
                    count = 0;
                    part.Clear();
                }

                count++;
            }
        }
    }
}
