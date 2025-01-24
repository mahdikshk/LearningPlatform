using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.DTO.CourseDTOs;
public class CourseDTO : BaseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Teacher_Id { get; set; }
    public string TeacherName { get; set; }
    public bool IsFree { get; set; }
    public int? OriginalPrice { get; set; }
    public bool HasDiscount { get; set; }
    public int? DiscountPercentage { get; set; }
    public DateTime? DiscountValidUntil { get; set; }
    public DateTime DateOfCreation { get; set; }


}
