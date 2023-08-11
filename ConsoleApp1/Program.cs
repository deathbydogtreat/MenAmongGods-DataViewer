using System.Text;

// See https://aka.ms/new-console-template for more information

// To open DAT files, 8.03
// 1. Read in the file into memory (done)
//  1.A Read into Byte Array specifically (done)
// 2. Convert Byte Array into a class (done)
//  2.A Convert raw bytes into ASCII (done)
// 3. Diplay class data to the console (done)
// 4. Create workable way to search for specific information (done)
// Start with just trying to get name - https://github.com/engineerjames/men-among-gods/blob/main/src/common/Character.h

// New set of instructions, 8.04
// 1. Proper Input Handling, i.e.- what happens if user types in 14 on main menu? (done)
// 2. When user inputs character number, what happens if that is NOT a number, like F or pizzahut? (done)
// 3. Keep app going unless end user truly wants to exit. (done)
// 4. Nice to print out indication if template is used or not. A console.writeline advising "This template is Used." or "This template is not Used." (done)
// 5. Eliminate junk data, whenever a template is printed) HINT- null termination byte value is 0, look for first 0 then stop
// 6. Bonus- Pull out the kindred value (templar, seyan, etc.) starts on byte 285. Is a 4 byte integer. 
// 7. Bonus Bonus- To identify sex AND class, Ishtar would combine bit level items. Take 4 bytes, stuff into integer, 


//static const constexpr unsigned int KIN_MERCENARY   = ( 1u << 0 ); 0000 0000 0000 0001 = 1
//static const constexpr unsigned int KIN_SEYAN_DU    = ( 1u << 1 ); 0000 0000 0000 0010 = 2
//static const constexpr unsigned int KIN_PURPLE      = ( 1u << 2 ); 0000 0000 0000 0100 = 4
//static const constexpr unsigned int KIN_MONSTER     = ( 1u << 3 );
//static const constexpr unsigned int KIN_TEMPLAR     = ( 1u << 4 );
//static const constexpr unsigned int KIN_ARCHTEMPLAR = ( 1u << 5 );
//static const constexpr unsigned int KIN_HARAKIM     = ( 1u << 6 );
//static const constexpr unsigned int KIN_MALE        = ( 1u << 7 );
//static const constexpr unsigned int KIN_FEMALE      = ( 1u << 8 );
//static const constexpr unsigned int KIN_ARCHHARAKIM = ( 1u << 9 );
//static const constexpr unsigned int KIN_WARRIOR     = ( 1u << 10 );
//static const constexpr unsigned int KIN_SORCERER    = ( 1u << 11 );
//
//
// 1. Get integer value of kindred - myKindred
// 2. if (myKindred & KIN_MERCENARY) { I'm a mercenary! }
// 3. if (myKindred & KIN_MERCENARY && myKindred & KIN_FEMALE) { I'm a female merc! }
//
//
// myKindred   =   0000 0000 0000 0001
// KIN_MERCENARY & 0000 0000 0000 0001
//                 -------------------
//                 0000 0000 0000 0001 != 0  (TRUE!)

// myKindred   =   0000 0000 0000 0001
// KIN_SEYAN     & 0000 0000 0000 0010
//                 -------------------
//                 0000 0000 0000 0000 == 0   (FALSE!)

