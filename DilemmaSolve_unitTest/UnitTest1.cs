using Xunit;
using DilemmaSolver;

namespace DilemmaSolve_unitTest
{
    public class CoinFlipTests
    {
        [Fact]
        public void Flip_WithLessThanTwoItems_ShouldThrowException()
        {
            // Arrange
            var engine = new CoinFlipEngine();
            var items = new List<string> { "只有一個項目" };

            // Act & Assert
            // 驗證當項目不足時，是否如預期拋出異常
            Assert.Throws<ArgumentException>(() => engine.GetFlipResult(items));
        }

        [Fact]
        public void Flip_ShouldReturnValidIndex()
        {
            // Arrange
            var engine = new CoinFlipEngine();
            var items = new List<string> { "正面", "反面" };

            // Act
            var result = engine.GetFlipResult(items);

            // Assert
            // 驗證 Index 必須是 0 或 1
            Assert.True(result.Index == 0 || result.Index == 1);

            Assert.Equal(items[result.Index], result.ChosenText);
        }
    }
    public class RandomModeLogicTests
    {
        [Theory]
        [InlineData(2, true)]  // 2 個項目應可投硬幣
        [InlineData(3, false)] // 3 個項目不可投硬幣
        public void Test_CoinValidation(int count, bool expected)
        {
            Assert.Equal(expected, RandomModeLogic.IsCoinValid(count));
        }

        [Fact]
        public void Test_DiceTooltip_ErrorState()
        {
            // 測試當數量不是 6 時，訊息是否正確顯示當前數量
            int count = 4;
            string msg = RandomModeLogic.GetDiceTooltip(count);
            Assert.Contains("目前：4", msg);
        }
    }

    public class DiceScreenTests
    {
        private readonly DiceEngine _engine = new DiceEngine();

        [Fact]
        public void GetChosenItem_RollOne_ShouldReturnFirstItem()
        {
            // Arrange
            var items = new List<string> { "蘋果", "香蕉", "橘子" };

            // Act
            var result = _engine.GetChosenItem(1, items);

            // Assert
            Assert.Equal("蘋果", result);
        }

        [Fact]
        public void GetChosenItem_RollSix_WithOnlyTwoItems_ShouldReturnNull()
        {
            // Arrange
            var items = new List<string> { "A", "B" };

            // Act
            var result = _engine.GetChosenItem(6, items);

            // Assert
            Assert.Null(result); // 測試它是否正確偵測到項目不足
        }

        [Theory]
        [InlineData(0, "Roll / 擲骰子")]
        [InlineData(1, "Roll Again / 再擲一次")]
        [InlineData(99, "Roll Again / 再擲一次")]
        public void GetButtonText_ShouldReflectRollCount(int count, string expected)
        {
            Assert.Equal(expected, _engine.GetButtonText(count));
        }
    }
}