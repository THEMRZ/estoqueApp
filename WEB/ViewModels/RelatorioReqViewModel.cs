using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.ViewModels
{
    public class RelatorioReqViewModel
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public Decimal PrecoCusto { get; set; }
        public Decimal PrecoVenda { get; set; }
    }
}