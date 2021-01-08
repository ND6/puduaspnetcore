using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("MaterialInventoryTable")]
    public class MaterialInventory : MBase
    {
        [StringLength(50)]
        public string materialName { get; set; }

        [StringLength(50)]
        public string materialNo { get; set; }

        [DefaultValue(0)]
        public int count { get; set; }

        [StringLength(50)]
        public string operatorName { get; set; }

        [StringLength(50)]
        public string cardNo { get; set; }

        [Browsable(false)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        public DateTime createTime { get; set; } = DateTime.Now;

        [Browsable(false)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        [DefaultValue(typeof(DateTime), "1753-1-1 00:00:00")]
        public DateTime updateTime { get; set; }

        [Browsable(false)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        [DefaultValue(typeof(DateTime), "1753-1-1 00:00:00")]
        public DateTime exportDateTime { get; set; } // chu

        [Browsable(false)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        [DefaultValue(typeof(DateTime), "1753-1-1 00:00:00")]
        public DateTime importDateTime { get; set; } // ru

        [Browsable(false)]
        [StringLength(50)]
        public string internalFileNo { get; set; }

        [Browsable(false)]
        [StringLength(50)]
        public string assetNo { get; set; }

        [DefaultValue(0)]
        public int boxId { get; set; }

        [Browsable(false)]
        [DefaultValue(1)]
        public int cabinetId { get; set; }

        [Browsable(false)]
        public string remarks { get; set; }
    }
}