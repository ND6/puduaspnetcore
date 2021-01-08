using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("InventoryTable")]
    public class Inventory : MBase
    {
        public int cabinetId { get; set; }

        public int boxId { get; set; }

        public string rfidCode { get; set; }

        /// <summary>
        /// 时间戳 13位 String
        /// </summary>
        public string scanTime { get; set; }

        public int checkFlag { get; set; }
    }
}