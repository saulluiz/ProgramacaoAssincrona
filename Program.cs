
using System.Diagnostics;

namespace ProgramacaoAssincrona
{



    class Program
    {
        static void ProgramaSincrono()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            AuxFunctions.RealizarOperacao(1, "Saulo", "Luiz");
            AuxFunctions.RealizarOperacao(2, "Samuel", "isaac");
            AuxFunctions.RealizarOperacao(3, "Cora", "Cachorrinha");
            sw.Stop();
            Console.WriteLine($"TEMPO = {sw.ElapsedMilliseconds}ms");
        }
        async private static void ProgramaThread()
        {
            var t1 = new Thread(() =>
            {
                AuxFunctions.RealizarOperacao(1, "Saulo", "Luiz");

            });
            var t2 = new Thread(() =>
            {
                AuxFunctions.RealizarOperacao(2, "Samuel", "isaac");

            });
            var t3 = new Thread(() =>
            {
                AuxFunctions.RealizarOperacao(3, "Cora", "Cachorrinha");

            });

            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();

        }


        private static void ProgramaTask()
        {
            var t1 = Task<int>.Run(() =>
            {
                AuxFunctions.RealizarOperacao(1, "Saulo", "Luiz");
                return 1;
            });
            var t2 = Task<int>.Run(() =>
            {
                AuxFunctions.RealizarOperacao(2, "Samuel", "isaac");
                return 2;


            });
            var t3 = Task<int>.Run(() =>
            {
                AuxFunctions.RealizarOperacao(3, "Cora", "Cachorrinha");
                return 3;


            });
            Console.WriteLine($"Tarefa{t1.Result} finalizou");
            Console.WriteLine($"Tarefa{t2.Result} finalizou");
            Console.WriteLine($"Tarefa{t3.Result} finalizou");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Escolha o tipo de processamento:\n1-Sincrono 2-Thread 3-Task");
            string aux = Console.ReadLine();
            Stopwatch sw = new Stopwatch();

            if (aux == "1")
            {
                ProgramaSincrono();
            }
            else if (aux == "2")
            {
                /* Threads sao um recurso primario para execuca de codigo paralelo. Entretanto,
                observase que atualmente existe as TASKS, um recurso mais modernos. 
                Enquanto a thread funciona a partir do preparo de uma linha de processamento de um nucleo,ocupando um espaco
                e sendo custoso ao processamento.
                */
                sw.Start();
                ProgramaThread();
                sw.Stop();
                Console.WriteLine($"TEMPO = {sw.ElapsedMilliseconds}ms");

            }
            else if (aux == "3")
            {
                /* Tasks funcionam de forma optimizadas, elas utilizam o thread pool.Utilizam de threads pré criadas
                nao necessitando dos custos para criacao de nova. Se existe um espaco para a realizacao de uma nova operacao
                a thread realiza a tarefa. A task gerencia melhor o espaco de processamento,tambem. */
                sw.Start();
                ProgramaTask();
                sw.Stop();
                Console.WriteLine($"TEMPO = {sw.ElapsedMilliseconds}ms");

            }


        }


    }

}