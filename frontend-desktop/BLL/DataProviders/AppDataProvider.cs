using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Repository;
using BLL.Services;
using DTO;

namespace BLL.DataProviders
{
    public class AppDataProvider
    {
        private static AppDataProvider instance;
        private static readonly object padlock = new object();
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

        private User user = null;
        public User User
        {
            get => user;
            set => user = value;
        }

        public Form MainForm { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public event EventHandler<Form> ShowModalRequested;

        private RelationshipDataProvider relationshipDataProvider;
        public event Action DataLoaded;

        private AppDataProvider()
        {
            user = new User
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imhpa" +
                "G9uNDU2QGdtYWlsLmNvbSIsImV4cCI6MTczMjQ0NzMzNiwiZnVsbG5hbWUiOiJIa" +
                "SBIb24iLCJpc0FjdGl2ZSI6dHJ1ZSwiaXNBZG1pbiI6dHJ1ZSwicGhvbmUiOiIwM" +
                "TIzMjExMjMzMiIsInVzZXJJRCI6ImFlMWE5NjkyLTFlMjEtNGEzYS1hNGZjLTA5MmJmO" +
                "TMzNDQyNCJ9.Bf1hFF7dsZS2wm8Q6w3hFoDjmUcIOn-0d6uCubJtpHM",
                //Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im10aHV3MTIzQGdtYWlsLmNvbSIsImV4cCI6MTczMjg2MDI0MSwiZnVsbG5hbWUiOiJNaW5oIFRodXciLCJpc0FjdGl2ZSI6dHJ1ZSwiaXNBZG1pbiI6dHJ1ZSwicGhvbmUiOiIwOTExMjExMjMzMiIsInVzZXJJRCI6IjZkNGYwNjQ0LWMzMGYtNGZjMy1hOGViLTg1ZmM1MWNlYWYzMCJ9.Rb2r9q4PYDEDQE_hsEZNViQ26W1A7rULz45PjRFdHyc",
                FullName = "Hi Hon",
                Username = "hihonnguyn123",
                //Username = "minhthu@@",
                Email = "hihon456@gmail.com",
                Password = "$2a$12$5uA6u046bYO1ogx6mBqd1OwDe1zLZZWZuK5lX75VGCrSUEbD1tZUG",
                PhoneNumber = "01232112332",
                Birthday = DateTime.Parse("2003-10-04T00:00:00Z"),
                Gender = "Male",
                Nation = "Viet Nam",
                Province = "Ho Chi Minh City",
                Avatar = "https://firebasestorage.googleapis.com/v0/b/multi-aura.appspot.com/o/Hihon%2F1728534046_9ea1c9841cadbef3e7bc.jpg?alt=media&token=3d221a08-d064-4ece-881a-32e2c5d273e1",
                IsAdmin = false,
                IsActive = true,
                IsPublic = true
            };
        }                

        public bool HasUser()
        {
            return user != null;
        }

        public void ShowModal(object sender, Form modal)
        {
            ShowModalRequested?.Invoke(sender, modal);
        }

        public async void Initialize()
        {
            relationshipDataProvider = RelationshipDataProvider.Instance;

            //Lấy thông tin từ AppSettings
            //string token = ConfigurationManager.AppSettings["UserToken"];
            //string username = ConfigurationManager.AppSettings["Username"];
            if (user == null || string.IsNullOrEmpty(user.Token) || string.IsNullOrEmpty(user.Username))
            {
                MessageBox.Show("User is not initialized. Please log in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user = null;
                return;
            }
            else {
                token = user.Token;
                username = user.Username;

            }


            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(username))
            {
                user.Token = token;
                user.Username = username;

                var (profileResult, errorMessage) = await relationshipDataProvider.GetAuthProfileAsync();
                if (string.IsNullOrEmpty(errorMessage))
                {
                    user = profileResult;
                    user.Token = token;
                    DataLoaded?.Invoke();
                }
                else
                {
                    user = null;
                    MessageBox.Show("Unable to load user data. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //TODO: logout
                }
            }
            else
            {
                user = null;
            }
        }
    }
}
