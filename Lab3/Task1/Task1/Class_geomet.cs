using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Class_geomet : Class_base
    {
        public Class_geomet(int size) : base(size) {}

        public override int k_elem(int k)
        {
            return (int)(SequenceFirstElem * Math.Pow(SequenceStep, k-1));
        }

        public override int Sum(int k)
        {
            k = 0;
            foreach(int item in sequence)
            {
                k += item;
            }
            return k;
        }

        private int next(int prev, int step)
        {
            return prev*step;
        }

        public void array_value()
        {
            sequence[0] = SequenceFirstElem;
            for(int i = 1; i < sequence.Length; i++)
            {
                sequence[i] = next(sequence[i-1], SequenceStep);
            }
        }

        public override string ToString()
        {
            string newStr = string.Empty;
            foreach(int i in sequence)
            {
                newStr += i + " ";
            }
            return newStr;
        }
    }
}
