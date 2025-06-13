using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace CodeVault.API.Models
{
    [Table("Snippets")]
    public class SnippetDto : BaseModel
    {
     
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}