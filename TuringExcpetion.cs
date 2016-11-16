using System.Windows.Forms;
using System;


namespace Faculdade___Linguagens_Formais_e_Autômatos
{
    class TuringExcpetion : Exception
    {
        public TuringExcpetion(String error)
        {
            MessageBox.Show(error + "\n -> Máquina Inválida <-", " ERROR ");
            //Application.Exit();
        }
    }
}
