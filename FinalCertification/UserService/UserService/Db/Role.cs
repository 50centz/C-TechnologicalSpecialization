namespace UserService.Db
{
    public partial class Role
    {
        public RoleId RoleId { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
