using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;
using System.Reflection.Metadata;


namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository:ICategoryRepository
    {
        // Dapper'ın döndüğü yer. Entity'den farkı query tarafı. Çok daha hızlı çok daha efektif.

        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryname,@categorystatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            { 
                var values=await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@CategoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID",id);
            using (var coonection = _context.CreateConnection())
            {
                var values = await coonection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;
            }

        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus",categoryDto.CategoryStatus);
            parameters.Add("@categoryID", categoryDto.CategoryID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
