using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public static class DBConnection
    {
        private static ApplicationContext _context;

        public static ApplicationContext getConnection()
        {
            if (_context == null)
            {
                _context = new ApplicationContext();
            }
            return _context;
        }
    }
}
