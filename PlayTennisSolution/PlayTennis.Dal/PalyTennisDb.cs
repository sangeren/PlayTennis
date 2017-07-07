using System.Reflection;
using PlayTennis.Model;

namespace PlayTennis.Dal
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PalyTennisDb : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“PalyTennisDb”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“PlayTennis.Dal.PalyTennisDb”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“PalyTennisDb”
        //连接字符串。
        public PalyTennisDb()
            : base("name=PalyTennisDb")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<WxUserLogin> WxUserLogin { get; set; }
        public virtual DbSet<WxMessage> WxMessage { get; set; }
        public virtual DbSet<LogInformation> LogInformation { get; set; }
        public virtual DbSet<WxUser> WxUser { get; set; }
        public virtual DbSet<UserBaseInfo> UserBaseInfo { get; set; }
        public virtual DbSet<SportsEquipment> SportsEquipment { get; set; }
        public virtual DbSet<TennisCourt> TennisCourt { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }
        public virtual DbSet<ExercisePurpose> ExercisePurpose { get; set; }
        public virtual DbSet<LogHttpRequest> LogHttpRequest { get; set; }
        public virtual DbSet<PurposeCommunication> PurposeCommunication { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<UserImage> UserImage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //是否启用代理类
            //Configuration.ProxyCreationEnabled = false;

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            //注册实体配置信息
            var tys = Assembly.Load("PlayTennis.Dal")
                 .GetTypes()
                 .Where(p => p.GetInterfaces().Contains(typeof(IEntityMapper)))
                 .ToArray();
            foreach (var mapper in tys)
            {
                var map = Activator.CreateInstance(mapper) as IEntityMapper;
                map.RegistTo(modelBuilder.Configurations);
            }
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}