

namespace SedgewickWayne.Algorithms
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    public class Stack<TStack> : IStack<TStack>
    {

        internal sealed class ListIterator : System.Collections.Generic.IEnumerator<TStack>
        {
            Node current;
            readonly Stack<TStack> stack;

            public ListIterator(Stack<TStack> stack, Node node)
            {
                this.stack = stack ?? throw new ArgumentNullException(nameof(stack));
                current = node;
            }

            public ListIterator(Stack<TStack> stack) : this(stack, stack.first) { }
            public TStack Current
            {
                get
                {
                    if (current == null) throw new IndexOutOfRangeException();

                    var oldCurrentValue = current.item;
                    current = current.next;

                    return oldCurrentValue;
                }
            }

            object System.Collections.IEnumerator.Current { get { return Current; } }

            /// <summary>
            /// doesn't actually move links
            /// </summary>
            public bool MoveNext()
            {
                return (current != null);
            }

            /// <summary>
            ///  Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                current = stack.first;
            }

            //public virtual void remove() { throw new NotSupportedException(); }

            public void Dispose()
            {
                //foreach (var node in this) node.Dispose();
            }
        }

        internal sealed class Node
        {
            internal TStack item;
            internal Node next;
        }


        private int N;

        private Node first;

        public Stack()
        {
            first = null;
            N = 0;
        }


        public void Push(TStack obj)
        {
            Node node = first;
            first = new Node
            {
                item = obj,
                next = node
            };
            N++;
        }



        [MethodImpl(MethodImplOptions.NoInlining)]
        public TStack Peek()
        {
            if (IsEmpty) throw new NotSupportedException("Stack underflow");
            return first.item;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public TStack Pop()
        {
            if (IsEmpty) throw new NotSupportedException("Stack underflow");

            TStack result = first.item;
            first = first.next;
            N--;
            return result;
        }
        public int Size
        {
            get
            {
                return N;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return first == null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TStack o in this)
                sb.AppendFormat("{0} ", o);
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new ListIterator(this, first);
        }
        public System.Collections.Generic.IEnumerator<TStack> GetEnumerator()
        {
            return new ListIterator(this, first);
        }
    }




}
