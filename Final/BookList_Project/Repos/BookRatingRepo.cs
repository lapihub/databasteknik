using BookList_Project.Contexts;
using BookList_Project.Entities;

namespace BookList_Project.Repos;

internal class BookRatingRepo : Repo<BookRatingEntity>
{
    private readonly DataContext _context;
    public BookRatingRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    //public override async Task<BookRatingEntity> CreateAsync(BookRatingEntity entity)
    //{
    //    try
    //    {
    //        _context.Set<BookRatingEntity>().Add(entity);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
    //    return null!;
    //}


    //public override async Task<IEnumerable<BookRatingEntity>> GetAllAsync()
    //{
    //    try
    //    {
    //        var books = await _context.BookRatings
    //        .ToListAsync();
    //        return books;
    //    }
    //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
    //    return Enumerable.Empty<BookRatingEntity>();
    //}

    //public override async Task<BookRatingEntity> GetAsync(Expression<Func<BookRatingEntity, bool>> expression)
    //{
    //    try
    //    {
    //        var book = await _context.BookRatings
    //            .Include(x => x.Book)
    //            .FirstOrDefaultAsync(expression);

    //        return book!;
    //    }
    //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
    //    return null!;
    //}
}
