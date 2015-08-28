namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BitArray64 : IEnumerable<int>
    {
        public BitArray64(ulong bits)
        {
            this.Bits = bits;
        }

        public ulong Bits { get; set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertsToBitArray();
                return bits[index];
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Equals(second);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.ConvertsToBitArray();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BitArray64))
            {
                return false;
            }

            BitArray64 other = obj as BitArray64;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Bits == other.Bits;
        }

        public override int GetHashCode()
        {
            return this.Bits.GetHashCode();
        }

        public override string ToString()
        {
            return this.Bits.ToString();
        }

        private int[] ConvertsToBitArray()
        {
            int[] bits = new int[64];
            for (int i = 0; i < bits.Length; i++)
            {
                int bit = (int)((this.Bits >> i) & 1);
                bits[63 - i] = bit;
            }

            return bits;
        }
    }
}
