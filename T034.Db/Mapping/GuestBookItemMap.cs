using Db.Entity;
using FluentNHibernate.Mapping;

namespace Db.Mapping
{
    public class GuestBookItemMap : ClassMap<GuestBookItem>
    {
        public GuestBookItemMap()
        {
            Id(x => x.Id).Column("GuestBookItemId").GeneratedBy.Increment();

            Map(p => p.Author);
            Map(p => p.Contact);
            Map(p => p.Date);
            Map(p => p.Message);

            References(p => p.Parent).Column("ParentId")
                .Not.LazyLoad();
        }
    }
}
