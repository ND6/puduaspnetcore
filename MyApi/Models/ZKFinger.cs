using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    [Table("ZKFingerTable")]
    public class ZKFinger
    {
        [Key]
        public int id { get; set; }

        public string fingerprint { get; set; }
    }
}