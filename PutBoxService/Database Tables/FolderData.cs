namespace PutBoxService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FolderData")]
    public partial class FolderData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? ownerId { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public string fullPath { get; set; }
    }
}
