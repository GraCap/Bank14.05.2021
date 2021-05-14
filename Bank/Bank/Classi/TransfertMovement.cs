using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classi
{
    public class TransfertMovement : Movement
    {
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        #region Ctor
        public TransfertMovement(decimal importo, string bancaOrigine, string bancaDestinazione) : base(importo)
        {
            BancaOrigine = bancaOrigine;
            BancaDestinazione = bancaDestinazione;
        }
        #endregion

        #region Prospetto dei dati

        public override string ToString()
        {
            return $"{base.ToString()} Banca Origine: {BancaOrigine}. Banca Destinazione: {BancaDestinazione}. ";
        }

        #endregion
    }
}
