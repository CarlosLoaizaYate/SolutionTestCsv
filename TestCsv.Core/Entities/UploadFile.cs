using System.ComponentModel.DataAnnotations;

namespace TestCsv.Core.Entities
{
    public class UploadFile
    {
        [Key]
        public int Id { get; set; }

        public string UploadFileName { get; set; }

        public DateTime InsertDate { get; set; }

        public virtual ICollection<ColumnNameFile> ColumnsNameFile { get; set; }

    }
}
