using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Entities
{
    class Category
    {
        public int Category_Id { set; get; }
        public int Id_Pai { set; get; }
        public String Description { set; get; }
        public Operation Operation { set; get; }
        public String Comments { set; get; }
        public int ShowOnDash { set; get; }
    }
}
