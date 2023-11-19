namespace Test2_Database_Library.Entities;

internal class BorrowedBookEntity
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public BookEntity Book { get; set; } = null!;
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public DateTime BorrowDate { get; set; } = DateTime.Now;
    public DateTime ReturnDate { get; set; } = DateTime.Now.AddMonths(1);
}
