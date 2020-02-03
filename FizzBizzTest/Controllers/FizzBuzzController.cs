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
        const int MINNUM = 1;
        const int MAXNUM = 100;
        const string path = @"C:\Users\magri\Desktop\test\test.txt";

        public IHttpActionResult GetFizzBuzz()
        {
            FizzBuzz fb = new FizzBuzz();
            Random rnd = new Random();
            int n = rnd.Next(MINNUM, MAXNUM);
            List<string> fizzList = fb.GetFizzBuzz(n);
            string s = "";

            if (fizzList.Count < 1)
            {
                return NotFound();
            }
            s = string.Join(", ", fizzList);
            
            s = string.Concat(s + " " + DateTime.Now.ToString("M/d/yyyy hh:mm:ss"));

            if (File.Exists(path))
            {
            using (StreamWriter sw = File.AppendText(path))
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

            return Ok(s);
        }
    }
}
