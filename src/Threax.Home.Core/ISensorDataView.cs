namespace Threax.Home.Core
{
    public interface ISensorDataView
    {
        float Value { get; set; }

        Units Units { get; set; }
    }
}
