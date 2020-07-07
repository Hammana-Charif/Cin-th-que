using System.IO;
using System.Linq;

namespace Cinetheque
{
    class Theme
    {
        public string Name { get; private set; }

        public string FilePath { get; private set; }

        private Movie[] movies;

        public Movie[] Movies { get
            {
                if(movies == null)
                    movies = Movie.ReadTitleFromDirectory(FilePath);

                return movies;
            }
        }

        public static Theme[] ReadFromDirectoty(string directoryPath)
        {
            var themeFiles = Directory.EnumerateFiles(directoryPath, "*txt");

            return themeFiles.Select(fileName => new Theme()
            {
                Name = Path.GetFileNameWithoutExtension(fileName),
                FilePath = fileName
            }).ToArray();
        }
    }
}
