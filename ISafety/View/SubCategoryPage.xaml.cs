using ISafety.Models;
using ISafety.Services;

namespace ISafety.View;

public partial class SubCategoryPage : ContentPage
{
    private List<Category> categories;

    public SubCategoryPage()
    {
        InitializeComponent();
        LoadCategoriesIntoPicker();
    }

    private async void LoadCategoriesIntoPicker()
    {
        categories = await new FirebaseHelper().GetAllCategories();
        CategoryPicker.ItemsSource = categories;
        CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");
    }

    private async void OnAddSubCategoryClicked(object sender, EventArgs e)
    {
        var selectedCategory = categories[CategoryPicker.SelectedIndex];
        var subCategory = new SubCategory
        {
            CategoryID = selectedCategory.CategoryID,
            SubCatName = SubCatNameEntry.Text,
            AreaSize = int.Parse(AreaSizeEntry.Text),
            DangerLvl = int.Parse(DangerLvlEntry.Text)
        };

        await new FirebaseHelper().AddSubCategory(subCategory);
    }
}