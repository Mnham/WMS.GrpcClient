using System.Threading.Tasks;

using WMS.NomenclatureService.Grpc;

using static WMS.NomenclatureService.Grpc.NomenclatureApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса номенклатур.
    /// </summary>
    public sealed class NomenclatureClient : GrpcClientBase<NomenclatureApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="NomenclatureClient"/>.
        /// </summary>
        public NomenclatureClient(string address) : base(address) =>
            Client = new NomenclatureApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Добавляет номенклатуру.
        /// </summary>
        public async Task<RequestResult<NomenclatureGrpc>> InsertAsync(NomenclatureGrpc nomenclature) =>
            await Execute(async () => await Client.InsertAsync(nomenclature));

        /// <summary>
        /// Выполняет поиск номенклатуры.
        /// </summary>
        public async Task<RequestResult<NomenclatureList>> SearchAsync(NomenclatureSearchFilter searchFilter) =>
            await Execute(async () => await Client.SearchAsync(searchFilter));

        /// <summary>
        /// Обновляет номенклатуру.
        /// </summary>
        public async Task<RequestResult<NomenclatureGrpc>> UpdateAsync(NomenclatureGrpc nomenclature) =>
            await Execute(async () => await Client.UpdateAsync(nomenclature));

        #endregion Public Methods
    }
}