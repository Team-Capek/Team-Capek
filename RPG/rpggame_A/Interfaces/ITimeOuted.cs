namespace Capec.RPGGame.Interfaces
{
    public interface ITimeOuted
    {
        int TimeOut { get; set; }
        int CurrentTimeout { get; set; }
        bool HasTimeout { get; set; }
    }
}
