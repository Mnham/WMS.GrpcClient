using System;

namespace WMS.GrpcClient.Clients
{
    /// <summary>
    /// Представляет клиент Grpc.
    /// </summary>
    public sealed class WmsGrpcClient
    {
        #region Public Properties

        /// <summary>
        /// Клиент сервиса документов приемки.
        /// </summary>
        public AdvanceShipmentNoticeClient AdvanceShipmentNotice { get; }

        /// <summary>
        /// Клиент сервиса приходных документов.
        /// </summary>
        public BillOfLadingClient BillOfLading { get; }

        /// <summary>
        /// Клиент сервиса работников.
        /// </summary>
        public EmployeeClient Employee { get; }

        /// <summary>
        /// Клиент сервиса сессий.
        /// </summary>
        public EmployeeSessionClient EmployeeSession { get; }

        /// <summary>
        /// Клиент сервиса номенклатур.
        /// </summary>
        public NomenclatureClient Nomenclature { get; }

        /// <summary>
        /// Клиент сервиса типов номенклатур.
        /// </summary>
        public NomenclatureTypeClient NomenclatureType { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Создает экземпляр класса <see cref="WmsGrpcClient"/>.
        /// </summary>
        public WmsGrpcClient(string inboundAddress, string employeeAddress, string nomenclatureAddress)
        {
            AdvanceShipmentNotice = new AdvanceShipmentNoticeClient(inboundAddress);
            BillOfLading = new BillOfLadingClient(inboundAddress);
            Employee = new EmployeeClient(employeeAddress);
            EmployeeSession = new EmployeeSessionClient(employeeAddress);
            Nomenclature = new NomenclatureClient(nomenclatureAddress);
            NomenclatureType = new NomenclatureTypeClient(nomenclatureAddress);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Устанавливает обработчик исключений.
        /// </summary>
        public void SetExceptionHandler(Action<Exception> exceptionHandler)
        {
            AdvanceShipmentNotice.SetExceptionHandler(exceptionHandler);
            BillOfLading.SetExceptionHandler(exceptionHandler);
            Employee.SetExceptionHandler(exceptionHandler);
            EmployeeSession.SetExceptionHandler(exceptionHandler);
            Nomenclature.SetExceptionHandler(exceptionHandler);
            NomenclatureType.SetExceptionHandler(exceptionHandler);
        }

        #endregion Public Methods
    }
}