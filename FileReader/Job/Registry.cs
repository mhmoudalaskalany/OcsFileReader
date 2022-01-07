using FluentScheduler;

namespace FileReader.Job
{
    public class DbfRegistry : Registry
    {
        public DbfRegistry()
        {
            Schedule(() => new DbfJob()).ToRunOnceIn(10).Seconds();
        }
    }
}
