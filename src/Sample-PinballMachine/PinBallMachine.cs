using Automatonymous;

namespace Sample_PinballMachine
{
    public class PinballMachine :
        AutomatonymousStateMachine<PinballMachineState>
    {
        public PinballMachine()
        {
            During(Initial,
                When(PowerOn)
                    .TransitionTo(NoCredits));

            During(NoCredits,
                When(InsertCoin)
                    .Execute(context => new AcceptCoins())
                    .If(SufficientCredits, x =>
                        x.TransitionTo(CreditsAvailable)));

            During(CreditsAvailable,
                When(StartButtonPressed)
                    .TransitionTo(Playing),
                When(InsertCoin)
                    .Execute(context => new AcceptCoins()));

            During(Playing,
                When(BallLost)
                    .Execute(context => new ProcessBallLost())
                    .If(SufficientCredits, x =>
                        x.TransitionTo(Playing))
                    .If(InSufficientCredits, x =>
                        x.TransitionTo(NoCredits)));
        }

        private bool SufficientCredits(BehaviorContext<PinballMachineState> context)
        {
            return context.Instance.NumberOfCoins > 0;
        }

        private bool InSufficientCredits(BehaviorContext<PinballMachineState> context)
        {
            return !SufficientCredits(context);
        }

        public Event PowerOn { get; set; }
        public Event<int> InsertCoin { get; set; }
        public Event StartButtonPressed { get; set; }
        public Event BallLost { get; set; }

        public State NoCredits { get; set; }
        public State CreditsAvailable { get; set; }
        public State Playing { get; set; }
    }
}