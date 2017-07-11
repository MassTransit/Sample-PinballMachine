using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes;

namespace Sample_PinballMachine
{
    class ProcessBallLost :
        Activity<PinballMachineState>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateScope("processBallLost");
        }

        public void Accept(StateMachineVisitor visitor)
        {
        }

        public Task Execute(BehaviorContext<PinballMachineState> context, Behavior<PinballMachineState> next)
        {
            context.Instance.NumberOfBallsLost += 1;

            Console.WriteLine("Ball Lost");

            return next.Execute(context);
        }

        public Task Execute<T>(BehaviorContext<PinballMachineState, T> context, Behavior<PinballMachineState, T> next)
        {
            context.Instance.NumberOfBallsLost += 1;

            Console.WriteLine("Ball Lost");

            return next.Execute(context);
        }

        public Task Faulted<TException>(BehaviorExceptionContext<PinballMachineState, TException> context, Behavior<PinballMachineState> next)
            where TException : Exception
        {
            return next.Faulted(context);
        }

        public Task Faulted<T, TException>(BehaviorExceptionContext<PinballMachineState, T, TException> context, Behavior<PinballMachineState, T> next)
            where TException : Exception
        {
            return next.Faulted(context);
        }
    }
}