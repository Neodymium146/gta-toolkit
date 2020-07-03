namespace RageLib.Hash
{
    public class Elf
    {
        // source: https://en.wikipedia.org/wiki/PJW_hash_function
        public static uint Hash(string str)
        {
            uint hash = 0;
            uint high;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];

                hash = (hash << 4) + c;

                if ((high = hash & 0xF0000000) != 0)
                {
                    hash ^= (high >> 24);
                }

                hash &= ~high;
            }

            return hash;
        }
    }
}
