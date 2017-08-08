using System;
using System.Collections.Generic;



namespace dojodachi.Controllers
{
    public class Dachi 
    {
        public int happy;
        public int fullness;
        public int energy;
        public int meals;

        public Dachi()
        {
            happy = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }


        public Dachi feed(Dachi dachi)
        {
            if (dachi.meals > 0)
            {
                Random rando = new Random();
                int roll = rando.Next(0,4);
                if(roll >=1)
                {
                    int feed = rando.Next(5,11);
                    dachi.fullness += feed;
                    dachi.meals -=1;
                }
                else
                {
                dachi.meals -=1;
                }
            }
            return dachi;
        }


        public Dachi play(Dachi dachi)
        {
            Random rando = new Random();
            int roll = rando.Next(0,4);
            if (roll >=1)
            {
                int happi = rando.Next(5,11);
                dachi.happy += happi;
                dachi.energy -= 5;
            }
            else
            {
                dachi.energy -= 5;
            }
            return dachi;
        }


        public Dachi work(Dachi dachi)
        {
            dachi.energy -= 5;
            Random rando = new Random();
            int roll = rando.Next(1,4);
            dachi.meals += roll;
            
            return dachi;
        }

        public Dachi sleep(Dachi dachi)
        {
            dachi.energy += 15;
            dachi.fullness -= 5;
            dachi.happy -= 5;
            return dachi;
        }

        public List<string> status(Dachi dachi)
        {
            List<string> result = new List<string>();
            if ( dachi.happy >= 100 && dachi.fullness >= 100 && dachi.energy >= 100)
            {
                result.Add("win");
                return result;
            }
            else if(dachi.happy <1 || dachi.fullness < 1 || dachi.energy < 1)
            {
                result.Add("dead");
                return result;
            }
            else
            {
                result.Add("fine");
                return result;
            }
        }
    }
}