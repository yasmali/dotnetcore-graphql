using System.Collections.Generic;

namespace GraphQlMaster.Test
{
    public class DummyDataGenerator
    {
        public static IEnumerable<object[]> GetFromDataGenerator()
        {
            yield return new object[] { "de-DE", "2017.12.19", "19 Dezember 2017" };
            yield return new object[] { "de-DE", "2017.12.18", "18 Dezember 2017" };
            yield return new object[] { "de-DE", "2017.12.17", "17 Dezember 2017" };
            yield return new object[] { "en-US", "2019.11.05", "05 November 2019" };
            yield return new object[] { "en-US", "2020.10.30", "30 October 2020" };
            yield return new object[] { "en-US", "2018.06.14", "14 June 2018" };
        }
    }
}
