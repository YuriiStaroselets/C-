/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Input X: ");
        float inputX = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input Z: ");
        float inputZ = Convert.ToInt32(Console.ReadLine());
        float r1, r2;
        if (inputX != 0)
        {
            r1 = inputZ / inputX;
            Console.WriteLine(r1);

        }
        else if (inputX == 0)
        {
            Console.WriteLine("Input X == 0! ");

        }
        else
        {
            Console.WriteLine("Enter X and Y ");

        }

    }

}
