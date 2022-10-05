using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class NewProduct
    {
        public int ProdProductId { get; set; }
        public int? ProdCreatedBy { get; set; }
        public DateTime? ProdCreatedDate { get; set; }
        public int? ProdUpdatedBy { get; set; }
        public DateTime? ProdUpdatedDate { get; set; }
        public DateTime? ProdTimeStamp { get; set; }
        public int? ProdDeleted { get; set; }
        public string ProdActive { get; set; }
        public int? ProdUomcategory { get; set; }
        public string ProdName { get; set; }
        public string ProdCode { get; set; }
        public int? ProdProductfamilyid { get; set; }
        public int? ProdIntegrationId { get; set; }
        public string ProdIntforeignid { get; set; }
        public int? ProdIntid { get; set; }
        public DateTime? ProdIntlastsyncdate { get; set; }
        public string ProdPromote { get; set; }
        public string ProdTraining { get; set; }
        public string ProdCs { get; set; }
    }
}
