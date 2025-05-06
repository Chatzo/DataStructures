

namespace DataStructures
{
    public enum HeapType
    {
        MaxHeap,
        MinHeap
    }
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private HeapType heaptype;
        private T[] elements;
        private int count;
        public int Count { get { return count; } }
        public BinaryHeap(HeapType type = HeapType.MaxHeap) //Maxheap is used as default if no other is entered
        {
            heaptype = type;
            elements = new T[16];
            count = 0;
        }
        /// <summary>
        /// Clears the heap.
        /// </summary>
        public void Clear()
        {
            Array.Clear(elements, 0, count);
            count = 0;
        }
        /// <summary>
        /// Checks if a value exists(not very efficient).
        /// </summary>
        public bool Contains(T value)
        {
            for(int i = 0; i  < count; i++)
            {
                if (elements[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if the heap is empty
        /// </summary>
        /// <returns>true if empty false otherwise</returns>
        public bool IsEmpty()
        {
            return count == 0 || elements.Length == 0;
        }
        private void Resize()
        {
            T[] newArray = new T[elements.Length * 2];
            Array.Copy(elements, newArray, elements.Length);
            elements = newArray;
        }
        /// <summary>
        /// Inserts the value and positions it correctly to maintain the heap property.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            if (count == elements.Length)
                Resize();

            elements[count] = value;
            count++;
            HeapifyUp(count - 1);
        }
        /// <summary>
        /// Returns the root element (highest in MaxHeap and lowest in MinHeap) and removes it after returning it.
        /// it rearrange the heap afterwards if needed.
        /// </summary>
        /// <returns>Returns highest stored value, throws exception if empty</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Extract()
        {
            if (count < 1)
                throw new InvalidOperationException("Heap is empty.");
            T extracted = elements[0];
            elements[0] = elements[count - 1];
            elements[count - 1] = default;
            count--;
            if (count > 0)
                HeapifyDown(0);

            return extracted;
        }

        private void HeapifyUp(int index)
        {
            if (index <= 0) //stop recursion
                return;
            int parentIndex = GetParentIndex(index);

            if ((heaptype == HeapType.MaxHeap) && (elements[index].CompareTo(elements[parentIndex]) > 0))
            {
                Swap(parentIndex, index);
                HeapifyUp(parentIndex);
            }
            else if ((heaptype == HeapType.MinHeap) && (elements[index].CompareTo(elements[parentIndex]) < 0))
                {
                    Swap(parentIndex, index);
                    HeapifyUp(parentIndex);
                }
        }
      
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private int GetLeftChildIndex(int index)
        {
            return (2 * index) + 1;
        }
        private int GetRightChildIndex(int index)
        {
            return (2 * index) + 2;
        }
        private void Swap(int positionOne, int positionTwo)
        {
            T temp = elements[positionOne];
            elements[positionOne] = elements[positionTwo];
            elements[positionTwo] = temp;
        }
        private void HeapifyDown(int index)
        {
            if (heaptype == HeapType.MaxHeap)
            {
                Max_HeapifyDownRecursive(index);
            }
            else if (heaptype == HeapType.MinHeap)
            {
                Min_HeapifyDownRecursive(index);
            }
        }
        private void Max_HeapifyDownRecursive(int index)
        {
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);
            int largest = index;

            //check left child
            if (leftChild < count && elements[leftChild].CompareTo(elements[largest]) > 0)
                {
                largest = leftChild;
            }
            //check right child, at this point "largest" is either "index" or "leftChild"
            if (rightChild < count && elements[rightChild].CompareTo(elements[largest]) > 0)
            {
                largest = rightChild;
            }


            if (largest != index) // if largest is not index it means a larger element has been found at position "largest"
            {
                Swap(index, largest);
                Max_HeapifyDownRecursive(largest);
            }
        }
        private void Min_HeapifyDownRecursive(int index)
        {
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);
            int smallest = index;

            //check left child
            if (leftChild < count && elements[leftChild].CompareTo(elements[smallest]) < 0)
            {
                smallest = leftChild;
            }
            //check right child, at this point "smallest" is either "index" or "leftChild"
            if (rightChild < count && elements[rightChild].CompareTo(elements[smallest]) < 0)
            {
                smallest = rightChild;
            }


            if (smallest != index) // If a smaller child is found, swap and recurse
            {
                Swap(index, smallest);
                Min_HeapifyDownRecursive(smallest);
            }
        }
        /// <summary>
        /// Returns the root element (highest in MaxHeap and lowest in MinHeap) without deleting it.
        /// </summary>
        /// <returns>first element in the BinaryHeap </returns>
        public T Peek()
        {
            if (count < 1)
                throw new InvalidOperationException("Heap is empty");
            return elements[0];
        }
        /// <summary>
        /// </summary>
        /// <returns>An array of the heap as is</returns>
        public T[] ToArray()
        {
            T[] result = new T[count]; 
            Array.Copy(elements, result, count); 
            return result; 
        }
        /// <summary>
        /// Clears the current heap and builds a new heap from an unsorted array.
        /// </summary>
        /// <param name="array"></param>
        public void BuildHeap(T[] array)
        {
            Clear();
            elements = new T[array.Length]; //Resize current heap
            Array.Copy(array, elements, array.Length);
            count = array.Length;

            // Start heapifying from the last non-leaf node all the way to the root
            for (int i = GetParentIndex(count - 1); i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }
    }
}
