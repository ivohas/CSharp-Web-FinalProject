namespace BookFindingAndRatingSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class BookConst
        {
            public const int BookTitleMaxLeght = 100;
            public const int BookTitleMinLenght = 5;

            public const int BookDescriptionMaxLenght = 1_000;
            public const int BookDescriptionMinLenght = 50;

            public const int BookMinPages = 1;
            public const int BookMaxPages = 2_000;

            public const float BookPriceMin = 1;
            public const float BookPriceMax = 30_800_000;

            public const int MinSoldCopies = 1;
            public const int MaxSoldCopies = 300_000_000;
            // Eventually add 0.0 to 10.0 for raiting
        }
        public static class UserConst 
        {

            public const int UserNameMaxLenght = 15;
            public const int UserNameMinLenght = 3;

            public const int UserEmailMaxLength = 100;
            public const int UserEmailMinLenght = 5;

            public const int UserPasswordMaxLength = 50;
            public const int UserPasswordMinLenght = 5;

            public const int MaxLengthAbout = 250;
            public const int MinLengthAbout = 10;

            public const int MinBooksToRead = 0;
            public const int MaxBookToRead = 1000;

            public const int UserAboutMaxLenght = 250;
            public const int UserAboutMinLenght = 10;
        }

        public static class ReviewsConst
        { 
        
            public const int ReviewMaxLeght = 500;
            public const int ReviewMinLeght = 50;
        }

        public static class GenreConst
        {

            public const int GenreNameMaxLength = 30;
            public const int GenreNameMinLength = 3;
        }

        public static class PublisherConst
        {

            public const int PublisherNameMaxLenght = 80;
            public const int PublisherNameMinLenght = 3;
        }

        public static class AuthorConst
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 3;

            public const int LastNameMaxLength = 30;
            public const int LastNameMinLength = 3;

            public const int NameMaxLenght = 60;
            public const int NameMinLenght = 6;
        }
    }
}
