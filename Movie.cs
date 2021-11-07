using System;

namespace Lab10
{
    class Movie
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private int category;
        public int Category
        {
            get { return category; }
            set { category = value; }
        }

        public Movie(string title, int category)
        {
            Title = title;
            Category = category;
        }
    }
}
