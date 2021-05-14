using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classi
{
    public class CreditCardMovement : Movement
    {
        public enum Tipo
        {
            AMEX,
            VISA,
            MASTERCARD,
            OTHER
        }

        public Tipo TipoCarta { get; set; }
        public string NumeroCarta { get; set; }

        #region Ctor

        public CreditCardMovement(decimal importo, Tipo tipo, string numeroCarta) : base(importo)
        {
            TipoCarta = tipo;
            NumeroCarta = numeroCarta;
        }
        #endregion

        #region Prospetto dei dati

        public override string ToString()
        {
            return $"{base.ToString()} Carta: {TipoCarta}. Numero: {NumeroCarta}. " ;
        }

        #endregion
    }
}
