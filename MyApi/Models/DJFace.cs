using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Models
{
    [Table("DJFaceTable")]
    public class DJFace : MBase
    {

        public string fileName { get; set; }

        public string savePath { get; set; }

        // public Image FaceImage { get; set; }

        public byte[] faceBuff { get; set; }

        public string faceBase64 { get; set; }
    }
}