namespace CatalogService.BusinessLogic.Exceptions
{
    [Serializable]
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException() { }

        public BusinessLogicException(string message)
            : base(message)
        { }
    }
}
