
using ISafety.Services;
using ISafety.Models;
namespace ISafety.View;

public partial class CategoryPage : ContentPage
{
    public CategoryPage()
    {
        InitializeComponent();
    }

    private async void OnAddCategoryClicked(object sender, EventArgs e)
    {
        var categoryName = CategoryNameEntry.Text;
        await new FirebaseHelper().AddCategory(new Category { CategoryName = categoryName });
    }
}