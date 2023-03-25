using System.Collections.Generic;
using ConsoleIdeaApp.Models;
using ConsoleIdeaApp.Data;
using System.Linq;
using ideas.Data;
using System.Text;
using System.Threading.Tasks;
using ideas;

namespace Controller
{
    public class IdeaController
    {
        private readonly IdeaData _ideaData;

        public IdeaController()
        {
            _ideaData = new IdeaData();
        }

        public void AddIdea(string title, string description)
        {
            _ideaData.AddIdea(new Idea { Title = title, Description = description });
        }

        public List<Idea> GetOldestIdeas(int count)
        {
            return _ideaData.GetIdeas().OrderBy(i => i.CreatedAt).Take(count).ToList();
        }
    }
}
