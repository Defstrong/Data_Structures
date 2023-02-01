using System.Collections;

namespace Data.LinkedList
{
    class CastomLinkedList<T> : IEnumerable<T>
    {
        public int count = 0;
        Node<T> startPoint;
        Node<T> endPoint;

        private void FindIndexElement(int index, ref Node<T> returnElement)
        {
            int idx = 1;
            returnElement = startPoint;
            while (idx != index && count > 0)
            {
                returnElement = returnElement.Next;
                idx++;
            }
        }


        public void Add(T Element)
        {
            var addElement = new Node<T>(Element);
            if (startPoint == null)
                startPoint = addElement;
            else
                endPoint.Next = addElement;

            endPoint = addElement;

            count++;
        }

        public void AddStart(T addElement)
        {
            var addStartElement = new Node<T>(addElement);

            addStartElement.Next = startPoint;

            startPoint = addStartElement;

            count++;
        }

        public void AddMiddle(T element)
        {
            var addElementToMiddle = new Node<T>(element);
            Node<T> startFind = null;
            int idx = 1;
            if (count == 0)
            {
                startPoint = addElementToMiddle;
                count++;
                return;
            }

            int middleIdx = (count / 2) + (count % 2);
            FindIndexElement(middleIdx, ref startFind);
            addElementToMiddle.Next = startFind.Next;
            startFind.Next = addElementToMiddle;
            count++;
        }
        public bool Remove(T element)
        {
            Node<T> elementToRemove = startPoint;
            int countIdx = 1;
            while (elementToRemove.Next is not null)
            {
                if (elementToRemove.Next.Data.Equals(element))
                    break;
                if (countIdx == 1 && elementToRemove.Data.Equals(element))
                {
                    startPoint = startPoint.Next;
                    return true;
                }
                elementToRemove = elementToRemove.Next;
                countIdx++;
            }
            if (elementToRemove.Next is null)
            {
                Console.WriteLine("Error. Element is not found.");
                return false;
            }
            elementToRemove.Next = elementToRemove.Next.Next;
            return true;
        }
        public bool RemoveBack()
        {
            Node<T> startFind = null;
            if (count == 0)
                return false;
            if (count == 1)
            {
                startPoint = null;
                count--;
                return true;
            }

            FindIndexElement(count - 1, ref startFind);
            startFind.Next = null;
            count--;
            return true;
        }

        public bool RemoveStart()
        {
            if (count != 0)
            {
                startPoint = startPoint.Next;
                count--;
                return true;
            }
            return false;
        }
        public void ReversList()
        {
            Node<T> listByRevers = null;
            Node<T> startListNext = null;
            Node<T> startList = startPoint;
            int idx = 1;
            while (idx++ <= count)
            {
                startListNext = startList.Next;
                startList.Next = listByRevers;
                listByRevers = startList;
                startList = startListNext;
            }
            Node<T> dupleStartPoint = startPoint;
            startPoint = endPoint;
            endPoint = dupleStartPoint;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = startPoint;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
