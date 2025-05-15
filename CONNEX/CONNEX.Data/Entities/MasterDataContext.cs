using CONNEX.ClassLibraries.Entities.OperationReports;
using CONNEX.ClassLibraries.Entities.Operations;
using CONNEX.ClassLibraries.Entities.Settings;
using CONNEX.ClassLibraries.Entities.WorkOrders;
using CONNEX.ClassLibraries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONNEX.Data.Entities
{
    public class MasterDataContext : DbContext
    {
        public MasterDataContext(DbContextOptions<MasterDataContext> options) : base(options)
        {

        }

        //Declaración de las entidades
        #region OperationReports
        public DbSet<OperationReport> OperationReports { get; set; }
        public DbSet<OperationReportData> OperationReportData { get; set; }
        public DbSet<OperationReportEvidence> OperationReportEvidences { get; set; }
        public DbSet<OperationReportEvidenceType> OperationReportEvidenceTypes { get; set; }
        public DbSet<OperationReportObservation> OperationReportObservations { get; set; }
        public DbSet<OperationReportReading> OperationReportReadings { get; set; }
        #endregion

        #region Operations
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationStatus> OperationStatus { get; set; }
        public DbSet<OperationWorker> OperationWorkers { get; set; }
        #endregion

        #region Settings
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Discovery> Discoveries { get; set; }
        public DbSet<EconomicActivity> EconomicActivities { get; set; }
        public DbSet<Novelty> Novelties { get; set; }
        public DbSet<ReadingType> ReadingTypes { get; set; }
        public DbSet<UserDocumentType> UserDocumentTypes { get; set; }
        #endregion



        #region WorkOrders
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderData> WorkOrderData { get; set; }
        public DbSet<WorkOrderObservation> WorkOrderObservations { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatus { get; set; }
        public DbSet<WorkOrderType> WorkOrderTypes { get; set; } 
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Definición de las entidades

            #region OperationReports
            modelBuilder.Entity<OperationReport>()
                    .ToContainer("OperationReports");
            modelBuilder.Entity<OperationReportData>()
                    .ToContainer("OperationReportData");
            modelBuilder.Entity<OperationReportEvidence>()
                    .ToContainer("OperationReportEvidences");
            modelBuilder.Entity<OperationReportEvidenceType>()
                    .ToContainer("OperationReportEvidenceTypes");
            modelBuilder.Entity<OperationReportObservation>()
                    .ToContainer("OperationReportObservations");
            modelBuilder.Entity<OperationReportReading>()
                    .ToContainer("OperationReportReadings");
            #endregion

            #region Operations
            modelBuilder.Entity<Operation>()
                    .ToContainer("Operations");
            modelBuilder.Entity<OperationStatus>()
                    .ToContainer("OperationStatus");
            modelBuilder.Entity<OperationWorker>()
                    .ToContainer("OperationWorkers");
            #endregion

            #region Settings
            modelBuilder.Entity<CustomerType>()
                    .ToContainer("CustomerTypes");
            modelBuilder.Entity<Discovery>()
                    .ToContainer("Discoveries");
            modelBuilder.Entity<EconomicActivity>()
                    .ToContainer("EconomicActivities");
            modelBuilder.Entity<Novelty>()
                    .ToContainer("Novelties");
            modelBuilder.Entity<ReadingType>()
                    .ToContainer("ReadingTypes");
            modelBuilder.Entity<UserDocumentType>()
                    .ToContainer("UserDocumentTypes");
            #endregion

            #region WorkOrders
            modelBuilder.Entity<WorkOrder>()
                    .ToContainer("WorkOrders");
            modelBuilder.Entity<WorkOrderData>()
                .ToContainer("WorkOrderData");
            modelBuilder.Entity<WorkOrderObservation>()
                .ToContainer("WorkOrderObservations");
            modelBuilder.Entity<WorkOrderStatus>()
                .ToContainer("WorkOrderStatus");
            modelBuilder.Entity<WorkOrderType>()
                .ToContainer("WorkOrderTypes"); 
            #endregion

            // Deshabilitar eliminación en cascada
            DisableCascadingDelete(modelBuilder);

            // Llamar al método base
            base.OnModelCreating(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> SaveWithMigrationChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IEntityDelete || x.Entity is IEntity && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                DateTime DateNow = DateTime.Now;

                if (entity is IEntityDelete)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((IEntityDelete)entity.Entity).Created = DateNow;
                    }

                    ((IEntityDelete)entity.Entity).Updated = DateNow;

                    if (entity.State == EntityState.Deleted)
                    {
                        ((IEntityDelete)entity.Entity).Deleted = DateNow;
                        entity.State = EntityState.Modified;
                    }
                }

                if (entity is IEntity)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((IEntity)entity.Entity).Created = DateNow;
                    }

                    ((IEntity)entity.Entity).Updated = DateNow;
                }
            }
        }
    }
}
