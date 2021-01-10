using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateMediaCategoriesViewModel
    {
        public string Name { get; set; }
    }
    public class EditMediaCategoriesViewModel:CreateMediaCategoriesViewModel
    {
        public int Id { get; set; }
    }
}
