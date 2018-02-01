using Db.DataAccess;

namespace Db
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    //TODO ненужный класс вроде как
    public abstract class AbstractDbFactory
    {
        /// <summary>
        /// Создать базовый менеджер
        /// </summary>
        /// <returns></returns>
        public abstract IBaseDb CreateBaseDb();
    }
}
