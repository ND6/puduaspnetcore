using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("UserInfoTable")]
    public class UserInfoDbM : MBase
    {
        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        [Browsable(false)]
        public string workNo { get; set; } // 工号

        [StringLength(50)]
        [Browsable(false)]
        public string gender { get; set; } //性别

        [Browsable(false)]
        public string cardNo { get; set; } //卡号

        [StringLength(50)]
        [Browsable(false)]
        public string department { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        [Browsable(false)]
        public DateTime birthday { get; set; }

        [StringLength(50)]
        [Browsable(false)]
        public string address { get; set; }

        [StringLength(50)]
        public string position { get; set; } //身份

        [Browsable(false)]
        [StringLength(50)]
        public string isExclusive { get; set; } //有无专属箱门

        [StringLength(50)]
        public string phoneNo { get; set; } //电话号码,20181225 ltw添加

        [StringLength(50)]
        public string phoneRfidCode { get; set; }

        [Browsable(false)]
        [StringLength(50)]
        public string passWord { get; set; }

        // [Browsable(false)]
        [StringLength(50)]
        public string faceId { get; set; } //人脸id

        [Browsable(false)]
        public int fingerId { get; set; } //指纹id

        [Browsable(false)]
        public int boxId { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        [Browsable(false)]
        public DateTime createTime { get; set; }

        [Browsable(false)]
        public string boxIds { get; set; }

        [Browsable(false)]
        public string materialNames { get; set; }

        [Browsable(false)]
        public string counts { get; set; }

        [Browsable(false)]
        public byte[] faceBuff { get; set; }

        [Browsable(false)]
        public string faceBase64 { get; set; }

        public UserInfoDbM()
        {
            Init();
        }

        private void Init()
        {
            cardNo = "";

            userName = "";
            boxIds = "";
            counts = "";
            position = "有";
            passWord = "888888";
            faceId = "-1";
            fingerId = -1;
            boxId = -1;
            phoneNo = "";

            materialNames = "";
            department = "";

            birthday = new DateTime(2000, 1, 1);
            createTime = DateTime.Now;
        }
    }
}