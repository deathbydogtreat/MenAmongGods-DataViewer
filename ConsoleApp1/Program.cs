using ConsoleApp1;
using System.Text;

// See https://aka.ms/new-console-template for more information

// struct character - the numbers on the right are the offsets
//{
//    std::uint8_t used; // 0
                       // general

//    char name[40];         // 1
//    char reference[40];    // 41
//    char description[200]; // 81

//    std::int32_t kindred; // 281



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
            //  Size of character 3605 bytes
            string startingbyte = Console.ReadLine();
            int characterTemplateNumber;

            // Idea to take 3605 and then divide by total file size would give us a safe range for "if it's within 1 and <>"
            // 4548 quantities for total characters
            bool numOrString = int.TryParse(startingbyte, out characterTemplateNumber);

            if (numOrString)
            {
                string filePath = @"C:\Users\secre\tchar.dat";
                if (File.Exists(filePath))
                {
                    int usedBytePoint = characterTemplateNumber * 3605 - 3;
                    int characterUsedSize = 4;

                    int nameBytePoint = characterTemplateNumber * 3605 + 1; // This controls the starting point for reading bytes
                    int characterNameSize = 40; // This controls how many bytes are listed

                    int kindredBytePoint = characterTemplateNumber * 3605 + 281;
                    int characterKindredSize = 4;

                    // int findCharacterUsed = 1; Finding if a character is usable needs to be the starting point, not at the end.
                    // good test case, #12- should be name "Thief"
                    // 137 is the 

                    try
                    {
                        byte[] fileContent = File.ReadAllBytes(filePath);

                        byte[] bufferUsed = new byte[characterUsedSize];
                        Array.Copy(fileContent, usedBytePoint, bufferUsed, 0, characterUsedSize);
                        if (BitConverter.IsLittleEndian) 
                        {
                            Array.Reverse(bufferUsed);
                            int contentUsed = BitConverter.ToInt32(bufferUsed, 0);

                            if (contentUsed == 1)
                            {

                                byte[] bufferName = new byte[characterNameSize]; // I'm not sure what this does, still.
                                Array.Copy(fileContent, nameBytePoint, bufferName, 0, characterNameSize);
                                string contentName = Encoding.ASCII.GetString(bufferName);
                                contentName = contentName.TrimEnd('\0', '');
                                Console.WriteLine("Character Name:");
                                Console.WriteLine(contentName);

                                byte[] bufferKindred = new byte[characterKindredSize]; // need to convert the buffer here into a 32 bit signed integer
                                Array.Copy(fileContent, kindredBytePoint, bufferKindred, 0, characterKindredSize);
                                int contentKindred = BitConverter.ToInt32(bufferKindred, 0);
                                Console.WriteLine("Character kindred:");
                                Console.WriteLine(contentKindred);
                            }
                            else
                            {
                                Console.WriteLine("Character not used, please provide other data.");
                            }

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