using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel;

namespace CRUD_MongoDB
{
    internal class InventoryController
    {

        IStringIO io;
        IDAO productDAO;
        public InventoryController(IStringIO io, IDAO productDAO)
        {
            this.io = io;
            this.productDAO = productDAO;
        }


        public void Start()
        {
            while (true)
            {
                try
                {
                    
                    io.PrintString("Sneaker Store - Välj vad du vill göra.\n");
                    io.PrintString("1. Create - Lägg till en ny produkt");
                    io.PrintString("2. Read - Få en lista på alla produkter");
                    io.PrintString("3. Update - Uppdatera priset på en produkt");
                    io.PrintString("4. Delete - Ta bort en produkt");
                    io.PrintString("5. Avsluta applikationen");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Create();
                            break;
                        case 2:
                            Read();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
                            io.PrintString("Avslutar...");
                            io.Exit();
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            io.PrintString("");
                            break;
                    }
                }
                catch (FormatException)
                {
                    io.PrintString("Vänligen ange en siffra.");
                    io.PrintString("");
                }
                catch (Exception ex)
                {
                    io.PrintString(ex.Message);
                }
            }
        }



        void Create()
        {
            io.Clear();
            io.PrintString("Lägg till ny produkt.\n \nSkriv in egenskaperna för produkten nedan:");
            
            while (true)
            {
                try
                {
                    io.PrintString("Namn:");
                    var name = io.GetString();

                    io.PrintString("Storlek:");
                    var size = int.Parse(io.GetString());

                    io.PrintString("Pris:");
                    var amount = int.Parse(io.GetString());

                    io.PrintString("Beskrivning");
                    var description = io.GetString();

                    var product = new ProductODM(name, size, amount, description);

                    productDAO.CreateProduct(product);
                    break;
                }
                catch (FormatException)
                {
                    io.PrintString("Du måste skriva in en siffra i detta fält. Försök igen.");
                }
                catch (Exception ex)
                {
                    io.PrintString(ex.Message);
                }
            }

            io.PrintString("Produkten har lagts till. Tryck på valfri knapp för att återgå till menyn.");
            io.GetString();
            io.Clear();
            

        }

        void Read()
        {
            io.Clear();
            io.PrintString("Produkter:");
            try
            {
                
                productDAO.GetAllProducts().ForEach(product => { io.PrintString(product.Name); io.PrintString(product.Size.ToString()); io.PrintString(product.Amount.ToString()); io.PrintString(product.Description); io.PrintString("---------------------------------"); });
                io.PrintString("Tryck på valfri knapp för att återgå till menyn");
                io.GetString();
                io.Clear();
            } 
            catch(Exception ex) 
            {
                io.PrintString(ex.Message);
            }
          
        }

        void Update()
        {
            io.Clear();
            while (true)
            {
                try
                {
                    io.Clear();
                    io.PrintString("Ange id på den produkt du vill uppdatera priset på:");
                    var id = ObjectId.Parse(io.GetString());
                    io.PrintString("Ange nytt pris:");
                    var amount = int.Parse(io.GetString());

                    productDAO.UpdateProduct(id, amount);
                    break;
                }
                catch (FormatException)
                {
                    io.PrintString("Du måste skriva in en siffra i detta fält. Försök igen.");
                }
                catch (Exception ex)
                {
                    io.PrintString(ex.Message);
                }               
            }
            io.PrintString("Priset på produkten har nu uppdaterats. Tryck på valfri knapp för att återgå till menyn.");
            io.GetString();
            io.Clear();
        }

        void Delete()
        {
            io.Clear();
            while(true)
            {
                try
                {
                    io.PrintString("Ange id på den produkt du vill ta bort");
                    var id = ObjectId.Parse(io.GetString());
                    productDAO.DeleteProduct(id);
                    break;
                }
                catch (Exception ex)
                {
                    io.PrintString(ex.Message);
                }
            }
            io.PrintString("Produkten har tagits bort. Tryck på valfri knapp för att återgå till menyn.");
            io.GetString();
            io.Clear();


        }

       
    }
}
