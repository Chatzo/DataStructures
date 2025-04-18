using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Globalization;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;

namespace DataStructures_Tests
{
    public class BinaryHeap_Test
    {
        [Fact]
        public void Test1()
        {

        }
        //? Insert
        //Inserting into an empty heap.
        //Inserting multiple elements and checking heap structure via Peek().
        //------------------------------------------------------

        //? Extract
        //Extract from a heap with one element.
        //Extract repeatedly and verify order (e.g.always decreasing for max-heap).
        //Extract from an empty heap(handle error or return default/null).
        //------------------------------------------------------

        //? Peek
        //Check that it returns the correct root element.
        //Peek without removing the item.
        //Peek on an empty heap(handle gracefully).
        //------------------------------------------------------

        //? Heapify Up/Down
        //Indirectly tested via insert and extract.
        //Check that the heap property is preserved after each operation.
        //------------------------------------------------------

        //? Size / Count
        //Ensure it increases with inserts and decreases with extracts.
        //------------------------------------------------------

        //? Clear / IsEmpty
        //Make sure the heap resets properly.
        //------------------------------------------------------

        //?? Bonus Stress Test:
        //Insert a large number of random values and then extract all — verify the final output is sorted (descending for max-heap, ascending for min-heap).
    }
}