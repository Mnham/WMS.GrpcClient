using System.Threading.Tasks;

using WMS.EmployeeService.Grpc;

using static WMS.EmployeeService.Grpc.EmployeeSessionApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса сессий.
    /// </summary>
    public sealed class EmployeeSessionClient : GrpcClientBase<EmployeeSessionApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="EmployeeClient"/>.
        /// </summary>
        public EmployeeSessionClient(string address) : base(address) =>
            Client = new EmployeeSessionApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Выполняет поиск сессии по ID.
        /// </summary>
        public async Task<RequestResult<EmployeeSessionGrpc>> GetByIdAsync(IntIdModel id) =>
            await Execute(async () => await Client.GetByIdAsync(id));

        /// <summary>
        /// Добавляет сессию.
        /// </summary>
        public async Task<RequestResult<EmployeeSessionGrpc>> InsertAsync(EmployeeSessionGrpc session) =>
            await Execute(async () => await Client.InsertAsync(session));

        /// <summary>
        /// Обновляет сессию
        /// </summary>
        public async Task<RequestResult<EmployeeSessionGrpc>> UpdateAsync(EmployeeSessionGrpc session) =>
            await Execute(async () => await Client.UpdateAsync(session));

        #endregion Public Methods
    }
}