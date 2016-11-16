using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculdade___Linguagens_Formais_e_Autômatos
{

    /**
    T = (Q, Σ, Γ, q0, δ)
    Q:  Número de estados;
    Σ:  Número de símbolos do alfabeto;
    Γ:  Número de símbolos da fita;
    q0: Código do estado inicial;
    δ:  Codificação da função de transição

    ∂(an,qm) = (ap, qr, ds)
    an: Código do símbolo lido;
    qm: Código do estado atual da máquina;
    ap: Código do símbolo escrito;
    qr: Código do novo estado;
    ds: Código da direção (esq, dir, halt)
    
    Ex:
    Q:  q0 q1 q2 q3 q4 q5 q6 ... ;
    Σ:  a b c d e ... ;
    Γ:  A B C D E ... ;
    q0: q0;
    δ:  (a, Q, b, W, L/R) ... ;
*/


    class MT
    {

        public List<Transition> Transitions = new List<Transition>();
        private String alphabet;
        private String states;
        private String Finalstate;
        private int initialState;
        private char SymbolWhite = '#'; // ?? 
        private String alphabetTape;

        public string States
        {
            get
            {
                states.Replace(",", "");
                states.Replace(" ", "");

        
                return states;
            }

            set
            {
               
                if (value.Length > 1)
                    throw new TuringExcpetion("Is only supported 9 states");
                if(!char.IsDigit(value[0]))
                    throw new TuringExcpetion("Is only supported numbes");

                else
                {
                    var tam = 0;

                    if (value == "")
                        value = 0.ToString();

                    while (tam <= int.Parse(value))
                    {
                        states += tam;
                        tam++;
                    }
                }

          
            }
        }
        public string FinalState
        {
            get
            {
                return Finalstate;
            }

            set
            {
                if (states.IndexOf(value.ToString()) == -1)
                    throw new TuringExcpetion("Seu estado de aceitação não pertentece aos estados");
                if (!char.IsDigit(value[0]))
                    throw new TuringExcpetion("Is only supported numbes");

                Finalstate = value;
            }
        }
        public int InitialState
        {
            get
            {
                return initialState;
            }

            set
            {
                if (states.IndexOf(value.ToString()) == -1)
                    throw new TuringExcpetion("Seu estado inicial não pertentece aos estados");
                if (!Char.IsDigit(Char.Parse(value.ToString())))
                    throw new TuringExcpetion("Is only supported numbes");


                initialState = value;
            }
        }
        public string Alphabet
        {
            get
            {
               
                return alphabet;
            }
            set
            {
              value = value.Replace(",", "");
              value = value.Replace(" ", "");
                alphabet = value;
            }
        }
        public char Symbolwhite
        {
            get
            {
                return SymbolWhite;
            }

            set
            {
                SymbolWhite = value;
            }
        }
        public string AlphabetTape
        {
            get
            {
                return alphabetTape;
            }

            set
            {
                value = value.Replace(",", "");
                value = value.Replace(" ", "");
                /*
                if (Alphabet.IndexOf(value) == -1)
                    throw new TuringExcpetion("O alfabeto da fita requer os elementos do alfabeto");
                    */

             
                    alphabetTape = value;
                    alphabetTape += this.Symbolwhite;
            }
        }
        public void validateTransition(List<Transition> list)
        {
            foreach (Transition t in list)
            {
                if (!t.Direction.Equals('L') && !t.Direction.Equals('R') && !t.Direction.Equals('H'))
                {
                    throw new TuringExcpetion("Direção da transição " + t.getTransitionStringDefault() + " Incorreta .Erro 01" );
                }
                else if (this.alphabet.IndexOf(t.elementRead) == -1
                         && this.alphabetTape.IndexOf(t.elementRead) == -1)
                {
                    throw new TuringExcpetion("Os elementos/símbolos de leitura não faz parte do alfabeto da fita. (Elemento: " + t.elementRead + ") Erro 02");
                }
                else if (this.alphabet.IndexOf(t.elementWrite) == -1
                         & this.AlphabetTape.IndexOf(t.elementWrite) == -1)
                {
                    throw new TuringExcpetion("Os elementos/símbolos de leitura não fazem parte do alfabeto da fita. (Elemento: " + t.elementWrite + ") Erro 03");
                }
                else if (this.states.IndexOf(char.ConvertFromUtf32(t.stateDestination)) == -1
                      || this.states.IndexOf(char.ConvertFromUtf32(t.stateOrigin)) == -1)
                {
                    throw new TuringExcpetion("Verifique o(s) estado(s) da(s) suas transições Erro 04");
                }
            }
        }
        public void setFuctionOfTransisiton(String TransitionString)
        {
 
            TransitionString = TransitionString.Replace(" ", "");
            TransitionString = TransitionString.Replace(",", "");

            if(TransitionString.Length < 5)
            {
                throw new TuringExcpetion("É necessário pelo menos uma matriz de transição");
            }

            if (TransitionString.Length % 5 == 0)
            {
                for (int i = 0; i < TransitionString.Length; i += 5)
                {
                    Transition t = new Transition();
                    t.elementRead = TransitionString[i];
                    t.stateOrigin = TransitionString[i + 1];
                    t.elementWrite = TransitionString[i + 2];
                    t.stateDestination = TransitionString[i + 3];
                    t.Direction = TransitionString[i + 4];
                    Transitions.Add(t);
                }
            } 
            else
                throw new TuringExcpetion("Cada transição requer tamanho 5");



            validateTransition(this.Transitions);
            }
        
    }
}




