

using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
#if First
    #region snippet
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    #endregion
#else
    // Use this to test you can over-post
    public class TodoItem
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
#endif
}