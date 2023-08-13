using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class KinValues
    {
        public const uint KIN_MERCENARY = (1u << 0);   // 1     1
        public const uint KIN_SEYAN_DU = (1u << 1);    // 2     10
        public const uint KIN_PURPLE = (1u << 2);      // 4     100
        public const uint KIN_MONSTER = (1u << 3);     // 8     1000
        public const uint KIN_TEMPLAR = (1u << 4);     // 16    10000
        public const uint KIN_ARCHTEMPLAR = (1u << 5); // 32    ******
        public const uint KIN_HARAKIM = (1u << 6);     // 64
        public const uint KIN_MALE = (1u << 7);        // 128
        public const uint KIN_FEMALE = (1u << 8);      // 256
        public const uint KIN_ARCHHARAKIM = (1u << 9); // 512
        public const uint KIN_WARRIOR = (1u << 10);    // 1024
        public const uint KIN_SORCERER = (1u << 11);   // 2048**



        // string templateOutput = Console.WriteLine(""+ templateName + " is " + monsterPart + ", and is a " + KIN_SEX + ", "+ templateClass + ".");
        static string whatAreTemplateValues(uint kindredinput, string templateName)
        {
            // Monster class
            // "is a monster" or "is not a monster"
            string monsterPart;
            if ((kindredinput & KIN_MONSTER) != 0)
            {
                monsterPart = "is a monster";
            }
            else
            {
                monsterPart = "is not a monster";
            }


            string isPurpleOne;
            if ((kindredinput & KIN_PURPLE) != 0)
            {
                isPurpleOne = "They are a follower of the Purple One";
            }
            else
            {
                isPurpleOne = "They are not a follower of the Purple One.";
            }

            // string monsterPart = ( kindredinput & KIN_MONSTER ) != 0 ? "is a monster" :
            //                                                            "is not a monster";
            string templateClass;
            if ((kindredinput & KIN_MERCENARY) != 0)
            {
                templateClass = "Mercenary";
            }
            else if ((kindredinput & KIN_SEYAN_DU) != 0)
            {
                templateClass = "Seyan Du";
            }
            else if ((kindredinput & KIN_TEMPLAR) != 0)
            {
                templateClass = "Templar";
            }
            else if ((kindredinput & KIN_ARCHTEMPLAR) != 0)
            {
                templateClass = "Arch-Templar";
            }
            else if ((kindredinput & KIN_HARAKIM) != 0)
            {
                templateClass = "Harakim";
            }
            else if ((kindredinput & KIN_ARCHHARAKIM) != 0)
            {
                templateClass = "Arch-Harakim";
            }
            else if ((kindredinput & KIN_WARRIOR) != 0)
            {
                templateClass = "Warrior";
            }
            else if ((kindredinput & KIN_SORCERER) != 0)
            {
                templateClass = "Sorcerer";
            }
            else
            {
                templateClass = "Mystery"; // Lmao
            }

            string templateSex;
            if ((kindredinput & KIN_MALE) != 0)
            {
                templateSex = "Male";
            }
            else if ((kindredinput & KIN_FEMALE) != 0)
            {
                templateSex = "Female";
            }
            else
            {
                templateSex = "Non-Gendered"; // Lmao
            }

            string templateOutput = "" + templateName + " is " + monsterPart + ", and is a " + templateSex + ", " + templateClass + ".";

            return templateOutput;
        }



    }

   
}
