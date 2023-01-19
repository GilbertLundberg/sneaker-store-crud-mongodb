namespace CRUD_MongoDB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IStringIO io; 
            IDAO productDAO; 

            io = new TextIO(); 
            productDAO = new MongoDAO("mongodb+srv://new_user:new_password@cluster0.ta43dc4.mongodb.net/?retryWrites=true&w=majority", "SneakerStore");

            InventoryController controller = new InventoryController(io, productDAO); 
            controller.Start(); 
        }
    }
}
