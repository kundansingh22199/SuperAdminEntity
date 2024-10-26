namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_DomainMaster
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }

        public DateTime? createdate { get; set; }

        [StringLength(200)]
        public string Connection { get; set; }
    }
}
