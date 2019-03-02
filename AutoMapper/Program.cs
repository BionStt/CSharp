namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapping.Initialize();

            var userTable = new UserTable
            {
                cd_user = 1,
                nm_user = "User",

                address = new AdressTable
                {
                    cd_address = 2,
                    nm_address = "Address"
                }
            };

            var userModel = Mapping.Map<UserModel>(userTable);

            userTable = Mapping.Map<UserTable>(userModel);
        }
    }
}