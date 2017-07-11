using Automatonymous;

namespace Sample_PinballMachine
{
    public class PinballMachineState
    {
        public State CurrentState { get; set; }

        public int NumberOfCoins { get; set; }
        public int NumberOfBallsLost { get; set; }
    }
}