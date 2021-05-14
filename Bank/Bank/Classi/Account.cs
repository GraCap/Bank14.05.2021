using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Classi
{
    public class Account
    {
        public int NumConto{ get; set; }
        private static int _numConto { get; set; } = 1;
        public string NomeBanca { get; set; }
        
        public List<Movement> ListaMovimenti { get; set; } = new List<Movement>();

        public decimal Saldo { get; private set; }

        public DateTime DataUltimaOperazione
        {
            get
            {
                DateTime movimentoRecente = ListaMovimenti.Max(mov => mov.DataMovimento);       //restituisce la data più recente
                return movimentoRecente;
            }
        }

        private Dictionary<int, Account> _conti = new Dictionary<int, Account>();

        public bool Esiste(int id)      //mi sarebbe tornata utile per l'interfaccia utente
        {
            return _conti.ContainsKey(id);
        }

        #region Ctor
        public Account(string nomeBanca)
        {
            NumConto = _numConto++;
            NomeBanca = nomeBanca;
        }
        #endregion

        #region Overloading operatori

        //Esegue accredito di denaro
        public static bool operator +(Account conto, Movement movement)
        {
            conto.ListaMovimenti.Add(movement);
            conto.Saldo += movement.Importo;    //aggiorno il saldo a seguito dell'accredito
            return true;
        }

        //Esegue addebito sul conto
        public static bool operator -(Account conto, Movement movement)
        {
            conto.ListaMovimenti.Add(movement);
            conto.Saldo -= movement.Importo;    //aggiorno il saldo a seguito dell'addebito
            return true;
        }

        #endregion

        #region Prospetto dei dati

        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            return $"Conto n°{NumConto}: {NomeBanca} Saldo: {Saldo} €. ";
        }

        public static string Statement(Account conto)
        {
            foreach (var mov in conto.ListaMovimenti)
            {
                Console.WriteLine(mov.ToString());
            }
            return conto.ToString();
        }

        #endregion
       
    }
}
