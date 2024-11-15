using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BLL
{
    public class AppDataProvider
    {
        private static AppDataProvider instance;
        private static readonly object padlock = new object();

        private User user = null;
        public Form MainForm { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        private AppDataProvider()
        {
            user = new User
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbC" +
                "I6Im10aHUwMTExQGdtYWlsLmNvbSIsImV4cCI6MTczMTI0NDc3Nyw" +
                "iZnVsbG5hbWUiOiJNaW5oIFRoxrAgMTIzIiwiaXNBY3RpdmUiOn" +
                "RydWUsImlzQWRtaW4iOmZhbHNlLCJwaG9uZSI6IjA5MTU3NDg3Nz" +
                "YiLCJ1c2VySUQiOiI1NDdmYTIyNS1iMDRkLTRiYmItODZlNC1mNWZkN" +
                "mY2Y2RhYzMifQ.R0DcvQQNpPyIGqJYYpZM2ZZ7EofF11gNpV15U1WUcgY",
                UserID = "547fa225-b04d-4bbb-86e4-f5fd6f6cdac3",
                FullName = "Minh Thư 123",
                Username = "minhthu123",
                Email = "mthu0111@gmail.com",
                Password = "$2a$12$5uA6u046bYO1ogx6mBqd1OwDe1zLZZWZuK5lX75VGCrSUEbD1tZUG",
                PhoneNumber = "0915748776",
                Birthday = DateTime.Parse("2003-10-04T00:00:00Z"),
                Gender = "Male",
                Nation = "US",
                Province = "TG",
                Avatar = "https://firebasestorage.googleapis.com/v0/b/multi-aura-8eb80.appspot.com/o/profile-photos%2F1729077318_2773d8b41134ee880c2f2ba46fe02303.jpg?alt=media&token=14759029-2076-4233-a726-4f903d843340",
                IsAdmin = false,
                IsActive = true,
                IsPublic = true
            };
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

        public bool HasUser()
        {
            return user != null;
        }
    }
}
