using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade___Linguagens_Formais_e_Autômatos
{
    class Tape
    {
        MT turingMachine;
        public char Delimiter;
        String input = "";
        string output = "";
        public string processing = "";
            
        public Tape(MT turingMachine)
        {
            this.turingMachine = turingMachine;
        }
        public string Input
        {
            get
            {
                return input;
            }

            set
            {
                foreach (char letra in value)
                {
                    if (turingMachine.AlphabetTape.IndexOf(letra) == -1)
                        throw new TuringExcpetion("Verifique se seus elemento de entrada pertecente ao alfabeto da fita");
                }

                input = value;
            }
        }
        public String FillOutTape()
        {
            String TapeFilled = "";

            TapeFilled += "{   ";

            TapeFilled += " q" + turingMachine.States[turingMachine.States.Length - 1] + "  " + Delimiter;
            
            TapeFilled += " q" + turingMachine.InitialState + "  " + Delimiter;
            
            foreach (char item in turingMachine.FinalState)
                TapeFilled += " q" + item + "  " + Delimiter;
      
            foreach (char item in turingMachine.Alphabet)
                TapeFilled +=  " " + item + "  " + Delimiter;

            foreach (char item in turingMachine.AlphabetTape)
                TapeFilled += " " +  item + "  " + Delimiter;

                TapeFilled += "\n";

            foreach (Transition item in turingMachine.Transitions)
                TapeFilled += item.getTransitionStringDefault() + Delimiter;

            TapeFilled += " }   \n";

            TapeFilled += "{   ";
             foreach (char item in input)
                TapeFilled += " " + item + " " + Delimiter;
            TapeFilled += " }   \n";

            TapeFilled += "{   ";
            foreach (char item in output)
                TapeFilled += " " + item + " " + Delimiter;
            TapeFilled += " }   \n";

            TapeFilled += "{    ";
            TapeFilled += turingMachine.Symbolwhite;
            TapeFilled += " }   \n";


            return TapeFilled;
        }
        /* validação do input */
        public bool validateInput()
        {

            int stateCurrent = turingMachine.InitialState,
                equals = 0;
         
            var searhStateInit = turingMachine.Transitions.Where
                                 (si => int.Parse(si.stateOrigin.ToString()) == turingMachine.InitialState);
    
            foreach (Transition t in searhStateInit)
            {
                if (input[0].Equals(t.elementRead))
                    equals++;
            }
         
            if(equals < 1)
                throw new TuringExcpetion("Verifique se seu primeiro símbolo lido sai de um estado inicial");


            this.output = this.input;
            this.output += turingMachine.Symbolwhite;

            for (int head = 0; head < output.Length;)
            {

                foreach (Transition t in turingMachine.Transitions)
                {

                    if (output[head].Equals(t.elementRead)
                        && int.Parse(t.stateOrigin.ToString()).Equals(stateCurrent))
                    {
                        if (head < 0)
                        {
                            processing += "\n \t Seu cabeçote foi direcionada para uma célula inexistente";
                            return false;
                        }

                        processing += "Read (" + t.elementRead + ") in state (q" + t.stateOrigin + ") ";

                        stateCurrent = int.Parse(t.stateDestination.ToString());

                        if (t.Direction == 'R')
                        {
                            output = this.ReplaceAt(output, head, t.elementWrite);
                            head++;
                            processing += "write (" + t.elementWrite + ") in state (q" + stateCurrent + "), GO Right > , repeat \n";
                            // processing += "Posição do cabeçote: " + head + "\n";
                        }
                        else if (t.Direction == 'L')
                        {

                            output = this.ReplaceAt(output, head, t.elementWrite);
                            head--;
                            processing += "write (" + t.elementWrite + ") in state (q" + stateCurrent + "), GO Left < , repeat \n";
                            // processing += "Posição do cabeçote: " + head + "\n";
                        }

                        else if (t.Direction == 'H')
                        {

                            processing += "write (" + t.elementWrite + ") in state (q" + stateCurrent + "), HALT! \n";
                            output = this.ReplaceAt(output, head, t.elementWrite);
                            if (!isStateAccept(stateCurrent))
                                return false;
                            else
                                return true;
                        }
                        break;
                    }
                    else
                    {
                        if (t.Equals(turingMachine.Transitions.Last()))
                        {
                            processing += "Não existe nenhuma transição que atenda ao caractere";
                            return false;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            
            }

            if (!isStateAccept(stateCurrent))
                return false;
            else
                return true;       
        }

        /* métodos para conversão em binário */
        public string BinaryTape()
        {
            return ConvertToBinaryTape(this.FillOutTape());
        }
        private String ConvertToBinaryTape(String tape)
        {
            // celulas da fita
            List<String> cells = new List<String>();
            String BinaryString = "";
            var binary = "";
            tape = RemoverCharInvalid(tape, "qδ()->{ }:, ");

            /*
            adicionamos dentro da lista de string várias strings de binários que representa
            cada letra passada no parâmetro , é aqui que precisamos colocar todas as informações úteis da fitas em binário, 
            ou seja,precisamos converter a string em um array de char, cada char transformar em número e cada número transformar em binario.
            */

            foreach (char letra in tape)
            {

                if (letra == this.Delimiter)
                {
                    binary = Conversao.DecimalParaBinario("99");
                }

                else if (letra == turingMachine.Symbolwhite)
                {
                    binary = Conversao.DecimalParaBinario("100");
                }
                else
                {
                    binary = Conversao.DecimalParaBinario(Conversao.CharToNum(letra).ToString());
                }
                cells.Add(binary);
                //cells.Add("Binário: (" + binary + ")" + "   Letra: (" + letra + ")" + "  Numero: (" + Conversao.CharToNum(letra) + ")" + " | \n");
            }


            // criamos uma string concatenando com cada array de string
            var maiorString = "";

            // procuro a maior string no array
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells.ElementAt(i).Length > maiorString.Length)
                    maiorString = cells.ElementAt(i);
            }


            foreach (string item in cells)
            {

                if (item.Length == maiorString.Length)
                {
                    BinaryString += item + " ";
                }
                else
                {
                    for (int j = item.Length; j < maiorString.Length; j++)
                    {
                        BinaryString += '0';
                    }

                    BinaryString += item + " ";
                }
            }

            return BinaryString;
        }
        /* métodos auxiliares */
        private string RemoverCharInvalid(String oldString, String caracteresInvalid)
        {

         foreach(char letra in caracteresInvalid)
         {
           oldString = oldString.Replace(letra.ToString(), "");
         }

            return oldString;
        }
        private string ReplaceAt(string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
        private bool isStateAccept(int state)
        {
            if (turingMachine.FinalState.IndexOf(state.ToString()) == -1) {
                processing += "\n \t x Você chegou em um estado de rejeição!";
                return false;
            }
            else
            {
                processing += "\n \t x Você chegou em um estado de Aceitação!";
                return true;
            }
                
                
        }
       
    }
}

