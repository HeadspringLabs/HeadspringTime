using System;

namespace Headspring
{
    public static class SystemClock
    {
        private static Func<DateTime> _getUtcNow = () => DateTime.UtcNow;
        private static Func<DateTime> _getNow = () => DateTime.Now;
 
        public static DateTime UtcNow
        {
            get { return _getUtcNow(); }
        }

        public static DateTime Now
        {
            get { return _getNow(); }
        }

        public static IDisposable Stub(DateTime dateTime)
        {
            _getUtcNow = () => dateTime;
            _getNow = () => dateTime;
            return new DisposableStub();
        }

        private class DisposableStub : IDisposable
        {
            public void Dispose()
            {
                _getUtcNow = () => DateTime.UtcNow;
                _getNow = () => DateTime.Now;
            }
        }
    }
}
