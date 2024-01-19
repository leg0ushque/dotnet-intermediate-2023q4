namespace Gof.ManagingState.Singleton
{
    public class ThreadSafeNoLockingSingleton
    {
        private static readonly Lazy<ThreadSafeNoLockingSingleton> _lazyInstance =
            new Lazy<ThreadSafeNoLockingSingleton>(() => new ThreadSafeNoLockingSingleton());

        private ThreadSafeNoLockingSingleton() { }

        public static ThreadSafeNoLockingSingleton Instance
        {
            get
            {
                return _lazyInstance.Value;
            }
        }
    }
}