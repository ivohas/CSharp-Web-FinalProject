﻿namespace BookFindingAndRatingSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class BookConst
        {
            public const int BookTitleMaxLeght = 100;
            public const int BookTitleMinLenght = 5;

            public const int BookDescriptionMaxLenght = 1_000;
            public const int BookDescriptionMinLenght = 50;

            public const int BookMinPages = 20;
            public const int BookMaxPages = 2_000;

            public const float BookPriceMin = 1;
            public const float BookPriceMax = 30_800_000;
            // Eventually add 0.0 to 10.0 for raiting
        }
        public static class UserConst 
        {

            public const int UserFirstNameMaxLenght = 15;
            public const int UserFirstNameMinLenght = 3;

            public const int UserLastNameMaxLenght = 15;
            public const int UserLastNameMinLenght = 3;

            public const int UserEmailMaxLength = 100;
            public const int UserPasswordMaxLength = 50;
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

        public static class AutorConst
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 3;

            public const int LastNameMaxLength = 30;
            public const int LastNameMinLength = 3;            
        }
    }
}
