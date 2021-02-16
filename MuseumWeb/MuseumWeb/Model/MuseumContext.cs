namespace MuseumWeb.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MuseumContext : DbContext
    {
        // Контекст настроен для использования строки подключения "Model" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "MuseumWeb.Model.Model" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model" 
        // в файле конфигурации приложения.
        public MuseumContext()
            : base("name=Model")
        {

        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}