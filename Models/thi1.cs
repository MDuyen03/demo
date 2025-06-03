
using System.ComponentModel.DataAnnotations;

namespace demothi.Models;

public class thi1
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
//dotnet aspnet-codegenerator controller -name thi1Controller -m thi1 -dc demothi.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
