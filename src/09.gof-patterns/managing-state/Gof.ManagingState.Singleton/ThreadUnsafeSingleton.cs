namespace Gof.ManagingState.Singleton
{
    public class ThreadUnsafeSingleton
    {
        private static ThreadUnsafeSingleton _instance;

        private ThreadUnsafeSingleton() { }

        public static ThreadUnsafeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThreadUnsafeSingleton();
                }
                return _instance;
            }
        }
    }
}