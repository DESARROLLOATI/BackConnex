using CONNEX.ClassLibraries.Entities.Operations;

namespace CONNEX.ClassLibraries.Entities.WorkOrders
{
    public class WorkOrderTemporal
    {
        public Guid Id { get; set; }
        public Guid WorkOrderId { get; set; } 
        public WorkOrder? WorkOrder { get; set; }
        public Guid WorkOrderDataId { get; set; }
        public WorkOrderData? WorkOrderData { get; set; }
        public int WorkOrderTypeId { get; set; }
        public DateTime? Created { get; set; }
        public Operation? Operation { get; set; }
    }
}
