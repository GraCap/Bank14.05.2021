
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classi
{
    class CashMovement : Movement
    {
        public string Esecutore { get; set; }

        #region Ctor
        public CashMovement(decimal importo, string esecutore) : base(importo)
        {
            Esecutore = esecutore;
        }
        #endregion

        #region Prospetto dei dati

        public override string ToString()
        {
            return $"{base.ToString()} Esecutore: {Esecutore}. ";
        }

        #endregion
    }
}
