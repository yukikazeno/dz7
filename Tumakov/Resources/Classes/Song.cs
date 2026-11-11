namespace Tumakov
{
    class Song
    {
        public string name;
        string author;
        Song prev;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public void PrintInfo()
        {
            Console.WriteLine(Title());
        }

        public string Title()
        {
            return $"{name} — {author}";
        }

        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }
    }
}
