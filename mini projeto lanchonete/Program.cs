using System;
using System.Globalization;

namespace mini_projeto_lanchonete
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int opcao = 0;

            string[] vetorItensCardapio = { "X-Burguer", "X-Salada", "X-Bacon", "Refrigerante", "Batata" };
            double[] vetorPrecosCardapio = { 18.00, 20.00, 23.00, 6.00, 10.00 };
            int[] vetorQuantidadeItens = new int[vetorItensCardapio.Length];

            // aqui crriamos o vetores que corresponde as sequencias de dados que precisremos armazenar, os itens do cardapio, os preços de cada otem e posteriroemnte a quantidade de cada item ( isso o proprio usuario vai escolhr)

            int codigoItem = 0;

            double subTotal = 0;
            int totalItens = 0;
            double valorTotal = 0;
            int codigoRemover = 0;

            while (opcao != 6) // definimos uma variavel opcao iniciando em 0, dps montamos o menu e colocamos 6 para sair, logo enquanto a opcao escolhida pelo usuario ( o proprio usario vai digitar a opcao ) enquanto ela for diferente de 6, repete todo o programa
            {

                Console.WriteLine("========== LANCHONETE =========="); // aqui é propriamente o menu, cada opcao corresponde a uma ação 
                Console.WriteLine("1 - Ver cardápio");
                Console.WriteLine("2 - Fazer pedido");
                Console.WriteLine("3 - Ver pedido");
                Console.WriteLine("4 - Remover item");
                Console.WriteLine("5 - Finalizar pedido");
                Console.WriteLine("6 - Sair");
                Console.WriteLine("================================");

                Console.WriteLine();

                Console.Write("Escolha um opção: ");
                opcao = int.Parse(Console.ReadLine()); // aqui temos a variavel opcao que o usuario coloca aquilo que ele quer fazer

                switch (opcao) // estrutura switch case parea controlar cada parte do codigo, se o usuario colocar 1, exeibe o menu se colocar 2 pode fazer pedido...
                {

                    case 1:

                        Console.WriteLine();

                        Console.WriteLine("========== CARDÁPIO ==========");

                        Console.WriteLine();

                        for (int i = 0; i < vetorItensCardapio.Length; i++) // aqui usamos um for para poder exibir todos os itens do menu com seus preços e como os inices são interligados, basta percorrer os vetores pois o elemento que ta na posicao 0 do vetor itens, tem o preço respectivo da posicao, ou seja, o item da posicao 0 tem o preço do vetor preço na posicao 0
                        {


                            Console.WriteLine($"{i} - {vetorItensCardapio[i]}         R$ {vetorPrecosCardapio[i].ToString("F2", CultureInfo.InvariantCulture)}");

                        }

                        Console.WriteLine(); // usar o Length para ele percorrewr o vetor e parar quando terminar de ter percorrido todas as posições od vetor 

                        Console.WriteLine("==============================");

                        Console.WriteLine();

                        break;

                    case 2:

                        int opcao2 = 0; // aqui começa o case 2, criamos novamente uma varivel dessa vez opcao2, para representar a opcao la no final se o  usuario vai querer continuar adicionando itens ou nn

                        while (opcao2 != 2) // enquanto a opcao2 for diferenet de 2 ( que representa o não) a logica e o menuzinho de fazer pedido vão continuar se repetindo
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== FAZER PEDIDO ==========\r\n");

                            Console.WriteLine();

                            Console.Write("Digite o codigo do produto: "); // aqui pede para digitar o codigo do produito e le a variavel
                            codigoItem = int.Parse(Console.ReadLine());

                            while (codigoItem < 0 || codigoItem > vetorItensCardapio.Length - 1) // aqui fazemos a validação do codigo do item que a pessoa quer adicionar, ele nn pode ser menor que 0 e tbm nn pode ser maior que a quantidade de posições existentes no vetor de itens
                            {
                                Console.WriteLine();

                                Console.WriteLine("Opção Inválida! ");
                                Console.Write("Digite o codigo do produto: ");
                                codigoItem = int.Parse(Console.ReadLine());

                                Console.WriteLine();
                            }

                            Console.WriteLine();

                            Console.Write("Digite a quantidade desejada: "); // pede a quamt e le a resposta 
                            int quantidadeItem = int.Parse(Console.ReadLine());

                            while (quantidadeItem <= 0) // faz a validação só que agora com a variavel quantidade, logicamente a quantidade inserida nn pode ser menor ou igual  a 0 
                            {
                                Console.WriteLine();

                                Console.Write("Quantidade Inválida! ");
                                Console.Write("Digite uma quantidade vaálida: ");
                                quantidadeItem = int.Parse(Console.ReadLine());

                                Console.WriteLine();
                            }

                            Console.WriteLine();

                            vetorQuantidadeItens[codigoItem] += quantidadeItem; // aq é uma das partes mais importantes, resumidamente fazemos uma acumualçao com o vetor quant na posicao codigo item, o usuario escolhe o codigo do produto, a quantidade inserida fica armazenada no vetor quant, na posicao do indice do item que ele escolheu, e isso se acumula. Se um cara vai la e coloca 2 x burguer, dps volta dnv e coloca mais 1 x buirguer, a varivael vetor quant na posição codig vale 3, dps ela pega o vetor quant na posicao codigo item e soma mais o valor atual da variavel quantidade, ou seja pega 0 + 2, ai a agr o vetor naqueala posição vale 2, dps pega 2 + 1 agr o vetor naquela posição vale 3

                            subTotal = vetorPrecosCardapio[codigoItem] * vetorQuantidadeItens[codigoItem]; // a variavel subtotal vai ser basicamente o vetor preço, na posição codigo item ( item que o usario escolheu pra add ) e dps multiplica pelo valor vetor quant na posicao codigo item, ou seja a quantidade armazenada que corresponde aquele item  

                            Console.WriteLine($"{quantidadeItem} {vetorItensCardapio[codigoItem]} adicionado com sucesso! "); // exibimos a mensagem na tela de que aquele produto foi add com sucesso, mostrando na tela  a quantidade adicioanda naquela hora e o produto escolhido

                            Console.WriteLine();

                            Console.WriteLine("Deseja adicionar outro pedido:   1 - Sim    2 - Não "); // aqui é feita a pergunta pra ver se o usuario vai querer continuar a add produtos ou nn, como expliquei la em cima no while,. se a resposta for 1, o programa segue pois a variavel opcao2 precisa receber um valor de 2 para parar de repetir, enquanto for diferente, repete
                            Console.Write("Digite sua resposta: ");
                            opcao2 = int.Parse(Console.ReadLine());

                            while (opcao2 < 1 || opcao2 > 2) // faz a validação da variavel opcao2 para que o usuario nn coloque nenhum outro numero além de 1 ou 2. 
                            {

                                Console.WriteLine("Deseja adicionar outro pedido:   1 - Sim    2 - Não ");
                                Console.Write("Digite sua resposta: ");
                                opcao2 = int.Parse(Console.ReadLine());
                            }

                            Console.WriteLine();

                     


                        }

                        break;

                    case 3:

                        bool temItens = false; // aqui é a validação que precisamos fazer para validar se tem ou nn itens adicionados ao pedido,basicamnete agente cria uam variavel booleana "temItens" recebendo false, percorremos o vetor quantidade e aplicamosum if, se o vetor quantidade na posição analisada, for maior que 0 a varivael "temItens" recebe true.

                        for (int i = 0; i < vetorQuantidadeItens.Length; i++)
                        {

                            if (vetorQuantidadeItens[i] > 0)
                            {

                                temItens = true;

                            }

                        }


                        if (!temItens) // aqui entramos no case 3, para ver o pedido, se "não tem itens ", ou seja se a variavel tem itens não for true, significa que não tem itens adicionados
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== RESUMO DO PEDIDO ==========");

                            Console.WriteLine();

                            Console.WriteLine("Nenhum item foi adicionado ainda!");

                            Console.WriteLine();

                            Console.WriteLine("========================================");

                            Console.WriteLine();

                        }

                        else
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== RESUMO DO PEDIDO =========="); // se fezpedido NÃO for igual a 0, ou seja se tiverem produtos adicionados ao pedido, ai aqui  fazemos a logica

                            Console.WriteLine();

                            Console.WriteLine("PRODUTO      QTD.      SUBTOTAL");

                            Console.WriteLine();

                            subTotal = 0;
                            totalItens = 0;
                            valorTotal = 0; // zerei todas as variaveis aqui pq logo abaixo vou ter que percorrer os vetores, e como eles vão exibir valores acumulados toda vez que o case 3 for acionado, eu precisei zerar as variaveism, se não mesmo que nn fosse adicionado mais nada, a variavel valorTotal e quantidade irriam ficar se somando 

                            for (int i = 0; i < vetorQuantidadeItens.Length; i++)
                            {

                                if (vetorQuantidadeItens[i] > 0) // colocamos uma consdição aqui para que só sejam exibidos os itens em que o vetor quantidade é maior que 0 na posição analisdada, ou seja se por exemplo na posicao 3 do vetor quantidade o valor armazenada for maior que 0, signmficia que teve um item na posicao 3 do vetor item que foi adicionado. Se for = 0 a posição analisada, o item em questão nn foi adiconado
                                {

                                    subTotal = vetorPrecosCardapio[i] * vetorQuantidadeItens[i]; // atribuo novamnete o valor para variavel subtotal seguindo a mesma logica de antes, o valor de subtotal é o valor od produto vezes a quantidade do produto adicionada 

                                    Console.WriteLine($"{vetorItensCardapio[i]}      {vetorQuantidadeItens[i]}        R$ {subTotal.ToString("F2", CultureInfo.InvariantCulture)}");

                                    totalItens += vetorQuantidadeItens[i]; // total itens é a soma de todas as posições od vetor quantidade itenms, ent ele pega todod os valores armazenados no vetor quantidade itens ( que guarda as quantidades ) e soma, se tem 2 itens na posicao 0 por exemplo, que é x burguer, dps tem 3 na posição 1 que é  o x salada, ele soma tudo 
                                    valorTotal += subTotal; // soma todos os valores da variavel subtotal, como ela ja vai pelo indice de cada produto, basta fazer a acumulação que ela vai de posição por posição somando todos os valires

                                }

                            }

                            Console.WriteLine();

                            Console.WriteLine("-------------------------------------");

                            Console.WriteLine();

                            Console.WriteLine($"Total de iten: {totalItens}");
                            Console.WriteLine($"valor total: R$ {valorTotal.ToString("F2", CultureInfo.InvariantCulture)}"); // exibe o total de itens  e valor total do pedido

                            Console.WriteLine();

                            Console.WriteLine("=======================================");

                            Console.WriteLine();

                        }

                        break;

                    case 4:

                        Console.WriteLine();

                        temItens = false; // a mesma coisa aqui, a variavel booleana recebe false. Percorremsoo vetor quantidade, aplicamos o if se o vetor quantidade na posição for maior que 0, signficia que foi adicionado um pedido e ai a varivael tem itens recebe true

                        for (int i = 0; i < vetorQuantidadeItens.Length; i++)
                        {

                            if (vetorQuantidadeItens[i] > 0)
                            {

                                temItens = true;

                            }

                        }

                        if (!temItens) // caso o usario tente remover itens, mesmo sem ter adicionado nada no seu pedido, se não tiver itens add signfica que não temcomo remover nada.Logo aparece essa mensagem, senão segue o fuxo normalcoms itens adicionados  mostrando eles na tela e peddidno para remover
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== REMOVER ITEM ==========");

                            Console.WriteLine();

                            Console.WriteLine("Não existe item para ser removido!");

                            Console.WriteLine();

                            Console.WriteLine("========================================");

                            Console.WriteLine();

                        }

                        else
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== REMOVER ITEM ==========\r\n");

                            Console.WriteLine();

                            Console.WriteLine("Seu Pedido: ");

                            Console.WriteLine();

                            for (int i = 0; i < vetorItensCardapio.Length; i++) // aqui exibe novamente os itens adiconados seguindo o mesmo padrão de cima, se o vetor quant na posição analisada for maior que 0, ai exibe o item, se nn for nn exibe
                            {

                                if (vetorQuantidadeItens[i] > 0)
                                {

                                    Console.WriteLine($"{i} - {vetorItensCardapio[i]}     Quantidade: {vetorQuantidadeItens[i]}");

                                }

                            }

                            Console.WriteLine();

                            Console.Write("Digite o código do produto que deseja remover: "); // pergunta o indice do item que o usuario quer remover e ler essa variavel
                            codigoRemover = int.Parse(Console.ReadLine());

                            while (codigoRemover < 0 || codigoRemover > vetorItensCardapio.Length - 1 || vetorQuantidadeItens[codigoRemover] == 0)
                            { // para validar se o codigo inserido é valido, respectivamente se ( se eel nn é menor que 0, se ele nn é maior que a quantidade de itens cadastrados, e se o indice escolhido pssoue alguma quantidade no vetor qwuantidade, ou seja se ele foi adicinado ao pedido )
                                Console.WriteLine();

                                Console.WriteLine("Este produto não foi encontrado! ");

                                Console.WriteLine();

                                Console.Write("Digite o código do produto que deseja remover: ");
                                codigoRemover = int.Parse(Console.ReadLine());

                            }

                            Console.WriteLine();

                            Console.WriteLine("Deseja remover quantas unidades: "); // pergunta se ele quer remover todas as unidades ou uma só, como nn precisamos repetir essa perguntar, nn precisar criar uma outra variavel tipo opcao2 pq aqui nn é necessario a repetição
                            Console.WriteLine(" 1 - Remover 1 unidade ");
                            Console.WriteLine(" 2 - Remover todas as unidades ");

                            Console.WriteLine();

                            Console.Write("Escolha: ");
                            int opcaoRemover = int.Parse(Console.ReadLine());

                            while (opcaoRemover < 1 || opcaoRemover > 2) // valida a resposta do usuario
                            {
                                Console.WriteLine();

                                Console.WriteLine("Opção Inválida, digite uma opção válida: ");

                                Console.WriteLine("Deseja remover quantas unidades: ");
                                Console.WriteLine(" 1 - Remover 1 unidade ");
                                Console.WriteLine(" 2 - Remover todas as unidades ");

                                Console.WriteLine();

                                Console.Write("Escolha: ");
                                opcaoRemover = int.Parse(Console.ReadLine());


                            }

                            if (opcaoRemover == 1) // se a pessoa escolher remover só uma unidade, o vetor quantidade na posicao que a pessoa escolheu, recebe o valor dele mesmo - 1, ent vamos supor que ela escolheu remover um x bburguer que tem 2 x burguer, ou seja na posicao 0 do vetor quantidade tem 2, ai ele vale 2, logo vai ser 2 - 1, então o valor atualizado do vetor quant na posicao 0 que foi a posicao codigo romver item seria = 1
                            {
                                Console.WriteLine();

                                vetorQuantidadeItens[codigoRemover] -= 1;

                                Console.WriteLine();

                                Console.WriteLine("Item Atualizado!");

                                Console.WriteLine();

                                Console.WriteLine($"{vetorItensCardapio[codigoRemover]}: {vetorQuantidadeItens[codigoRemover]} unidade "); // exibe o item removido e a quantidade restante com o valor ja atualizado

                                Console.WriteLine();
                            }

                            else // logica para remover todas as unidades do produto, nesse caso o vetor quant na posicao escolhida recebe 0.
                            {
                                Console.WriteLine();

                                vetorQuantidadeItens[codigoRemover] = 0; // se o usuario quer remover tudo, o vetor quantidade na posicao de escolha do codigo item recebe o valor de 0. ou seja se foi escolhido a posicao 0 ( x burguer ) qe tem 2 na posicao, esse 2 agr vai valer 0.

                                Console.WriteLine("Produto removido do pedido! ");
                            }

                        }

                        break;

                    case 5:

                        temItens = false; // aqui segue o mesmo principio, varivael tem itens recebe false percorremos todo o vetor quantidade e se em uma posição i analçisada, tiver um valor maior que 0 armazenada, a varivael boolena temItens recebe true, pq se em uma pos~ição analisada do vetorquantidade for maior que 0, significa que tem itens adicionados

                        for (int i = 0; i < vetorQuantidadeItens.Length; i++)
                        {

                            if (vetorQuantidadeItens[i] > 0)
                            {

                                temItens = true;

                            }

                        }

                        Console.WriteLine();

                        if (!temItens) // se a pessoa tentar acessar a parte de finalizar pedido sem ter adicionado nada, ( se NÃO tem itens) signficia que o pedido está vazio e nn tiveram itens adicionados, logo exibi que o pedido estávazio
                        {

                            Console.WriteLine();

                            Console.WriteLine("Não é possível finalizar um pedido vazio!\r\n");

                            Console.WriteLine();

                            Console.WriteLine("Adicione pelo menos um produto.");

                            Console.WriteLine();
                        }

                        else
                        {

                            Console.WriteLine();

                            Console.WriteLine("========== FINALIZAR PEDIDO ==========");

                            Console.WriteLine();

                            Console.WriteLine("Seu pedido: ");

                            Console.WriteLine();

                            int contadorCupom = 0;

                            totalItens = 0;
                            valorTotal = 0; // zeramos novamente as 2 variaveis pq precisamos percorrer os vetores novamente, mesma situação do case 3

                            for (int i = 0; i < vetorItensCardapio.Length; i++) // exibi novamente os itens adicionados, se o vetor quant na posicao analisada for maior que 0, exeibi a quantidade de cada um, nome e subtotal de cada um baseado no preço e quantidade de cada item
                            {

                                if (vetorQuantidadeItens[i] > 0)
                                {
                                    subTotal = vetorPrecosCardapio[i] * vetorQuantidadeItens[i];

                                    totalItens += vetorQuantidadeItens[i];
                                    valorTotal += subTotal;

                                    Console.WriteLine($" {vetorQuantidadeItens[i]}  {vetorItensCardapio[i]}         R$ {subTotal.ToString("F2", CultureInfo.InvariantCulture)}");

                                }

                            }

                            Console.WriteLine("-----------------------------------------------");

                            Console.WriteLine();

                            Console.WriteLine($"Total de itens: {totalItens}");
                            Console.WriteLine($"Valor total: R$ {valorTotal.ToString("F2", CultureInfo.InvariantCulture)}");

                            Console.WriteLine();

                            Console.WriteLine("Deseja confirmar o pedido: "); // pergunta se o usuario quer continuar adicionando itens ou nn

                            Console.WriteLine();

                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não");

                            Console.WriteLine();

                            Console.Write("Escolha: ");
                            int opcaoFinalizarPedido = int.Parse(Console.ReadLine()); // le a varivel e o while valida a resposta

                            while (opcaoFinalizarPedido < 1 || opcaoFinalizarPedido > 2)
                            {
                                Console.WriteLine("Deseja confirmar o pedido, escolha uma opção válida: ");

                                Console.WriteLine();

                                Console.WriteLine("1 - Sim");
                                Console.WriteLine("2 - Não");

                                Console.WriteLine();

                                Console.Write("Escolha: ");
                                opcaoFinalizarPedido = int.Parse(Console.ReadLine());
                            }

                            if (opcaoFinalizarPedido == 1) // se o usuario apertar 1 (para finalizar o pedido), exibe o valor final da compra agradece e o valor da variavel opcao recebe 6, pois ai encerrra o programa 
                            {

                                Console.WriteLine();

                                Console.WriteLine("Deseja utilizada um cupom de desconto: ");  // aqui aplicamos um logica para o cliente aplicar um cupom de desconto ou nn, isso aqui já é dentro do if, ou seja, so aparece se o cliente clicar 1( no caso se ele escolher finalizar o pedido )

                                Console.WriteLine();

                                Console.WriteLine("1 - Sim\r\n");
                                Console.WriteLine("2 - Não\r\n");

                                Console.WriteLine();

                                Console.Write("Escolha: "); // criamos uma varivael para controlar se o usuario vai querer ou não aplicar seu cupom de desconto,  e lemos ela
                                int opcaoCupom = int.Parse(Console.ReadLine());

                                while (opcaoCupom < 1 || opcaoCupom > 2) // validamos o recebimento da resposta, se for menor que 1 repete e se for maior que 2 repete tbm
                                {

                                    Console.WriteLine();

                                    Console.WriteLine("Opção Inválida, escolha o opção válida! ");

                                    Console.Write("Escolha: ");
                                    opcaoCupom = int.Parse(Console.ReadLine());

                                }

                                if (opcaoCupom == 1) // aqui entramos entramos em mais um if, esse if é oque acontece caso o usuario tivesse apertado sim para poder aplicar o desconto
                                {

                                    string cupom = "Lanchonete10"; // criamos a variavel do tipo string que vai ser o nosso cupom

                                    Console.WriteLine();

                                    Console.Write("Digite o cupom: "); // solicitamos que o usuario coloque o cupom e lemos a variavel criada 
                                    cupom = Console.ReadLine();

                                    while (cupom != "Lanchonete10") // fazemos a validação com ele para que enquanto o cupom seja diferente do que foi definido "Lanchonete10" dê cupom invalido
                                    {
                                        Console.WriteLine();

                                        Console.WriteLine("Cupom Inválido! Digite um cupom ativo. ");

                                        Console.Write("Digite o cupom: ");
                                        cupom = Console.ReadLine();
                                    }

                                    valorTotal = valorTotal - valorTotal * 0.10; // caso o cupom seja valido e o usuario acerte o cupom, aplicamos o desconto. O valor total vai ser o valor total - o valor total multiplicado por 10%, que é justamnete o valor od desconto

                                    Console.WriteLine();

                                    Console.WriteLine("Cupom aplicado com sucesso!");
                                    Console.WriteLine("Desconto: 10%");


                                    Console.WriteLine("Pedido Confirmado!");

                                    Console.WriteLine();

                                    Console.WriteLine("Obrigado pela preferência!");

                                    Console.WriteLine();

                                    Console.WriteLine($"Valor final: R$ {valorTotal.ToString("F2", CultureInfo.InvariantCulture)}"); // aqui bastou imprimir o valor atualizado, já com o desconto aplicado

                                    Console.WriteLine();

                                    Console.WriteLine("Seu pedido foi finalizado.");

                                    Console.WriteLine();

                                    opcao = 6;


                                }

                                else // aqui é a outra situação em que caso o usuario escolha a opcao 2 (ou seja, não quer aplicar nenhum cupom, então só aparece as mensagens normal que o pedido foi confirmado e tudo mais 
                                {
                                    Console.WriteLine();

                                    Console.WriteLine("Pedido Confirmado!");

                                    Console.WriteLine();

                                    Console.WriteLine("Obrigado pela preferência!");

                                    Console.WriteLine();

                                    Console.WriteLine($"Valor final: R$ {valorTotal.ToString("F2", CultureInfo.InvariantCulture)}");

                                    Console.WriteLine();

                                    Console.WriteLine("Seu pedido foi finalizado.");

                                    Console.WriteLine();

                                    opcao = 6;


                                }

                            }

                            else // se nn, apenas retorna ao menu mesmo e ocntinua normal preservando os itens do pedido
                            {

                                Console.WriteLine();

                                Console.WriteLine("Finalização cancelada! ");

                                Console.WriteLine();

                                Console.WriteLine("Retornando ao menu principal....");

                                Console.WriteLine();

                            }


                        }

                        break;

                    default: // mensagem que aparece caso o usuario digite algum numero fora dos cases do menu

                        Console.WriteLine();

                        Console.WriteLine("Opção Inválida!");

                        Console.WriteLine();

                        break;
                }
            }


        }

    }



}