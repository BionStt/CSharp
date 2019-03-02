using System;
using System.ComponentModel.DataAnnotations;

namespace Examples
{
    public class UserLog
    {
        public virtual long UserLogId { get; set; }

        public virtual User Users { get; set; }

        [Required]
        public virtual DateTime Datetime { get; set; }

        [Required]
        public virtual int LogType { get; set; }

        [StringLength(8000)]
        public virtual string Message { get; set; }
    }
}