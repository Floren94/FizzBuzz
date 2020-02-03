using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBizzTest.Models
{
    public class FizzBuzz
    {
        //size of the list. Count of numbers tested and returned from taken integer.
        const int LISTSIZE = 10;

        //returns a list of string with numbers and fizzbuzzes staring from given integer. 
        public List<string> FizzBuzzToList(int num)
        {
            List<string> fizzList = new List<string>(LISTSIZE);

            for ( int i = 0; i < fizzList.Capacity; i++)
            {
                if (num % 3 == 0 && num % 5 == 0)
                {
                    fizzList.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    fizzList.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    fizzList.Add("Buzz");
                }
                else
                {
                    fizzList.Add(num.ToString());
                }
                num++;
            }

            return fizzList;
        }


    }
}