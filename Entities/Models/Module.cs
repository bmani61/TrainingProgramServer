using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Module")]
    public class Module
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FLDMODULEID { get; set; }

        [Required,ForeignKey(nameof(Programs))]
        public Guid? FLDPROGRAMID { get; set; }
        [Required(ErrorMessage = "Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        public string  FLDMODULECODE{ get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Name can't be longer than 500 characters")]
        public string FLDMODULENAME { get; set; }

        //public Programs Program { get; set; }
    }
}
