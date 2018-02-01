using System.Collections.Generic;

namespace Db.Dto.Common
{
    public abstract class AbstractDto<T> : IDto<T>
    {
        public T Id { get; set; }

        protected bool Equals(AbstractDto<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;

            var eobj = obj as AbstractDto<T>;
            return eobj != null && Equals(eobj);
        }
    }
}
