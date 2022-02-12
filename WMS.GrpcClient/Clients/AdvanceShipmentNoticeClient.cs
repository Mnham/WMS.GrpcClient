using System.Threading.Tasks;

using WMS.InboundService.Grpc;

using static WMS.InboundService.Grpc.AdvanceShipmentNoticeApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса документов приемки.
    /// </summary>
    public sealed class AdvanceShipmentNoticeClient : GrpcClientBase<AdvanceShipmentNoticeApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="AdvanceShipmentNoticeClient"/>.
        /// </summary>
        public AdvanceShipmentNoticeClient(string address) : base(address) =>
            Client = new AdvanceShipmentNoticeApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Выполняет поиск документа приемки по ID.
        /// </summary>
        public async Task<RequestResult<AdvanceShipmentNoticeGrpc>> GetByIdAsync(IntIdModel id) =>
            await Execute(async () => await Client.GetByIdAsync(id));

        /// <summary>
        /// Добавляет документ приемки.
        /// </summary>
        public async Task<RequestResult<AdvanceShipmentNoticeGrpc>> InsertAsync(AdvanceShipmentNoticeGrpc employee) =>
            await Execute(async () => await Client.InsertAsync(employee));

        /// <summary>
        /// Выполняет поиск документов приемки.
        /// </summary>
        public async Task<RequestResult<AdvanceShipmentNoticesList>> SearchAsync(AdvanceShipmentNoticeSearchFilter searchFilter) =>
            await Execute(async () => await Client.SearchAsync(searchFilter));

        /// <summary>
        /// Обновляет документ приемки.
        /// </summary>
        public async Task<RequestResult<AdvanceShipmentNoticeGrpc>> UpdateAsync(AdvanceShipmentNoticeGrpc employee) =>
            await Execute(async () => await Client.UpdateAsync(employee));

        #endregion Public Methods
    }
}