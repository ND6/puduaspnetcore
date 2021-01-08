using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("OpenBoxRecordTable")]
    public class OperatingRecord : MBase
    {
        public OperatingRecord()
        {
            dateTime = DateTime.Now;
        }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string workNo { get; set; } // 工号

        public string cardNo { get; set; } //卡号

        [StringLength(50)]
        public string department { get; set; }

        [StringLength(50)]
        public string materialName { get; set; }

        [StringLength(50)]
        public string materialNo { get; set; }

        [StringLength(50)]
        public string openTarget { get; set; } //开箱目的

        [DefaultValue(0)]
        public int count { get; set; }

        public int cabinetId { get; set; } //箱柜号

        [StringLength(50)]
        public string cabinetNo { get; set; } //箱柜号

        [DefaultValue(-1)]
        public int boxId { get; set; } //箱门号

        // [StringLength(50)]
        // public string bindObject { get; set; } //物品名

        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public DateTime dateTime { get; set; } //操作时间
    }
}