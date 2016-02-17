using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// Array Implementation of stack
    /// </summary>
    public class StackWithArray<T> : IStack<T>
    {
        private T[] stackVar;

        private int nextFreeStackIndex;

        public int StackSize => this.stackVar.Length;

        public StackWithArray()
        {
            this.stackVar = new T[10];
            this.nextFreeStackIndex = 0;
        }

        public void Push(T value)
        {
            // Don't reallocate before we actually want to push to it
            if (this.nextFreeStackIndex == this.stackVar.Length)
            {
                // Double for small stacks, and increase by 20% for larger stacks
                Array.Resize(
                    ref this.stackVar,
                    this.stackVar.Length < 100 ? 2 * this.stackVar.Length : (int)(this.stackVar.Length * 1.2));
            }

            // Store the value, and increase reference afterwards
            this.stackVar[this.nextFreeStackIndex++] = value;
        }

        public T Pop()
        {
            if (this.nextFreeStackIndex == 0) throw new InvalidOperationException("The stack is empty");

            // Decrease the reference before fetching the value as
            // the reference points to the next free place
            T returnValue = this.stackVar[--this.nextFreeStackIndex];

            // As a safety/security measure, reset value to a default value
            this.stackVar[this.nextFreeStackIndex] = default(T);

            return returnValue;
        }
    }
}



