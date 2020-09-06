using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProgramDTO
    {
        public Guid Id { get; set; }
        public string ProgramCode { get; set; }
        
        public string ProgramName { get; set; }
    }
    public class ProgramForCreationDto
    {
        [Required(ErrorMessage = "Program Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        public string ProgramCode { get; set; }
        
        [Required(ErrorMessage = "Program Name is required")]
        [StringLength(500, ErrorMessage = "Program Name cannot be loner then 500 characters")]
        public string ProgramName { get; set; }
    }
    public class ProgramForUpdateDto
    {
        [Required(ErrorMessage = "Program Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        public string ProgramCode { get; set; }

        [Required(ErrorMessage = "Program Name is required")]
        [StringLength(500, ErrorMessage = "Program Name cannot be loner then 500 characters")]
        public string ProgramName { get; set; }
    }
}
