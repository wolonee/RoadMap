namespace Controllers_2.Controllers;


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class LibraryController : ControllerBase
{
    
    private static readonly List<Book> list = new List<Book>()
    {
        new Book (1, "Война и мир", "Толстой"),
        new Book (2, "Преступление и наказание", "Достоевский")
    };

    [HttpGet]
    public IActionResult getAllBooks()
    {
        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult getOneBook(int id)
    {
        var book = list.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPut("{id}")]
    public IActionResult updateBook(int id, [FromBody] Book updatedBook)
    {
        var book = list.FirstOrDefault(b => b.Id == id);
        
        if (book == null) return NotFound();

        var index = list.IndexOf(book);
        list[index] = updatedBook;

        return Ok(list[index]);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = list.FirstOrDefault(b => b.Id == id);
    
        if (book == null) 
            return NotFound();

        if (book.Author == "Unknown")
            return BadRequest("Нельзя удалять книги неизвестных авторов");

        list.Remove(book);
    
        return NoContent();
    }
}

public record Book(int Id, string Title, string Author);