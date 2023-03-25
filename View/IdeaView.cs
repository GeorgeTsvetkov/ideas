using ConsoleIdeaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagementSystem.View
{
    class IdeaView
    {
        public static void DisplayTopThreeIdeas(List<Idea> ideas)
        {
            Console.WriteLine("Top 3 oldest ideas:");
            Console.WriteLine("====================");
            if (ideas.Count == 0)
            {
                Console.WriteLine("There are no ideas to display.");
            }
            else
            {
                int counter = 0;
                foreach (Idea idea in ideas)
                {
                    counter++;
                    Console.WriteLine("{0}. {1} - {2} (Created on: {3})", counter, idea.Title, idea.Description, idea.CreatedAt.ToShortDateString());
                    if (counter == 3)
                    {
                        break;
                    }
                }
            }
        }

        public static void DisplaySearchResults(List<Idea> ideas)
        {
            Console.WriteLine("Search results:");
            Console.WriteLine("====================");
            if (ideas.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                foreach (Idea idea in ideas)
                {
                    Console.WriteLine("{0} - {1} (Created on: {2})", idea.Title, idea.Description, idea.CreatedAt.ToShortDateString());
                }
            }
        }
    }
}
