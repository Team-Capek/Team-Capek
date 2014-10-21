namespace Capek.RPGGame.Interfaces
{
    public interface IAIBrain
    {
        int DecisionToMoveRight
        {
            get;
            set;
        }

        int DecisionToMoveLeft
        {
            get;
            set;
        }

        int DecisionToMoveUp
        {
            get;
            set;
        }

        int DecisionToMoveDown
        {
            get;
            set;
        }

        int DecisionToUseWeapon
        {
            get;
            set;
        }

        int DecisionToGoToTarget
        {
            get;
            set;
        }
    }
}
