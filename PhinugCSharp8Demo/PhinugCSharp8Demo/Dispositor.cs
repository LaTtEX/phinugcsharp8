using System;
using System.Collections.Generic;
using System.Text;

namespace PhinugCSharp8Demo
{
    public class Dispositor : IDisposable
    {
        public Dispositor()
        {
            Console.WriteLine("This is the Dispositor class constructor!");
            this.Numbers = new List<int>() { 1, 2, 3, 4, 5 };
        }

        public IEnumerable<int> Numbers { get; }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }

            Console.WriteLine("This is the Dispositor class destructor!");
        }

        ~Dispositor()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
