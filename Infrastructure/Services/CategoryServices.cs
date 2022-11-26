using Npgsql;
using Dapper;

public class CategoryService
{

    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=DapperExam;User Id=postgres;Password=Muhammad.23;";
    public List<Category> GetCategories()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM categories order by id asc";
            var result = connection.Query<Category>(sql).ToList();
            return result;
        }
    }

    public int InsertCategory(Category category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Insert into categories(name) values ('{category.Name}')";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int UpdateCategory(Category category)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"Update categories Set name = '{category.Name}' where id = {category.Id}";
            var result = connection.Execute(sql);
            return result;
        }
    }

    public int DeleteCategory(int id){
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"delete from categories where id = {id}";
            var result = connection.Execute(sql);
            return result;
        }
    }
}