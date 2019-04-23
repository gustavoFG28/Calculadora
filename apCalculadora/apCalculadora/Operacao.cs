using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apCalculadora
{
    class Operacao
    { 
        bool[,] precedencia;
        string sequenciaPosFixa;
        string[] vetIn;
        string[] vetPos;
        PilhaHerdaLista<double> valores;
        PilhaHerdaLista<string> operadores;
        double resultado;
        int cont = 0;
        int cont2 = 0;

        public Operacao()
        {
            Resetar();
            precedencia = new bool[100, 100];
            IniciarMatrizPrecedencia();
        }

        public void Resetar()
        {
            sequenciaPosFixa = "";
            valores = new PilhaHerdaLista<double>();
            operadores = new PilhaHerdaLista<string>();
            resultado = 0.0;
            cont = 0;
            cont2 = 0;
        }

        public string Resultar(string texto, ref string seqIn, ref string seqPos)
        {
            vetIn = new string['Z'];
            vetPos = new string['Z'];
            string sequenciaInfixa = texto;
            for (int i = 0; i < sequenciaInfixa.Length; i++)
            {
                string elemento = "";

                if (!EhOperador(sequenciaInfixa[i].ToString()))
                {
                    elemento = "";
                    int inicial = i;
                    while (inicial + elemento.Length < sequenciaInfixa.Length && (!EhOperador(sequenciaInfixa[inicial + elemento.Length].ToString()) || sequenciaInfixa[inicial + elemento.Length] == '.'))
                        elemento += sequenciaInfixa[inicial + elemento.Length];
                    i = inicial + elemento.Length - 1;
                }
                else
                    elemento = sequenciaInfixa[i] + "";
                vetIn[cont++] = elemento;
                TratarElemento(elemento);

            }
            EscreverInfixa(ref seqIn);
            TratarPilhaOperadores();
            EscreverPosfixa(ref seqPos);

            Calcular();

            return resultado.ToString();
        }
        private void EscreverInfixa(ref string seq)
        {
            char pos = 'A';
            for (int i = 0; i < cont; i++)
            {
                if (EhOperador(vetIn[i]))
                    seq += vetIn[i];
                else
                    seq += pos++;

            }
        }
        private void EscreverPosfixa(ref string seq)
        {
            char pos = 'A';
            for (int i = 0; i < cont2; i++)
            {
                if (EhOperador(vetPos[i]))
                    seq += vetPos[i];
                else
                    seq += pos++;

            }
        }
        private void TratarElemento(string c)
        {

            if (!EhOperador(c))
            {
                sequenciaPosFixa += c;
                vetPos[cont2++] = c;
            }
            else
            {
                string operador = c;
                if (operadores.EstaVazia())
                {
                    operadores.Empilhar(operador);
                }
                else
                {
                    do
                    {
                        if (TemPrecedencia(operadores.OTopo()[0], operador[0]))
                        {
                            string op = operadores.Desempilhar();
                            if (op != "(" && op != ")")
                            {
                                sequenciaPosFixa += op;
                                vetPos[cont2++] = op;
                            }

                            if (operadores.EstaVazia())
                            {
                                operadores.Empilhar(operador);
                                break;
                            }
                        }
                        else
                        {
                            operadores.Empilhar(operador);
                            break;
                        }
                    }
                    while (!operadores.EstaVazia());
                }
            }
        }
        private void TratarPilhaOperadores()
        {
            while (!operadores.EstaVazia())
            {
                string op = operadores.Desempilhar();
                if (op != "(" && op != ")")
                {
                    sequenciaPosFixa += op;
                    vetPos[cont2++] = op;
                }
            }
        }
        private void Calcular()
        {
            double v1 = 0, v2 = 0, result = 0;
            for (int c = 0; c < cont2; c++)
            {
                if (!EhOperador(vetPos[c]))
                {
                    valores.Empilhar(double.Parse(vetPos[c].Replace('.', ',')));
                }
                else
                {
                    v1 = valores.Desempilhar();
                    v2 = valores.Desempilhar();
                    switch (vetPos[c])
                    {
                        case "+": result = v2 + v1; break;
                        case "-": result = v2 - v1; break;
                        case "*": result = v2 * v1; break;
                        case "/": result = v2 / v1; break;
                        case "^": result = Math.Pow(v2, v1); break;
                        case "V": result = Math.Pow(v2, 1 / v1); break;
                    }
                    valores.Empilhar(result);
                }
            }

            this.resultado = valores.Desempilhar();
        }
        private void IniciarMatrizPrecedencia()
        {
            precedencia['+', '+'] = true;
            precedencia['+', '-'] = true;
            precedencia['+', '*'] = false;
            precedencia['+', '/'] = false;
            precedencia['+', '^'] = false;
            precedencia['+', 'V'] = false;
            precedencia['+', '('] = false;
            precedencia['+', ')'] = true;
            precedencia['-', '+'] = true;
            precedencia['-', '-'] = true;
            precedencia['-', '*'] = false;
            precedencia['-', '/'] = false;
            precedencia['-', '^'] = false;
            precedencia['-', 'V'] = false;
            precedencia['-', '('] = false;
            precedencia['-', ')'] = true;
            precedencia['*', '+'] = true;
            precedencia['*', '-'] = true;
            precedencia['*', '*'] = true;
            precedencia['*', '/'] = true;
            precedencia['*', '^'] = false;
            precedencia['*', 'V'] = false;
            precedencia['*', '('] = false;
            precedencia['*', ')'] = true;
            precedencia['/', '+'] = true;
            precedencia['/', '-'] = true;
            precedencia['/', '*'] = true;
            precedencia['/', '/'] = true;
            precedencia['/', '^'] = false;
            precedencia['/', 'V'] = false;
            precedencia['/', '('] = false;
            precedencia['/', ')'] = true;
            precedencia['^', '+'] = true;
            precedencia['^', '-'] = true;
            precedencia['^', '*'] = true;
            precedencia['^', '/'] = true;
            precedencia['^', '^'] = true;
            precedencia['^', 'V'] = true;
            precedencia['^', '('] = false;
            precedencia['^', ')'] = true;
            precedencia['V', '+'] = true;
            precedencia['V', '-'] = true;
            precedencia['V', '*'] = true;
            precedencia['V', '/'] = true;
            precedencia['V', '^'] = true;
            precedencia['V', 'V'] = true;
            precedencia['V', '('] = false;
            precedencia['V', ')'] = true;
            precedencia['(', '+'] = false;
            precedencia['(', '-'] = false;
            precedencia['(', '*'] = false;
            precedencia['(', '/'] = false;
            precedencia['(', '^'] = false;
            precedencia['(', 'V'] = false;
            precedencia['(', '('] = false;
            precedencia['(', ')'] = true;


        }

        public bool EhOperador(string qual)
        {
            switch (qual)
            {
                case "+":
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

        public bool TemPrecedencia(char a, char b)
       {
             if (a == ')')
                return false;

            return precedencia[a, b];
       }
       
    }
}
