using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCepAPI
{
    using ConsultaAPI;

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe o CEP que deseja consultar: ");
            var cep = Console.ReadLine();

            if (!string.IsNullOrEmpty(cep)) //Testa se o CEP não é nulo
            {
                Consulta(cep); //Chama o método
            }

        }

        private static void Consulta(string cep) //Método de consulta recebe CEP como parâmetro
        {
            using (var webserv = new AtendeClienteClient()) //Objeto do Web Service
            {
                var resposta = webserv.consultaCEP(cep); //Atribui o retorno da consulta a "resposta"

                Console.Clear();

                //Output das propriedades do Web Service
                Console.WriteLine(String.Format("Endereço : {0}", resposta.end));
                Console.WriteLine(String.Format("Bairro : {0}", resposta.bairro));
                Console.WriteLine(String.Format("Cidade : {0}", resposta.cidade));
                Console.WriteLine(String.Format("UF : {0}", resposta.uf));
                Console.WriteLine(String.Format("CEP : {0}", resposta.cep));

                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();

            }
        }
    }
}
