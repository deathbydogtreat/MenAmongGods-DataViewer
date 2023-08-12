using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class KinValues
    {
        public const uint KIN_MERCENARY = (1u << 0);  // 1     1
        public const uint KIN_SEYAN_DU = (1u << 1);  // 2     10
        public const uint KIN_PURPLE = (1u << 2);  // 4     100
        public const uint KIN_MONSTER = (1u << 3);  // 8     1000
        public const uint KIN_TEMPLAR = (1u << 4);  // 16    10000
        public const uint KIN_ARCHTEMPLAR = (1u << 5);  // 32    ******
        public const uint KIN_HARAKIM = (1u << 6);  // 64
        public const uint KIN_MALE = (1u << 7);  // 128
        public const uint KIN_FEMALE = (1u << 8);  // 256
        public const uint KIN_ARCHHARAKIM = (1u << 9);  // 512
        public const uint KIN_WARRIOR = (1u << 10); // 1024
        public const uint KIN_SORCERER = (1u << 11); // 2048**
    }
}
