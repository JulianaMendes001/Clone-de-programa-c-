using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ReferenceConsoleRedisApp
{
    class Program
    {
      static readonly connectuibMultiplexer redis = ConnectionMultiplex.connect("redis-17704.c299,asia-northeast1-1.gce.redns.redis-cloud.com:17704,password=suggestion-harmonic-moon-94573.db.redis.io:19723");
    static async Task Main(string[] args)
        {
            var db = redis.getDatabase();

            while (true)
            {
                Console.WriteLine("selecionar uma opção:");
                Console.WriteLine("1. Criar Cadastro:");
                Console.WriteLine("2. Atualizar Cadastro:");
                Console.WriteLine("3. Excluir Cadastro:");
                Console.WriteLine("4. Listar Cadastros:");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    await CriarCadastro(db);
                    break;
                     case "2":
                    await AtualizarCadastro(db);
                    break;
                     case "3":
                    await ExcluirCadastro(db);
                    break;
                     case "4":
                    await ListarCadastro(db);
                    break;
                     case "5":
                    Environment.Exit(0);
                    break;
                    default:
                    Console.WriteLine("Opção inválida. Tente novamente");
                    break;
                }
            }

        
        //método criar cadastro
        static async Task CriarCadastro(IDatabase db)
            {
                console.WriteLine("Digite a chave do cadastro:");
                var chave = Console.ReadLine();

                console.WriteLine("Digite os detalhes do cadastro:");
                var detalhes = Console.ReadLine();
            
                await db.StringSetAsync(chave, detalhes);
                console.WriteLine("Cadastro criado com sucesso!");
            }

            //método atualizar cadastro
              static async Task AtualizarCadastro(IDatabase db)
            {
                console.WriteLine("Digite a chave do cadastro que deseja atualizar:");
                var chave = Console.ReadLine();

                console.WriteLine("Digite os novos detalhes do cadastro");
                var novosDetalhes = Console.ReadLine();
            
                await db.StringSetAsync(chave, novosDetalhes);
                console.WriteLine("Cadastro atualizado com sucesso!");
            }

            //método de excluir cadastro
              static async Task ExcluirCadastro(IDatabase db)
            {
                console.WriteLine("Digite a chave do cadastro que deseja excluir:");
                var chave = Console.ReadLine();
               
                await db.KeyDeleteAsync(chave);
                console.WriteLine("Cadastro excluído com sucesso!");
            }

            //método listar cadastro
              static async Task ListarCadastro(IDatabase db)
            {
                console.WriteLine("Listando cadastros:");

                var keys = await db.ExecuteAsync("KEYS", "*");
                foreach (var key in (RedisResult[])keys)
                {
                    var detalhes = await db.StringGetAsync((string)key);
                    Console.WriteLine($"Chave: {key}, Valor: {detalhes}\n");
                }
            }
        }
    }

}
