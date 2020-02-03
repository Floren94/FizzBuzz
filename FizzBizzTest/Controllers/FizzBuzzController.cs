using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FizzBizzTest.Models
{
    public class FizzBuzzController : ApiController
    {
        // random num range
        const int MINNUM = 1;
        const int MAXNUM = 100;
        //.txt path
        const string folder = "\\fizzbuzztest";
        const string fileName = "\\test.txt";

        public IHttpActionResult GetFizzBuzz()
        {
            FizzBuzz fb = new FizzBuzz();
            Random rnd = new Random();
            int n = rnd.Next(MINNUM, MAXNUM);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // List of strings with numbers and fizzbuzzes from randomly given number
            List<string> fizzList = fb.FizzBuzzToList(n);
            string s = "";

            //Returns warning the if list is empty
            if (fizzList.Count < 1)
            {
                return NotFound();
            }
            // merges the list to a string separeted by commas and adds the datetime
            s = string.Join(", ", fizzList);
            s = string.Concat(s + " " + DateTime.Now.ToString("d/M/yyyy hh:mm:ss"));

            path = string.Concat(path + folder);

            // writes the string in the selected file if folder in desktop exists. If not creates the foder and file before writing it
            if (File.Exists(path + fileName))
            {
                using (StreamWriter sw = File.AppendText(path + fileName))
                {
                    try
                    {
                        sw.WriteLine(s);
                    }
                    catch
                    {
                        return NotFound();
                    }
                }
            }
            else
            {

                if (CreateDirectory(path))
                {
                    using (StreamWriter sw = File.CreateText(path + fileName))
                    {
                        try
                        {
                            sw.WriteLine(s);
                        }
                        catch
                        {
                            return NotFound();

                        }
                    }
                }
                else
                {
                    return NotFound();
                }
            }
                    return Ok(s);
        }

        bool CreateDirectory(string path)
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                return true;
            }
            catch 
            {
                return false;
            }
        }

    }
}
