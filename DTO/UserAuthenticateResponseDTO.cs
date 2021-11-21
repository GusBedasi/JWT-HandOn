using Shop.Models;

namespace Shop.DTO
{
    public class UserAuthenticateResponseDTO
    {
        public UserAuthenticateResponseDTO(User user, string token)
        {
            User = new UserResponseDTO(user);
            Token = token;
        }
        
        public UserResponseDTO User { get; set; }
        public string Token { get; set; }
    }
}