namespace Threax.Home.MFi.Services
{
    public interface IPowerStripManager
    {
        void Dispose();
        IPowerStrip GetClient(string name);
    }
}