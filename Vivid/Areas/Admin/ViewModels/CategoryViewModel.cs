using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
    }
    public class EditCategoryViewModel:CreateCategoryViewModel
    {
        public int Id { get; set; }
    }
}
