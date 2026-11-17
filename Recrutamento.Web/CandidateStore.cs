using Microsoft.Data.Sqlite;

namespace Recrutamento.Web;

public sealed class CandidateStore(IWebHostEnvironment environment)
{
    private string DatabasePath => Path.Combine(environment.ContentRootPath, "App_Data", "candidatos.db");

    private SqliteConnection OpenConnection()
    {
        var connection = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = DatabasePath }.ToString());
        connection.Open();
        return connection;
    }

    public void Initialize()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(DatabasePath)!);
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS Candidates (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
                Email TEXT NOT NULL,
                Role TEXT NOT NULL,
                Experience TEXT NOT NULL
            )
            """;
        command.ExecuteNonQuery();
    }

    public void Add(CandidateInput candidate)
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = """
            INSERT INTO Candidates (Name, Email, Role, Experience)
            VALUES ($name, $email, $role, $experience)
            """;
        command.Parameters.AddWithValue("$name", candidate.Name.Trim());
        command.Parameters.AddWithValue("$email", candidate.Email.Trim());
        command.Parameters.AddWithValue("$role", candidate.Role.Trim());
        command.Parameters.AddWithValue("$experience", candidate.Experience.Trim());
        command.ExecuteNonQuery();
    }

    public List<CandidateInput> GetAll()
    {
        using var connection = OpenConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Name, Email, Role, Experience FROM Candidates ORDER BY Id DESC";
        using var reader = command.ExecuteReader();
        var candidates = new List<CandidateInput>();
        while (reader.Read())
        {
            candidates.Add(new CandidateInput
            {
                Name = reader.GetString(0),
                Email = reader.GetString(1),
                Role = reader.GetString(2),
                Experience = reader.GetString(3)
            });
        }
        return candidates;
    }
}
