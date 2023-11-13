using ISafety.Models;
using ISafety.Services;

namespace ISafety.View;

public partial class QuickReportPage : ContentPage
{
    private List<Category> _categories;
    private List<SubCategory> _subCategories;

    public QuickReportPage()
    {
        InitializeComponent();
        LoadCategories();
    }

    private async void LoadCategories()
    {
        _categories = await new FirebaseHelper().GetAllCategories();
        CategoryPicker.ItemsSource = _categories;
        CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");
    }

    private async void OnCategorySelected(object sender, EventArgs e)
    {
        if (CategoryPicker.SelectedIndex == -1) return;

        var selectedCategory = _categories[CategoryPicker.SelectedIndex];
        _subCategories = await new FirebaseHelper().GetSubCategoriesByCategoryId(selectedCategory.CategoryID);
        SubCategoryPicker.ItemsSource = _subCategories;
        SubCategoryPicker.ItemDisplayBinding = new Binding("SubCatName");
    }

    private async void OnCreateReportClicked(object sender, EventArgs e)
    {
        if (SubCategoryPicker.SelectedIndex == -1) return;

        var selectedSubCategory = _subCategories[SubCategoryPicker.SelectedIndex];
        var quickReport = new QuickReport
        {
            SubCatID = selectedSubCategory.SubCatID,
            ReportDateTime = ReportDatePicker.Date,
            Latitude = decimal.Parse(LatitudeEntry.Text),
            Longitude = decimal.Parse(LongitudeEntry.Text),
            QRDescription = DescriptionEditor.Text,
            QRAddress = AddressEntry.Text
        };


        await new FirebaseHelper().AddQuickReport(quickReport);

        // Optionally, clear fields or give some feedback that report was submitted
    }
}