using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVol1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*The project is a game. The game which my first project was done by Oğuz Kağan EREN for Dokuz Eylül University. I didn't use arrays because it was not allowed us. I explained how to play the game in readme.txt. You can develop it.
             mail:oguzkaganeren@gmail.com
             myWebSite:oguzeren.net
             */
            //tekrar oynama
            bool isAgain = true;
            //----*------
            //istatistikler
            int timesPlayed = 0;
            int sumScores = 0;
            bool isStatistics = false;
            //----*------
            //yardim
            bool isHelp = false;
            //----*------

            while (isAgain)//command'dan, 200 geldiyse oyun yeniden başlayacaktır.
            {
                isAgain = false;
                //Oyuncu istatistilerini gösterilecekse eğer
                if (isStatistics)
                {
                    isStatistics = false;
                    Console.WriteLine("How many times have I played the game? : {0} times", timesPlayed);
                    Console.WriteLine("My total score is {0}", sumScores);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("If you want to play the game, please press enter");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                }
                //---------*----------
                //Oyuncu yardım istiyorsa eger
                if (isHelp)
                {
                    isHelp = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Playing Rules");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. The game is played on two 3*3 boards: Computer's board and player's board.\n");
                    Console.WriteLine("2. At the beginning, computer shapes its board placing random X marks. Each square is filled by X or left empty.\n");
                    Console.WriteLine("3. The objective of the game is to create the same board with the computer in minimum number of rounds.\n");
                    Console.WriteLine("4. In each round, a 1*2 small random piece is generated in order to be placed by the player on the player's board.\n");
                    Console.WriteLine("5. Player can rotate this piece as many times as he likes, then place it wherever he wants. The piece should not\nbe placed out of the board. Otherwise, an error occurs. Each error, rotation and placement takes one round.\nAfter the placement, a new round starts.\n");
                    Console.WriteLine("Game playing commands are as follows:\n");
                    Console.WriteLine("Placement commands:");
                    Console.WriteLine("YX: Place the small piece starting from row Y and column X.(Y and X values can be 1,2 or 3)\n");
                    Console.WriteLine("Rotation commands:");
                    Console.WriteLine("41: Rotate the small piece 90 degrees clockwise.");
                    Console.WriteLine("42: Rotate the small piece 90 degrees anticlockwise.\n");
                    Console.WriteLine("6. When the small piece is being placed, XOR operation is applied with the existing player's board.\n");
                    Console.WriteLine("7. When the same board is formed by the player the game is over. The score is calculated as follows:");
                    Console.WriteLine("Score=200-10*(the number of rounds)\n");
                    Console.WriteLine("8. Otherwise, the next round begins and the game continues.\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("If you want to play the game, please press enter");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                }
                //-----------*----------

                timesPlayed = timesPlayed + 1;
                /*Değişkenlerde kullanılan 0 değerleri yokluğu, 1 değerleri varlığı temsil eder.*/
                //Command
                int gamerDirect = 0;
                //----*------
                //Randon sayı üret
                Random rnd = new Random();
                //----*------
                //Bilgisayarın değerleri
                int perma11 = rnd.Next(0, 2);
                int perma12 = rnd.Next(0, 2);
                int perma13 = rnd.Next(0, 2);
                int perma21 = rnd.Next(0, 2);
                int perma22 = rnd.Next(0, 2);
                int perma23 = rnd.Next(0, 2);
                int perma31 = rnd.Next(0, 2);
                int perma32 = rnd.Next(0, 2);
                int perma33 = rnd.Next(0, 2);
                //----*------
                //Hata(Out of Board Error!)
                bool error = false;
                //----*------
                //Gamer değerleri
                int temp11 = 0;
                int temp12 = 0;
                int temp13 = 0;
                int temp21 = 0;
                int temp22 = 0;
                int temp23 = 0;
                int temp31 = 0;
                int temp32 = 0;
                int temp33 = 0;
                //----*------
                //Round 
                int rd = 1;
                //----*------
                //Yatay veya dikey kolonlar
                int a = 0;//kolonun ilk satırıdır
                int b = 0;//kolunun ikinci satırıdır
                int YDoran = 0;//Kolonlar icin kullanılacak olan oran değerini tutacaktır

                //----*------
                //Dikey kontrolu icin olusturulan degisken
                //Dikey kolon olup olmadığı kontrol edilir
                bool isVertical = false;
                //----*------
                //Oyunun bitisini kontrol etme
                bool isFinish = false;
                //----*------
                //SetCursor için sayac
                int setInc = 0;
                //----*------
                //Score
                int score = 200;
                //----*------
                //Dondurme
                bool isRotate = false;
                //----*------
                //String veya bosluk hata koruması
                string errorControl;
                //----*------
                while (!isFinish)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("------ Round " + rd + " ------");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Computer's");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" & ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Player's Boards");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("   1 2 3      1 2 3");
                    Console.WriteLine(" + - - - +  + - - - +  ");
                    Console.WriteLine("1|       |  |       |");
                    Console.WriteLine("2|       |  |       |");
                    Console.WriteLine("3|       |  |       |");
                    Console.WriteLine(" + - - - +  + - - - +");

                    //Bilgisayarın yarattığı tabloları yazdırıyorum rasgele sayılarını degiskenleri tanımlarken atadım
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (perma11 == 1)
                    {
                        Console.SetCursorPosition(3, 6 + setInc);
                        Console.Write("x");
                    }
                    if (perma12 == 1)
                    {
                        Console.SetCursorPosition(5, 6 + setInc);
                        Console.Write("x");
                    }
                    if (perma13 == 1)
                    {
                        Console.SetCursorPosition(7, 6 + setInc);
                        Console.Write("x");
                    }
                    if (perma21 == 1)
                    {
                        Console.SetCursorPosition(3, 7 + setInc);
                        Console.Write("x");
                    }
                    if (perma22 == 1)
                    {
                        Console.SetCursorPosition(5, 7 + setInc);
                        Console.Write("x");
                    }
                    if (perma23 == 1)
                    {
                        Console.SetCursorPosition(7, 7 + setInc);
                        Console.Write("x");
                    }
                    if (perma31 == 1)
                    {
                        Console.SetCursorPosition(3, 8 + setInc);
                        Console.Write("x");
                    }
                    if (perma32 == 1)
                    {
                        Console.SetCursorPosition(5, 8 + setInc);
                        Console.Write("x");
                    }
                    if (perma33 == 1)
                    {
                        Console.SetCursorPosition(7, 8 + setInc);
                        Console.Write("x");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    //Tablo oluşumu burada biter
                    //Oyuncu ekranını yazdırma
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //İlk satır
                    Console.SetCursorPosition(14, 6 + setInc);
                    if (temp11 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(16, 6 + setInc);
                    if (temp12 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(18, 6 + setInc);
                    if (temp13 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    //ikinci satır
                    Console.SetCursorPosition(14, 7 + setInc);
                    if (temp21 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(16, 7 + setInc);
                    if (temp22 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(18, 7 + setInc);
                    if (temp23 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    //ücüncü satır
                    Console.SetCursorPosition(14, 8 + setInc);
                    if (temp31 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(16, 8 + setInc);
                    if (temp32 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(18, 8 + setInc);
                    if (temp33 == 1)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    //Oyuncu ekranını yazdırma biter
                    if (error == false)//Hatalı geldiyse tekrar blok olusturmayacak
                    {
                        //Dikey veya Yatay blokların oluşturulması
                        if (isRotate == false)//Eger dondurme komutu kullanılmadıysa buraya gir
                        {
                            YDoran = rnd.Next(0, 101);

                            if (YDoran > 10)//Çift gelen bloklar xx seklinde
                            {
                                a = 1;
                                b = 1;
                            }
                            else if (YDoran > 5 && YDoran < 11)//ilk once x sonra bosluk
                            {
                                a = 1;
                                b = 0;
                            }
                            else//ilk once bosluk sonra x
                            {
                                a = 0;
                                b = 1;
                            }
                            if (rnd.Next(0, 2) == 1)//1 ise dikey
                            {
                                isVertical = true;
                            }
                            else
                            {
                                isVertical = false;
                            }
                        }
                        else
                        {
                            isRotate = false;
                        }
                    }

                    else//Eger hatalı bir sekilde geldiyse degeri degistiriyoruz
                    {
                        error = false;
                    }
                    //Dikey veya yatay blok olusması biter

                    
                    //Kolonların yazdırılması
                    if (isVertical == false)
                    {
                        Console.SetCursorPosition(22, 5 + setInc);
                        Console.Write("+ - - +");
                        Console.SetCursorPosition(22, 6 + setInc);
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (a == 1) Console.Write("x ");
                        else Console.Write("  ");
                        if (b == 1) Console.Write("x ");
                        else Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.SetCursorPosition(22, 7 + setInc);
                        Console.Write("+ - - +");
                    }
                    else
                    {
                        Console.SetCursorPosition(22, 5 + setInc);
                        Console.Write("+ - +");
                        Console.SetCursorPosition(22, 6 + setInc);
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (a == 1) Console.Write("x ");
                        else Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.SetCursorPosition(22, 7 + setInc);
                        Console.Write("| ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (b == 1) Console.Write("x ");
                        else Console.Write("  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("|");
                        Console.SetCursorPosition(22, 8 + setInc);
                        Console.Write("+ - +");
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    //Kolonların yazdırılması biter
                    //Yan kisim
                    Console.SetCursorPosition(45, 0 + setInc);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("*If you ask for help, please you enter the following values.");
                    Console.SetCursorPosition(50, 1 + setInc);
                    Console.Write("1- If you enter 100, you will inform about");
                    Console.SetCursorPosition(50, 2 + setInc);
                    Console.Write("how to play the game.(The game is restarted!)");
                    Console.SetCursorPosition(50, 3 + setInc);
                    Console.Write("2- If you enter 200, you will replay the game.");
                    Console.SetCursorPosition(50, 4 + setInc);
                    Console.Write("3- If you enter 300, the game will show about ");
                    Console.SetCursorPosition(50, 5 + setInc);
                    Console.Write("how many times have you played the game");
                    Console.SetCursorPosition(50, 6 + setInc);
                    Console.Write("and your total scores.(The game is restarted!)");
                    Console.ForegroundColor = ConsoleColor.White;
                    //yan kisim biter
                    Console.SetCursorPosition(0, 11 + setInc);//imleci command kısmına getirdik
                    if (perma11 == 0 && perma12 == 0 && perma13 == 0 && perma21 == 0 && perma22 == 0 && perma23 == 0 && perma31 == 0 && perma32 == 0 && perma33 == 0)//Bu kısımda bilgisayar bordu boş gelirse direk kazandınız yazması içindir.
                    {
                        Console.WriteLine("You are Win!!");
                        Console.WriteLine("Congratulations!!!");
                        Console.WriteLine("Your score: " + score);
                        sumScores = sumScores + score;
                        isFinish = true;
                        Console.WriteLine("If you replay the game, please press enter.");
                        Console.ReadLine();
                        Console.Clear();

                        isAgain = true;
                    }
                    else
                    {
                        if (perma11 == temp11 && perma12 == temp12 && perma13 == temp13 && perma21 == temp21 && perma22 == temp22 && perma23 == temp23 && perma31 == temp31 && perma32 == temp32 && perma33 == temp33)
                        {
                            Console.WriteLine("You are Win!!");
                            Console.WriteLine("Congratulations!!!");
                            Console.WriteLine("Your score: " + (score - 10 * rd));
                            sumScores = sumScores + (score - 10 * rd);
                            isFinish = true;
                            Console.WriteLine("If you replay the game, please press enter.");
                            Console.ReadLine();
                            Console.Clear();

                            isAgain = true;

                        }
                        else
                        {
                            Console.Write("Command: ");
                            errorControl = Console.ReadLine();//string bir değişkene atıyoruz
                            //Asagidaki kontrol ile harf, bosluk, istenmeyen sayilar girilmesi onlendi
                            if (errorControl == "11" | errorControl == "12" | errorControl == "13" | errorControl == "21" | errorControl == "22" | errorControl == "23" | errorControl == "31" | errorControl == "32" | errorControl == "41" | errorControl == "42" | errorControl == "100" | errorControl == "200" | errorControl == "300")
                            {
                                gamerDirect = Convert.ToInt32(errorControl);
                                switch (gamerDirect)
                                {
                                    case 11:
                                        if (isVertical == false)//yatay
                                        {
                                            temp11 = temp11 ^ a;
                                            temp12 = temp12 ^ b;

                                        }
                                        else//Dikey
                                        {
                                            temp11 = temp11 ^ a;
                                            temp21 = temp21 ^ b;
                                        }
                                        break;
                                    case 12:
                                        if (isVertical == false)//yatay
                                        {
                                            temp12 = temp12 ^ a;
                                            temp13 = temp13 ^ b;
                                        }
                                        else//Dikey
                                        {
                                            temp12 = temp12 ^ a;
                                            temp22 = temp22 ^ b;
                                        }
                                        break;
                                    case 13:
                                        if (isVertical == true)//Dikey
                                        {
                                            temp13 = temp13 ^ a;
                                            temp23 = temp23 ^ b;
                                        }
                                        else
                                        {
                                            error = true;
                                        }
                                        break;
                                    case 21:
                                        if (isVertical == false)//yatay
                                        {
                                            temp21 = temp21 ^ a;
                                            temp22 = temp22 ^ b;
                                        }
                                        else//Dikey
                                        {
                                            temp21 = temp21 ^ a;
                                            temp31 = temp31 ^ b;
                                        }
                                        break;
                                    case 22:
                                        if (isVertical == false)//yatay
                                        {
                                            temp22 = temp22 ^ a;
                                            temp23 = temp23 ^ b;
                                        }
                                        else//Dikey
                                        {
                                            temp22 = temp22 ^ a;
                                            temp32 = temp32 ^ b;
                                        }
                                        break;
                                    case 23:
                                        if (isVertical == true)//Dikey
                                        {
                                            temp23 = temp23 ^ a;
                                            temp33 = temp33 ^ b;
                                        }
                                        else
                                        {
                                            error = true;
                                        }
                                        break;
                                    case 31:
                                        if (isVertical == false)//yatay
                                        {
                                            temp31 = temp31 ^ a;
                                            temp32 = temp32 ^ b;
                                        }
                                        else
                                        {
                                            error = true;
                                        }
                                        break;
                                    case 32:
                                        if (isVertical == false)//yatay
                                        {
                                            temp32 = temp32 ^ a;
                                            temp33 = temp33 ^ b;
                                        }
                                        else
                                        {
                                            error = true;
                                        }
                                        break;
                                    case 41://rotation clockwise
                                        if (isVertical == true)
                                        {
                                            isVertical = false;
                                            if (a == 1 && b == 0)//the a and the b are part of the piece
                                            {
                                                a = 0;
                                                b = 1;
                                            }
                                            else if (a == 0 && b == 1)
                                            {
                                                a = 1;
                                                b = 0;
                                            }
                                        }
                                        else
                                        {
                                            isVertical = true;
                                        }

                                        isRotate = true;
                                        break;
                                    case 42:
                                        if (isVertical == true)
                                        {
                                            isVertical = false;

                                        }
                                        else
                                        {
                                            isVertical = true;
                                            if (a == 1 && b == 0)
                                            {
                                                a = 0;
                                                b = 1;
                                            }
                                            else if (a == 0 && b == 1)
                                            {
                                                a = 1;
                                                b = 0;
                                            }
                                        }

                                        isRotate = true;
                                        break;
                                    case 100://yardım icin kullanılacaktır
                                        isAgain = true;
                                        isFinish = true;
                                        isHelp = true;
                                        Console.Clear();
                                        break;
                                    case 200://replay icin
                                        isAgain = true;
                                        isFinish = true;
                                        Console.Clear();
                                        break;
                                    case 300://oyuncu istatistigi
                                        isAgain = true;
                                        isFinish = true;
                                        isStatistics = true;
                                        Console.Clear();
                                        break;
                                    default:
                                        error = true;
                                        break;
                                }

                            }
                            else
                            {
                                error = true;
                            }
                            if (error==true)
                            {
                                Console.SetCursorPosition(0, 10 + setInc);
                                Console.Write("Out of Board Error!");
                                Console.SetCursorPosition(0, 12 + setInc);
                            }
                            setInc += 12;//Her round yazdırma kısmını 12 birim asagi kaydiriyor
                            rd++;

                        }//<==Oyunun bitip bitmediğini kontrol ettirme kısmının parantezi

                    }
                }//<==while isFinish'e ait
            }
                Console.ReadLine();
            }
            }
    }

