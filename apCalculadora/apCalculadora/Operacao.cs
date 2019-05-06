using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    class Operacao
    {
        string expressao;
        string sequenciaInfixa;
        string sequenciaPosfixa;

        FilaLista<string> infixa;
        FilaLista<string> posfixa;
        PilhaHerdaLista<string> operadores;
        double resultado;

        public string Expressao { get => expressao;}
        public string SequenciaPosfixa { get => sequenciaPosfixa; }
        public string SequenciaInfixa { get => sequenciaInfixa; }
        public double Resultado { get => resultado; }

        public Operacao(string exp)
        {
            expressao = exp;
            operadores = new PilhaHerdaLista<string>();
            infixa = new FilaLista<string>();
            posfixa = new FilaLista<string>();
            resultado = 0.0;
        }

        public double CalcularExpressao()
        {
            for (int i = 0; i < expressao.Length; i++)
            {
                string elemento = "";

                if (!EhOperador(expressao[i].ToString()))
                {
                    elemento = "";
                    int inicial = i;
                    while (inicial + elemento.Length < expressao.Length && (!EhOperador(expressao[inicial + elemento.Length].ToString()) || expressao[inicial + elemento.Length] == '.'))
                        elemento += expressao[inicial + elemento.Length];
                    i = inicial + elemento.Length - 1;
                    posfixa.Enfileirar(elemento);
                }
                else
                {
                    if (expressao[i] == '-' && (i == 0 || expressao[i - 1] == '('))
                        elemento = "@";
                    else
                        elemento = expressao[i] + "";

                    while (!operadores.EstaVazia() && TemPrecedencia(operadores.OTopo()[0], elemento[0]))
                    {
                        string op = operadores.Desempilhar();
                        if (op != "(" && op != ")")
                            posfixa.Enfileirar(op);
                    }
                    operadores.Empilhar(elemento);
                }
                infixa.Enfileirar(elemento);
            }

            TratarPilhaOperadores();
            sequenciaInfixa = EscreverSequencia(infixa);
            sequenciaPosfixa = EscreverSequencia(posfixa);
            resultado = CalcularResultado();
            return resultado;
        }

        private string EscreverSequencia(FilaLista<string> qualSequencia)
        {
            string seq = "";
            char letra = 'A';
            string[] vet = qualSequencia.ToArray();
            for (int i = 0; i < vet.Length; i++)
            {
                if (EhOperador(vet[i]))
                {
                    if (vet[i] == "@")
                        seq += "-";
                    else
                    seq += vet[i];
                }
                else
                    seq += letra++;
            }
            return seq;
        }

        private void TratarPilhaOperadores()
        {
            while (!operadores.EstaVazia())
            {
                string op = operadores.Desempilhar();
                if (op != "(" && op != ")")
                {
                    posfixa.Enfileirar(op);
                }
            }
        }

        private double CalcularResultado()
        {
            PilhaHerdaLista<double> valores = new PilhaHerdaLista<double>();
            double v1 = 0, v2 = 0, result = 0;
            string[] vet = posfixa.ToArray();

            for (int c = 0; c < vet.Length; c++)
            {
                if (!EhOperador(vet[c]))
                    valores.Empilhar(double.Parse(vet[c].Replace('.', ',')));
                else
                {
                    v1 = valores.Desempilhar();
                    if (vet[c] != "V" && vet[c] != "@")
                        v2 = valores.Desempilhar();

                    switch (vet[c])
                    {
                        case "+": result = v2 + v1; break;
                        case "-": result = v2 - v1; break;
                        case "*": result = v2 * v1; break;
                        case "/": result = v2 / v1; break;
                        case "^": result = Math.Pow(v2, v1); break;
                        case "V": result = Math.Sqrt(v1); break;
                        case "@": result = -v1; break;
                    }
                    valores.Empilhar(result);
                }
            }

            return valores.Desempilhar();
        }

        public static bool EhOperador(string qual)
        {
            switch (qual)
            {
                case "+":
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

        private bool TemPrecedencia(char topo, char operacao)
        {
            switch (topo)
            {
                case '+':
                case '-':
                    if (operacao == '+' || operacao == '-' || operacao == ')')
                        return true; break;

                case '*':
                case '/':
                case '^':
                case 'V':
                    if (operacao == '+' || operacao == '-' || operacao == '*' || operacao == '/' || operacao == ')')
                        return true; break;
                case '(':
                    if (operacao == ')')
                        return true; break;
                case '@': return true; break;

            }
            return false;
        }
    }
}
