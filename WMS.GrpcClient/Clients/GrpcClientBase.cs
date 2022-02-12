using Google.Protobuf;

using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет базовый класс Grpc-клиента.
    /// </summary>
    public abstract class GrpcClientBase<TClient> where TClient : ClientBase<TClient>
    {
        #region Private Fields

        /// <summary>
        /// Обработчик исключений.
        /// </summary>
        private Action<Exception> _exceptionHandler;

        #endregion Private Fields

        #region Protected Properties

        /// <summary>
        /// Канал подключения.
        /// </summary>
        protected GrpcChannel Channel { get; }

        /// <summary>
        /// Grpc-клиент.
        /// </summary>
        protected TClient Client { get; set; }

        #endregion Protected Properties

        #region Protected Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="GrpcClientBase{T}"/>.
        /// </summary>
        protected GrpcClientBase(string address) =>
            Channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

        #endregion Protected Constructors

        #region Public Methods

        /// <summary>
        /// Устанавливает обработчик исключений.
        /// </summary>
        public void SetExceptionHandler(Action<Exception> exceptionHandler) =>
            _exceptionHandler = exceptionHandler;

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Возвращает результат запроса.
        /// </summary>
        protected async Task<RequestResult<T>> Execute<T>(Func<Task<T>> func) where T : IMessage<T>
        {
            try
            {
                return new RequestResult<T>(await func(), true);
            }
            catch (Exception ex)
            {
                _exceptionHandler?.Invoke(ex);
                return new RequestResult<T>(default, false);
            }
        }

        #endregion Protected Methods
    }
}