while (true)
{


static string MainMenu()
{
    Console.Clear();
    Console.WriteLine("Data File Reader: Men Among Gods");
    Console.WriteLine("Menu Options: Select a number then press Enter to move forward.");
    Console.WriteLine("1. Character Info Search");
    Console.WriteLine("2. Exit the Program");

    string menuchoice = Console.ReadLine();

    return menuchoice;
}

static string ReRunData()
{
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Input your desired character number and press Enter.");
            // Things to keep in mind-
            //  Need to find starting byte
            //  Size of character 3605 bytes
            string startingbyte = Console.ReadLine();
            int startingByteValue;

            // Idea to take 3605 and then divide by total file size would give us a safe range for "if it's within 1 and <>"
            // 4548 quantities for total characters
            bool numOrString = int.TryParse(startingbyte, out startingByteValue);

            if (numOrString)
            {
                string filePath = @"C:\Users\secre\tchar.dat";
                if (File.Exists(filePath))
                {
                    int startingbytestoreadname = Convert.ToInt32 (startingByteValue) * 3605; // This controls the starting point for reading bytes
                    int characterNameSize = 40; // This controls how many bytes are listed
                    
                    // Commented out the code for now, but starting to experiment with byte converters- my thought is provide an int value, then use a byte converter and print the information to get what I want?
                    int findCharacterKindred = 285;
                    // Trying to figure out how to determine the used or not value  Guard
                    int findCharacterUsed = 1; 

                    try
                    {
                        byte[] fileContent = File.ReadAllBytes(filePath);

                        byte[] buffer1 = new byte[characterNameSize]; // I'm not sure what this does, still.
                        Array.Copy(fileContent, startingbytestoreadname, buffer1, 0, characterNameSize);
                        string content = Encoding.ASCII.GetString(buffer1);
                        content = content.TrimStart('\0', '').TrimEnd('\0', '');
                        Console.WriteLine("Character Name:");
                        Console.WriteLine(content);

                        byte[] buffer2 = new byte[findCharacterKindred]; // I'm not sure what this does, still.
                        Array.Copy(fileContent, startingbytestoreadname, buffer2, 0, findCharacterKindred);
                        string content2 = Encoding.ASCII.GetString(buffer2);
                        content2 = content2.TrimStart('\0', '').TrimEnd('\0', '');
                        Console.WriteLine("Character description:");
                        Console.WriteLine(content2);

                        byte[] buffer3 = new byte[findCharacterUsed]; // I'm not sure what this does, still.
                        Array.Copy(fileContent, startingbytestoreadname, buffer3, 0, findCharacterUsed);

                        string content3 = Encoding.ASCII.GetString(buffer3);
                        if (findCharacterUsed == 1) 
                        {
                            Console.WriteLine("Character template in use.");
                        }
                        else if (findCharacterUsed == 0) 
                        {
                            Console.WriteLine("Character template not in use.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("File does NOT exist.");
                }

                Console.WriteLine("");
                Console.WriteLine("Would you like to run a different set of numbers?");
                Console.WriteLine("1: Yes, I want to run a different set.");
                Console.WriteLine("2: No, I want to exit to the Main Menu");
                Console.WriteLine("3: No, I want to exit out of the application itself.");

                string runnewnumbers = Console.ReadLine();
                if (runnewnumbers == "1")
                {
                    Console.Clear();
                    ReRunData();
                }
                else if (runnewnumbers == "2")
                {
                    Console.Clear();
                    MainMenu();
                }
                else if (runnewnumbers == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Exiting Now.");
                    Thread.Sleep(1000);
                    System.Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("I'm sorry, that was an incorrect prompt. Please try again.");
                Thread.Sleep(2000);
                Console.Clear();
                ReRunData();
            }
        }
            
            
      
}
    



    {
        string MainMenuAnswer = MainMenu();

        if (MainMenuAnswer == "1")
        {
            Console.Clear();
            ReRunData();
        }
        else if (MainMenuAnswer == "2")
        {
            Console.Clear();
            Console.WriteLine("Are you certain you want to exit?");
            Console.WriteLine("1. Yes, Exit.");
            Console.WriteLine("2. No, I've changed my mind.");

            string sureyouwanttoexit = Console.ReadLine();

            if (sureyouwanttoexit == "1")
            {
                Console.Clear();
                Console.WriteLine("Exiting Now.");
                Thread.Sleep(1000);
                System.Environment.Exit(0);
            }
            else if (sureyouwanttoexit == "2")
            {
                Console.Clear();
                Console.WriteLine("Returning you to the Main Menu.");
                Thread.Sleep(1000);
                MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect choice- returning to Main Menu until you can learn how to use choices.");
                Thread.Sleep(2000);
                Console.Clear();
                MainMenu();
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("I'm sorry, that is an incorrect choice. Lets try this again, shall we?");
            Thread.Sleep(2000);
            Console.Clear();
            MainMenu();
        }
    }


}