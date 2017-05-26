using GTR.Administration.Logic.Services;
using GTR.Administration.Services;
using GTR.Authorization.Logic.Services;
using GTR.Authortization.Services;
using GTR.Domain.Configuration;
using GTR.Domain.Logic.Configuration;
using GTR.Domain.Logic.Services.Comercial;
using GTR.Domain.Logic.Services.Facturacion;
using GTR.Domain.Logic.Services.Files;
using GTR.Domain.Logic.Services.Master;
using GTR.Domain.Logic.Services.Operativa;
using GTR.Domain.Logic.Services.Reports;
using GTR.Domain.Logic.Services.Reports.DetalleReport;
using GTR.Domain.Logic.Validations.FileTask;
using GTR.Domain.Logic.Validations.Reports;
using GTR.Domain.Services.Comercial;
using GTR.Domain.Services.Facturacion;
using GTR.Domain.Services.Files;
using GTR.Domain.Services.Master;
using GTR.Domain.Services.Operativa;
using GTR.Domain.Services.Reports;
using GTR.Domain.Services.Reports.DetalleReport;
using GTR.Domain.Validations;
using GTR.Service.Configuration;
using GTR.Service.Logic.Services.Export;
using GTR.Service.Services.Export;
using Microsoft.Practices.Unity;

