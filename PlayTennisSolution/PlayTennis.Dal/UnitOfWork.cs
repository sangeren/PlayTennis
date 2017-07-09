using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Dal
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public PalyTennisDb MyDbContext;
        public static bool IsTransaction;
        public UnitOfWork()
        {
            if (MyDbContext == null)
            {
                MyDbContext = new PalyTennisDb();
            }
        }
        public void Dispose()
        {
            MyDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool EnableTransation { get { return IsTransaction; } set { IsTransaction = value; } }

        public int SavaChanges()
        {
            IsTransaction = false;
            return MyDbContext.SaveChanges();
        }
    }
}
