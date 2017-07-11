using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes.Util;

namespace Sample_PinballMachine
{
    class PinballMachineStateChangeObserver :
        StateObserver<PinballMachineState>
    {
        public Task StateChanged(InstanceContext<PinballMachineState> context, State currentState, State previousState)
        {
            string previous = previousState != null ? previousState.Name : "null";
            string current = currentState.Name;
            Console.WriteLine($"=>State Transition from '{previous}' to '{current}'");

            return TaskUtil.Completed;
        }
    }
}