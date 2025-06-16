using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeVault.Domain.Entities
{
    public class Snippet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Code { get; set; }
        public string Lenguage { get; set; }
    }
}