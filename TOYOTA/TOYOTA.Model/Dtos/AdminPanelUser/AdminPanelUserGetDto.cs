using Infrastructure.Model;

namespace TOYOTA.Model.Dtos.AdminPanelUser
{
    public class AdminPanelUserGetDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
