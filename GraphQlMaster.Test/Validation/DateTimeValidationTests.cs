using GraphQlMaster.Shared.Extensions;
using System;
using System.Globalization;
using Xunit;

namespace GraphQlMaster.Test.Validation
{
    public class DateTimeValidationTests
    {
        [Fact]
        public void ToPrettyDate_ShouldArgumentNullException_WhenCultureIsNull()
        {
            var result = Record.Exception(() => DateTime.Now.ToPrettyDate(null));
            Assert.NotNull(result);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "culture";
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new object[] { "de-DE", "2017.12.19", "19 Dezember 2017" })]
        [InlineData(new object[] { "de-DE", "2017.12.18", "18 Dezember 2017" })]
        [InlineData(new object[] { "de-DE", "2017.12.17", "17 Dezember 2017" })]
        [InlineData(new object[] { "en-US", "2019.11.05", "05 November 2019" })]
        [InlineData(new object[] { "en-US", "2020.10.30", "30 October 2020" })]
        [InlineData(new object[] { "en-US", "2018.06.14", "14 June 2018" })]
        public void ToPrettyDate_ShouldAssertTrue_WhenCultureIsGiven(string cultureCode, string textDate, string expected)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureCode);
            var date = DateTime.ParseExact(textDate, "yyyy.MM.dd", culture);
            var actual = date.ToPrettyDate(culture);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(DummyDataGenerator.GetFromDataGenerator), MemberType = typeof(DummyDataGenerator))]
        public void ToPrettyDate_ShouldAssertTrue_WhenCultureIsGiven_WithMemberData(string cultureCode, string textDate, string expected)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureCode);
            var date = DateTime.ParseExact(textDate, "yyyy.MM.dd", culture);
            var actual = date.ToPrettyDate(culture);
            Assert.Equal(expected, actual);
        }
    }
}
