using System;
using System.ComponentModel;

namespace Capek.RPGGame.Constructions
{
    public class Brain : INotifyPropertyChanged
    {
        private int decisionToMoveLeft;
        private int decisionToMoveRight;
        private int decisionToMoveUp;
        private int decisionToMoveDown;
        public event PropertyChangedEventHandler PropertyChanged;
        private Random RandomDecision;

        public Brain()
        {
            RandomDecision = new Random();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void TakeDecision()
        {
            int probatilityDecision = RandomDecision.Next(0, 25);

            if (probatilityDecision >= 0 && probatilityDecision < 5)
            {
                this.DecisionToMoveLeft++;
            }
            else if (probatilityDecision >= 5 && probatilityDecision < 10)
            {
                this.DecisionToMoveRight++;
            }
            else if (probatilityDecision >= 10 && probatilityDecision < 15)
            {
                this.DecisionToMoveUp++;
            }
            else if (probatilityDecision >= 15 && probatilityDecision < 20)
            {
                this.DecisionToMoveDown++;
            }
            else if (probatilityDecision >= 20 && probatilityDecision < 25)
            {
                //passive deceision
            }
            else if (probatilityDecision >= 25 && probatilityDecision < 30)
            {
                //continue to do before
            }
        }

        public int DecisionToGoToTarget { get; set; }

        public int DecisionToMoveDown
        {
            get { return decisionToMoveDown; }
            set
            {
                this.decisionToMoveDown = value;
                OnPropertyChanged("DecisionToMoveDown");
            }
        }

        public int DecisionToMoveLeft
        {
            get { return decisionToMoveLeft; }
            set
            {
                this.decisionToMoveLeft = value;
                OnPropertyChanged("DecisionToMoveLeft");
            }
        }

        public int DecisionToMoveRight
        {
            get { return decisionToMoveRight; }
            set
            {
                this.decisionToMoveRight = value;
                OnPropertyChanged("DecisionToMoveRight");
            }
        }

        public int DecisionToMoveUp
        {
            get { return decisionToMoveUp; }
            set
            {
                this.decisionToMoveUp = value;
                OnPropertyChanged("DecisionToMoveUp");
            }
        }

        public int DecisionToUseWeapon { get; set; }

    }
}
