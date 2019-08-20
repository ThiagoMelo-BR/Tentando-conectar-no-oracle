using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Tentando_conectar_no_oracle
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdicionarProdutos();
            //RemoverProdutos();
            ListarProdutos();
            //ListarProdutos2();
            //ListarProdutos3();
            //ExcluindoComExecuteSqlCommand();
            //ExecutandoSQLAnonimo();
            Console.ReadLine();
        }
        private static void ExecutandoSQLAnonimo()
        {
            using (var context = new MyContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select * from \"Produtos\"";
                context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Console.WriteLine("{0}\t{1}", result["Codigo"].ToString(), result["Descricao"].ToString());
                    }
                    result.Close();
                }
            }
        }
        private static void ListarProdutos3()
        {
            using (var context = new MyContext())
            {
                var produtos = context.Produtos.FromSql("select * from \"Produtos\"").ToList();
                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto.Descricao);
                }
            }
        }
        private static void ExcluindoComExecuteSqlCommand()
        {
            using (var context = new MyContext())
            {
                var produtos = context.Database.ExecuteSqlCommand("delete \"Produtos\"");

            }
        }
        private static void ListarProdutos2()
        {
            using (var context = new MyContext())
            {
                var listaProdutos = from produtos in context.Produtos
                                    select produtos;

                foreach (var produto in listaProdutos)
                {
                    Console.WriteLine("{0}\t{1}", produto.Codigo, produto.Descricao);
                }
            }
        }
        private static void ListarProdutos()
        {
            using (var context = new MyContext())
            {
                var produtos = context.Produtos.ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine("{0}\t{1}", produto.Codigo, produto.Descricao);
                }
            }
        }
        private static void RemoverProdutos()
        {
            using (var context = new MyContext())
            {
                for (int i = 1; i < 10; i++)
                {
                    var produtoDB = context.Produtos.ToList().First(p => p.Codigo == i);

                    context.Produtos.Remove(produtoDB);
                }
                context.SaveChanges();
            }
        }
        private static void AdicionarProdutos()
        {
            using (var context = new MyContext())
            {
                var data = new DateTime(2019, 04, 16);

                for (int i = 1; i < 10; i++)
                {
                    var p = new Produto()
                    {
                        Codigo = i,
                        Descricao = "Produto " + i.ToString(),
                        DataRegistro = data
                    };
                    context.Produtos.Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}
