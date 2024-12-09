using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Dto.DTO
{
    public class JobTypeDTO
    {
        public Guid Id { get; set; }
        public string? Desc { get; set; }
        public Guid Department_Id { get; set; }
        public Guid Flow_Id { get; set; }
        public DepartmentDTO? DepartmentDTO { get; set; }
    }
}
