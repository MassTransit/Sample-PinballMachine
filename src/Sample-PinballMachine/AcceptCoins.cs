using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes;

namespace Sample_PinballMachine
{
    class AcceptCoins :
        Activity<PinballMachineState, int>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("acceptCoins");
        }

        public void Accept(StateMachineVisitor visitor)
        {
        }

        public Task Execute(BehaviorContext<PinballMachineState, int> context, Behavior<PinballMachineState, int> next)
        {
            context.Instance.NumberOfCoins += context.Data;

            Console.WriteLine("Coin accepted");

            return next.Execute(context);
        }

        public Task Faulted<TException>(BehaviorExceptionContext<PinballMachineState, int, TException> context, Behavior<PinballMachineState, int> next)
            where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}