using Xunit;
using DilemmaSolver;
using TreeEditResult = DilemmaSolve_unitTest.TreeEditResult;

namespace DilemmaSolve_unitTest
{
    public class ListModelTests
    {
        [Fact]
        public void AddCategory_WithValidName_ShouldAddCategory()
        {
            var model = new DilemmaListModel();

            var result = model.AddCategory("Food");

            Assert.Equal((int)TreeEditResult.Success, (int)result);
            Assert.Single(model.Categories);
            Assert.Equal("Food", model.Categories[0].Name);
        }

        [Fact]
        public void AddCategory_EmptyName_ShouldReturnNoInput()
        {
            var model = new DilemmaListModel();

            var result = model.AddCategory("");

            Assert.Equal((int)TreeEditResult.NoInput, (int)result);
            Assert.Empty(model.Categories);
        }

        [Fact]
        public void AddItem_EmptyItem_ShouldReturnNoInput()
        {
            // Arrange
            var model = new DilemmaListModel();
            model.AddCategory("Food");

            // Act
            var result = model.AddItem("Food", "");

            // Assert
            Assert.Equal((int)TreeEditResult.NoInput, (int)result);
            Assert.Empty(model.Categories[0].Items);
        }

        [Fact]
        public void AddItem_CategoryNotExist_ShouldReturnNoSelection()
        {
            var model = new DilemmaListModel();

            var result = model.AddItem("Food", "Apple");

            Assert.Equal((int)TreeEditResult.NoSelection, (int)result);
        }

        [Fact]
        public void DeleteCategory_WhenOnlyOneCategory_ShouldFail()
        {
            var model = new DilemmaListModel();
            model.AddCategory("Food");

            var result = model.DeleteCategory("Food");

            Assert.Equal((int)TreeEditResult.LastCategoryCannotDelete, (int)result);
            Assert.Single(model.Categories);
        }

        [Fact]
        public void RenameCategory_ValidName_ShouldChangeName()
        {
            var category = new DilemmaCategory("Food");

            var result = category.Rename("Drink");

            Assert.Equal((int)TreeEditResult.Success, (int)result);
            Assert.Equal("Drink", category.Name);
        }

        [Fact]
        public void RenameCategory_EmptyName_ShouldReturnNoInput()
        {
            // Arrange
            var category = new DilemmaCategory("Food");

            // Act
            var result = category.Rename("");

            // Assert
            Assert.Equal((int)TreeEditResult.NoInput, (int)result);
            Assert.Equal("Food", category.Name); // 名稱不應被改掉
        }
    }
}
