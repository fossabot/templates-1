namespace Company.Projects.Options
{
    using Consts;

    public class DbOptions
    {
        public static string Prefix { get; set; } = "";

        public static string Schema { get; set; } = ModuleConsts.ProjectName;
    }
}
