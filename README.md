# MenAmongGods-DataViewer
Tasks so far- 
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


static const constexpr unsigned int KIN_MERCENARY   = ( 1u << 0 );  // 1
static const constexpr unsigned int KIN_SEYAN_DU    = ( 1u << 1 );  // 2
static const constexpr unsigned int KIN_PURPLE      = ( 1u << 2 );  // 4
static const constexpr unsigned int KIN_MONSTER     = ( 1u << 3 );  // 8
static const constexpr unsigned int KIN_TEMPLAR     = ( 1u << 4 );  // 16
static const constexpr unsigned int KIN_ARCHTEMPLAR = ( 1u << 5 );  // 32
static const constexpr unsigned int KIN_HARAKIM     = ( 1u << 6 );  // 64
static const constexpr unsigned int KIN_MALE        = ( 1u << 7 );  // 128
static const constexpr unsigned int KIN_FEMALE      = ( 1u << 8 );  // 256
static const constexpr unsigned int KIN_ARCHHARAKIM = ( 1u << 9 );  // 512
static const constexpr unsigned int KIN_WARRIOR     = ( 1u << 10 ); // 1024
static const constexpr unsigned int KIN_SORCERER    = ( 1u << 11 ); // 2048
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



**// Thief - Kindred 137
// KIN_FEMALE / KIN_MALE = 256 / 128
// KIN_MERCENARY         = 1
// KIN_MONSTER           = 8
// ----------------------------
//                         137

// 1 byte = 8 bits
//        = 12 bits
// ------------------
// 2 bytes = 16 bits
// 4 bytes = 32 bits
//
// 0000 0000 0000 0000 0000 0000 0000 0000 <-- We don't care about the 'top' 16
//
// 0000 0000 0000 0000
// 0000 0000 1000 1001 = 137
//
//
// Bit-wise AND 'if (kindredValue & KIN_WARRIOR)'
// 0000 0000 1000 1001 = 137
// 0000 0010 0000 0000 = 1024
// 0000 0000 0000 0000 = 0 (FALSE), ANYTHING ELSE = TRUE
//
// What about one that DOES work? KIN_MALE?
// 0000 0000 1000 1001 = 137
// 0000 0000 1000 0000 = 128
// 0000 0000 1000 0000 = 128 = TRUE
static const constexpr unsigned int KIN_MERCENARY   = ( 1u << 0 );  // 1     1
static const constexpr unsigned int KIN_SEYAN_DU    = ( 1u << 1 );  // 2     10
static const constexpr unsigned int KIN_PURPLE      = ( 1u << 2 );  // 4     100
static const constexpr unsigned int KIN_MONSTER     = ( 1u << 3 );  // 8     1000
static const constexpr unsigned int KIN_TEMPLAR     = ( 1u << 4 );  // 16    10000
static const constexpr unsigned int KIN_ARCHTEMPLAR = ( 1u << 5 );  // 32    ******
static const constexpr unsigned int KIN_HARAKIM     = ( 1u << 6 );  // 64
static const constexpr unsigned int KIN_MALE        = ( 1u << 7 );  // 128
static const constexpr unsigned int KIN_FEMALE      = ( 1u << 8 );  // 256
static const constexpr unsigned int KIN_ARCHHARAKIM = ( 1u << 9 );  // 512
static const constexpr unsigned int KIN_WARRIOR     = ( 1u << 10 ); // 1024
static const constexpr unsigned int KIN_SORCERER    = ( 1u << 11 ); // 2048**
