using System.Threading.Tasks;

using WMS.InboundService.Grpc;

using static WMS.InboundService.Grpc.BillOfLadingApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса приходных документов.
    /// </summary>
    public sealed class BillOfLadingClient : GrpcClientBase<BillOfLadingApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="BillOfLadingClient"/>.
        /// </summary>
        public BillOfLadingClient(string address) : base(address) =>
            Client = new BillOfLadingApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Добавляет приходный документ.
        /// </summary>
        public async Task<RequestResult<BillOfLadingGrpc>> InsertAsync(BillOfLadingGrpc billOfLading) =>
            await Execute(async () => await Client.InsertAsync(billOfLading));

        /// <summary>
        /// Выполняет поиск приходных документов.
        /// </summary>
        public async Task<RequestResult<BillOfLadingList>> SearchAsync(BillOfLadingSearchFilter searchFilter) =>
            await Execute(async () => await Client.SearchAsync(searchFilter));

        /// <summary>
        /// Обновляет приходный документ.
        /// </summary>
        public async Task<RequestResult<BillOfLadingGrpc>> UpdateAsync(BillOfLadingGrpc billOfLading) =>
            await Execute(async () => await Client.UpdateAsync(billOfLading));

        #endregion Public Methods
    }
}