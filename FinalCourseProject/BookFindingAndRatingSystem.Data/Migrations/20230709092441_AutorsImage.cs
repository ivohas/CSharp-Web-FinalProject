using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AutorsImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("013dcdef-f7db-47b2-8567-19071d240abb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4a6f5f5f-ec2b-4854-a995-cba4a5d5d27d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("77ec2458-ee02-4bb6-97da-0ce7dd184147"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("95272621-ed1a-4988-a887-53aa90e5b39f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a3b58236-340a-4a4c-87e1-dbfce3deeb86"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("feb1602c-9abe-4248-afb0-28e4c31e87cc"));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTReVcWyO6IeOE_W2fMOZfLytey--b9ZjowDg&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1500w,f_auto,q_auto:best/streams/2013/November/131120/2D9748492-g-cvr-130826-jd-salinger-tease-9a.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSA1o23Uj2ZRQPJye6056UwvfsgxCcoU2fWwQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBYVFRgVFhYZGBgYGBoYGBgZGBkaGRkaGBgZGhoYGRgcIS4lHB4rIRgYJjgmKy8xNjU1GiQ7QDs0Py40NTEBDAwMDw8QERERETEdGB0xMTQxNDE0MTE/MT80NDQxPzQxMTQ0MTExMTE/MTExMTExMTExMTExMTExMTExMTExMf/AABEIALcBEwMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAACAAEDBAUGBwj/xAA6EAACAgAEBAQEBQIFBAMAAAABAgARAxIhMQQFQVEGImFxEzKBkUJSobHwwdEHI2Lh8RQzcoIVQ5L/xAAWAQEBAQAAAAAAAAAAAAAAAAAAAQL/xAAWEQEBAQAAAAAAAAAAAAAAAAAAEQH/2gAMAwEAAhEDEQA/APNC8YvIS8dWgJxciySysMJAqqsmXDMlCCLOIAMkrsJYd5CxgFhtUmzSoWizwLLPI2MizRAwCzQWaIQ1wWOw39oEdR8s63k/gXHxWBZkVevmDE6A6AejDf2m3zLwEFTNhIzkMfLmGYjYb+xP1r2lHnASOyaTusL/AA/x3Ga0TbRib16ULIPpJ0/w34mwfiYYIN2C9itQR5d4o85qGpnc868E8Sq5siO174K5S3Ul10Wx/pUb6zkH4R0YqylSOjCj9QZRXIgGWmSV3EAbigkxZoCKyREuBLOCP5/tAcYcZ1lhmFaSBjZgMiXLC8NcbBUdZbZxWkmiqeFEjfhpcR5OtHpAx/gSfDSpZdakDPAPOIpBmiiCncbNHIiKyghiSVMeVSI6wLZxZCzwYxgOWgloxMAwCJjiBHUQJISISQACSdgBZPoAJPwPL3xWKICWrQDUk/lrfoZ6b4U5V/02Bmx8MZ7sBtShF+Y9ATr9NJBR8N+A1ZM/EggkA5AxsfNeo66rp3X1nXcs5RwuAuREA9GJayNiQ259d9vSVmxsfG/7a0v5nG/qPvLXD8jNEO5br7doVcPFomlDXsB/Su0H/wCSQevtrvCTlaD1hpwShvlgRpx12K9VPf3lvC45SOoNa37yZeHTaoJ4Rei/0EKZ0zg1Wu99qnLeKfDPxVseVxs2hB/8jOqwno1dSyz94R858ZgPhuUdSrA6g39x3HrKjCe1+LfD2DxC+YZG/DiL0PZhsQZ5DzLl74DsjjVeo2IOoPpYhGawjIusnKxBJQkEkYx1aCxuAlaT4aXI8LCl1FqQJMOBiGG7yBngEorrJlepTOJAOJEFl8W5XYxKfWEElA5I8fLFJRUUxzAuPcoREVRw0RaAwiuDmiuAxjR4IMB6iEe5Jw+EXZUHUge19T6dYHoX+GXJwwbH3Y+VdBa0zBjZ2BoD6Geg4fJ0L538y/hXoSPxN39JD4S5QnCcMEGrE5nPUsf2E1MTGkUZobCpDisSNN5XfGodZG2KahVlcShqYx4gd5n4mKfvKmO7Af7wNb/5AXVyZOOFbzjnxiGrTuNRde0kw+KO1/Tr+v8AWSjo8bisxBHeW2x6S+k5ZOMJOvtfr6ibeBj5sPXcWDKhsbHBtCbRrF9j2nnHjDlrgagsyHyPqcyMdUY75l+YX0JnXYpayE/b+bfz1oc4f4uG7XTopXEqwCoBKuB1rv7wPMkwzJgkuOB3/wB5WxGEqKuKKgI1R8RpCxgXcPFhPjTPzmOMSBaZ5G7yE4kYmA5eLPI2jXAnRpOrymDHLwLfxY0qZooCMa41xEwHuLNBigPFGigIxo56RjAcTo/ByMcdQFAzELnbNoL82Wjqa9CBoe055L6C+u1zf8DqW47Bo1RYmzQrKRVddSNIHug8qCVVe9Kg8Xj0APp/tFhqaLbE9ZGhsKFk/wA95X4hhRo3X6SlxPFgGv1J6/WUuN4yldhqcv7f8zI1ESrY6Vpr7fpKnF8QNs9fT+tyrxXMaIB0BUv7nT+8wOI5gDexO5J7+g7f2lwa7sos5rO21fpcoYrkLrXp6fWDw/MEArS9q0/tpA4vGR1yggMNavf7dOkgrYPHtoT1Pf1m5wXNAyab6WPUCv1qcg+NmI3AFgCpB/1ZUnWvrp7TSO5Rviarr37WDsw6GQcWhQO63Ywn8u+YZSQNN+unvMPlfNqay36HUepXep1zhXRHsMCSDfQEa760e0DynGxSf9Iv8oGn6SozS5xPD5WIu6JF1V0ZVfSVEJjFY5aBngJlkRkjOK2+t/0kcBwZIsjAh3ATyMmOzRoCiMaEogNcULLFACPGEeAooxiMBVHqICGBAAiNUkqNUAQJu+CsEtxuBVAB8xvalUsR9amLUtcr4s4WMmIpoo4PuNiPsTA9f4riszhddG/qB/eafEcQVTcKBdkmvp/PSc/g45fFVyjIHAYI6lWUXfymF4xdkRMv42oemlmr66TMVm8y5vQO313/AH/4mZwPNWxHyLqzhqFittB/O0x+YcDxBa2TIOpJF/Uj+0k8PcI7cQmzDOu17Ajv0rSINrxRxGTKAbZAAf8AUMtH3nKHjRuyFvZqr956P434FBhClUE9a1FTzbB4O6DXvqBV/rLhq4nMEFZVb2OUEHTUMN/qIsPiCWBButQDofUeshx+XJqS1egr+XI04VrFXvpf81hG5gKGJJrTftsaHvKXMsMakH2lzDOVAH+wGUfvK3GIGWh0gZL4zL5NtdTtY6a9p6H4P4hzggulhSd6axXzKoGbvtPPMTE12Gm9DtHTj3DAhmFbUSIg7PxBh8IELoFQm/MjO1k30ZfLrOE4jEBOgoeps+8u864ly4bMaxEDEXubINgdyt/WZhEoEmRmWCmkjZIEcJRFljmA9QTHuCTAExgI9QwsBlkqCLLFcCTKIpF8SKBDEIoqgKKoQWGqwBAh1DVImWBHGJjtAMByZe5HxGXHwu3xUsdwXUG/SZ1xK5BDDcEEe41ED1LgeeviY5GIubKzLmqqGb0G4qdVxfCDEot8qm/TexQ+05PhijYispBVwzqR1zjNXvf2qdS+OUAF/wA6SKwOacHmYgIx7AkmvoNL+pHpNDk/JhhlWIGa+3y+g+w19JoJiBRmar6SLlnMPiO75hkSkX1ci2P2K/eBR8WYbMljYaV6d5xnDcNncrY+Xfrpf9513PuYrXzqL6d5yHF4mHhhcTDbzggsAbBBJzfuIFs8BibBvqR/BLHCcMqDMwzsdPbvpclw+Y2mmzAXr/P4ZkcZxhQ777QJuYYxJIFUO/8AfrMn4p83qdaH6Rn4sn2j8OLIuEVOaYJTK3Rt/p/P0lc4W1dRN3H4QYtBnCKoJs2fahMvinVBQObKMoNbtZur6DSBX45szgflUAfqf6yJRIwxjF5RKTAMHP8Az944MAGFQTCZTBKwBuIdoVQSsCbieGyV50e7+Ri1VXzWBW/6QFaRkRXAlZ4LPI7jGAVxQYoD3HBjRwIBrJQJGslgFmjFpGWiLQGeRmEWjEwAIhBY4hgQNfw1zQYLqr/9suCf9DX849O47T1TjFzEAdCCfv8A8TxnhiA6kiwGUkdwCCR9p7GvHJisXwyGQ3RB9Lk1WR4g5iUU/pUwORYOK6M6vlBbNXRumo+kn8XgjTvQB9TL/L3TCwguYChV3p2gclzVnzMpvyn95ncJgktqfL1m/wASuEc7FyS22m5lBMRF2P0OkqD4biMpKXoNvbtDx2BFNKeMw+Yb7iXsEbE7EXr7SaKpUDS70h4TaaQnWzemkgZq0gavLOJS6bQjUHfvoftH8W8hOHg4XEJqji2r8LP5hYA0Gm5MzuAw8z5iuYAgEa121+plfmnNcXEZldzlusl+QEaAgdNO0DNX1jFJIFjkSiCoaR67xAQJ8twDhwkeFmgRhIZwozHWJngQYiSIrJ2a5EYEUcQ3Xp1EECA1xR6igSBYqhXGJgMDCVuunsesjuPcAjAaFcBoDGOI0NVgOgj3HZdKjBYBpOl8Gcy+HjfDY0uIRXo67fcWPcLOaWMzdjR3BG4I2I9YHoPivh71N+XWv5tA4HwymKi53cMwseba/Tb1k6Y54vAwmHzOAH9GUkOfuDNx8EkZV2Ar9O8iuL4zwjhoSF4jQb2ddb/tKmLyTAQfOzH3ofzadFxfIXF+cCzda11mTj8ne9WFQM08rSsy5q9TJnOVF9v5ctMuTQnSZ/G4go0d+nrAQff+XM5fM1ev/MlbGofSBwykC+p0AHXuP2H1lRucmwvLiMOisQKJ1HmoetA/acs5GYn1ne4uAOHw8JD85dnfXslOv0zBdJxXNeBODiMh+U+ZD+ZG1U/uPcGQRB4maQBoVygrjFo1xrgEpkmaRJJQukCN2gs0JpGYCLRgY1xCAUVx1NaiOFgBFDqKAjGuHkuJkr+fvAiYmJR/eShYJEBozG49xoDASbDkSiFmgSgCOBIQ8NHgEwkZMdmkTQOm8Lc4+GGwidznQ9mqmX6gAj1B7idty3mqsl38ujD+s4bwJyr/AKjilZheHg/52IdxSaqp72wXTsDOgOGHQcRhjyOzK6j8LKxBquhqwe0i4m5lz8Xob129pkcRzo6aVp6frKPHYRDkX16/1lDEB6+0C5xXMiw2qpl3ZjsYEqHJ1nReHOFpxjMNFP8Alr3bo1dgSD6nL3mLwHDhiGYWvb8+tVp0uh67DU6bPGcUUQgHVhXTQG7I+maum52yyaD4/jfiY1gkhPKpvSgbL+xY0D1AH0ucZy//AKrByDKMRAWwyTV9ShJ6EV7EA95h8KKsEdACvUA2O3Zvu34pu8t4og3Qs6V2oG+5Ozmuml1A4fFwWRijqVZTTKwog9iIFT0nm3KMLijbvkxAMqso+ZQAfMjasASdRt9ZynNfC3EYNsF+Kg/Hh2a/8l+Zf1HrAw4xhIYiJQyyW4BERMBnMiMJjAMBoSiMFhAQCEe4EJdf7wGzRQqigOcQwQYJMEiBIHjFoEcQHijRQHMEwhLHB8DiYzhMJGdj+FRf1PYepgVjHUzvOVf4bYjU3E4i4S7lEp3+rfKvTvOw5XyXhuHNYGEubQDEbzue5LEeUe0lHnHKfBfF49MU+Eh/HiWpr/SnzH7D3nYcB4C4XBGbHZsZhqVPkQf+q6m/UmdO/EVr8zHp19D3nLeNObnCwigJzvu2aruwQNbNC97AuKqzyXmSY/EY/C8OqphrwzhMi5VzZ0BYihR1rXXQ7zB8M4r4Zx+ExBldMRjR9QLr7Aj3lz/CLBAxcViPM2ED+GwpcUK+YA/b36aPixOHxsZlw8VF4rDYfiWzYKnDIuzRVT6X9I0cd4n4f4bhr0dQw9L3/WYT4prczqeecs4niWQLgsWRVVgHTy7am2FC+8PB8H5Ncd1JAsopNAXVu9bXpp7DMdlHKAM4GUEk9v6nYSxhcvb8RFaE75aOx01o7Dq3TvOrXly3VUooVlrU6hcg3J3GH9XMr46UbHTMbzVqNHOfv+bE2X5U1ikZ1BLGx1u9Koa3W1A6kfKDlHmJMptiZn16dCBoQNydhttpQUC5Z4p6BoVWg0rWvKAvQ62q9LzHUiVuGwyNC3UXeovSxdnY0L0337ES4Kg0xBJ6EAaDYk7WNd+7DU1U1+GXKAMoOmU7BGG9WNa0G2lA9ZTwcM6Zl0BAG+tliTqaH4js3TtLuHVbLfQEktVdbOlAAUa2MKtcPjszMfJQOVSbB+ZL1HWyx/bpNLgeKKBde9USdchJ091P9picM5CAkAkqDZ31TDazWlWO2mu0u4TC6rrVKV0sYuxJ38vTpCrnH8j4fic2ZSr2QHQU12R5hs40G+uu4nKcy8G8Th2yAYyDW8P5gCL1Tf7XOsTHCspvQka9fnwmph9b97mlw/E0BWtbG+wOu+3kEI8gII0O/Y7itwR0MBjPWebckwOLBLAI9kDEUAEmzv0fp669JwPM/CXE4Nn4ZxE6Phgtp3KjzDQjpXrCMKPUGEhlC+HEqySRsagHkhphyNHkqtAf4UUL4seBQqGfao0IQAIjQogsAJJhYTOwVVLMxpVUEkk9ABvCweHZ2CIpZmICqNyTsBPXvCPhpOEUsQHxmAzvV5e6J2A6nQkj2kHO+H/8Onan4olBv8JCM5H+t9l9hZ9RO+4bh8HhkyYSDDXsF3PcknzH1JkmNxFaA3te3fqD9d6mJxvG2ct69etAblt6H/6H3Fyqu8RxWaxdCwb22OoOun3EDDIXU73pQ+a9Sx2v2126ypwwJJCnKcpoaNQPUVQA0XY1pt2toimtAbF2Nj3sV+ldJVEpyqXZbIuhrudTp3uzYA3nk/NeKfiuJILWuY2dgFUan00BP1nY+MecjCw8ikhidCD2Gh9rr6rOO5dw+TAbFOhchBdCl3Js6C9P5oTLrPBmOypjsjZS/wAPAw2DK2VmDviMBVWiJfXprJePTCwhSAKB1oBr8tkuwstqxvfrcHhsQcPgZnJGRDdnVsfiAjOLFaphjCS/VpxPMuaNisSToT+9nufzH7Qrb4fxPiYeMjtiuyK9shfEK5WFN5SddCxAAG3Sd1xjhzdkjUrRGtDVgdgQCLc6ICFXWeVcm5ccfEC7Lux9L1/eep8BweXCRaJVAiLYzWEUZRRPmIN0uw1Y7QYotkHQBQvqBlY/dEJ/93PYTned8VlJYtlAI0oWWUeQFdgw3CbINWsmb3OeJTAT4jsRqcgU27sRrkY/M35sQ6KNFnnGPivxOKLoXoFGiooBJoewJvc69YNW+GBc52018i2dAT5iCdSxNm7vQnWaS4QGoFKaYAHQCyFNBSK21oba1pJFwCnlGoAoDKRYG2YaaXQOarNAGhLZGWzVmg1k2B081irtasjWvmCgkkRYCiqHz6HQFq2rzMasXqbA8puWcpCNa+VhmGoGY0AKG11X2O4MxuN5oMJiuVnfRlLbBStaEGz+LU9RYoGUk5li4jjNYU7hVF1d1mIvoNLryiFdDw7gISCR5RdBTQ+GNSNO/wCvW5ZQG26E66ALs2McxsUOp67b6SrwrUVWjrQN9P8AsiyDuLvS+3aTuGIqiLGby2ACVcliV0Pz1W+ohUy4hXy6sdb1UnzNhDTetiCQOglzA4g2LDaWbuhr8Y2b9PX/AHzcRgHDa5gT2O2JqRa6k5Nt9DI8FzlFVag3ZQkMUAPlYDq5H96gdLh8QFNn09euDvl0HmI6fpJ04itAxG9VoTavWhIusi6+kxMDHCkUxNNYshbXOTupN6Ye/avWWHxvIBQGlX1ByKo1PUlzr6QLXMuTcPxJ/wAxBn2Dqcj1mIGo+YeZdDc5DmPgfGQF8FhipvWiPVX8rGjQvY9Np2i8UCLPl1smvmUuzeUjuE295E/GWKzkWug1XUIBfmFfM9fTeSo8p4jAdGKOrIw3VgQR9DIiJ6bxeTibRk+LR6HzrmJYOjfhOUL1AObXpOJ59yVuGZbzFHvIxAvTXK2WxmA7GjuPS0ZI0hBoDRgZUHmMeRZooEirHKRRQBCyQLFFA6vwNwQDYnEUCyDJhg7Bn0zEegNf+3pPRsTEXCw9b0FE76gDqTev1iimdXGHxnFsSaBtR3og0CACCK0YeYfm20kPBYVjXarN/lYAl6XrRG1H7RRSq0X/AAqoIG9aZiANy17nf3h8R/loXugEvTtvfe6v7xRQjy3m2MeK4ogHyg0LOwG9aDrcuc6xATh4WGAMoRLIsZmIBYg+p6RRQLHi4ZCmCCaQHcLbEs+ZiR1J1nMcOmZgD8ti/a4ooR6p4Z5AEpetmzp2IP64bfebPPeY4fDoztquGKCgG2slQt9AzKxPoiiKKFx41zjmmJxOIcTENsdABoqqLpVHQC5p+G+HpGxTYv8AywQSKBq6I1v5dxWmukUUqNpMI0KNbBdTagkqBY1UVmW16BiVsiHhYPmyAUFAIrpnqqqq26VplBG8eKRouM4TCxMMMwyCmplF6ggkAVZGo/L817lpl4OGFUsFAOVqNKd0xa0rQ+vpFFDK/mFkHQq21ZfKuI12FtTph9tdJIcBgxUUdACSBX/1LrVEi7iiho/wiSQCdLJu9NMZqFPtt1jYVhlv8wWiWsFThAqCHoaKRdbGKKAeHiM48pa8h0zEaBAoN3rq56j21MscOlEOoJ3JsLooZzoSSfwDTTWKKAsTFKKAx1IIXcD5EQkhdj5227feE5ndMNbDPrmsaC2bNRPTKpOutHTWKKBqMy4CZVLAL1s2WUWffQem46jWnxrpjLkcWpAvSiOxHt33iimUcDzTgzg4jYZN1RDd1OoNdNOkpiKKbQ9RRRQP/9k=");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_wEikOnTJqLDZfeoDsBoBl4W-B5XltD2adg&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://media.newyorker.com/photos/59097447ebe912338a3777b2/master/w_2560%2Cc_limit/Rothman-Harper-Lee-A-Reading-List.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "data:image/jpeg;base64,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");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("06c113c6-0857-4063-bfa6-4542a011c417"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("31a1975d-a518-4512-9037-9280f3c3bb26"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" },
                    { new Guid("5ccafe24-66a0-468d-8c59-0f6c0962d770"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("6e4d741f-b78e-4a6b-b9a3-9372261412b5"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("c068f961-c879-4fce-b280-2df1a1b6f3a4"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("f9503fa2-6cba-4234-81dd-e5ed6ca7a8f6"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("06c113c6-0857-4063-bfa6-4542a011c417"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("31a1975d-a518-4512-9037-9280f3c3bb26"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5ccafe24-66a0-468d-8c59-0f6c0962d770"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6e4d741f-b78e-4a6b-b9a3-9372261412b5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c068f961-c879-4fce-b280-2df1a1b6f3a4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f9503fa2-6cba-4234-81dd-e5ed6ca7a8f6"));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/george-orwell.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/jd-salinger.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/f-scott-fitzgerald.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/jrr-tolkien.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/jk-rowling.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://example.com/harper-lee.jpg");

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://example.com/stephen-king.jpg");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("013dcdef-f7db-47b2-8567-19071d240abb"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("4a6f5f5f-ec2b-4854-a995-cba4a5d5d27d"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("77ec2458-ee02-4bb6-97da-0ce7dd184147"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("95272621-ed1a-4988-a887-53aa90e5b39f"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("a3b58236-340a-4a4c-87e1-dbfce3deeb86"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("feb1602c-9abe-4248-afb0-28e4c31e87cc"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" }
                });
        }
    }
}
