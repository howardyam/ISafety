using Firebase.Database;
using Firebase.Database.Query;
using ISafety.Models; // Replace with your actual namespace
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISafety.Services
{
    public class FirebaseHelper
    {
        private FirebaseClient firebase = new FirebaseClient(baseUrl: "https://auth-73419-default-rtdb.asia-southeast1.firebasedatabase.app/");

        // Add Category
        public async Task<string> AddCategory(Category category)
        {
            var result = await firebase.Child("categories").PostAsync(category);
            return result.Key;
        }

        // Add SubCategory
        public async Task<string> AddSubCategory(SubCategory subCategory)
        {
            var result = await firebase.Child("subcategories").PostAsync(subCategory);
            return result.Key;
        }

        // Add QuickReport
        public async Task AddQuickReport(QuickReport quickReport)
        {
            await firebase.Child("quickreports").PostAsync(quickReport);
        }

        // Get all categories
        public async Task<List<Category>> GetAllCategories()
        {
            return (await firebase.Child("categories").OnceAsync<Category>()).Select(item => new Category
            {
                CategoryID = item.Key,
                CategoryName = item.Object.CategoryName
            }).ToList();
        }

        // Get subcategories by category ID
        public async Task<List<SubCategory>> GetSubCategoriesByCategoryId(string categoryId)
        {
            return (await firebase.Child("subcategories").OnceAsync<SubCategory>()).Where(item => item.Object.CategoryID == categoryId).Select(item => new SubCategory
            {
                SubCatID = item.Key,
                CategoryID = item.Object.CategoryID,
                SubCatName = item.Object.SubCatName,
                AreaSize = item.Object.AreaSize,
                DangerLvl = item.Object.DangerLvl
            }).ToList();
        }

        public async Task<List<QuickReportWithSubCategory>> GetQuickReportsWithSubCategory()
        {

            var quickReports = await firebase.Child("quickreports").OnceAsync<QuickReport>();
            var subCategories = await firebase.Child("subcategories").OnceAsync<SubCategory>();
            var categories = await firebase.Child("categories").OnceAsync<Category>();

            return quickReports.Select(qr => new QuickReportWithSubCategory
            {
                QuickReport = qr.Object,
                SubCategory = subCategories.FirstOrDefault(sc => sc.Key == qr.Object.SubCatID)?.Object,
                Category = categories.FirstOrDefault(cat => cat.Key == qr.Object.CategoryID)?.Object
            }).ToList();
        }
    }
}
