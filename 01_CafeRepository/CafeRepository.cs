using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _01_Cafe.CafeClass;

namespace _01_Cafe

{
    public class CafeRepository
    {
        // protected - can only access ?
        protected readonly List<MenuItem> _contentMenuItem = new List<MenuItem>();
        //CRUD
        public bool AddMealToMenu(MenuItem content)
        {
            int startingCount = _contentMenuItem.Count;
            _contentMenuItem.Add(content);
            bool wasAdded = (_contentMenuItem.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<MenuItem> GetContents()
        {
            return _contentMenuItem;
        }

        public MenuItem GetContentByNumber(int number)
        {
            foreach (MenuItem content in _contentMenuItem)
            {
                if (content.MealNumber == number)
                {
                    return content;
                }
            }
            return null;
        }

        public bool DeleteExistingContent(MenuItem existingContent)
        {
            bool deleteResult = _contentMenuItem.Remove(existingContent);
            return deleteResult;

        }
    }
}
