namespace Examples
{
    public class UserRole
    {
        public virtual long UserId { get; set; }

        public virtual int Role { get; set; }

        public virtual User Users { get; set; }

        #region NHibernate Composite Key Requirements

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as UserRole;
            if (t == null) { return false; }
            if (UserId == t.UserId && Role == t.Role) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ UserId.GetHashCode();
            hash = (hash * 397) ^ Role.GetHashCode();
            return hash;
        }

        #endregion
    }
}