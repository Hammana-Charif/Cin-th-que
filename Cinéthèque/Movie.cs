using System.Collections.Generic;
using System.IO;

namespace Cinetheque
{
    class Movie
    {
        public string Label { get; private set; }
        public string Synopsis { get; private set; }

        public string[] Sections { get; private set; }
        public string[] Informations { get; private set; }
        public string[] Actors { get; private set; }

        public static Movie[] ReadTitleFromDirectory(string filePath)
        {
            List<Movie> movies = new List<Movie>();

            using (var file = File.OpenText(filePath))
            while(!file.EndOfStream)
            {
                var titleLine = file.ReadLine();
                var sectionLine = file.ReadLine();
                var informationsLine = file.ReadLine();
                var actorsLine = file.ReadLine();
                var synopsisLine = file.ReadLine();

                    movies.Add(new Movie()
                    {
                        Label = titleLine,
                        Sections = sectionLine.Split('|'),
                        Informations = informationsLine.Split('|'),
                        Actors = actorsLine.Split('|'),
                        Synopsis = synopsisLine
                    });
            }

            return movies.ToArray();
        }
    }
}
