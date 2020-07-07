using System;

namespace Cinéthèque
{
    class Cinetheque
    {
        static int askAMovieChoice;
        public static void Run()
        {
            do
            {
                ColorTheMenu();
                var theme = ChooseATheme();
                ColorTheMovie();
                var movie = AskAMovie(theme);
                do
                {
                    ColorTheInformations();
                    ShowInformations(theme, movie);
                } while (AskMoreMovieInformations());
            } while (AskComebackToMenu());
        }

        private static void ColorTheInformations()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }

        private static void ColorTheMovie()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
        }

        private static void ColorTheMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.White;
        }

        private static void CenterText(string text)
        {
            int spacesNum = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(spacesNum, Console.CursorTop);
            Console.WriteLine(text);
        }

        private static bool AskComebackToMenu()
        {
            CenterText("Voulez vous retournez au sommaire (O/N)?");
            return AskContinue();
        }

        private static bool AskMoreMovieInformations()
        {
            CenterText("______________________________________");
            CenterText("Voulez vous d'autres informations sur le film (O/N)?");
            return AskContinue();
        }

        private static bool AskContinue()
        {
            char key;
            do
            {
                key = Console.ReadKey(true).KeyChar;
            } while (!"ON".Contains(char.ToUpper(key)));
            CenterText("______________________________________");

            Console.Clear();

            return char.ToUpper(key) == 'O';
        }

        private static void ShowInformations(Theme theme, Movie movie)
        {
            var infoSection = AskInformationsSections(movie);
            var section = infoSection;

            if (section == "Informations")
            {
                var infos = movie.Informations;
                for (int i = 0; i < infos.Length; i++)
                    CenterText($"{i + 1}: {infos[i]}");
            }
            else if (section == "Acteurs")
            {
                var actors = movie.Actors;
                for (int i = 0; i < actors.Length; i++)
                    CenterText($"{i + 1}: {actors[i]}");
            }
            else
            {
                var synopsis = theme.Movies;
                Console.WriteLine($"{synopsis[askAMovieChoice].Synopsis}");
            }
        }

        private static string AskInformationsSections(Movie movie)
        {
            var sections = movie.Sections;
            for (int i = 0; i < sections.Length; i++)
                Console.WriteLine($"{i + 1}: {sections[i]}");

            var input = Console.ReadLine();
            int choiced = int.Parse(input) - 1;
            string sectionChoiced = sections[choiced];
            CenterText($"Vous avez choisi: {sectionChoiced}");
            CenterText("______________________________________");

            Console.Clear();

            return sectionChoiced;
        }

        public static Movie AskAMovie(Theme theme)
        {
            CenterText("Veuillez choisir un film:");

            var titles = theme.Movies;

            for (int i = 0; i < titles.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {titles[i].Label}");
            }

            var input = Console.ReadLine();
            askAMovieChoice = int.Parse(input) - 1;
            Movie movieChoiced = titles[askAMovieChoice];
            Console.Clear();
            CenterText($"Vous avez choisi: {movieChoiced.Label}");
            CenterText("______________________________________");

            return movieChoiced;
        }

        public static Theme ChooseATheme()
        {
            Theme themeChoiced = null;
            var themes = Theme.ReadFromDirectoty("./Data");

            CenterText("Veuillez choisir un thème:");
            for (int i = 0; i < themes.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {themes[i].Name}");
            }

            try
            {
                var input = Console.ReadLine();
                int choiced = int.Parse(input) - 1;
                themeChoiced = themes[choiced];
                Console.Clear();
                Console.WriteLine($"Vous avez choisi: {themeChoiced.Name}");
                Console.WriteLine("______________________________________");
            }
            catch (Exception)
            {
                Console.WriteLine("La saisie est erronnée, veuillez reésseyer");
            }

            return themeChoiced;
        }
    }
}
