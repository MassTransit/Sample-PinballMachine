using System;
using System.Threading.Tasks;
using Automatonymous;

namespace Sample_PinballMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            _pinballMachine = new PinballMachine();

            _machineInformation = new PinballMachineState();
            _pinballMachine.ConnectEventObserver(new PinballMachineEventObserver());
            _pinballMachine.ConnectStateObserver(new PinballMachineStateChangeObserver());

            PlayGame().GetAwaiter().GetResult();
        }

        static PinballMachine _pinballMachine;

        static PinballMachineState _machineInformation;


        static async Task PlayGame()
        {
            await _pinballMachine.RaiseEvent(_machineInformation, _pinballMachine.PowerOn);
            await _pinballMachine.RaiseEvent(_machineInformation, _pinballMachine.InsertCoin, 1);
            await _pinballMachine.RaiseEvent(_machineInformation, _pinballMachine.InsertCoin, 1);
            await _pinballMachine.RaiseEvent(_machineInformation, _pinballMachine.StartButtonPressed);
            await _pinballMachine.RaiseEvent(_machineInformation, _pinballMachine.BallLost);

            if (_machineInformation.NumberOfCoins != 2)
                Console.WriteLine("Number of coins was wrong: {0}", _machineInformation.NumberOfCoins);
            if (_machineInformation.NumberOfBallsLost != 1)
                Console.WriteLine("Number of coins was wrong: {0}", _machineInformation.NumberOfBallsLost);

            Console.WriteLine("End of line.");
        }
    }
}