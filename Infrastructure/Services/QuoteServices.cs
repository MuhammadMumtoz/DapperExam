using Npgsql;
using Dapper;

public class QuoteService
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=DapperExam;User Id=postgres;Password=Muhammad.23;";
    public List<Quote> GetQuotes()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM quotes order by id asc";
            var result = connection.Query<Quote>(sql).ToList();
            return result;
        }
    }
    public List<Quote> GetQuotesByCategory(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM quotes where categoryid = {id}";
            var result = connection.Query<Quote>(sql).ToList();
            return result;
        }
    }
    public List<Quote> GetRandomQuote()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM quotes order by rand() Limit 1";
            var result = connection.Query<Quote>(sql).ToList();
            return result;
        }
    }

    public int InsertQuote(Quote quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into quotes (author,quotetext,categoryId) values ('{quote.Author}','{quote.QuoteText}',{quote.CategoryId})";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateQuote(Quote quote)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update quotes Set author = '{quote.Author}', quotetext = '{quote.QuoteText}', categoryid = {quote.CategoryId} where id = {quote.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int DeleteQuote(int id){
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from quotes where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}