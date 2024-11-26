using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL.Services;
using BLL.Repository;

namespace BLL.DataProviders
{
    public class AuthDataProvider
    {
        private static AuthDataProvider instance;
        private static readonly object padlock = new object();

        public static AuthDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthDataProvider();
                    }
                    return instance;
                }
            }
        }

        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private AuthRepository authRepository;
        private AuthService authService;

        private User currentUser = null;
        public User CurrentUser
        {
            get => currentUser;
        }

        public event Action UserLoggedIn;
        public event Action UserLoggedOut;

        private AuthDataProvider()
        {
            authRepository = AuthRepository.Instance;
            if (authRepository == null)
            {
                throw new Exception("AuthRepository is not initialized.");
            }

            authService = new AuthService(authRepository);
            if (authService == null)
            {
                throw new Exception("AuthService is not initialized.");
            }

            appDataProvider.DataLoaded += Initialize;
        }

        private void Initialize()
        {
            if (appDataProvider.User != null)
            {
                currentUser = appDataProvider.User; // Lấy thông tin người dùng đã lưu
                UserLoggedIn?.Invoke();
            }
        }

        public async Task LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            try
            {

                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var (user, errorMessage) = await authService.LoginAsync(loginRequest);
                MessageBox.Show(user.Token);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    currentUser = user;
                    appDataProvider.User = user;
                    UserLoggedIn?.Invoke();    

                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Login failed: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Logout()
        {
            currentUser = null;
            appDataProvider.User = null;
            UserLoggedOut?.Invoke(); // Kích hoạt event khi đăng xuất
            MessageBox.Show("Logged out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
