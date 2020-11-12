namespace Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class MesContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MesContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Mes.Model.MesContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MesContext”
        //连接字符串。
        public MesContext()
            : base("name=MesContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
    }
    public class Dept
    {
        //.net法则 约定大于配置，必须有ID，会自动作为主键，也可以使用注解标识主键
        //表一对多，多对多自行设置自行百度
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        
        public virtual Dept Dept { get; set; }
        
        public string Role { get; set; }

    }
}