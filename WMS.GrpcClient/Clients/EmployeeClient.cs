using System.Threading.Tasks;

using WMS.EmployeeService.Grpc;

using static WMS.EmployeeService.Grpc.EmployeeApiGrpc;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент сервиса работников.
    /// </summary>
    public sealed class EmployeeClient : GrpcClientBase<EmployeeApiGrpcClient>
    {
        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="EmployeeClient"/>.
        /// </summary>
        public EmployeeClient(string address) : base(address) =>
            Client = new EmployeeApiGrpcClient(Channel);

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Добавляет работника.
        /// </summary>
        public async Task<RequestResult<EmployeeGrpc>> InsertAsync(EmployeeGrpc employee) =>
            await Execute(async () => await Client.InsertAsync(employee));

        /// <summary>
        /// Выполняет поиск работников.
        /// </summary>
        public async Task<RequestResult<EmployeeList>> SearchAsync(EmployeeSearchFilter searchFilter) =>
            await Execute(async () => await Client.SearchAsync(searchFilter));

        /// <summary>
        /// Обновляет данные работника.
        /// </summary>
        public async Task<RequestResult<EmployeeGrpc>> UpdateAsync(EmployeeGrpc employee) =>
            await Execute(async () => await Client.UpdateAsync(employee));

        #endregion Public Methods
    }
}