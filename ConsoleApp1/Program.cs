using System.Text;

// See https://aka.ms/new-console-template for more information

// To open DAT files, 8.03
// 1. Read in the file into memory
//  1.A Read into Byte Array specifically
// 2. Convert Byte Array into a class
//  2.A Convert raw bytes into ASCII
// 3. Diplay class data to the console
// 4. Create workable way to search for specific information
// Start with just trying to get name - https://github.com/engineerjames/men-among-gods/blob/main/src/common/Character.h

// New set of instructions, 8.04
// 1. Proper Input Handling, i.e.- what happens if user types in 14 on main menu?
// 2. When user inputs character number, what happens if that is NOT a number, like F or pizzahut?
// 3. Last front end modification, keep application going unless end user truly wants to exit. (think while loop for something this simple)
// 4. Nice to print out indication if template is used or not. A console.writeline advising "This template is Used." or "This template is not Used."
// 5. Eliminate junk data, whenever a template is printed (Blank Template also has a bunch of shit at the end, how do you get rid of that?) HINT- null termination byte value is 0, look for first 0 then stop
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
    Console.Clear();
    Console.WriteLine("Input your desired character number and press Enter.");
    // Things to keep in mind-
    //  Need to find starting byte
    //  Size of character 3605 bytes
    int startingbyte = (Convert.ToInt32(Console.ReadLine())) * 3605 + 1;

    // Since we are looking strictly for names, this value can remain static.
    int startingbytestoread = 40; 
    

    string filePath = @"C:\Users\secre\tchar.dat";

    if (File.Exists(filePath))
    {
        try
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            int contentLength = Math.Min(startingbytestoread, fileContent.Length - startingbyte);
            byte[] buffer = new byte[contentLength];
            Array.Copy(fileContent, startingbyte, buffer, 0, contentLength);

            string content = Encoding.ASCII.GetString(buffer);
            Console.WriteLine("Read content from byte offset " + startingbyte + ":");
            Console.WriteLine(content);
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
    Console.WriteLine("2: No, I want to exit");
    
    string runnewnumbers = Console.ReadLine();

    return runnewnumbers;
}

{
    
    string MainMenuAnswer = MainMenu();
  
    if (MainMenuAnswer == "1")
    {
        string runnewnumbers = ReRunData();
        if (runnewnumbers == "1")
        {
            Console.Clear();
            ReRunData();
        }
        else
        {
            Console.Clear();
            MainMenu();
        }
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
            Thread.Sleep(1000);
            MainMenu();
        }
    }

}
