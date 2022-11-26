using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class QuoteController
{
    private QuoteService _quoteService;
    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpGet("GetAll")]
    public List<Quote> GetQuotes()
    {
        return _quoteService.GetQuotes();
    }
    [HttpGet("GetByCategory")]
    public List<Quote> GetQuotesByCategory(int id)
    {
        return _quoteService.GetQuotesByCategory(id);
    }
    [HttpGet("GetRandom")]
    public List<Quote> GetRandomQuote()
    {
        return _quoteService.GetRandomQuote();
    }

    [HttpPost]
    public int InsertQuote(Quote quote)
    {
        return _quoteService.InsertQuote(quote);
    }
    [HttpPut]
    public int UpdateQuote(Quote quote)
    {
        return _quoteService.UpdateQuote(quote);
    }
    [HttpDelete]
    public int DeleteQuote(int id)
    {
        return _quoteService.DeleteQuote(id);
    }
}