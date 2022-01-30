﻿using FluentScheduler;

namespace FileReader.Job
{
    public class DbfRegistry : Registry
    {
        public DbfRegistry()
        {
            Schedule(() => new DbfJob()).ToRunEvery(4).Hours();
        }
    }
}
