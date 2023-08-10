using BookFindingAndRatingSystem.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;

[ApiController]
[Route("api/statistics")]
[Authorize(Roles = AdminRoleName)]
public class StatisticsController : ControllerBase
{
    private readonly BooksDbContext _dbContext;
    public StatisticsController(BooksDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    [HttpGet]
    public IActionResult StatisticsPage()
    {
        var statistics = new StatisticsViewModel
        {
            NumberOfBooks = _dbContext.Books.Count(),
            NumberOfAuthors = _dbContext.Autors.Count(),
            NumberOfUsers = _dbContext.Users.Count()
        };

        return RedirectToPage("/StatisticsPage",statistics);  // Assuming "StatisticsPage" is the name of the view
    }
}
