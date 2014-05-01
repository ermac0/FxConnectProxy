using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy.Samples
{
    class OutputBuffer
    {
        private int Limit { get; set; }
        private Queue<string> Buffer { get; set; }

        public OutputBuffer(int size = 300)
        {
            this.Limit = size;
            this.Buffer = new Queue<string>(size);
        }

        public void Clear()
        {
            this.Buffer.Clear();
        }

        public override string ToString()
        {
            var sb = new StringBuilder(50000);
            foreach (var item in this.Buffer)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }

        public void WriteLine(string text)
        {
            while (this.Buffer.Count >= this.Limit)
            {
                this.Buffer.Dequeue();
            }

            this.Buffer.Enqueue(text);
        }
    }
}
