using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPDataAccess
{
    public class CategoryDAO
    {
        public static Category GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public static bool AddNew(Category entity)
        {
            throw new NotImplementedException();
        }

        public static bool Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public static bool Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public static List<Category> GetList()
        {
            throw new NotImplementedException();
        }

        public static List<Category> GetList(bool condition)
        {
            throw new NotImplementedException();
        }

        public static Category[] GetArray()
        {
            throw new NotImplementedException();
        }

        public static Category[] GetArray(bool condition)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Kiểm tra tồn tại 
        /// </summary>        
        public static bool IsExist(int amountBuy)
        {
            return DataAccessLayer.mpdb.Categories.Any(c => c.Value == amountBuy && c.Active == true);
        }
    }
}
