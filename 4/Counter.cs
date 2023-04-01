using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Counter
    {
        public delegate void Notifier();
        public event Notifier desiredNumber;

        public void Count()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 77)
                {
                    if(desiredNumber != null)
                    {
                        desiredNumber();
                    }
                }
            }
        }
    }
}