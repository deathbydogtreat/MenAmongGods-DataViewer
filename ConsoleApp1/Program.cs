using System.Text;

// See https://aka.ms/new-console-template for more information

//To open DAT files
// 1. Read in the file into memory
//  1.A Read into Byte Array specifically
// 2. Convert Byte Array into a class
//  2.A Convert raw bytes into ASCII
// 3. Diplay class data to the console
// 4. Create workable way to search for specific information

// First thing I should do is take very first template and print out something with it
// Start with just trying to get name - https://github.com/engineerjames/men-among-gods/blob/main/src/common/Character.h

// 1st successful name is "1" "Blank/0, 2nd successful name is "BlankTemplate/0""

//getstring(byte[]) will play a part in this

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
    Console.WriteLine("Input your starting byte and press Enter.");// Makes this modular, can now ask inside the program instead of doing it beforehand.
    int startingbyte = (Convert.ToInt32(Console.ReadLine()));

    Console.WriteLine("Now input the number of bytes you want to read, and press Enter.");// Makes this modular, can now ask inside the program instead of doing it beforehand.
    int startingbytestoread = (Convert.ToInt32(Console.ReadLine()));

    int startByteOffset = startingbyte; // Adjust the starting byte offset
    int bytesToRead = startingbytestoread; // Adjust the number of bytes you want to read

    string filePath = @"C:\Users\secre\tchar.dat";

    if (File.Exists(filePath))
    {
        try
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            int contentLength = Math.Min(bytesToRead, fileContent.Length - startByteOffset);
            byte[] buffer = new byte[contentLength];
            Array.Copy(fileContent, startByteOffset, buffer, 0, contentLength);

            string content = Encoding.ASCII.GetString(buffer);
            Console.WriteLine("Read content from byte offset " + startByteOffset + ":");
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
