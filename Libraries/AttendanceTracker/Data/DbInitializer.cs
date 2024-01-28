namespace MDRC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MDRCSiteDbContext context)
        {
            // Look for any club members.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            throw new Exception("Why is the db empty???");
        }
    }
}
