using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetComm
{
    class Hornet
    {
        public string Code { get; set; }
        public string Message { get; set; }
        

        public Hornet(string code, string mess)
        {
            Code = code;
            Message = mess;
        }

    }
    class HornetComm
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            
            Dictionary<string, List<Hornet>> decodemMessage = new Dictionary<string, List<Hornet>>();
            decodemMessage.Add("Messages", new List<Hornet>());
            decodemMessage.Add("Broadcasts", new List<Hornet>());

            while (inputText != "Hornet is Green")
            {
                if (IsMessage(inputText))
                {
                    var messageText = inputText
                        .Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var code = messageText[0].ToCharArray().Reverse();
                    var mess = messageText[1];
                    var ready = String.Join("", code);
                    Hornet hor = new Hornet(ready, mess);

                    decodemMessage["Messages"].Add(hor);

                }
                else if (IsBroadcasts(inputText))
                {

                    var broadcastsText = inputText
                        .Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string mess = broadcastsText[0];
                    string broadcastFrequency = broadcastsText[1];
                    string code = "";
                    foreach (var @char in broadcastFrequency)
                    {
                        if (char.IsLower(@char))
                        {
                            var letter = char.ToUpper(@char);
                            code += letter;
                        }
                        else if (char.IsUpper(@char))
                        {
                           var letter =  char.ToLower(@char);
                            code += letter;
                        }
                        else
                        {
                        code += @char;

                        }
                    }
                    Hornet hor = new Hornet(code, mess);

                    decodemMessage["Broadcasts"].Add(hor);
                }
                inputText = Console.ReadLine();
            }

            var decodMessage = decodemMessage.OrderBy(d => d.Key);
            foreach (var item in decodMessage)
            {
                Console.WriteLine($"{ item.Key}:");
                if (item.Value.Count != 0)
                {
                    foreach (var kvp in item.Value)
                    {
                        Console.WriteLine($"{kvp.Code} -> {kvp.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }

        private static bool IsBroadcasts(string inputText)
        {

            Regex regex = new Regex(@"(?<firstQuery>[^\D+]*) <-> (?<secondQuery>[a-zA-Z0-9]+)$");
            var valid = regex.IsMatch(inputText);

            return valid;
        }

        private static bool IsMessage(string inputText)
        {
            Regex regex = new Regex(@"\b(?<firstQuery>\d+) <-> (?<secondQuery>[A-Za-z0-9]+)$");
            var valid = regex.IsMatch(inputText);
            return valid;
        }
    }
}
