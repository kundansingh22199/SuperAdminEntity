namespace SuperAdminEntity.Models
{
    public class ModChangePass
    {
        public string Domain { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfPassword { get; set; }

    }
}
