using assessment_server_side.Exceptions;
using assessment_server_side.Models;
using assessment_server_side.Models.Factory;
using assessment_server_side.Properties;
using assessment_server_side.utils;
using assessment_server_side.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace assessment_server_side.CSVDataSource
{
    public class CSVFIleDataSource : IDataSource<Person>
    {
        public readonly string CSVFilePath = AppDomain.CurrentDomain.BaseDirectory + @"resources\sample-input.csv";
        private readonly ICollection<Person> _cachePeople;
        public CSVFIleDataSource()
        {

            _cachePeople = new List<Person>();
        }
        public IEnumerable<Person> ReadAll()
        {
            if (_cachePeople.Count > 0)
            {
                return _cachePeople;
            }
            var text =  File.ReadAllText(CSVFilePath);
            ; //just a hack, not suitable to be honest.
            var members = text.Split(",").Select(x => x.Trim()).ToList();
            int counter = 0;
            string[] items = new string[6];
            for (int i = 0; i < members.Count(); i++)
            {
                var j = i % 4;

                switch (j)
                {
                    case 0:
                        items[0] = members[i];
                        break;
                    case 1:
                        items[1] = members[i];
                        break;
                    case 2:
                        items[2] = members[i].Split(" ")[0];
                        items[3] = members[i].Split(" ")[1];
                        break;
                    case 3:
                        {
                            if (members[i].Contains("\r\n"))
                            {
                                var val = members[i];
                                int index = members.IndexOf(val);
                                members.Insert(index, val.Split("\r\n")[0]);
                                members[index + 1] = val.Split("\r\n")[1];
                            }
                            items[4] = (members[i]);
                            items[5] = counter++.ToString();
                            _cachePeople.Add(UtilPerson.FromString(items[5], items[1], items[0], items[2], items[3], items[4]));

                        }

                        break;
                }

            }
            return _cachePeople;
        }

        public bool WriteAll(IEnumerable<Person> people)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in people)
            {
                item.Id = -1;
                item.FavColour = UtilColor.Colors.FirstOrDefault(f => f.Id == item.FavColourId); //just to keep things in sync with Entity, Dumb hack
                sb.Append(UtilPerson.FromPerson(item));
            }
            File.AppendAllText(CSVFilePath, sb.ToString());
            _cachePeople.Clear();
            return true;

        }
    }
}
