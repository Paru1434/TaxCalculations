namespace TaxCalculation.Common.Constants
{
    public static class Constant
    {
        public enum TaxRule
        {
            Rule1 = 1,
            Rule2 = 2
        }

        public enum MunicipalitySchedules
        {
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Yearly = 4
        }

        public const string InvalidMunicipality = "Invalid Municipality name";
        public const string InvalidTaxRule = "Invalid TaxRule Id";
        public const string InvalidMunicipalityTaxRule = "Invalid Municipality and TaxRule Id combination";

    }

}
