using System;

class Program
{
    static void Main(string[] args)
    {
        // Request names at the start
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        
        Console.WriteLine($"Welcome to Guess My Number, {name}!");
        Console.WriteLine();

        string playAgain = "yes";
        
        // Main game loop - allows replaying
        while (playAgain.ToLower() == "yes")
        {
            PlayGame();
            
            Console.WriteLine();
            Console.Write("Would you like to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }
        
        Console.WriteLine($"Thank you for playing, {name}! Goodbye!");
    }
    
    static void PlayGame()
    {
        // Generate random number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        
        int guess = 0;
        int guessCount = 0;
        
        // Loop until user guesses the magic number
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;
            
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        
        // Display number of guesses
        Console.WriteLine($"It took you {guessCount} guess(es) to get the answer!");
    }
}