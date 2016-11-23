using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    public class SemaphoreSlimLock : IDisposable
    {
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public SemaphoreSlimLock()
        {

        }

        public void Dispose()
        {
            semaphore.Dispose();
        }

        public async Task Run(Action func)
        {
            await semaphore.WaitAsync();
            try
            {
                func();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<T> Run<T>(Func<T> func)
        {
            await semaphore.WaitAsync();
            try
            {
                return func();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<T> Run<T>(Func<Task<T>> func)
        {
            await semaphore.WaitAsync();
            try
            {
                return await func();
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task Run(Func<Task> func)
        {
            await semaphore.WaitAsync();
            try
            {
                await func();
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
