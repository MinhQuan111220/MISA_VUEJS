using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MySqlConnector;
using NPOI.SS.Formula.Functions;
using System.Net.Http.Json;

namespace MISA.Infarstructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region DECLARE
        
        // 1. Khai báo thông tin kết nối với database
        public  readonly string connectionString;
        string className;
        #endregion
        #region Constructor
            public BaseRepository(IConfiguration configuration)
            {
            // Lấy tên của class
            className = typeof(MISAEntity).Name;

            connectionString = configuration.GetConnectionString("CukCukDataBase");

        }
        #endregion

        #region Method

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public Int32 Add(MISAEntity entity)
        {
           

            // Truy cập vào database 
         
            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            // Khai báo dynamicParam
            var dynamicParam = new DynamicParameters();

            // 3. Thêm mới dữ liệu 
            var columsName = string.Empty;
            var columsParam = string.Empty;
            // Đọc từng property của object
            var properties = entity.GetType().GetProperties();
            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(entity);

                if (propName == $"{className}Id" && prop.PropertyType == typeof(Guid))
                {
                    propValue = Guid.NewGuid();
                }
                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $"{propName},";
                columsParam += $"@{propName},";
            }
            columsName = columsName.Remove(columsName.Length - 1, 1);
            columsParam = columsParam.Remove(columsParam.Length - 1, 1);

            var sqlComand = $"INSERT INTO {className}({columsName}) VALUES({columsParam})";
            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam,transaction: transaction);
            transaction.Commit();
            return rowEffects;

        }


        /// <summary>
        /// Xóa  theo Id
        /// </summary>
        /// <param name="entityId">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public Int32 Delete(Guid? entityId)
        {
            
            var classNameId = $"{className}Id";
            // Truy cập vào database 
          

            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 4. Xoá dữ liệu theo id
                string sqlCommandDelete = $"DELETE FROM {className} WHERE {classNameId} = @CustomerIdParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerIdParam", entityId);
                var rowEffects = dbConnection.Execute(sqlCommandDelete, param: parameters);
                return rowEffects;
            }
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public List <MISAEntity> GetAll()
        {
            
            // Truy cập vào database 
            
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu
                var entities = dbConnection.Query<MISAEntity>($"Proc_Get{className}s", commandType: CommandType.StoredProcedure);
                return (List<MISAEntity>)entities; 
            }
        }

        /// <summary>
        /// Lấy dữ liệu khách  Id
        /// </summary>
        /// <param name="entityId">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (13/08/2021)
        public Object GetById(Guid? entityId)
        {
           
            var classNameId = $"{className}Id";
            // Truy cập vào database 
           
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                string sqlCommand = $"SELECT * FROM {className} WHERE {classNameId} = @CustomerIdParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerIdParam", entityId);
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
                return entity;
            }

        }

        /// <summary>
        /// Cập nhật thông tin theo Id
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <param name="entityId">Id </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public Int32 Update(MISAEntity entity, Guid? entityId)
        {
            
            var classNameId = $"{className}Id";
            // Truy cập vào database 
          

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            // Khai báo dynamicParam
            var dynamicParam = new DynamicParameters();
            // 3. Sửa dữ liệu 
            var columsName = string.Empty;
            var columsParam = string.Empty;
            // Đọc từng property của object
            var properties = entity.GetType().GetProperties();
            // Duyệt từng property
            var index = 0;
            foreach (var prop in properties)
            {
                index++;
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(entity);

                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $" {propName} = @{propName},";

            }

            columsName = columsName.Remove(columsName.Length - 1, 1);
            var sqlComand = $"UPDATE {className} SET {columsName} WHERE {classNameId} = @CustomerIdParam";

            dynamicParam.Add("@CustomerIdParam", entityId);

            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam,transaction:transaction);
            transaction.Commit();
            return rowEffects;
        }
        #endregion

        #region validate
        /// <summary>
        /// Kiểm tra mã bị trùng 
        /// </summary>
        /// <param name="entityCode">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (13/08/2021)
        public bool  checkDuplicateCode(String entityCode)
        {
            var propName = $"{className}Code";
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                string sqlCommand = $"SELECT * FROM {className} WHERE {propName} = @entityCodeParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EntityCodeParam", entityCode);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Lấy mã mới 
        /// </summary>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (19/08/2021)
        public object GetNewCode()
        {
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                var entityCode = $"{className}Code";
                var data = dbConnection.QueryFirstOrDefault($"Proc_GetNew{className}Code", commandType: CommandType.StoredProcedure);
                //var Code = data.entityCode;
                //var newCode = "";
                //var number = 0;
                //for(var i = 3; i < Code.length; i++)
                //{
                //    number = number * 10 + Code[i];
                //}
                //for(var i = 0; i < 3; i++)
                //{
                //    newCode += Code[i];
                //}
                return data;
            }
        }
        #endregion
    }
}
