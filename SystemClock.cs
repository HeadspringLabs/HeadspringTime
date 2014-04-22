using System;

namespace Headspring
{
    public static class SystemClock
    {
        private static Func<DateTime> _getUtcNow = () => DateTime.UtcNow;
        private static Func<DateTimeOffset> _getOffsetUtcNow = () => DateTimeOffset.UtcNow;

        public static DateTime UtcNow
        {
            get { return _getUtcNow(); }
        }
        
        public static DateTimeOffset OffsetUtcNow
        {
            get { return _getOffsetUtcNow(); }
        }

        public static IDisposable Stub(DateTime dateTime)
        {
            _getUtcNow = () => dateTime;
            return new DisposableStub();
        }
        
        public static IDisposable Stub(DateTimeOffset dateTimeOffset)
        {
           _getOffsetUtcNow = () => dateTimeOffset;
           return new DisposableStub();
        }

        private class DisposableStub : IDisposable
        {
            public void Dispose()
            {
                _getUtcNow = () => DateTime.UtcNow;
                _getOffsetUtcNow = () => DateTimeOffset.UtcNow;
            }
        }
    }
}
