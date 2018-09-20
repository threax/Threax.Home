using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threax.Home.Core
{
    /// <summary>
    /// This class provides an easy way to use a semaphore to lock access to critical sections
    /// that are implemented as delegates. You can await the locks to follow the async pattern.
    /// </summary>
    public class SemaphoreSlimLock : IDisposable
    {
        private SemaphoreSlim semaphore;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maxWorkers">The maximum number of workers that can run at once.</param>
        public SemaphoreSlimLock(int maxWorkers = 1)
        {
            semaphore = new SemaphoreSlim(maxWorkers, maxWorkers);
        }

        /// <summary>
        /// Release semaphore.
        /// </summary>
        public void Dispose()
        {
            semaphore.Dispose();
        }

        /// <summary>
        /// Run an action.
        /// </summary>
        /// <param name="func">The action</param>
        /// <returns>void</returns>
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

        /// <summary>
        /// Run a func.
        /// </summary>
        /// <typeparam name="T">The type of the Func's return value.</typeparam>
        /// <param name="func">The func.</param>
        /// <returns>Func's return value.</returns>
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

        /// <summary>
        /// Run an async func that returns a value.
        /// </summary>
        /// <typeparam name="T">The type of the Func's return value.</typeparam>
        /// <param name="func">The func.</param>
        /// <returns>Func's return value.</returns>
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

        /// <summary>
        /// Run an async action.
        /// </summary>
        /// <param name="func">The action to run.</param>
        /// <returns>void</returns>
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
