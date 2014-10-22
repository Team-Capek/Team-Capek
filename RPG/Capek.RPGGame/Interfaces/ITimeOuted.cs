namespace Capek.RPGGame.Interfaces
{
    public interface ITimeOuted : IGameObject
    {
        int TimeOut { get; set; }
        int CurrentTimeout { get; set; }
        bool HasTimeout { get; set; }
    }
}
