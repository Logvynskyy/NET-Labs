using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class MyLinkedList<T> : ICollection<T>
    {
        private class Node
        {
            public T value;
            public Node next;

            public Node(T value)
            {
                this.value = value;
                this.next = null;
            }
        }

        private Node head;
        private Node last;
        private int size = 0;

        public delegate void EventHandler(T item);
        public event EventHandler insertion = delegate { };
        public event EventHandler deletion = delegate { };

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("An item must not be null!");
            Node node = new Node(item);
            if (isEmpty)
            {
                head = node;
                last = head;
            }
            else
            {
                last.next = node;
                last = node;
            }
            size++;

            this.insertion.Invoke(item);
        }

        public void Clear()
        {
            Node temp = head;
            while (temp != null)
            {
                this.deletion.Invoke(temp.value);
                temp.value = default(T);
                temp = temp.next;
            }

            size = 0;
        }

        public bool Contains(T item)
        {
            if (item == null) throw new ArgumentNullException("An item must not be null!");

            Node temp = head;
            while (temp != null)
            {
                if (temp.value.Equals(item))
                {
                    this.insertion.Invoke(item);
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null || arrayIndex < 0 ) throw new ArgumentException("Trying passing wrong parameters!");
            for (int i = 0, j = arrayIndex; i < size && j < array.Length; i++, j++)
            {
                array[j] = getItem(i);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node curr = head;
            while (curr != null)
            {
                yield return curr.value;
                curr = curr.next;
            }
        }

        public bool Remove(T item)
        {
            if (item == null) throw new ArgumentNullException("An item must not be null!");
            if (!Contains(item)) return false;
            Node prev = head;
            Node curr = head;
            while (curr.next != null || curr == last)
            {
                if (curr.value.Equals(item))
                {
                    if (size == 1)
                    {
                        head = null;
                        last = null;
                    }
                    else if (curr.Equals(head))
                    { // remove first element
                        head = head.next;
                    }
                    else if (curr.Equals(last))
                    {  // remove last element
                        last = prev;
                        last.next = null;
                    }
                    else
                    { // remove element
                        prev.next = curr.next;
                    }
                    size--;
                    this.deletion.Invoke(curr.value);

                    return true;
                }
                prev = curr;
                curr = prev.next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        private bool isEmpty => size == 0;

        private T getItem(int index)
        {
            if(index >= size) throw new IndexOutOfRangeException("Wrong index!");

            Node temp = head;
            for(int i = 0; i < index; i++){
                temp = temp.next;
            }

            return temp.value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("LinkedTaskList{");
            for (int i = 0; i < size; i++)
            {
                sb.Append(getItem(i).ToString()).Append(", ");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
