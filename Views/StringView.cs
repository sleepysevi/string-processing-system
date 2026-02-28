using StringProcessingApp.Services;

namespace StringProcessingApp.Views
{
    public class StringView
    {
        private StringService service = new StringService();

        public void Run()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("    String Processing System");
            Console.WriteLine("===================================");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1.  Enter Text");
                Console.WriteLine("2.  View Current Text");
                Console.WriteLine("3.  Convert to UPPERCASE");
                Console.WriteLine("4.  Convert to lowercase");
                Console.WriteLine("5.  Count Characters");
                Console.WriteLine("6.  Check if Contains Word");
                Console.WriteLine("7.  Replace Word");
                Console.WriteLine("8.  Extract Substring");
                Console.WriteLine("9.  Trim Spaces");
                Console.WriteLine("10. Reset Text");
                Console.WriteLine("11. Exit");
                Console.Write("\nEnter choice: ");

                string input = Console.ReadLine();
                int choice;

                // para check if input is a valid number
                bool isValid = int.TryParse(input, out choice);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                // para check if there is text before doing anything except enter text or exit
                if (choice != 1 && choice != 11 && !service.HasText())
                {
                    Console.WriteLine("No text yet. Please enter text first (option 1).");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Write("Enter your text: ");
                    string text = Console.ReadLine();

                    if (text == "" || text == null)
                    {
                        Console.WriteLine("Text cannot be empty.");
                    }
                    else
                    {
                        service.SetText(text);
                        Console.WriteLine("Text saved!");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Current Text: " + service.GetCurrentText());
                }
                else if (choice == 3)
                {
                    string result = service.ToUpperCase();
                    Console.WriteLine("Result: " + result);
                }
                else if (choice == 4)
                {
                    string result = service.ToLowerCase();
                    Console.WriteLine("Result: " + result);
                }
                else if (choice == 5)
                {
                    int count = service.CountCharacters();
                    Console.WriteLine("Number of characters: " + count);
                }
                else if (choice == 6)
                {
                    Console.Write("Enter word to search: ");
                    string word = Console.ReadLine();

                    bool found = service.ContainsWord(word);

                    if (found)
                    {
                        Console.WriteLine("Yes, the text contains \"" + word + "\".");
                    }
                    else
                    {
                        Console.WriteLine("No, the text does not contain \"" + word + "\".");
                    }
                }
                else if (choice == 7)
                {
                    Console.Write("Word to replace: ");
                    string oldWord = Console.ReadLine();

                    Console.Write("New word: ");
                    string newWord = Console.ReadLine();

                    string result = service.ReplaceWord(oldWord, newWord);
                    Console.WriteLine("Updated Text: " + result);
                }
                else if (choice == 8)
                {
                    Console.Write("Enter start index: ");
                    int startIndex;
                    bool validStart = int.TryParse(Console.ReadLine(), out startIndex);

                    Console.Write("Enter length: ");
                    int length;
                    bool validLength = int.TryParse(Console.ReadLine(), out length);

                    if (!validStart || !validLength)
                    {
                        Console.WriteLine("Invalid input. Please enter numbers only.");
                    }
                    else
                    {
                        string result = service.ExtractSubstring(startIndex, length);
                        Console.WriteLine("Extracted: " + result);
                    }
                }
                else if (choice == 9)
                {
                    string result = service.TrimSpaces();
                    Console.WriteLine("Trimmed Text: " + result);
                }
                else if (choice == 10)
                {
                    string result = service.ResetText();
                    Console.WriteLine("Text has been reset to: " + result);
                }
                else if (choice == 11)
                {
                    Console.WriteLine("Exiting... Goodbye!");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose from 1 to 11.");
                }
            }
        }
    }
}
