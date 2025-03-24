using HouseholdAccounts.Data;
using HouseholdAccounts.DTOs;
using HouseholdAccounts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdAccounts.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public partial class CategoryController : ControllerBase
    {
        DataContextDapper _dapper;
        public CategoryController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            string sql = @"SELECT [ID], 
                                [Name], 
                                [Item] 
                            FROM [dbo].[Category]";
            return _dapper.LoadData<Category>(sql);
        }

        [HttpGet("GetSingleCategory/{categoryId}")]
        public Category GetSingleCategory(int categoryId)
        {
            string sql = @$"SELECT [ID], 
                                [Name], 
                                [Item] 
                            FROM [dbo].[Category]
                            WHERE [ID] = {categoryId}";
            return _dapper.LoadDataSingle<Category>(sql);
        }

        [HttpGet("SearchCategories/{searchParam}")]
        public IEnumerable<Category> SearchCategories(string searchParam)
        {
            string sql = @$"SELECT [ID], 
                                [Name], 
                                [Item] 
                            FROM [dbo].[Category]
                            WHERE [Name] LIKE '%{searchParam}%' 
                                OR [Item] LIKE '%{searchParam}%'";
            return _dapper.LoadData<Category>(sql);
        }

        [HttpPut("EditCategory")]
        public IActionResult EditCategory(Category category)
        {
            string sql = $@"UPDATE [dbo].[Category]
                            SET 
                            [Name] = '{category.Name}',
                            [Item] = '{category.Item}'
                            WHERE [ID] = {category.ID}";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to edit Category");
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(CategoryToAddDTO category)
        {
            string sql = $@"INSERT INTO [dbo].[Category] (
                                [Name],
                                [Item]
                            ) VALUES (
                                '{category.Name}',
                                '{category.Item}'
                            )";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to add Category");
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            string sql = $@"DELETE FROM [dbo].[Category]
                            WHERE [ID] = {categoryId}";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete Category");
        }
    }
}
