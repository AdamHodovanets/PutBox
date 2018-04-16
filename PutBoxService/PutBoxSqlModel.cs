namespace PutBoxService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PutBoxSqlModel : DbContext
    {
        public PutBoxSqlModel()
            : base("name=PutBoxSqlModel")
        {
        }

        public virtual DbSet<FileData> FileDatas { get; set; }
        public virtual DbSet<FolderData> FolderDatas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileData>()
                .Property(e => e.fileName)
                .IsUnicode(false);

            modelBuilder.Entity<FileData>()
                .Property(e => e.fullPath)
                .IsUnicode(false);

            modelBuilder.Entity<FolderData>()
                .Property(e => e.fullPath)
                .IsUnicode(false);

            modelBuilder.Entity<UserData>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
