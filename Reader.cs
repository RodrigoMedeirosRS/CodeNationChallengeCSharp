using System;
using System.Collections.Generic;
namespace CodeNationChallenge
{
    public class Reader
    {
        public string[] myInfo;

        public Reader(string path)
        {
            string[] myText = System.IO.File.ReadAllLines(path);
            myInfo = new string[myText.Length - 1];
            for (int i = 1; i < myText.Length; i++)
            {
                myInfo[i - 1] = myText[i];
            }
        }

        public List<string> ProcessInfo(string text)
        {
            string read = "";
            int infoCounter = 0;
            List<string> resultData = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ',')
                {
                    read += text[i];
                }
                else
                {
                    infoCounter += 1;
                    if (infoCounter == 3)//Full Names = 0
                    {
                        resultData.Add(read);
                        read = "";
                    }
                    else if (infoCounter == 4)//Club = 1
                    {
                        resultData.Add(read);
                        read = "";
                    }
                    else if (infoCounter == 7)//Age = 2
                    {
                        resultData.Add(read);
                        read = "";
                    }
                    else if (infoCounter == 15)//Nationality = 3
                    {
                        resultData.Add(read);
                        read = "";
                    }
                    else if (infoCounter == 18)//Salary = 4
                    {
                        resultData.Add(read);
                        read = "";
                        break;
                    }
                    else
                    {
                        read = "";
                    }
                }
            }
            return resultData;
        }
    }
}
