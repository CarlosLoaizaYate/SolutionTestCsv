using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestCsv.Core.Entities
{
    public class ColumnNameFile
    {
        [Key]
        public int Id { get; set; }

        public string ColumnName { get; set; }

        public int IdUploadFile { get; set; }

        [ForeignKey("IdUploadFile")]
        public virtual UploadFile UploadFile { get; set; }

        public virtual ICollection<ColumnValueFile> ColumnsValueFile { get; set; }

    }
}
