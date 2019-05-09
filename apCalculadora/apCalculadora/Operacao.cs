using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Ana Clara Sampaio Pires - 18201
 *  Gustavo Ferreira Gitzel - 18194
*/

namespace apCalculadora
{
    //A classe operação tem por objetivo transfomar a expressão em uma 
    //sequencia infixa e outra posfixa armazenadas em filas, armazenar
    //os operadores da expressão em uma pilha e calcular o resultado 
    //a partir desta ultima sequência, utilizando a precendencia dos 
    //operadores
    class Operacao
    {   
        // Atributos da classe que armazenam a expressao, a sequencia infixa e a sequencia posfixa
        string expressao;
        string sequenciaInfixa;
        string sequenciaPosfixa;

        //Atributos que armazenam a sequencia infixa e posfixa em filas
        FilaLista<string> infixa;
        FilaLista<string> posfixa;
        
        //Atributo que armazena os operadores da expressão em uma pilha
        PilhaHerdaLista<string> operadores;

        //Atributo que armazena o resultado da expressão
        double resultado;

        // Propriedades que permite o acesso externo para visualização
        public string Expressao { get => expressao; }
        public string SequenciaPosfixa { get => sequenciaPosfixa; }
        public string SequenciaInfixa { get => sequenciaInfixa; }
        public double Resultado { get => resultado; }

        // Construtor que incia todas as váriaveis e armazena a expressão
        public Operacao(string exp)
        {
            expressao = exp;
            operadores = new PilhaHerdaLista<string>();
            infixa = new FilaLista<string>();
            posfixa = new FilaLista<string>();
            resultado = 0.0;
        }

        // Método que calcula o resultado da expressão
        public double CalcularExpressao()
        {
            for (int i = 0; i < expressao.Length; i++)  // Percorre cada caracter da expressão
            {
                string elemento = "";

                if (!EhOperador(expressao[i].ToString()))       // se for um número
                {
                    int inicial = i;
                    while (inicial + elemento.Length < expressao.Length && (!EhOperador(expressao[inicial + elemento.Length].ToString()) ||
                           expressao[inicial + elemento.Length] == '.')) //percorre os caracteres da expressao na posição do elemento anterior e da variavel inicial
                        elemento += expressao[inicial + elemento.Length]; //concatena os caracteres antes do operador na variavel elemento
                    i = inicial + elemento.Length - 1; // atribui o tamanho do elemento somado com a variavel inicial à variavel i
                    posfixa.Enfileirar(elemento);//enfileira o elemento na posfixa
                }
                else // se for um operador
                {
                    if (expressao[i] == '+' && (i == 0 || expressao[i - 1] == '(')) //se for o operador unário de +
                        elemento = "#";
                    else
                    if (expressao[i] == '-' && (i == 0 || expressao[i - 1] == '('))//se for o operador unário de -
                        elemento = "@";
                    else //se não for nenhum operador unario
                        elemento = expressao[i] + ""; //elemento recebe o caracter na posição i da expressão
                    while (!operadores.EstaVazia() && TemPrecedencia(operadores.OTopo()[0], elemento[0]))
                    {   //enquanto a pilha operadores não está vazia e o topo tiver precedencia sobre o elemento
                        char op = operadores.OTopo()[0];
                        if (op == '(') //se o topo for ( sair do while
                            break;
                        else //se não
                        {
                            posfixa.Enfileirar(op + ""); //enfileirar topo na posfixa
                            operadores.Desempilhar(); //desempilhar o topo de operadores
                        }
                    }

                    if (elemento != ")") //se o elemento não for )
                        operadores.Empilhar(elemento); //empilhar elemento nos operadores
                    else //se o elemento for )
                        operadores.Desempilhar(); //desempilhar o topo de operadores
                }
                if (elemento != "(" && elemento != ")")//se o elemento não for ( ou )
                    infixa.Enfileirar(elemento); //enfileirar elemento na infixa
            }

            TratarPilhaOperadores(); //deixar a pilha operadores vazia
            sequenciaInfixa = EscreverSequencia(infixa);//escrever oque está na fila infixa na sequencia infixa
            sequenciaPosfixa = EscreverSequencia(posfixa);//escrever oque está na fila posfixa na sequencia posfixa
            resultado = CalcularResultado(); //calcular resultado
            return resultado;//retornar resultado
        }