namespace GTR.Service.Logic.Configuration
{
    public class ServicesConfig : IServicesConfig
    {
        public void Configure(IUnityContainer container)
        {
            RegisterDomain(container);
            RegisterDomainValidators(container);
            RegisterSecurityAdministration(container);
            RegisterSecurityAuthorization(container);

            ConfigureDomain(container);
        }
        private void RegisterSecurityAdministration(IUnityContainer container)
        {
            container.RegisterType<IUserAdministrationLogic, UserAdministrationLogic>();
            container.RegisterType<IOperationAdministrationLogic, OperationAdministrationLogic>();
            container.RegisterType<IRoleAdministrationLogic, RoleAdministrationLogic>();

        }
        private void RegisterSecurityAuthorization(IUnityContainer container)
        {
            container.RegisterType<IRoleAuthorizationLogic, RoleAuthorizationLogic>();
            container.RegisterType<IAuthorizationLogic, AuthorizationLogic>();
            container.RegisterType<IOperationAuthorizationLogic, OperationAuthorizationLogic>();
        }
        private void RegisterDomainValidators(IUnityContainer container)
        {
            container.RegisterType<IReportWhereModelColumnValidator, ReportWhereModelColumnValidator>();
            container.RegisterType<ITmpReportWhereModelColumnValidator, TmpReportWhereModelColumnValidator>();
            container.RegisterType<IReportOrderModelColumnValidator, ReportOrderModelColumnValidator>();
            container.RegisterType<ITmpReportOrderModelColumnValidator, TmpReportOrderModelColumnValidator>();
            container.RegisterType<IReportSelectModelColumnValidator, ReportSelectModelColumnValidator>();
            container.RegisterType<ITmpReportSelectModelColumnValidator, TmpReportSelectModelColumnValidator>();
            container.RegisterType<IReportValidator, ReportValidator>();
            container.RegisterType<ITmpReportValidator, TmpReportValidator>();
            container.RegisterType<IReportGrupoValidator, ReportGrupoValidator>();
            container.RegisterType<IReportUsuarioValidator, ReportUsuarioValidator>();
            container.RegisterType<ITmpReportUsuarioValidator, TmpReportUsuarioValidator>();
            container.RegisterType<IReportTotalFieldsModelColumnValidator, ReportTotalFieldsModelColumnValidator>();
            container.RegisterType<IReportTotalsGroupFieldsModelColumnValidator, ReportTotalsGroupFieldsModelColumnValidator>();
            container.RegisterType<ITmpReportTotalFieldsModelColumnValidator, TmpReportTotalFieldsModelColumnValidator>();
            container.RegisterType<ITmpReportTotalsGroupFieldsModelColumnValidator, TmpReportTotalsGroupFieldsModelColumnValidator>();
            container.RegisterType<IReportFilterValidator, ReportFilterValidator>();
            container.RegisterType<IFacadeReportValidator, FacadeReportValidator>();
            container.RegisterType<IFileTaskValidator, FileTaskValidator>();

        }
        private static void RegisterDomain(IUnityContainer container)
        {
            container.RegisterType<IDomainConfig, DomainConfig>();
            container.RegisterType<IAutoMapperDomainContainer, AutoMapperDomainContainer>();
            container.RegisterType<IReportLogic, ReportLogic>();
            container.RegisterType<ITmpReportLogic, TmpReportLogic>();
            container.RegisterType<IReportUsuarioLogic, ReportUsuarioLogic>();
            container.RegisterType<ITmpReportUsuarioLogic, TmpReportUsuarioLogic>();
            container.RegisterType<IReportGrupoLogic, ReportGrupoLogic>();
            container.RegisterType<IReportSubGrupoLogic, ReportSubGrupoLogic>();
            container.RegisterType<IModelColumnLogic, ModelColumnLogic>();
            container.RegisterType<IModelColumnGroupLogic, ModelColumnGroupLogic>();
            container.RegisterType<IModelTableLogic, ModelTableLogic>();
            container.RegisterType<IModelTableRelationLogic, ModelTableRelationLogic>();

            container.RegisterType<IComparisonTypesLogic, ComparisonTypesLogic>();
            container.RegisterType<IAgregationTypesLogic, AgregationTypesLogic>();
            container.RegisterType<IReportTotalGroupFieldsModelColumnLogic, ReportTotalGroupFieldsModelColumnLogic>();
            container.RegisterType<IReportTotalFieldsModelColumnLogic, ReportTotalFieldsModelColumnLogic>();
            container.RegisterType<ITmpReportTotalGroupFieldsModelColumnLogic, TmpReportTotalGroupFieldsModelColumnLogic>();
            container.RegisterType<ITmpReportTotalFieldsModelColumnLogic, TmpReportTotalFieldsModelColumnLogic>();            
            container.RegisterType<IOrderTypesLogic, OrderTypesLogic>();
            //container.RegisterType<IReportOrderFieldsLogic, ReportOrderFieldsLogic>();

            container.RegisterType<IMaestrosLogic, MaestrosLogic>();

            container.RegisterType<IReportSelectModelColumnLogic, ReportSelectModelColumnLogic>();
            container.RegisterType<ITmpReportSelectModelColumnLogic, TmpReportSelectModelColumnLogic>();
            container.RegisterType<IReportWhereModelColumnLogic, ReportWhereModelColumnLogic>();
            container.RegisterType<ITmpReportWhereModelColumnLogic, TmpReportWhereModelColumnLogic>();
            container.RegisterType<IReportOrderModelColumnLogic, ReportOrderModelColumnLogic>();
            container.RegisterType<ITmpReportOrderModelColumnLogic, TmpReportOrderModelColumnLogic>();
            container.RegisterType<IEnvioHistoryLogic, EnvioHistoryLogic>();
            container.RegisterType<IDetalleReportFacade, DetalleReportFacade>();
            container.RegisterType<IReportFacade, ReportFacade>();
            container.RegisterType<IExportToPDF, ExportToPDF>();

            container.RegisterType<IExportToPDFMigradoc, ExportToPDFMigradoc>();
            container.RegisterType<IExportToPDFMigradocHeaderFooter, ExportToPDFMigradocHeaderFooter>();
            container.RegisterType<IExportToPDFMigradocDocumentBody, ExportToPDFMigradocDocumentBody>();
            container.RegisterType<IExportToPDFMigradocAgrupaciones, ExportToPDFMigradocAgrupaciones>();

            container.RegisterType<IExportToExcel, ExportToExcel>();
            container.RegisterType<IExportToExcelNPOI, ExportToExcelNPOI>();
            container.RegisterType<IExportToCSV, ExportToCSV>();

            container.RegisterType<IEfectosComercialesLogic, EfectosComercialesLogic>();
            container.RegisterType<IFacturaLogic, FacturaLogic>();
            container.RegisterType<IPropuestaFacturaLogic, PropuestaFacturaLogic>();
            container.RegisterType<IValoracionLogic, ValoracionLogic>();

            container.RegisterType<IClienteEdicionLogic, ClienteEdicionLogic>();
            container.RegisterType<ITarifaLogic, TarifaLogic>();

            container.RegisterType<IMandatoryModelColumWhereGroupLogic, MandatoryModelColumWhereGroupLogic>();

            container.RegisterType<IReportDataColumnLogic, ReportDataColumnLogic>();
            container.RegisterType<IReportSelectParameterLogic, ReportSelectParameterLogic>();
            container.RegisterType<IReportOrderParameterLogic, ReportOrderParameterLogic>();
            container.RegisterType<IReportWhereParameterLogic, ReportWhereParameterLogic>();
            container.RegisterType<IReportTotalParameterLogic, ReportTotalParameterLogic>();
            container.RegisterType<IReportJoinParameterLogic, ReportJoinParameterLogic>();
            container.RegisterType<IReportTotalGroupParameterLogic, ReportTotalGroupParameterLogic>();
            container.RegisterType<IDetalleReportLogic, DetalleReportLogic>();
            container.RegisterType<IDetalleReportAnualLogic, DetalleReportAnualLogic>();
            container.RegisterType<IReportDefinitionLogic, ReportDefinitionLogic>();

            container.RegisterType<IFileOnDemandLogic, FileOnDemandLogic>();
            container.RegisterType<IFontSizesPdfLogic, FontSizesPdfLogic>();
        }
        private static void ConfigureDomain(IUnityContainer container)
        {
            IDomainConfig domainConfig = container.Resolve<IDomainConfig>();
            domainConfig.Configure(container);
        }
    }
}