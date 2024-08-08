using System.Diagnostics;

namespace ProjectTimer
{
    internal class Program
    {
        static int countdownTimer = 720000; // 2 hours in seconds

        static void Main(string[] args)
        {
            StartTimer();
            CloseSteam();
            Console.ReadLine();
            
        }



        static void StartTimer()
        {
            // Sets up a new timer with a 5 second interval, enables the timer and sets the title.
            var Timer = new System.Timers.Timer(1000);
            Timer.Elapsed += UpdateTimer;
            Timer.Enabled = true;
            Console.Title = "Get To Work!";
        }

        static void UpdateTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (countdownTimer > 0) {
                Console.WriteLine(countdownTimer-- + "Seconds remaining");
            }
            else { Console.WriteLine();
                ((System.Timers.Timer)source).Stop();
                Environment.Exit(0);
                
            }
        }

        static void CloseSteam()
        {
            while (true)
            {
                Process[] steamProcesses = Process.GetProcessesByName("steam");
                // Get the steam process and kills it if it launches
                foreach (Process steamProcess in steamProcesses)
                {
                    try
                    {
                        steamProcess.Kill();
                        Console.WriteLine("Steam process killed.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error killing Steam process: {ex.Message}");
                    }
                }

                // Introduce a delay to avoid excessive CPU usage
                Thread.Sleep(10000); // Wait for 10 seconds before checking again
            }
        }

    }
}
