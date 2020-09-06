using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Programs")]
    public class Programs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FLDPROGRAMID")]
        public Guid Id { get; set; }
       
        [Required(ErrorMessage = "Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        [Column("FLDPROGRAMCODE")]
        public string ProgramCode { get; set; }
        [Column("FLDPROGRAMNAME")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Name can't be longer than 500 characters")]
        public string ProgramName { get; set; }
    }
}
