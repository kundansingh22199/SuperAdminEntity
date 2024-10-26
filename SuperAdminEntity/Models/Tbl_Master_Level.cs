namespace SuperAdminEntity.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tbl_Master_Level
    {
        public int Id { get; set; }

        public int? Level_No { get; set; }

        [StringLength(20)]
        public string Inc_type { get; set; }

        public decimal? Level_per { get; set; }

        public decimal? Level_fix { get; set; }

        public int? Direct_id_require { get; set; }

        public decimal? Package { get; set; }

        [StringLength(100)]
        public string Domain { get; set; }
    }
}
