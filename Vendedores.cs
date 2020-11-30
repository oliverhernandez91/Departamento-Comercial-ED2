using System;
using System.Collections.Generic;
using System.Text;

namespace DepartamentoComercial
{
    class Vendedores
    {
        public List<Vendedor> osVendedores;
        public static int max;
        public static int qtde;

        public Vendedores()
        {
            Vendedores.max = 10;
            Vendedores.qtde = 0;
            this.osVendedores = new List<Vendedor>();
        }

        public bool addVendedor(Vendedor v)
        {
            if(Vendedores.qtde == Vendedores.max)
            {
                return false;
            } else {
                this.osVendedores.Add(v);
                Vendedores.qtde = Vendedores.qtde + 1;
                return true;
            }
        }

        public bool delVendedor(Vendedor v)
        {
            if(v == null || v.valorVendas() != 0)
            {
                return false;
            } else {
                this.osVendedores.Remove(v);
                Vendedores.qtde = Vendedores.qtde - 1;
                return true;
            }
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            foreach (Vendedor vendedor in this.osVendedores)
            {
                if (v.nome.Equals(vendedor.nome))
                {
                    return vendedor;
                }
            }
            return null;
        }

        public double valorVendas()
        {
            double sum = 0;
            foreach(Vendedor v in this.osVendedores)
            {
                sum = sum + v.valorVendas();
            }
            return sum;
        }

        public double valorComissao()
        {
            double sum = 0;
            foreach (Vendedor v in this.osVendedores)
            {
                sum = sum + v.valorComissao();
            }
            return sum;
        }
    }
}
