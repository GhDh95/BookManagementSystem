using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

public class NullableDateTimeConverter : DateTimeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text) || text.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            return null; // Handle "None" or empty strings as null
        }

        return base.ConvertFromString(text, row, memberMapData);
    }

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value == null)
        {
            return ""; // Handle null values as empty string when writing to CSV
        }

        return base.ConvertToString(value, row, memberMapData);
    }
}