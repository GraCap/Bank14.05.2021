using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Classi
{
    public abstract class Movement
    {
        public decimal Importo { get; set; }
        public DateTime DataMovimento { get; set; }

        #region Ctor
        public Movement(decimal importo)
        {
            Importo = importo;
            DataMovimento = DateTime.Today;
        }
        #endregion

        #region Prospetto dei dati

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            return $"Data operazione: {DataMovimento.ToShortDateString()}. Importo: {Importo} €. ";
        }

        #endregion
    }
}
