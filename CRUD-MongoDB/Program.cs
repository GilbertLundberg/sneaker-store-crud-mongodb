namespace CRUD_MongoDB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IStringIO io; 
            IDAO productDAO; 

            io = new TextIO(); 
            productDAO = new MongoDAO(File.ReadAllText($"connectionstring.txt"), "SneakerStore");

            InventoryController controller = new InventoryController(io, productDAO); 
            controller.Start(); 
        }
    }
}
