using System;
using System.Collections.Generic;
using System.Threading;

namespace CodeNationChallenge
{
    public class MultiProcess
    {
        public List<string> names = new List<string>();
        public List<string> clubs = new List<string>();
        public List<int> age = new List<int>();
        public List<string> nationalities = new List<string>();
        public List<double> salary = new List<double>();

        public MultiProcess(string[] inputText, Reader reader)
        {
            string resultQ3 = "";

            for (int i = 0; i < inputText.Length; i++)
            {
                List<string> dataMining = reader.ProcessInfo(inputText[i]);
                if (i < 20)
                {
                    resultQ3 += dataMining[0] + ", ";
                }
                else if (i == 20)
                {
                    Console.WriteLine("\nQ3) Liste o nome completo dos 20 primeiros jogadores.\n " + resultQ3);
                }
                names.Add(dataMining[0]);
                clubs.Add(dataMining[1]);
                age.Add(Convert.ToInt32(dataMining[2]));
                nationalities.Add(dataMining[3]);
                salary.Add(Convert.ToDouble(dataMining[4]));
            }
        }

        public void Run()
        {
            Thread question1 = new Thread(Question1);
            question1.Start();
            Thread question2 = new Thread(Question2);
            question2.Start();
            Thread question4 = new Thread(Question4);
            question4.Start();
            Thread question5 = new Thread(Question5);
            question5.Start();
            Thread question6 = new Thread(Question6);
            question6.Start();

            question1.Join();
            question2.Join();
            question4.Join();
            question5.Join();
            question6.Join();
        }

        void Question1()
        {
            List<string> totalNationalities = new List<string>();
            totalNationalities.Add(nationalities[0]);

            for (int i = 1; i < nationalities.Count; i++)
            {
                bool finded = false;
                for (int j = 0; j < totalNationalities.Count; j++)
                {
                    if (nationalities[i] == totalNationalities[j])
                    {
                        finded = true;
                        break;
                    }
                }
                if (!finded)
                {
                    totalNationalities.Add(nationalities[i]);
                }
            }
            Console.WriteLine("\nQ1) Quantas nacionalidades diferentes existem no arquivo?\n" + totalNationalities.Count);
        }

        void Question2()
        {
            List<string> totalClubs = new List<string>();
            totalClubs.Add(clubs[0]);

            for (int i = 1; i < clubs.Count; i++)
            {
                bool finded = false;
                for (int j = 0; j < totalClubs.Count; j++)
                {
                    if (clubs[i] == totalClubs[j])
                    {
                        finded = true;
                        break;
                    }
                }
                if (!finded)
                {
                    totalClubs.Add(clubs[i]);
                }
            }
            Console.WriteLine("\nQ2) Quantos clubes diferentes existem no arquivo?\n" + totalClubs.Count);
        }

        void Question4()
        {
            List<int> result = new List<int>();
            result.Add(0);
            for (int i = 1; i < salary.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (salary[i] > salary[result[j]])
                    {
                        result.Insert(j, i);
                        break;
                    }
                }
                if (result.Count < 10)
                {
                    result.Add(i);
                }
                else if (result.Count > 10)
                {
                    result.RemoveAt(result.Count-1);
                }
            }

            string mostRichPeople = "";
            for (int i = 0; i < result.Count; i++)
            {
                mostRichPeople += names[result[i]] +  ", ";
            }
            Console.WriteLine("\nQ4) Quem são os top 10 jogadores que ganham mais dinheiro?\n" + mostRichPeople);
        }

        void Question5()
        {
            List<int> result = new List<int>();
            result.Add(0);
            for (int i = 1; i < age.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if (age[i] > age[result[j]])
                    {
                        result.Insert(j, i);
                        break;
                    }
                }
                if (result.Count < 10)
                {
                    result.Add(i);
                }
                else if (result.Count > 10)
                {
                    result.RemoveAt(result.Count - 1);
                }
            }

            string mostOldPeople = "";
            for (int i = 0; i < result.Count; i++)
            {
                mostOldPeople += names[result[i]] + ", ";
            }
            Console.WriteLine("\nQ5) Quem são os 10 jogadores mais velhos?\n" + mostOldPeople);
        }

        void Question6()
        {
            List<int[]> lineAge = new List<int[]>();
            int[] enter = { age[0], 1 };
            lineAge.Add(enter);

            for (int i = 1; i < age.Count; i++)
            {
                bool finded = false;
                for (int j = 0; j < lineAge.Count; j++)
                {
                    if (age[i] == lineAge[j][0])
                    {
                        finded = true;
                        lineAge[j][1] += 1;
                        break;
                    }
                }
                if (!finded)
                {
                    int[] newEnter = { age[i], 1 };
                    lineAge.Add(newEnter);
                }
            }

            string result = "";
            for (int i = 0; i < lineAge.Count; i++)
            {
                result += "Age:" + lineAge[i][0] + " Have:" + lineAge[i][1] + ", ";
            }

            Console.WriteLine("\nQ6) Conte quantos jogadores existem por idade.\n" + result);
        }

    }
}
