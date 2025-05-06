
using DataStructures;


namespace DataStructures_Tests
{
    /// <summary>
    /// Only Max heap is implemented.
    /// </summary>
    public class BinaryMaxHeap_Test
    {
        private readonly BinaryHeap<int> heap;
        public BinaryMaxHeap_Test()
        {
            heap = new BinaryHeap<int>(HeapType.MaxHeap);

        }
        [Fact]
        public void Count_Test()
        {
            Assert.Equal(0, heap.Count);
            heap.Insert(45);
            heap.Insert(46);
            Assert.Equal(2, heap.Count);
            heap.Extract();
            Assert.Equal(1, heap.Count);
        }
        [Fact]
        public void Clear_Test()
        {
            //Make sure the heap resets properly.
            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(30);
            heap.Clear();
            Assert.True(heap.Count == 0);
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
            Assert.False(heap.Contains(10));
            Assert.False(heap.Contains(20));
            Assert.False(heap.Contains(30));
        }
        [Fact]
        public void IsEmpty_Test()
        {
            Assert.True(heap.IsEmpty(), "Heap should be empty initially.");

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(30);
            // After inserting elements, the heap should not be empty
            Assert.False(heap.IsEmpty(), "Heap should not be empty after inserting elements.");

            heap.Extract();
            heap.Extract();
            heap.Extract();

            // After extracting all elements, the heap should be empty again
            Assert.True(heap.IsEmpty(), "Heap should be empty after extracting all elements.");
        }
        [Fact]
        public void Contains_Test()
        {
            //Test empty
            Assert.False(heap.Contains(5));

            heap.Insert(10);
            heap.Insert(20);
            heap.Insert(30);

            Assert.True(heap.Contains(20));  // Should be found
            Assert.False(heap.Contains(99)); // Should not be found
        }
        [Theory]
        [InlineData(8)]
        [InlineData(16)] //initial array size is set to 8 or 16.
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        [InlineData(512)]
        [InlineData(1024)]
        [InlineData(2048)]
        [InlineData(4096)]
        public void Resize_Test(int size)
        {

            Random rand = new Random();
            int[] testArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                int testNum = rand.Next();
                testArray[i] = testNum;
                heap.Insert(testNum);
            }
            heap.Insert(45);
            int expected = size + 1;
            Assert.Equal(expected, heap.Count);
        }
        [Fact]
        public void Insert_Test()
        {
            heap.Insert(45);
            Assert.Equal(1, heap.Count);
            Assert.Equal(45, heap.Peek());
            heap.Insert(46);
            heap.Insert(47);
            Assert.Equal(47, heap.Peek());
            Assert.Equal(3, heap.Count);
        }
        [Fact]
        public void ExtractEmpty_Test()
        {
            Assert.Throws<InvalidOperationException>(() => heap.Extract());
        }
        [Fact]
        public void ToArray_Test()
        {
            heap.Insert(30);
            heap.Insert(10);
            heap.Insert(20);

            int[] array = heap.ToArray();

            Assert.Equal(3, array.Length);
            Assert.Contains(10, array);
            Assert.Contains(20, array);
            Assert.Contains(30, array);
        }
        [Fact]
        public void Extract_Test()
        {

            heap.Insert(10);
            int extracted = heap.Extract();
            Assert.Equal(10, extracted);

            heap.Insert(15);
            heap.Insert(20);
            heap.Insert(5);
            heap.Insert(10);

            extracted = heap.Extract();

            Assert.Equal(20, extracted);
            Assert.Equal(3, heap.Count);
            Assert.DoesNotContain(20, heap.ToArray());

            extracted = heap.Extract();    // 15 should be the largest
            Assert.Equal(15, extracted);

            extracted = heap.Extract();
            Assert.Equal(10, extracted);

            extracted = heap.Extract();
            Assert.Equal(5, extracted);

        }
        [Fact]
        public void Peek_EmptyHeap_Test()
        {
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }
        [Fact]
        public void Peek_Test()
        {
            heap.Insert(45);
            Assert.Equal(45, heap.Peek());
            Assert.Equal(1, heap.Count);
        }

        [Fact]
        public void HeapifyUp_Test()
        {

            heap.Insert(10);
            Assert.Equal(10, heap.Peek());
            heap.Insert(20);
            Assert.Equal(20, heap.Peek());
            heap.Insert(15);

            Assert.Equal(20, heap.Peek());
        }
        [Fact]
        public void HeapifyDown_Test()
        {
            heap.Insert(50);
            heap.Insert(40);
            heap.Insert(30);
            heap.Insert(20);
            heap.Insert(10);

            heap.Extract(); // removes 50

            Assert.Equal(40, heap.Peek());
            heap.Extract(); // removes 40
            Assert.Equal(30, heap.Peek());
        }
        [Fact]
        public void BuildHeap_Test()
        {
            int[] input = { 15, 23, 57, 98, 25, 3, 0, 10, 23 };
            heap.BuildHeap(input);

            var result = heap.ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                int left = 2 * i + 1; //index of left child
                int right = 2 * i + 2; //index of right child

                if (left < result.Length)
                    Assert.True(result[i] >= result[left], $"Heap property violated at index {i} (parent: {result[i]}, left: {result[left]})");

                if (right < result.Length)
                    Assert.True(result[i] >= result[right], $"Heap property violated at index {i} (parent: {result[i]}, right: {result[right]})");
            }
        }
        [Fact]
        public void Stress_Test()
        {
            var rand = new Random();
            int numElements = 100_000;

            // Insert a large number of random values
            for (int i = 0; i < numElements; i++)
            {
                heap.Insert(rand.Next());
            }

            // Extract elements and ensure each one is less than or equal to the previous
            int previous = heap.Extract();
            int current;
            for (int i = 1; i < numElements; i++)
            {
                current = heap.Extract();
                Assert.True(current <= previous, $"Heap property violated at index {i}");
                previous = current;
            }

            Assert.Equal(0, heap.Count);
        }

    }
}