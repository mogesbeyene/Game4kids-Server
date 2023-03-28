using System;
using System.Collections.Generic;
using System.Text;

namespace Games4Kids
{
    public abstract class BaseLogic : IDisposable
    {
        protected Games4KidsContext DB;

        public BaseLogic(Games4KidsContext db)
        {
            DB = db;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
