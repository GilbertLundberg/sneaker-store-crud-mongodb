using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MongoDB
{
    internal interface IDAO
    {
        List<ProductODM> GetAllProducts();

        void CreateProduct(ProductODM product);

        void UpdateProduct(ObjectId id, int amount);

        void DeleteProduct(ObjectId id);    


    }
}
