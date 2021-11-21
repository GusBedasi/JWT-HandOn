using Shop.Models;

namespace Shop.DTO
{
    public class UserResponseDTO
    {
        public UserResponseDTO(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Role = user.Role;
        }
        
        public string Username { get; }
        
        private string _password { get; set; }
        public string Password
        {
            get => _password;
            set => _password = new string('*', value.Length != 0 ? value.Length : 8);
        }
        public string Role { get; set; }
    }
}