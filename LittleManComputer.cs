using System;
using System.Net.Sockets;

namespace LittleManComputerSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Object[] MemoryLocations = new Object[100];
            int accumulator = 0;
            bool running = true;
            List<string> programCounter = new List<string>();
            // Implement While Loop
            while (running){
                Console.WriteLine("Choose an option: \n1.Store Data\n2.Load Data\n3.Add\n4.Subtract\n5.Input Data\n6.Output Memory\n7.Output Program Counter\n8.Quit");
                bool inpverified = false;
                while (!inpverified){
                    System.Console.WriteLine("Accumulator: " + accumulator);
                    var userInput = Console.ReadLine();
                    inpverified = true;
                    switch(userInput)
                    {
                        case "1":
                            programCounter.Add("Store Data");
                            System.Console.WriteLine("Where do you want to store the data? 1 - 100");
                            int address = Convert.ToInt32(Console.ReadLine());
                            if (address <= 100 && address > 0)
                                storedata(MemoryLocations,address, accumulator);
                            break;
                        case "2":
                            programCounter.Add("Load Data");
                            System.Console.WriteLine("Where do you want to load the data from? 1 - 100");
                            address = Convert.ToInt32(Console.ReadLine());
                            if (address <= 100 && address > 0)
                                load(MemoryLocations,address, ref accumulator);
                            break;
                        case "3":
                            programCounter.Add("Add");
                            System.Console.WriteLine("What is the address of the data you want to add? 1-100");
                            address = Convert.ToInt32(Console.ReadLine());
                            if (address <= 100 && address > 0)    
                                changeaccumulator(MemoryLocations,address, ref accumulator, true);
                            break;
                        case "4":
                            programCounter.Add("Subtract");
                            System.Console.WriteLine("What is the address of the data you want to subtract? 1 - 100");
                            address = Convert.ToInt32(Console.ReadLine());
                            if (address <= 100 && address > 0)    
                                changeaccumulator(MemoryLocations,address, ref accumulator, false);
                            break;
                        case "5":
                            programCounter.Add("Input Data");
                            System.Console.WriteLine("Enter the data:");
                            int numinput = Convert.ToInt32(Console.ReadLine());
                            accumulator = numinput;
                            break;
                        case "6":
                            programCounter.Add("Output Memory");
                            for (int i = 0; i < 100; i++)
                            {
                                System.Console.WriteLine(i+1 + ". " + MemoryLocations[i]);
                            }
                            break;
                        case "7":
                            for (int i = 0;i < programCounter.Count;i++){
                                System.Console.WriteLine(i+1 + ". " + programCounter[i]);
                            }
                            break;
                        case "8":
                            running = false;
                            break;
                        default:
                            System.Console.WriteLine("Enter an option from 1 to 7");
                            inpverified = false;
                            break;
                    }
                    Console.Write("\n\n\n\n\n");
                }
            }
        }  
    
        static void storedata(object[] memory, int position, int accumulator)
        {
            memory[position-1] = accumulator;
        }
    

        static void load(object[] memory, int position, ref int accumulator)
        {
            accumulator = Convert.ToInt32(memory[position-1]);
        }

        static void changeaccumulator(object[] memory, int position, ref int accumulator, bool sign)
        {
            if (sign){
                accumulator += Convert.ToInt32(memory[position-1]);
            }
            else{
                accumulator -= Convert.ToInt32(memory[position-1]);
            }
        }
    }
}