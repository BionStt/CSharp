namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var uow = new UoW();
            var userRepository = new RepositoryBase<User>(uow);
            var list = userRepository.List();
        }
    }
}