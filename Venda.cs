using System;
using System.Collections.Generic;
using System.Text;

namespace DepartamentoComercial{
    class Venda
    {
        public int qtde;
        public double valor;

        public double valorMedio()
        {
            return this.valor / this.qtde;
        }
    }
}
