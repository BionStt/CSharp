using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examples
{
    public class User
    {
        public User()
        {
            UsersLogs = new List<UserLog>();
            UsersRoles = new List<UserRole>();
        }

        public virtual long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string Surname { get; set; }

        [Required]
        [StringLength(250)]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(300)]
        public virtual string Login { get; set; }

        [Required]
        [StringLength(500)]
        public virtual string Password { get; set; }

        [Required]
        public virtual int Status { get; set; }

        public virtual IList<UserLog> UsersLogs { get; set; }

        public virtual IList<UserRole> UsersRoles { get; set; }
    }
}