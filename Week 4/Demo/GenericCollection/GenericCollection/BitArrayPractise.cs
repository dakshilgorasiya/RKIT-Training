using System.Collections;
using System.Xml.Linq;

namespace GenericCollection
{
    internal class BitArrayPractise
    {
        static void Main(string[] args)
        {
            // Constructor
            bool[] val1 = new bool[] { true, false, true };
            BitArray br1 = new BitArray(val1); // arg1: bool[] values
            PrintBitArray(br1);

            byte[] val2 = new byte[] { 1, 2, 3 };
            BitArray br2 = new BitArray(val2); // arg1: byte[] values
            PrintBitArray(br2);

            BitArray br3 = new BitArray(br1); // arg1: BitArray bits

            BitArray br4 = new BitArray(10); // arg1: int length
            PrintBitArray(br4);

            int[] val5 = new int[] { 1, 2, 3 };
            BitArray br5 = new BitArray(val5); // arg1: int[] values
            PrintBitArray(br5);

            BitArray br6 = new BitArray(10, true); // arg1: int length, arg2: bool defaultValue
            PrintBitArray(br6);





            // Properties
            Console.WriteLine("Count :" + br1.Count); // get;

            Console.WriteLine("IsReadOnly :" + br1.IsReadOnly); // get;

            Console.WriteLine("IsSynchronized :" + br1.IsSynchronized); // get;

            br1[1] = true; // get; set; arg: int index


            // If Length is set to a value that is less than Count, the BitArray is truncated and the elements after the index value -1 are deleted.
            // If Length is set to a value that is greater than Count, the new elements are set to false.
            br1.Length = 5; // get; set;
            PrintBitArray(br1);





            // Methods  
            BitArray br7 = new BitArray(new bool[] { true, false, true, false });
            BitArray br8 = new BitArray(new bool[] { false, false, true, true });


            // Modify original BitArray and also return the modified BitArray
            PrintBitArray(br7.And(br8)); // arg: BitArray value // Performs a bitwise AND operation between the current BitArray and the specified BitArray. 
            PrintBitArray(br7.Or(br8)); // arg: BitArray value // Performs a bitwise OR operation between the current BitArray and the specified BitArray.
            PrintBitArray(br7.Xor(br8)); // arg: BitArray value // Performs a bitwise XOR operation between the current BitArray and the specified BitArray.
            PrintBitArray(br7.Not()); // Inverts all the bits in the current BitArray.

            br7.Set(1, false); // arg1: int index, arg2: bool value // Sets the bit at the specified index to the specified value
            //br7.SetAll(true); // arg: bool value // Sets all bits to the specified value
            PrintBitArray(br7);
            PrintBitArray(br7.RightShift(1)); // arg: int // Performs a bitwise rightshift operation
            PrintBitArray(br7.LeftShift(2)); // arg: int // Performs a bitwise leftshift operation


            // Clone // Shallow copy
            //BitArray br9 = (BitArray)br7.Clone(); // creates a shallow copy of the BitArray

            // CopyTo // Copies the entire BitArray to a compatible one-dimensional array, starting at the specified index of the target array.
            int[] copied = new int[5];
            br5.CopyTo(copied, 1); // arg1: Array array, arg2: int index
            Console.WriteLine(string.Join(", ", copied));


            Console.WriteLine(br1.Get(1)); // arg: int index // gets the value of the bit at the specified index

            Console.WriteLine(br1.HasAllSet()); // returns true if all bits are set to true

            Console.WriteLine(br1.HasAnySet()); // returns true if any bit is set to true
        }

        static void PrintBitArray(BitArray bitArray)
        {
            Console.WriteLine("Count :" + bitArray.Count);
            for (int i = 0; i < bitArray.Count; i++)
            {
                Console.Write(bitArray[i] ? "1" : "0");
            }
            Console.WriteLine();
        }
    }
}
