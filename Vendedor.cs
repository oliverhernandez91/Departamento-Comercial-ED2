using System;
using System.Collections.Generic;
using System.Text;

namespace DepartamentoComercial
{
    class Vendedor
    {
        public int id;
        public string nome;
        public double percComissao;
        public Venda[] asVendas;

        public Vendedor(string nome)
        {
            this.nome = nome;
        }

        public Vendedor(string nome, double percComissao)
        {
            this.id = Vendedores.qtde + 1;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
        }

        public void registrarVenda(int dia, Venda venda)
        {
            this.asVendas[dia] = venda;
        }

        public double valorVendas()
        {
            double sum = 0;
            foreach(Venda v in this.asVendas)
            {
                if(v != null)
                {
                    double valor = v.valor;
                    sum = sum + valor;
                }
                
            }
            return sum;
        }

        public double valorComissao()
        {
            double sum = 0;
            double comissao = 0;
            foreach (Venda v in this.asVendas)
            {
                if (v != null)
                {
                    double valor = v.valor;
                    sum = sum + valor;
                }  
            }

            comissao = (this.percComissao / 100) * sum;

            return comissao;
        }
    }
}
