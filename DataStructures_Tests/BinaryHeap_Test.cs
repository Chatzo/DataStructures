using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;
using DataStructures;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures_Tests
{
    public class BinaryHeap_Test
    {
        private readonly BinaryHeap<int> heap;
        public BinaryHeap_Test()
        {
            heap = new BinaryHeap<int>(HeapType.MaxHeap);
        }
        [Fact]
        public void Count_Test()
        {
            //Ensure it increases with inserts and decreases with extracts.
            throw new NotImplementedException("Not implimented");
        }
        [Fact]
        public void IsEmpty_Test()
        {
            //Make sure the heap resets properly.
            throw new NotImplementedException("Not implimented");
        }
        [Fact]
        public void Clear_Test()
        {
            //Make sure the heap resets properly.
            throw new NotImplementedException("Not implimented");
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
            int[] testArray = new int [size]; 
            for(int i = 0; i < size; i++)
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
            //? Insert
            //Inserting into an empty heap.
            //Inserting multiple elements and checking heap structure via Peek().
            heap.Insert(45);
            Assert.Equal(1, heap.Count);
            Assert.Equal(45, heap.Peek());
        }
        [Fact]
        public void ExtractEmpty_Test()
        {
            Assert.Throws<InvalidOperationException>(() => heap.Extract());
        }
        [Fact]
        public void ToArray_Test()
        {
            throw new NotImplementedException("Not implimented");
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

            extracted = heap.Extract();

            Assert.Equal(20, extracted); 
            Assert.Equal(2, heap.Count); 
            Assert.DoesNotContain(20, heap.ToArray());

            //Extract repeatedly and verify order (e.g.always decreasing for max-heap).
            throw new NotImplementedException("Not implimented");

        }
        [Fact]
        public void Peek_EmptyHeap_Test()
        {
            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }
        [Fact]
        public void Peak_Test()
        {
            //Check that it returns the correct root element.
            //Peek without removing the item.

            Assert.Equal(45, heap.Peek());
            Assert.Equal(1, heap.Count);
        }

        [Fact]
        public void HeapifyUp_Test()
        {
            //Indirectly tested via insert and extract.
            //Check that the heap property is preserved after each operation.
            throw new NotImplementedException("Not implimented");
        }
        [Fact]
        public void HeapifyDown_Test()
        {
            //Indirectly tested via insert and extract.
            //Check that the heap property is preserved after each operation.
            throw new NotImplementedException("Not implimented");
        }

        [Fact]
        public void Stress_Test()
        {
            //Insert a large number of random values and then extract all — verify the final output is sorted (descending for max-heap, ascending for min-heap).
            throw new NotImplementedException("Not implimented");
        }
    }
}