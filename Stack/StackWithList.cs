using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// Stack Implementation With List
    /// </summary>

    public class StackWithList<T> : IStack<T>
    {
        private readonly List<T> stack;

        public StackWithList()
        {
            this.stack = new List<T>();
        } 

        int IStack<T>.StackSize => this.stack.Count;

        public void Push(T item)
        {
            this.stack.Add(item);
        }

        public T Pop()
        {
            if (this.stack.Count == 0)
            {
                throw new SystemException("Stack is empty");
            }

            var lastElementInList = this.stack.Count - 1;
            var itemAtTopOfStack = this.stack[lastElementInList];
            this.stack.RemoveAt(lastElementInList);
            return itemAtTopOfStack;
        }
    }
}
