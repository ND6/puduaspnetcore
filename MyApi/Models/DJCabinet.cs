using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("DJCabinetTable")]
    public class DJCabinet : MBase
    {
        public string cabinetNo { get; set; }

        public int boxCount { get; set; }

        public int columnCount { get; set; }

        public int rowCount { get; set; }
    }
}