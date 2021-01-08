using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("MaterialTable")]
    public class Material : MBase
    {
        [StringLength(50)]
        public string materialName { get; set; }

        [StringLength(50)]
        public string materialNo { get; set; }

        [StringLength(50)]
        public string itemNo { get; set; }

        [StringLength(50)]
        public string type { get; set; } //类型

        public int count { get; set; } //数量.

        public string rfidCode { get; set; }

        public string uhfId { get; set; }

        public string qrCode { get; set; }

        public string remark { get; set; }

        public int? boxId { get; set; }

        public int? cabinetId { get; set; }
    }
}