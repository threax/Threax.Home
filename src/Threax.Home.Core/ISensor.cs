namespace Threax.Home.Core
{
    public interface ISensor
    {
        string Id { get; set; }

        float TempValue { get; set; }

        Units TempUnits { get; set; }

        float LightValue { get; set; }

        Units LightUnits { get; set; }

        float HumidityValue { get; set; }

        Units HumidityUnits { get; set; }

        float UvValue { get; set; }

        Units UvUnits { get; set; }
    }
}
