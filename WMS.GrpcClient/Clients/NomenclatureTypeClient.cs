using Google.Protobuf.WellKnownTypes;

using System.Threading.Tasks;

using WMS.NomenclatureService.Grpc;

using static WMS.NomenclatureService.Grpc.NomenclatureTypeApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса типов номенклатур.
    /// </summary>
    public sealed class NomenclatureTypeClient : GrpcClientBase<NomenclatureTypeApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="NomenclatureTypeClient"/>.
        /// </summary>
        public NomenclatureTypeClient(string address) : base(address) =>
            Client = new NomenclatureTypeApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Возвращает все типы номенклатур.
        /// </summary>
        public async Task<RequestResult<NomenclatureTypeList>> GetAllAsync() =>
            await Execute(async () => await Client.GetAllAsync(new Empty()));

        /// <summary>
        /// Добавляет тип номенклатуры.
        /// </summary>
        public async Task<RequestResult<NomenclatureTypeGrpc>> InsertAsync(NomenclatureTypeGrpc nomenclatureType) =>
            await Execute(async () => await Client.InsertAsync(nomenclatureType));

        /// <summary>
        /// Обновляет тип номенклатуры.
        /// </summary>
        public async Task<RequestResult<NomenclatureTypeGrpc>> UpdateAsync(NomenclatureTypeGrpc nomenclatureType) =>
            await Execute(async () => await Client.UpdateAsync(nomenclatureType));

        #endregion Public Methods
    }
}