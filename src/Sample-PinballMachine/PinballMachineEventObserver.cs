using System;
using System.Threading.Tasks;
using Automatonymous;
using GreenPipes.Util;

namespace Sample_PinballMachine
{
    class PinballMachineEventObserver :
        EventObserver<PinballMachineState>
    {
        public Task PreExecute(EventContext<PinballMachineState> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PreExecute<T>(EventContext<PinballMachineState, T> context)
        {
            Console.WriteLine($"=>In State '{context.Instance.CurrentState.Name}', received Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute(EventContext<PinballMachineState> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task PostExecute<T>(EventContext<PinballMachineState, T> context)
        {
            Console.WriteLine($"=> In State from '{context.Instance.CurrentState.Name}' , after processing Event '{context.Event.Name}'");
            return TaskUtil.Completed;
        }

        public Task ExecuteFault(EventContext<PinballMachineState> context, Exception exception)
        {
            return TaskUtil.Completed;
        }

        public Task ExecuteFault<T>(EventContext<PinballMachineState, T> context, Exception exception)
        {
            return TaskUtil.Completed;
        }
    }
}