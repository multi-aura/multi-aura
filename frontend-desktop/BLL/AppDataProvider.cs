using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AppDataProvider
    {
        private static AppDataProvider instance;
        private static readonly object padlock = new object();

        private bool hasUser;

        private AppDataProvider()
        {
            hasUser = false;
        }

        public static AppDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AppDataProvider();
                    }
                    return instance;
                }
            }
        }

        public bool HasUser
        {
            get => hasUser;
            set => hasUser = value;
        }
    }
}
