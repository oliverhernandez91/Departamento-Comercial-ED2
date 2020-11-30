using System;

namespace DepartamentoComercial{
    class Program{

        Vendedores iVendedores = new Vendedores();
        static void Main(string[] args){

            /*
                OPÇÕES:
                0. Sair
                1. Cadastrar vendedor (*)
                2. Consultar vendedor (**)
                3. Excluir vendedor; (*)
                4. Registrar venda
                5. Listar vendedores; (**)

                (*) Limitar a quantidade de vendedores cadastrados (máximo 10)
                (**) Quando encontrado, deverá ser informado o id, nome, o valor total das vendas,
                o valor da comissao devida e o valor médio das vendas diárias(de cada dia que houve registro de venda)
                (*) O vendedor só poderá ser excluído enquanto não houver nenhuma venda associada a ele
                (**) Deverá ser informado, para cada vendedor, o id, nome, valor total das vendas e o valor da comissão devida
                no final da listagem esses valores deverão ser totalizados
            */
            Program main = new Program();
            string option = "";
            string bye = "Fim da execução!";
            string menu = "OPÇÕES\n" + 
                          "0. Sair\n" +
                          "1. Cadastrar vendedor\n" +
                          "2. Consultar vendedor\n" +
                          "3. Excluir vendedor\n" +
                          "4. Registrar venda\n" +
                          "5. Listar vendedores\n" +
                          "Opção: ";

            do {
                Console.Write(menu);
                option = Console.ReadLine();
                option = main.executeSelectedOption(option);
            } while (!option.Equals("0"));
            Console.WriteLine(bye);

        }
        public string executeSelectedOption(string option)
        {
            switch (option)
            {
                case "1": // 1. Cadastrar vendedor
                    cadastrarVendedor();
                    break;
                case "2": // 2. Consultar vendedor
                    consultarVendedor();
                    break;
                case "3": // 3. Excluir vendedor
                    excluirVendedor();
                    break;
                case "4": // 4. Registrar venda
                    registrarVenda();
                    break;
                case "5": // 5. Listar vendedores
                    listarVendedores();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Opção incorreta!");
                    break;
            }
            pulaLinha();
            return option;
        }
        private void cadastrarVendedor()
        {
            string nome = ""; double percComissao = 0;

            Console.Write("Digite o nome do vendedor a ser cadastrado: ");
            nome = Console.ReadLine();
            Console.Write("Digite o % de comissão do vendedor a ser cadastrado(Apenas números, ex: 10 para 10%): ");
            percComissao = double.Parse(Console.ReadLine());

            Vendedor v = new Vendedor(nome, percComissao);
            bool retorno = this.iVendedores.addVendedor(v);
            if(retorno){
                Console.WriteLine("Vendedor cadastrado com sucesso!");
            } else {
                Console.WriteLine("Falha ao cadastrar vendedor! Limite máximo de vendedores alcançado!");
            }

        }
        private void consultarVendedor()
        {
            string nome = "";
            Console.Write("Digite o nome do vendedor a ser pesquisado: ");
            nome = Console.ReadLine();
            Vendedor v = new Vendedor(nome);
            Vendedor vendedor = this.iVendedores.searchVendedor(v);

            Console.Write("Id: " + vendedor.id + " - " +
                          "Nome: " + vendedor.nome + " - " +
                          "Vlr. Total Vendas: " + vendedor.valorVendas() + " - " +
                          "Vlr. Comissão: " + vendedor.valorComissao() + " - " +
                          "Vlr. médio das vendas diárias: ");

            int tamanhoArray = vendedor.asVendas.Length;
            string mes = "";

            for (int i = 0; i < tamanhoArray; i++){
                if (vendedor.asVendas[i] == null){
                    continue;
                }
                if (i == 0){
                    mes = mes + "\n";
                }
                int diaMes = i + 1;
                string aux = "[" + diaMes + "] " + vendedor.asVendas[i].valorMedio() + " ";
                switch (i){
                    case 0: case 1: case 2: case 3: case 4: case 5:
                        mes = mes + aux;
                        break;
                    case 6: case 7: case 8: case 9: case 10: case 11:
                        mes = mes + "\n" + aux;
                        break;
                    case 12: case 13: case 14: case 15: case 16: case 17:
                        mes = mes + "\n" + aux;
                        break;
                    case 18: case 19: case 20: case 21: case 22: case 23:
                        mes = mes + "\n" + aux;
                        break;
                    case 24: case 25: case 26: case 27: case 28: case 29:
                        mes = mes + "\n" + aux;
                        break;
                    case 30: case 31:
                        mes = mes + "\n" + aux;
                        break;
                }
            }
            if(mes.Length == 0)
            {
                mes = "0";
            }
            Console.WriteLine(mes);
        }
        private void excluirVendedor()
        {
            string nome = "";
            Console.Write("Digite o nome do vendedor a ser excluido: ");
            nome = Console.ReadLine();
            Vendedor v = new Vendedor(nome);
            Vendedor vendedor = this.iVendedores.searchVendedor(v);
            bool retorno = this.iVendedores.delVendedor(vendedor);
            if (retorno){
                Console.WriteLine("Vendedor excluido com sucesso!");
            } else {
                Console.WriteLine("Falha ao excluir vendedor! Existe vendas associadas a este vendedor!");
            }
            
        }
        private void registrarVenda()
        {
            string nome = ""; double valor = 0; int qtd = 0;

            Console.Write("Digite o nome do vendedor: ");
            nome = Console.ReadLine();

            Console.Write("Digite o valor da venda: ");
            valor = double.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade da venda: ");
            qtd = int.Parse(Console.ReadLine());

            Vendedor v = new Vendedor(nome);
            Vendedor vendedor = this.iVendedores.searchVendedor(v);

            Venda venda = new Venda();
            venda.qtde = qtd;
            venda.valor = valor;

            int tamanhoArray = vendedor.asVendas.Length;
            bool conseguiuRegistrar = false;
            for (int i = 0; i < tamanhoArray; i++){
                if(vendedor.asVendas[i] == null)
                {
                    vendedor.registrarVenda(i, venda);
                    conseguiuRegistrar = true;
                    break;
                }
            }
            if (conseguiuRegistrar){
                Console.WriteLine("Venda registrada com sucesso!");
            } else {
                Console.WriteLine("Não foi possível registrar a venda!");
            }
        }
        private void listarVendedores()
        {
            double vlrTotalVendas = 0;
            double vlrTotalComissao = 0;
            Console.WriteLine("---- LISTA DE VENDEDORES ----");
            foreach (Vendedor vendedor in this.iVendedores.osVendedores){
                Console.WriteLine("Id: " + vendedor.id + "\t- " +
                                  "Nome: " + vendedor.nome + "\t- " +
                                  "Vlr. Vendas: " + vendedor.valorVendas() + "\t- " +
                                  "Vlr. Comissão: " + vendedor.valorComissao());
                vlrTotalVendas = vlrTotalVendas + vendedor.valorVendas();
                vlrTotalComissao = vlrTotalComissao + vendedor.valorComissao();
            }
            Console.WriteLine("TOTAL\t- Vlr. Total Vendas: " + vlrTotalVendas + "\t- Vlr. Total Comissão: " + vlrTotalComissao);
        }
        private void pulaLinha()
        {
            Console.WriteLine(" ");
        }
    }
}
