namespace Company.Projects.Configurations
{
    public class RootConfiguration : IRootConfiguration
    {
        public AdminConfiguration Admin { get; set; } = new AdminConfiguration();

        public AppConfiguration App { get; set; } = new AppConfiguration();
    }
}
