namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет результат запроса.
    /// </summary>
    public sealed class RequestResult<T>
    {
        #region Public Properties

        /// <summary>
        /// Статус ответа.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Ответ.
        /// </summary>
        public T Response { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="RequestResult"/>.
        /// </summary>
        public RequestResult(T response, bool isSuccess)
        {
            Response = response;
            IsSuccess = isSuccess;
        }

        #endregion Public Constructors
    }
}