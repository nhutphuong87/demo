using FoodServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodServer.Controllers
{
    public class FoodsController : ApiController
    {

        ///


        /// Dịch vụ lấy toàn bộ Food
        /// </summary>


        /// <returns></returns>
        [HttpGet]
        public List<Food> GetFoodLists()
        {
            DBFood_DataContext db = new DBFoodDataContext();
            return db.Foods.ToList();
        }
        ///


        /// Dịch vụ lấy 1 Food theo khóa chính nào đó
        /// </summary>


        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Food GetFood(int id)
        {
            DBFoodDataContext db = new DBFoodDataContext();
            return db.Foods.FirstOrDefault(x => x.id == id);
        }
        ///


        /// Dịch vụ này để thêm mới 1 Food, các thông số gửi từ client lên
        /// </summary>


        /// <param name="name">tên </param>
        /// <param name="type">loại-nhóm</param>
        /// <param name="price">đơn giá</param>
        /// <returns>true thành công, false thất bại</returns>
        [HttpPost]
        public bool InsertNewFood(string name, string type, int price)
        {
            try
            {
                DBFoodDataContext db = new DBFoodDataContext();
                Food food = new Food();                            
                food.name = name;
                food.type = type;
                food.price =price;
                db.Foods.InsertOnSubmit(food);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        ///


        /// Dịch vụ chỉnh sửa thông tin
        /// </summary>


        /// <param name="id">mã food muốn sửa</param>
        /// <param name="name">tên mới</param>
        /// <param name="type">loại mới</param>
        /// <param name="price">giá mới</param>
        /// <returns></returns>
        [HttpPut]
        public bool UpdateFood(int id, string name, string type, int price)
        {
            try
            {
                DBFoodDataContext db = new DBFoodDataContext();
                //lấy food tồn tại ra
                Food food = db.Foods.FirstOrDefault(x => x.id == id);
                if (food == null) return false;//không tồn tại false
                food.name = name;
                food.type = type;
                food.price = price;
                db.SubmitChanges();//xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }
        ///


        /// Dịch vụ dùng để xóa Food có id
        /// </summary>


        /// <param name="id">id muốn xóa</param>
        /// <returns></returns>
        [HttpDelete]
        public bool DeleteFood(int id)
        {
            DBFoodDataContext db = new DBFoodDataContext();
            //lấy food tồn tại ra
            Food food = db.Foods.FirstOrDefault(x => x.id == id);
            if (food == null) return false;
            db.Foods.DeleteOnSubmit(food);
            db.SubmitChanges();
            return true;
        }


    }
}