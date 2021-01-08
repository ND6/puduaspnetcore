using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace MyApi.Models
{
    [Table("DJBoxTable")]
    [XmlRoot("DJbox")]
    public class DJBox : MBase
    {
        [Browsable(false)]
        public int cabinetId { get; set; }

        [Display(Name = "箱门号")]
        public int boxId { get; set; }

        public int rowNo { get; set; }

        public int columnNo { get; set; }

        [DefaultValue(false)]
        [Browsable(false)]
        public bool isBind { get; set; }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool isSnapBind { get; set; }

        [Browsable(false)]
        [DefaultValue(false)]
        public bool isLongBind { get; set; }

        [DefaultValue(false)]
        public bool isLocked { get; set; }

        [Browsable(false)]
        [DefaultValue(true)]
        public bool isFree { get; set; } //是否占用，并不是是否空箱

        [Browsable(false)]
        [Display(Name = "箱门类型")]
        [StringLength(50)]
        public string boxType { get; set; } // 大 中 小 三种箱子

        [Browsable(false)]
        [StringLength(50)]
        public string bindFeature { get; set; } //占用箱门的凭证特征码

        [Display(Name = "物品名称")]
        [Browsable(false)]
        public string bindObject { get; set; }

        [Browsable(false)]
        public int bindUserId { get; set; }
        [Browsable(false)]
        [StringLength(50)]
        public string bindUserName { get; set; }

        [Browsable(false)]
        public string bindObjectFormat { get; set; }

        [Browsable(false)]
        public string bindObjectProof { get; set; } //绑定物凭证，必须具有唯一性

        [Browsable(false)]
        public string remarks { get; set; }

        [Browsable(false)]
        [Display(Name = "数量")]
        public int count { get; set; }

        [Browsable(false)]
        public bool hasPhone { get; set; }

        /// <summary>
        /// 盘点到的rfid标签列表 逗号分隔 形如 "id1,id2,id3"
        /// </summary>
        public string rfidList { get; set; } 

        public string scanTime { get; set; }

    }
}