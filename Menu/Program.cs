/*
 * Name:         Brayton Moloney
 * Course:       CSCI 1250, Section 001
 * Assignment:   Lab 06, Three Short Problems
 * Date:         October 21, 2026
 * Description:  A menu that keeps running until the user quits, offering three
 *               independent exercises or all three at once. Each exercise
 *               practices decisions and one of the four loops.
 */
using System;

const int SEED = 4000;
const int SCORE_COUNT = 5;
const int PASSING_MARK = 60;
const int MENU_OPTIONS = 5;
const int QUIT_OPTION = 5;

Random rng = new Random(SEED);

int choice = 0;

do
{
    choice = 0;

    Console.WriteLine("=== CSCI 1250 Lab 06 ===");
    Console.WriteLine("1. The Grade Checker");
    Console.WriteLine("2. The Dice Table");
    Console.WriteLine("3. The Score Report");
    Console.WriteLine("4. All three");
    Console.WriteLine("5. Quit");
    Console.Write("Choose 1 through 5: ");
    choice = Convert.ToInt32(Console.ReadLine());

    while (choice < 1 || choice > MENU_OPTIONS)
    {
        Console.WriteLine("Choose a number from 1 to 5.");
        Console.Write("Choose 1 through 5: ");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine();

    if (choice == 1 || choice == 4)
    {
        Console.WriteLine("=== Exercise 1: The Grade Checker ===");

        Console.Write("Score: ");
        int score = Convert.ToInt32(Console.ReadLine());

        while (score < 0 || score > 100)
        {
            Console.WriteLine("A score must be between 0 and 100.");
            Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());
        }

        string grade;
        if (score >= 90)
        {
            grade = "A";
        }
        else if (score >= 80)
        {
            grade = "B";
        }
        else if (score >= 70)
        {
            grade = "C";
        }
        else if (score >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine(score + " earns a " + grade + ".");
        Console.WriteLine();
    }

    if (choice == 2 || choice == 4)
    {
        Console.WriteLine("=== Exercise 2: The Dice Table ===");

        int rollCount = 0;
        int winCount = 0;
        string answer = "";

        do
        {
            rollCount++;
            int die1 = rng.Next(1, 7);
            int die2 = rng.Next(1, 7);
            int total = die1 + die2;

            Console.Write("Roll " + rollCount + ": " + die1 + " and " + die2 + ", total " + total + ".");

            if (die1 == 1 && die2 == 1)
            {
                Console.WriteLine(" Snake eyes.");
            }
            else if (die1 == die2)
            {
                Console.WriteLine(" Doubles!");
            }
            else if (total == 7 || total == 11)
            {
                winCount++;
                Console.WriteLine(" A winner.");
            }
            else
            {
                Console.WriteLine();
            }

            Console.Write("Roll again? (y/n): ");
            answer = Console.ReadLine();
        } while (answer == "y");

        Console.WriteLine("You rolled " + rollCount + " times and won " + winCount + ".");
        Console.WriteLine();
    }

    if (choice == 3 || choice == 4)
    {
        Console.WriteLine("=== Exercise 3: The Score Report ===");

        int[] scores = new int[SCORE_COUNT];

        for (int i = 0; i < scores.Length; i++)
        {
            Console.Write("Score " + (i + 1) + ": ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        int total = 0;
        int highest = scores[0];
        int passing = 0;

        foreach (int s in scores)
        {
            total = total + s;
            if (s > highest)
            {
                highest = s;
            }
            if (s >= PASSING_MARK)
            {
                passing++;
            }
        }

        double average = (double)total / scores.Length;

        Console.WriteLine();
        Console.WriteLine("Scores entered: " + scores.Length);
        Console.WriteLine("Total: " + total);
        Console.WriteLine("Average: " + average.ToString("F1"));
        Console.WriteLine("Highest: " + highest);
        Console.WriteLine("Passing: " + passing + " of " + scores.Length);
        Console.WriteLine();
    }
} while (choice != QUIT_OPTION);

Console.WriteLine("Goodbye.");