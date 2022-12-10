using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal abstract class Class_base
    {
        protected int[] sequence;
        private int sequenceFirstElem;
        private int sequenceStep;

        protected Class_base(int size)
        {
            this.sequence = new int[size];
        }

        public int SequenceFirstElem
        {
            get { return sequenceFirstElem; }
            set { sequenceFirstElem = value; }
        }

        public int SequenceStep
        {
            get { return sequenceStep; }
            set { sequenceStep = value; }
        }

        public int[] return_elements()
        {
            return sequence;
        }

        public abstract int Sum(int k);

        public abstract int k_elem(int k);
    }
}
