using BookFindingAndRatingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BookFindingAndRatingSystem.Data.Configurations
{
    public class BookEntityConfiguraion : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(this.GenereteBooks());
        }

        public Book[] GenereteBooks()
        {
            ICollection<Book> books = new HashSet<Book>();
            Book book;
            book = new Book
            {
                Title = "To Kill a Mockingbird",
                Description = "A classic novel by Harper Lee",
                Pages = 336,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg",
                Price = 12.99f,
                PublishersId = 1,
                CategoryId = 8,
                AutorId  = 6,
                SelledCopies = 40_000_000
            };
            books.Add(book);
            book = new Book
            {
                Title = "1984",
                Description = "A dystopian novel by George Orwell",
                Pages = 328,
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg",
                Price = 9.99f,
                PublishersId = 2,
                CategoryId = 8,
                AutorId = 1,
                SelledCopies = 30_000_000
            };
            books.Add(book);
            book = new Book
            {
                Title = "The Catcher in the Rye",
                Description = "A coming-of-age novel by J.D. Salinger",
                Pages = 224,
                ImageUrl = "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg",
                Price = 8.99f,
                PublishersId = 3,
                CategoryId = 8,
                AutorId = 2,
                SelledCopies = 65_000_000
            };
            books.Add(book);
            book = new Book
            {
                Title = "The Great Gatsby",
                Description = "A novel by F. Scott Fitzgerald",
                Pages = 180,
                Price = 7.99f,
                ImageUrl = "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750",
                PublishersId = 4,
                CategoryId = 8,
                AutorId = 3,
                SelledCopies = 25_000_000
            };
            books.Add(book);
            book = new Book
            {
                Title = "The Hobbit",
                Description = "A fantasy novel by J.R.R. Tolkien",
                Pages = 304,
                Price = 11.99f,
                ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg",
                PublishersId = 5,
                CategoryId = 5,
                AutorId = 4,
                SelledCopies = 100_000_000
            };
            books.Add(book);
            book = new Book
            {
                Title = "Harry Potter and the Philosopher's Stone",
                Description = "The first book in the Harry Potter series by J.K. Rowling",
                Pages = 332,
                Price = 10.99f,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU",
                PublishersId = 6,
                CategoryId = 5,
                AutorId = 5,
                SelledCopies = 120_000_000
            };
            books.Add(book);

            book = new Book
            {
                Title = "The Shining",
                Description = "A horror novel by Stephen King",
                Pages = 688,
                Price = 13.99f,
                ImageUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoGCBUTExcVFRUXFxcZGRkaGBoYGRkaGhkaGhofGRkbGRgbHysjHBwoHRcZJTUkKCwxMjMyHyE3PDcxOysxMi4BCwsLDw4PHRERHTEhIygyLjEzMTExMTExMTExMTExMTExMTExMTExMTExMTExMTExLjExMTExMTExMTExMTExMf/AABEIAR0AsQMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAAFBgADAgQHAQj/xABREAACAQIEAgUFDAUKAwgDAAABAgMAEQQFEiExQQYTIlFhBzJxgZEIFCM1QlJyc6GxsrMVYmPB0RYkJTM2dIKSovBUw+EmU4OjwtLi8TRDk//EABkBAAMBAQEAAAAAAAAAAAAAAAABAgMEBf/EACURAAICAgIBBQEBAQEAAAAAAAABAhEDEiExUQQTIjJBcSNhM//aAAwDAQACEQMRAD8A7LVbOL2vVlCsTl+rERyaU0qsmq/EuWjKNw5dWd78xSGkn2EddQMDwoHl2VPHIjsVKqk6lbiw6yRXW3ZG1lIN++tno/gXghVG03CqCQb6mChSTsPmgczYUWNxS6dhMOK91jhS9JkshiRQypJGr6XFyAWOysu2tCLhhceG+42/0Z8NG+lNKxsrd5a8ZQjbkI+PK9FsGor9CusVNVA1ymTROvZvJ12k383rGJUebfmL7/JFqxTJnMYRmAIlMgdSQV7JC2W1tjYEcGAJPEii2PWPkPaqmoUEmy6UrFYpqiKuOKqz6u3YWOkFCwHHziKvjy3S8zBUs4ATvB0kNfba5PjRyLVeQpqFTWKBSZS5jC3U/ALGLk/BOoPbjsL3NweR7C792eJypzKHDAdqPVe5DohBOpeAcEbNvzHPYseq8hosKyFBVwMnWyOdNpIyrDUdipPV2237LEH1VuZZG6RKjBewqr2TcHSoBvsLbg00JxS6Zu6xXgYUtYLI5UjCFlPbhfidtFtdjptuFFtu+/Gt85c/WRMNK6BZhe4K9rgNIs243FuY3G1K2Nxj5C2sVA1BkyiyziyrrY6dJ0kIVRdNwOz5vDceBrH9FyaoWOhurjkVh5oJZ0ZdgtttHK2/C1FsVLyHNQrzUKCSZbIYZorIOsaVlOo8XfUtxp2sDVuNwTyNGxCdkOCuq4YNpsCSh2Omx257UBqvIWDDhVlA4ctcYkzdnSdrAm+6ItztvuhFu434ijYoQmkunZ7UqVKYiV4RXtSgDy1S1e0t9Nse8CRMFvH1gEtrg6eQuOAP7gOdJulYVYx2qjG4hY0eR9lRSzHjsBc7eiscDh1jQKt9O5FzewJLADwF7AcgBQLykSBcG9+JKqNyOJudgd9gdjSlKlY0uQxk+PTERLKgYI19OoWJAJF7XO21b1qHdHsAIIEjF7hV1XJPasNXHhuOA2r3PseIIS+xYlUQHgXc6Vv4XNz4A074tgELV4aDZNgXE0kzM5DqihWJ30cX08EueCjl6bUWxMgVSxNgASfQBc/ZQmIwjxCMxVWUsttQBBK3uBccuB49xq+1cqGXRPgpcUynrnxBMTC+vUX4A8ySz+NdOwCsIkDm7hFDHvbSLn21MZ2NqgF5R8SY8DIVLK7FFUqzKQSwvYqQfN1UR6L4Mw4WGNvOEa6+d3I1Puf1iaA+UJTM+Fwym3WSaj6BYX9QLH1VIUY5sFV3Kxw3e7Egki3m+aPOTYADalt8h1wONqlq9pVx49/ddErsqxuI1KllAddLO5bnYMFC89z4imyaGm1S1YItgBe+3E8aUM8R5szhiEjqqIJGCsbXBJB0na/mi9qJSoaVjlUtSd0SQNmGNkXVpGmMXJN7EjiTfipI+kacqIytWDVEtUqVKoRKlSpQBKleE0vZznk2HsXw6spJAZZj9oMYIpSkkrYJWMVCswyzrldHa8bsrMtt+yVNg19gSoPAnc78LAD01b/hvD+t79vmUz5ZPK63kjWM8lD6z6+yLfbUKUZ9DaaNxRYUH6TZMMXGqFymlwwIAPAEWIO3Bjvy9oJmhfSDNVw0WsjUb2Vb2v378gBz9HfVSquQQSXxoV0kyk4mNVDmNkdXVgNVivhcX4mrcoxU0g1SQiIchrLMfSNIsPXWeZTyoLxxpIACSGkKNtyXsEH1kUOmg6ZfhIiiBWYuQN2biT37bD0ChnTfEdXg5TzZdA9LkL9xNBf5bP8A8MP/AOv/AMKIZZi2x6fCYZOqDcTKWuy7bKEF7eJtUbRktYsdNcsnRjJ9MOHMh1BEDolgAjv22Y/OYarAnh6TTLQbNMdNApZYEkRR8mQqwUcypS1gO4mgn8tm/wCG/wDN/wDhRtGHDCmw5iMmD4qPEs7XjXSiADTuHBJvz7fK3missHlAjxMmIDn4QKCpAsLdzceQ2rYybHriIUlUEBxex4qQbMp8QQRW8atRXYrZ4aC5Nkgw8jssjlHcv1dgFDNsSTxbaw9lTO80mw6s/UI8YPnCUhgO9lMe3qJq3I8wmnAZ4VjQi4PWFmN+BA0AW8b0uG6/Q/ArahWGyhUxMmJ1MXdQtjbSqjTsBx+QD7aLUPzjMo8Omtz4Ko3Zjxso/wBjvpyrtgVZNlC4d5WRmtK2sqbWU+Btf2mitKeGznG4gkwRRIl7AylyduNyuw9G9XDP5YGC42JY1JsJoiWiH09Vinp39VJSilwDTGapQ18yXr0hWxLI0hPIKtrW8SW9golVJ2IlSpUpgSgPTGDVEvg33j/pR6tDOY9SAfrD7jWWf6MqPYhz4WwBtwZT/qFdKpUzDC2jO3DSf9QprFc/pHaY5njcKWI4DjMRrcXiiOwPM7FRbn84/wCEUWzmUldC7sxA9vAfx8Aa2cuwoijCDe3E95O5Ptrd/KVfiF0jarxuFe14a1fRJzpsJududNXQdLYVR+vL+Y1azYPfhRDoutoLftJfzGrh9M/mzSfQTYXFq53Jg9ztzP310U0uw4TUhawuHkU+gMQKv1UW6aFB0afQ6fqpGhY9mTtxg/PA+EUHxADW+kab6VJ8GwAdANaEOnpHEesEr66ZMJOsiK6m6sAw9BF6r02TaNeAmuTT6UrfDSj9Q1fkgth4h+zj/CK8ztbwSD9RvurPLP6mP6CfhFar7Mn8LMVKEUs3AC//ANeNI2YK+ImXUSDIwRbfIU7nT6FBPpFNucAsAvrP7qHZdhR18d/kq7j0iyfdIa58mTbIoIpKlYdw0CxqEUAKosAO6scbhVlRkYXVhY/xHjWxUrspVRAmZDl/U41U37McgFzfbsafVa1OdC54AMVE45pKD/oIopUY46qhydkqVKlaCKRODUkswpVwuZ350Ww2N7JPo+2svUL/ADY4vktzaMdS/oH3iiUj2F6AZtjx1L+j99buKxqliOQuPXwP8PbXBgyKEJMuUW2W4OPU2s2PEJ/6j67WHgPE0QoVkGJ1IUJu0Z0HxHyGPiVt670TrvxVqqIfZlUNY1K0fQjW6sVVkQtEfrJfzGrXOPFW9HH1Q3/aS/mNXnel/wDRmkugka0srUaXH7ST8RrcrQyV9SOf2sn4zXdJW0iPwvMYrXy74OR49gDeSP0MfhB6nN/8Yq/HSaAG5cD+6hGYY22lwLtGdX+HhIP8t7eIFefG8OWvwutkGsw/q3+i33V5l39VH9BfwiqsfKOpdgbjQSDyII2NZ5ZvDGf1F/CK7k/k/wCEfhlKtzWth0+HJ+bEB/mc3/AKqfHi59JqzKZtbyH6A+wn99cGH5Zr/pclUQlepevL1gz16pmYyJdlbuv7CP8AoK9eSqJZrUPxWMtzoSE2FPfFSl/9IV5ToVnP8Fm3jTJluY6opN+BT7b1y3B4k99O/Qp+sSYdwiP+pqxz/Rlw+yCuYYsmNx3i1Fs5fQwZAArDgNgGHEW5cj66D4/DWjY25Vv4WYTKYza7eaTyYcPbuvrrix494So1lKpI9yfNOqxCMTZJLRv6z8E1/BiR/iPdT0GrnUuCuCDzBH+/GmfI8xZ4l1n4RbrJ9JefrGlv8Vbelna0ZORVyH9Ve3rUSYVar11vozESTGm59J++mXoS+rDA/tJPzDSxLhTqPpP30y9CRpwwH7SX8w1wem+7NZ9B2hHRJ7wsf2sv5hoqGoT0TFoGH7WX8w12P7oz/Ani4g6Mp5j7eX20iTYllYq2xUkEeI2NPxalfpXgPhBKo87ZvSOHtH3Vz+qx2tvBWOXNGrl+YfzKeLnEOzvuY33X1KSV9Q76Z8qb+bxH9kn4BSHNg9ibb6WF9+B3IPeNhTxkz/zeL6qP8IowT3T/AIOSoTjjjTB0Mm1LKT/3ij2Rqf30vz4MqzC3BiPYaK9GX6tZQfng/wChR+6sfTL/AEKn9RmeWtTEYqh2NxCsLMAw7iARQDMMsjJDIlgy3IBa17kcL+HCu7Jk9tWzKK24DWMx/jQHH5j41o4vCpDv1anYncX3uoGx+kaC47G3508WT3FdETjrwF/0l41KW/fXjUrcgVI2IrpHkds74gH5kX4mrnzRN3U3+TDE9V75b9WEf62rmzr/ADZpB3JHTM1wq9TJ9E1z3A5haxvTBj86vG4vyrn2Gn4Vz+ji0maZfw7FlLpiIlkFrnZh3OPO9vH11hjYeqbWttLbMP1x5h9Y1L6dNJ3QvNmDPFudYLLv8tASQB3stx6QtFsRmwdSpPHnzB4gjxB3rOcHiy7LocflENQ5h41vYbF3I9IpJ9+WCsODC5A4KwNnS/gfsKnnW/lmYfCIL/KX7xXo2nGzB8MaGwq3PpqrJ5AkZX9pL+Y1AZc77R35n76wy3Mbpe/FpPxtXn+li92b5HURxjxO49Na2XOEVh+0l/GaDYXH3dd/lL99VYbMOyT+0l/NYV3NfNGV8DMcUKreVX7LcD9/Kl85h41U+YeNVKKkqYtqDc+EXS3oP3VThsVpiQX4Io/0ihWY5sdAe/nBgfBlFj7RY+s0NOYdld/kr9wrj9NjcZyTNZu0mOHVJJ2/nbn08/toTmjiFyBzVD+Ifuodlmb3DRjzt3XfjYdpfE2Fx6D30PznMOs3vuFNvEhht/lZz6qhQcM//B3cDYxWY+NMmSosmHiY81P42rl2Ix/jTdk2b6MPCL/IJ/8AMcfurb1nMOCca5LvKGgjhDDx/Elc2xGKpr6d5prhAv8A71Kf3Vz6aan6TiAsn2N7r6lDOtqV02Z0PoyMkWKgcaxy/LpIRKqoTr0DUSqr2STxZhfjThg5YplAYXavZstF9hdTyrXJBTjqcePI4O+xOnwspUiyb/tYR9uqgGMwrRHjte3FdQ9IViPWCR4mnXGdHg29yPC1L2Nyd1JtY+q1Z48Ch0zeXqNu0DMNimRlZSQykMD3EG4+6mWZWlPWRBdDgMB1iAqT5yEMQdm1DhwsedLU2GYcRaiWRQEsL8KWTCp9lQzacoILBIoIKjSSG7MkRIbgTYPcgra9gT2RYcatwrMrqQNVmU7Mo2vfixAHrIqrO8KVJKjhQVJmN/DjTji1jrYnl2d0HZcJMSToFiSf6yL/AN9X4ASKmhhYjUb6kZSCxOzKx334Gx7r0DjxVhvvVnvm522FRDAoO0ypZnJU0H4cWQy2BYhgbAqOBvxYgD1mph3cDSylTqkYHUjK2p2fYox3APA28L0EBPGvesNae23LYlZFVBZ8Ua15MWaHviSDsarnxRbjVaiUwrDiOsV4yyjUCVLGw1qCV7XK41L6xWjiJyPYPurUjlHOscaxYWFCxpPYfufhhJjyCCCQQQQRxBG4IPfeiMONTEkFerWUG/VMbJIbEHqye8Egpe+509wXcThyASWtahTvWOSCl2awn4Dua4GWM7xugJ7IdWBty306WHiD3eovgDIYYlEb9hCCbbecz3vwtY0nwZlPGNMcsqL81JHUewG3OqMTipZPPkke/wA5mb7zWcsbmqbNIySGjOMyhQWZhK/zF3XxDvwHAeb2r2tzsptJcnaw7u7wqspUFVCCgqQm7Mr1Klq8qyTo8KSRm6saPZdmclwGpRi6WJp83f0D+Nb2X52nFhcfq22rdM4HGS7R0/BokqDgTQ/MspG9hSFjekxXeNiBfb53rFMHRvpp1xVJAAOBY2Bv6KnlF8Ncoxmyxb7r9la0mXhSCo9VHel2cYbCBTK12fdVQAsRzaxI23oFj8+iCFg2k2JAkVlvttbbf21SlZEoNM3cREHXzQDQHG4JY7nalvBdJpyxZpDvvay2HoBFEcvilzCXTqBUcVvoLf4lUkcaE7KcHHs1ZJk1abi/detmGMUWz3JsMI/ey4OVJ0GoNE6yN3Xa7Albkcu6gGClZBomBDA2FxYnuup3vQgfXAXw+9YSIe6jAw/VYeSRU1sALBe0bk2FvXWWXYRp49TRyRMNirqB61ty9Nq0dIhNiy6G+wqLhjY3Bpm/RGm/M1rYnClRSVFbMWMShU7mqxiQAb0Znj24C9B8Xhrm9DCLvsG4zFF9t6rw+DLcqJ4fAAnhRCyJtbes9bfJq8lKkai5UgW54gbiheJw4XhYg/ZTHMpkQ6eyefjQ/wDRMrbBSfAXvVSj4RnCbT5YvOlYLHRvF5RIhsVIPca8iwJA32rPR2b+6qA/UmpRrqBUo1F7ovMRyvbx/wClbuFxZiB0gm/Hu9Nq1rCrsLJoNwP3VKfJpJWjxJXkbiBfvvVzyOjCzbjfsk/bVTyktqPE16QeVFioIZzjjiCjEvqUEEu5YW5Bb7gcedVS4x3XQXYr825IqhFPOvY0A507ZNJHhNhsKc/JkjtNaOQxvsb6Qw9DC47NJ5ba9O/koh1YnhwAI7Jax79vN+l/GqRMuR4jw+K19Ypwcr+aT21JI23sxF9u6ubdM8O/vtmkRFJIJCEsosSSA1uO3Cn1ssijnjkVQHZ42JBW+ppRqJA3sRTBlWHSQ4gOqv8ADNxCt8hPDxouiUrZzBs5SKIjDyMSzs7RyqhFjYgW1EGxF+R3ojD0wQW0qbEdpZb6lPgwOkg78qkWRh5gHWNkMiKdUaXOp1TiEFuPImivS7oNho4GkgR1kFtKIx0kk2tp41TdMmMW1fgxynpHDiJViCFXbVa7JbsqWPEg8AarzDMMOSyF9DLsQ23sPCkrBYCTDzLLLBLYBgRoZTZkK+dpNrar8Krz/FRySu0YZQx4NYNe2+3Pe+9NEtWMUkcbX0urehgaGY1oo/PkVfC4v7KG4N0OGkQyRhxqYB7BiQBp0k2F+VhvStKdyfGlOdGkMds6HlaRyJrjYEc+8ekcqqxMYJ2pNyyQhl7RA1Lq7iLi9+8eFHc+xTr1ZjkjGtLuI2UhWDMOW6kqFNj3mkpcClDmkGImRfPIUeJApgyCfSOsjCyA3F+PDlSZ0VwfXSB3j98LF23UyMCw3G7FT2b8RtTH0dzJMLiGeOMx4WezIjEFVYXv1RUWsb8Kq2ZuC8huPKmxLF5DZm5AcO70Vuv0XgVNJDMbcbj+FZv0igUagwqqHpTCzAXqW5AopIGfyUX5h9v/AEqUyfpiL5w+yvKLfgdR8nz2KzFeaedqnCsjsLETetpIq1Vc1kH2qkS0zdk0aFXTZwWJa/nA2sPVv7aZuiWTtIuoRxWN92LXO/cAaTlY22p1w+OZo1EUqg2QMGIXbTZvO8bVpDk58iaROmWTrFJF2EXUrXCk6SF3uQQN962PJxI0eIZkjMgFgQpsQO8C4B9e1a/lIxQZodLq1kbgQefePRW95IjeeQ7cN+1a3q+V6KLEk6Q2ticKWUFpwyMH6sMz7g380MwAvyFq3slzmENKGk0M8hZQ40m2hQL7WG4NJuWYNRjQxA06kK9oHcyJwUHbieNOk+OMEc76Ndpd1LBdurUk3AI5UmuCoN3YDg6PzrIsqyxSfCKxUGwAEquSDa52XhembpViBHBrNyFdG2072YbC5rm75xM+NYvCCgI1RWQr1ZNyvcWCnj30yZrluEfAPiUwwiJF+StYNpvZTblw41L7RSfDSBOS9JI4AySSz63RtPWXcBjpK6AjNYedubGhUGapLhputeGWWyFDJGo3YsCB2ATtpud+NKsGYxFtL9bHxKlWL22PEEeFXROJ9bvM4ZF+Wga6DhbTb2VVkuNLk3c7wsYhEnVxh2ZVPVMyqLqTtYnwpSkjsTej0GFWSNpNcRC+dqBUjuPPvqsZSxTrAgKX88Olt+AsxB5fbSkrKhLXsYPJxksOJhk6yNSVcWO97EcLg1k/RcPiGjA0qrlNQL9xYW1EjgKIeSp/e7SiRHsdNtKF7bcToBNvRtR98GjYl51eMszXBPWIwSwBWzWB3F+FNeGRN/qYvdHMm974ySLrZFtGW1JYXUKWIsBY+utLpxiFGER4pusjjcKF6pYymvxAFxse+j+JcrmcTsADIjAm4t5pAsTtzoN0zyuSLL5usVhcxMCwXlI1wNDMD/WXpvoUeWjn75lI3yiPAVuYbHG254c770CFZ3rJTZ1vHFqg/wDpo95qUCvUp7sn2Ym1blt7RUCdzLt+sBwosmdYm2xW1+USAfYKrlzOZtmaw/wiikG0gQzm/D99EsuwrSkDgDxJU2Hde29VS4lzsGPt/hVuW4po2BJZh3BmXjw33+6hJWEm64CQ6OtzlQDv0ufTtV38nZJEMkTo69xVkbYWOzW51Q+dE8CU8C5a/wB3+zWWKzDEHdC9vQbc/wD2mtHqYLd9gsRSXtpZbcQVI37uFb2X5hLh45YwGV3IBNrFQDfmLg3FZx5jKAdUsa8di4vsRba/ifYatnxaN52Ij4DgJCfEcLfbUqvJT2faK8H0hmjlSXUGZdOxAsQpBF/8op4xvTHCy4eWMOyPMxYWU2TVGq9ogd9+A4A1znFyxHgZCe8ItvtcGtcSoPn/AOVR+80WUojLgM1j60O8pu0Sq1wwCyaVVrm1iSQd+Atxp5yzGNLluIVzePrNEbmyqyHTqsT5wD665dgsTHYXT0k8SPAAHfvq/F4x2hkjgYqr21Jc2IBvtqFh37UWRVMuyHMIsNiZWILqEZQQD2zqZRa/KwO/pqpcJHoYqdQ0GxudioBIIt3f7NL2LxwLgoukBVUi97kXuftrcyh5S3zVcGxIFjbY2uRfiaUZKzScXXZtLCoRrk7kAW3vY7/feq5Lqhj3069W452sPsptwvR/rI7gtcjiQLX9X8ayXonI4KlhqA2OkhbcgeO9VSMVM2fJFjwkzqzf/rVRx5E/dtxq3M8zxMmLjcyITHrAsthZSSQV3vqAP2UqZtkuKwhDsAFvbUjlb1sYNMREVfQd7kE3PHjuaIhJ8cMb87xMUzYLEBI0V9etVOoW4bmw7xyoTnaySriYdYZFR9K32uoLKbcPk8N6EmeZQqmM6VJKje1mBBHDx+6tnAYvEai6xdYflaTvuLG9x4mq/Cf2znhWxrO1H8flZVyXikQXvuDsDQeRRvblWDjR2RmmU3qVZb0VKRYwYrDSMl78NiN6Fy4Q03hCBpCi3E7cz41rvl9+VW6ZlG0KwwVvZV8Mek3tcg8OXC29H/0ae6rFyongCfVSSG2AxLLbY22A22NlBA39BPtNUyYdm84k+kk/fTrguissnCMjxYED2mmHLvJ8NjLIB4JufaRVcCT8HKRgvCrI8udvNRm+ipP3V27CdDMJHv1ev6dmH+W1qJQ5VHHskagdwAC/5Rt9lK0hfI4bhejs8nCJvWLffvR/A+T2Rhd3A24AMTew7wPGusxwhdlAA7gLD2CsxHRsFSOSN0Pk7KrHIQCd2VU5j9Y91bsXQeRUd3YR2BO7XuACeCjaun9XVWIwqupRr2YWNtqNhaM4lk/RFNR6wlwACAuwO+4a4uR6LU79HOjqogaM2GohlfW1gLf1ZDjTe5Jvfet+HAKsckgG4YKO4gne/qpkwOHVUAA47n0kb0dGaUpPlg3D4EJ8pj6Tt9tz9tXCHxolorwoO4eylZXtg44c+BHj/CrRh/8Adq2+rFQpRYaI1TB6PZVL4QfNHsre0DnWQS1FhoCZcGDsyg+kUFzDolBKblLHwC2+6/204aa8KC/CixaeBC/kND3D2H+NSn7qhUp2Gj8iXHkhY7Lf1UQw3RVm86yjx/hTsIwo2Fq403lUx+iWVcJCYonCM/wlgzEhR53E25cNqWxtodBw/RaJfOJb7BRLD5XGnmxqPVv7TXKW8rWPWFZzhIeqZiiv8JYuouV87jaiXTXyi47L8U2HfD4dh5yMC/bjYkK1g+x2IIPMHlY0rZWqOnLD4VYErnvTbpfmOXQwTPBhnWRQHsZPg5SC2jz+0NPyhtdW4bV7lPS7MZsufHrh8MyqWIjDOGaNLiR9Ra1wR5trkA25AodHQtNeFa4/gvKzjZVkePAI6xLqkKlyEXfdjyGx9ldF8n2etmGDTEuiozM40qSQNLFeJ9FAUGdFTTSv5RuljYERRQRrLip2AijYEra9izWIJ3NgLjmeVL+UdOse+JGAmwsMeLLOd9XVaFgaVBs7Ekso7QYix4XoCjoxWsSh5WPprlvRryj4/F4pMKmFwwcsQxJeyBfPY9vewBNhx5Vn0x8o+NwGLfDNh8O1rFGHWDWjbqba9jyI7wfTTCjoPvBurZNK7tfjw3B228K31S1I/TjpVmOXYeCd4cM2vsyqC/wchuwUHX2hp2uOankRVvRLpHmWOwcmJTD4ZSP6hCW+FKkhwSZBo3FgTz8N6LJUEh00ViYzSB5PPKHLj8TJhpY4opNDGMrqKl1NmVgW3232IvY78KnRzphmOIzBsE+HwyGMt1zAuwRV5gaxq1EqBbhquRsaQ6H8JXjL4VyvNvKPmEGLbBthcOZRII1AZ7MXICEHXYBtSnci197Uc8oHSnMMtVJGhw0kbaVLguCspUsyaddyOyxB7hv4sNRyfxFqsRfH20lZr0ym/RUWY4eGN1O06OXHVnUIyUsRcB9vQQe+trIulUgy18wxqRRx2vEkWoswuVAOpiNTNYActyfAsWo2lKrLW5VyuHyjZrLFJiYcFEcLGTqYrISqjjdhINRA4kLYc66J0Ezpsfg0xLIELtJZVuQFWRlW5PE2Audt77CgNTf1+ipW/wBVXlAalr8K5D03yT3n0e6srpkaVJJL2vrdySCR3Cw9VdgpB8vfxU/1sX4qRYodC8hOO6OzRKA0gmd4xtfWgUgAngWBZb/rUL90Gf6Uj+oi/Mkp89z38WH66T7lpC90Gf6TT+7x/jkoAbvdCfF2H+uT8p6u6Bf2Zk+qxf4pKVvK102wmPwcUUDOXSRWYMhUWCMp39JFNPQH+zMn1WL/ABSUAAPc5IGONVgCpSIEHgQTICCPQa6V5P8AKPeeGMAvoWWYxkm942ctGb8+yRvXBug/Slcvw+NUB+tnjRImXTZGGsMzEm4sHuLA7jlX0J0KH8wwf92g7v8Aul7qAOYeU/OBh8/wcj+ZFHGT4K7uHPqBv6qdc/yW+bZfjUBNutikIuRpMErox5AXLC/6y+FJ3uiclY9TjFF0UGKS3EXJaMnw84X79I50d8i3S335h/e8pHXQKFHfJEAArekcD6jzoAQfJF8en04n7mrDy7/G3/hxePfyrQ6D51Fgc2aecsI1acHSCxu2oDYeNV+U/PIcfmAmgLFCka9oFTdeO3HnxoA6j7oj4uj+vT8D0R8hw/oeD6Uv5r0O90R8XR/Xp+B6I+Q74og+lL+a1AHBsrzV8HjRiIxdopWYA7XFyGU9wKlh666t5OsQs3SDHSLurxalv3MYyPsNc+iyQT4DG4hR24MShJAuTG+pWHqOlr+Bph9zof59N9QfxpQBq9Nv7Sj+84X/AJVPHujfi+L+9J+VLSP03P8A2lH95wv/ACqd/dHfF0X96T8qWgDmvRnOyMrzDBsRZljmjHO4liWQD0rpPhYnetvp3jj+isphDG3VSSOvInUFQn0dv21oeVnJ/emZTKF0pIetjHLS9728NYcW8K1OmUhMeAXkMElvXLLf7qAPoLybYQR5XhUsN4VYi3Eydtr99yxrd6KZOMHAYV2QSysgHJHkZ1X1BreqgH8sMNl2EwS4jrFEmHjKFY9SmyLcXB2IuNvGmTo5nMWNgWeEsY31BSw0nssVO3pFABOpUqUASkDy9/FL/WRfip/pB8vfxU/1sX4qAKPc9/Fh+uk+5aQ/dB/Gkf1EX5klPfufPiw/XSfctIfugvjRPqI/zJKAGHy6ZTBBgIHihjjYyoCyIqkjq2NiQO8US6Bf2Yf6nF/ikqr3Qnxdh/rk/KerugX9mZPqsX+KSgBN8jWTpjYMxgYLd4olRmF9LXkKsO6zBT6q7b0ZgeLCYeORdLpDEjLcGzLGoYXGxsQdxtXJPc5SBDjmY2VUiZieAAMhJPqBro/k3zQ4vCtiN7STzlQSTZOsIQb9ygUAF87y+LExSYeUBkkWzLfex4EdxBFwe8V875IkmUZzGsnGOUIx4B4pOxqHgUfV6fEV1/Ps797Z5hY2ICYjDtEbmwD9YWQ78TcFR9OkXy4YYvnGERB2nihAAG5JnkAP++6gAR5MsHHLnbRyIjrqxF1dQym2q3ZIrDy0YOOHNNEaJGnVxHSihVub3NhtWz5I/j4/SxP3NWHl3+N//Ci/fQA/e6I+Lo/r0/A9EfId8UQfSl/NahvuiD/R0f16fgeiXkOP9EQfSl/NagBc8heFSaHMY5BqSSQI4PAqyuCPYaGeRPL2w2b4uBuMcbpvzCyqAdu8WProx7n3hj/rl/8AXU6EH/tJmP0G/FHQAodN/wC0o/vOF/5VO/ujfi+L+8p+VLSR02/tKP7zhf8AlU7+6N+L4v7yn5UtAHnug8m63BpiVteB7N3lJCE29DlNvE1yfpnERHgG5Ngkt6pZb/eK7v5Zj/Q+K9EX50dcj6eYEnKcpnCkgRyRu3IEsGjB9NpPZQA4+VEhuj2Ebj/+MRzseqYX9l6ZPId8UQfSl/Nak7pnOH6MYNhY7wrsb7oHQ7991O3I04+Q74og+lL+a1ADvUqVKAJSh5R+i82ZRpCmIWGIHU69XrLsPN31CwG+3MnwpvrRx2D1srCxII1K19LgBgARvaxcnhQAueTnopLlkbxNiFmjZtajqyhRuDWOo3BAG3ePE0vdMPJnPmGJbESY1QTZUUQmyIL6VB178Sb8yTTtDlciElJAt/C42MjBLEeaNajjey257WJg5182QW1EnYXbtMdyF4kFLn9U8b3p0TbFbpj0JxWYwwQy4xFWJRq0wm8sgGnrG7e3Z+SOZPhb3AdC8XBl0mATGJpctaQxHUsb3MiAa/lEntcRc+BDI+DnuC0gJViUIFytwy77AFd1v4A78K25IJdd1caOrZQDx1m1nO3Kx9tA7OXYHyR4uFZFizHQsg0yBY2Add9ms+43PtroPQHIGy/CJhmcSFWc6gCoOpi3Ak241sdRiLEdavEceOxYkebzUoPUTXqYXEAgmUWsL22va/IqfC9rX34bUUKxY8o/QJ8znSVZ1i6uPSvZLEvrLXJBFhw4b0O6PdA8aMQuLxmLjlniQpBs0iqbEKzFlQnSXZgo4mxvTmcNiGuOsHZ0WLAEFgEJYdnkwf28rVcsE44yDzhzHm2sVvo4htwbbjbxooLELo55L8Rg8UmKTHIZFYlgYNnDecp7e2oEi44cqy6XeTCbMMS+JfGIpawVViJCqoAVQde/C9+8mnvGLOxGhur+CJPAqHIIAvbexIN/DxrF8FMXDdYOzcLtuLk78Pm6QRztfa9FDsXOmfQ/FZlBDDJi0Xq+07LCfhZLWDFddlAB4DmT4Vd0R6K4rAYSXCpi1bUD1LmGxhZr6mtqIcXNwDz8DRd8smbUXdCWQK3GxsZCAezy1rv+r41dNhpJIbM9iWe+o2vGVZUDWHGxUkd96KCxd8nvQubLHlPvlZUlF2UxlSHHmsG1HvIItzHdVHR7oNisNj2xrYxZGkLdanVFQ6t8kHWdNiFI+iBwJpqiwstmVnDAo6gektpv2d+yUF7jhzvWMeFnXbrRay6RttYbg9m7cL3uONuVyUKxCzbyXYifFNi2x6iVpA4Kw7KVI0BRr4LZR6t6O9PuhuIzNIkbFpGiWZlEROqWxXXcuCBYmy8rnjTMcPNoULILjVqJ31XIK7225j18614ocRqIMnm6QeADbLcg6TbcNvbmaVDsE9J+jOLxuBTCPi0DG3XydV/W6CCtl1WTcAm3EjkNq8y3oZ/RrZfiZFmQArHIsehk3LKbEkEqTsfUaNrhcSLfCg7G9+Z7dvkeMf8AlNYrg8SAPhQTtq4726u9hp2vok2/X8KdBZy9/JXmOgYX37GcIH1hSZLg79oRadN7k7a7b3rqHQzI1wGFTDK5dULkMwAJDMW3A22varBg5i8ZZ1ZU0k34lgpBYWX9Y0WpMESpUqUDJUqVKAJUqVKANLMoHcDQ+kjVzI3KkLw7mIPqrWGCmsfhjexA22vYWNr94Jt+tblRapTsVAb9HSANpcAs5e/E7w9UN7cQwDXrYXDS2QdZ5rlm47oWuF9S7URqUWFAWPLplJtJZdbNpF7dqRnP2ED2moMumNtUmqzKwuTsQADvbmbnwo1UosWqAj5bMVKtLqBG4JO/Aj2EH035W32JcNIzErIygt5p5ALbbjtqF/XROpRY9QTh8HMCNUt7abjex7TlrjxVkHH5PpFWZhgOsEabBF1XH+AooG3DtH7KJVKLCkA/0ZPYDryOxp2J87jq9Fza3cBvtV2Ly92bUr2soQE31W1AsdV9mtqAItxotUosNUBmwE+1pjYC5vc3bVc8/NtsB6Kuy7Aujs7PqLBR/lAF/bqP+I9+xOpRYaolSpUpDJUqVKAJUqVKAP/Z",
                PublishersId = 4,
                CategoryId = 1,
                AutorId = 7,
                SelledCopies = 600_000
            };
            return books.ToArray();
        }

    }
}
