using FluentScheduler;

namespace FileReader.Job
{
    public class DbfRegistry : Registry
    {
        public DbfRegistry()
        {
            Schedule(() => new DbfJob()).ToRunEvery(1).Days().At(7,0);
        }
    }
}
