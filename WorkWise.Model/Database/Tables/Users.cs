using WorkWise.Model.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkWise.Model.Database.Tables
{
    public class Users : DbItem
    {
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? RegDate { get; set; }

    }
}