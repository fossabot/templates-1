namespace Company.Projects.Configurations
{
    public interface IRootConfiguration
    {
        AdminConfiguration Admin { get; set; }

        AppConfiguration App { get; set; }
    }
}
