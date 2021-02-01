using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting_DataLayer.Repository;
using Accounting_DataLayer.Context;

namespace Accounting_DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        AccountingEntities db = new AccountingEntities();

        private GenericRepository<Customers> _Customers;

        public GenericRepository<Customers> Customers
        {
            get
            {
                if (_Customers == null)
                {
                    _Customers = new GenericRepository<Customers>(db);
                }
                return _Customers;
            }
        }



        private GenericRepository<Accounting> _accountingRepository;

        public GenericRepository<Accounting> AccountingRepository
        {
            get
            {
                if (_accountingRepository == null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(db);
                }
                return _accountingRepository;
            }
        }


        private GenericRepository<Login> _LoginRepository;

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if(_LoginRepository == null)
                {
                    _LoginRepository = new GenericRepository<Login>(db);
                }
                return _LoginRepository;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
