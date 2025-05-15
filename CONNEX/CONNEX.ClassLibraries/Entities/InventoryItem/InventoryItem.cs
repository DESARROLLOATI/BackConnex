namespace CONNEX.ClassLibraries.Entities.InventoryItem
{
    public class InventoryItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Serial { get; set; }

        public DateTime EntryDate { get; set; }

        public Guid? OperationUserId { get; set; }
    }
}