        private string EscreverSequencia(FilaLista<string> qualSequencia) //método que passa todos os elementos de uma fila para uma sequencia string
        {
            string seq = "";
            char letra = 'A';
            string[] vet = qualSequencia.ToArray();// transforma a fila em vetor
            for (int i = 0; i < vet.Length; i++) //percorre o vetor
            {
                if (EhOperador(vet[i]))// se for operador
                {
                    if (vet[i] == "#")//se for operador unário de +
                        seq += "+";
                    else
                    if (vet[i] == "@")//se for operador unário de -
                        seq += "-";
                    else
                        seq += vet[i]; //escreve na string
                }
                else //se for numero
                    seq += letra++; //escreve o numero na string em letra e passa para a proxima letra
            }
            return seq; //retorna a sequencia string
        }


        // Método que limpa a pilha dos operadores armazenando na fila Posfixa
        private void TratarPilhaOperadores()
        {
            while (!operadores.EstaVazia())     // enquanto a pilha tem operador
            {
                string op = operadores.Desempilhar();       // desempilha 
                if (op != "(" && op != ")")             // enfileira na posfixa se não for ( ou )
                {
                    posfixa.Enfileirar(op);
                }
            }
        }


        // Função que retorna o resultado da expressão
        private double CalcularResultado()
        {
            // Pilha que armazenará os valores da expressão
            PilhaHerdaLista<double> valores = new PilhaHerdaLista<double>();
            double v1 = 0, v2 = 0, result = 0;
            string[] vet = posfixa.ToArray();   //vetor que armazena o vetor da posfixa

            for (int c = 0; c < vet.Length; c++) //percorre o vetor que armazena a sequencia posfixa
            {
                if (!EhOperador(vet[c])) //verifica se for numero.Se sim empilha na pilha de valores
                    valores.Empilhar(double.Parse(vet[c].Replace('.', ',')));
                else
                { // se não desempilha os valores
                    v1 = valores.Desempilhar();
                    if (vet[c] != "V" && vet[c] != "@" && vet[c] != "#")    // se for raiz quadrada ou operadores unarios não desempilha o segundo valor
                        v2 = valores.Desempilhar();

                    switch (vet[c]) // verifica qual é o operador e faz a operação do operador especificado
                    {
                        case "+": result = v2 + v1; break;
                        case "-": result = v2 - v1; break;
                        case "*": result = v2 * v1; break;
                        case "/":
                            if (v1 == 0)
                                throw new DivideByZeroException("Divisão por 0"); //lança uma exceção se for uma divisão por 0
                            result = v2 / v1; break;
                        case "^": result = Math.Pow(v2, v1); break;
                        case "V":
                            if (v1 < 0)
                                throw new NotFiniteNumberException("Raiz negativa"); //lança uma exceção se for uma raiz negativa
                            result = Math.Sqrt(v1); break;
                        case "@": result = -v1; break;
                        case "#": result = v1; break;
                    }
                    valores.Empilhar(result); //empilha o resultado na pilha de valores
                }
            }

            return valores.Desempilhar();//retorna o valor da pilha, ou seja, o resultado da expressão
        }

        public static bool EhOperador(string qual)// retorna se o caracter passado por parametro é ou não um operador
        {
            switch (qual)
            {
                case "+":
                case "#":
                case "@":
                case "-":
                case "*":
                case "/":
                case "^":
                case "V":
                case "(":
                case ")": return true;

                default: return false;
            }
        }

        private bool TemPrecedencia(char topo, char operacao) //método que retorna se o topo tem precedencia sobre o operador passado
        {
            switch (topo)
            {
                case '+': // se o topo for + ou -
                case '-':
                    if (operacao == '+' || operacao == '-' || operacao == ')') //e o operador for + ou - ou ) o topo tem precedencia
                        return true; break;

                case '*'://se o topo for * ou / ou ^ ou V 
                case '/':
                case '^':
                case 'V':
                    if (operacao == '+' || operacao == '-' || operacao == '*' || operacao == '/' || operacao == ')')
                        return true; break;// e o operador for + ou - ou * ou / ou ) o topo tem precedencia

                case '(': //se o topo for ( e o operador for ) o topo tem precedencia
                    if (operacao == ')')
                        return true;
                    break;
                case '#': //se o topo for # ou @
                case '@':
                    if (operacao != 'V') //e o operador não for V, o topo tem precedencia
                        return true; break;

            }
            return false;
        }
    }
}
