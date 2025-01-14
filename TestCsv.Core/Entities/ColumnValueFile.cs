using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestCsv.Core.Entities
{
    public class ColumnValueFile
    {
        [Key]
        public int Id { get; set; }

        public string ColumnValue { get; set; }

        public int IdColumnNameFile { get; set; }

        [ForeignKey("IdColumnNameFile")]

        public virtual ColumnNameFile ColumnNameFile { get; set; }
    }
}
