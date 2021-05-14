using Bank.Classi;
using System;

namespace Bank
{
    class Program
    {
        //private static Account account = new Account("");
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Account account1 = new Account("Mediolanum");
            Account account2 = new Account("Mediolanum");
            Account account3 = new Account("Unicredit");
            Account account4 = new Account("BNP");

            CreditCardMovement mov1 = new CreditCardMovement(130, CreditCardMovement.Tipo.VISA, "7888 1299 2534 8989");
            CreditCardMovement mov2 = new CreditCardMovement(2500, CreditCardMovement.Tipo.MASTERCARD, "9273 1234 5678 9090");
            CreditCardMovement mov3 = new CreditCardMovement(7822,  CreditCardMovement.Tipo.AMEX, "7888 1299 2534 8989");

            CashMovement mov4 = new CashMovement(8000,  "Graziella Caputo");
            CashMovement mov5 = new CashMovement(3000, "Karanjit Kaur");
            CashMovement mov6 = new CashMovement(8000,  "Ilaria Bonelli");

            TransfertMovement mov7 = new TransfertMovement(490, "Mediolanum","Unicredit");
            TransfertMovement mov8 = new TransfertMovement(490,  "Unicredit", "BNP");
            TransfertMovement mov9 = new TransfertMovement(490,  "Unicredit", "Mediolanum");


            
            if (account3 + mov1)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account3.NumConto} \n{mov1.ToString()} \nSaldo aggiornato: {account3.Saldo} €\n");
            if (account3 + mov4)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account3.NumConto} \n{mov4.ToString()} \nSaldo aggiornato: {account3.Saldo} €\n");
            if (account3 + mov7)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account3.NumConto} \n{mov7.ToString()} \nSaldo aggiornato: {account3.Saldo} €\n");

            if (account3 - mov2)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account3.NumConto} \n{mov2.ToString()} \nSaldo aggiornato: {account3.Saldo} €\n");

            if (account1 + mov3)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account1.NumConto} \n{mov3.ToString()} \nSaldo aggiornato: {account1.Saldo} €\n");
            if (account1 - mov5)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account1.NumConto} \n{mov5.ToString()} \nSaldo aggiornato: {account1.Saldo} €\n");

            if (account2 + mov6)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account2.NumConto} \n{mov6.ToString()} \nSaldo aggiornato: {account2.Saldo} €\n");
            if (account2 - mov8)
                Console.WriteLine($"Operazione eseguita con successo su conto n°:{account2.NumConto} \n{mov8.ToString()} \nSaldo aggiornato: {account2.Saldo} €\n");

            
            //Stampo il prospetto di uno degli account
            Console.WriteLine(Account.Statement(account1));
            Console.WriteLine($"Data Ultima Operazione {account1.DataUltimaOperazione.ToShortDateString()}");

           
        }

        //Stavo provando a realizzare un'interfaccia utente per poter inserire dati in input ma non sono riuscita a completarlo
        #region Prova Inserimento dati Utente
        private static void InterfacciaUtente()
        {
            do
            {
                Console.WriteLine("a. Crea un nuovo conto");
                Console.WriteLine("b. Effettua un versamento");
                Console.WriteLine("c. Preleva denaro");
                Console.WriteLine("d. Visualizza prospetto");
                switch (Console.ReadKey().Key)     //Console.ReadKey().Kchar con i case '1' '2' ecc
                {
                    case ConsoleKey.A:
                        CreaConto();
                        break;
                    case ConsoleKey.B:
                        Versa();
                        break;
                    case ConsoleKey.C:
                        Preleva();
                        break;
                    case ConsoleKey.D:
                        VisualizzaProspetto();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;

                }
                Console.WriteLine("Vuoi provare ancora (s/n)?");
            } while (Console.ReadKey().Key == ConsoleKey.S);
        }
        #region Prospetto
        private static void VisualizzaProspetto()
        {
            int id;
            do
                Console.Write("Diquale conto vuoi visualizzare il prospetto? ");
            while (!int.TryParse(Console.ReadLine(), out id));
           // recuperare il conto tramite id e chiamare il metodo statement ---> Account.Statement(conto)
        }
        #endregion

        #region Creazione nuovo conto
        private static Account CreaConto()
        {
            string nomeBanca = "";
            Console.Write("Inserisci il nome della banca in cui vuoi creare un nuovo conto: ");
            nomeBanca = Console.ReadLine();

           return new Account(nomeBanca);
        }
        #endregion

        #region Prelievo e Versamento
        private static void Preleva()
        {
            int id;
            decimal importo;

            do
                Console.Write("Da quale conto vuoi prelevare denaro? ");
            while (!int.TryParse(Console.ReadLine(), out id));
            //recuperare il conto tramite l'id 
                do
                    Console.Write("Inserire importo: ");
                while (!decimal.TryParse(Console.ReadLine(), out importo));

            //if (account.Esiste(id))
            //{
            //    account- ModalitaDiTrasferimento(importo);
            //}
            //else
            //    Console.WriteLine("Il conto indicato non è presente nei nostri sistemi.");

            //effettuare operazione sul conto indicato conto - ModalitaDiTrasferimento(importo)
            ModalitaDiTrasferimento(importo);

        }

        private static void Versa()
        {
            int id;
            decimal importo;

            do
                Console.Write("Su quale conto vuoi versare denaro? ");
            while (!int.TryParse(Console.ReadLine(), out id));
            //recuperare il conto tramite l'id 
            do
                Console.Write("Inserire importo: ");
            while (!decimal.TryParse(Console.ReadLine(), out importo));

            //effettuare operazione sul conto indicato conto + ModalitaDiTrasferimento(importo)
            ModalitaDiTrasferimento(importo);
        }

        #endregion

        #region Scelta Movimento
        private static Movement ModalitaDiTrasferimento(decimal importo)
        {
            Console.Write("In che modo vuoi trasferire il tuo denaro? ");
            do
            {
                
                Console.WriteLine("a. Movimento con carta di credito");
                Console.WriteLine("b. Bonifico Bancario");
                Console.WriteLine("c. Trasferimento in contanti");
                switch (Console.ReadKey().Key)     //Console.ReadKey().Kchar con i case '1' '2' ecc
                {
                    case ConsoleKey.A:
                        CreditCardMovement mov1 = NewCreditCardMovement(importo);
                        return mov1;
                    case ConsoleKey.B:
                        TransfertMovement mov2 = NewTransfertMovement(importo);
                        return mov2;
                    case ConsoleKey.C:
                        CashMovement mov3 = NewCashMovement(importo);
                        return mov3;
                    default:
                        break;
                }
            } while (true);
           
        }

        
        private static CashMovement NewCashMovement(decimal importo)
        {
            string esecutore = "";
            Console.Write("Inserisci nome esecutore: ");
            esecutore = Console.ReadLine();

            return new CashMovement(importo, esecutore);

        }

        private static TransfertMovement NewTransfertMovement(decimal importo)
        {
            string bancaOrigine = "";
            Console.Write("Inserisci banca origine: ");
            bancaOrigine = Console.ReadLine(); 
            string bancaDestinazione = "";
            Console.Write("Inserisci banca destinazione: ");
            bancaDestinazione = Console.ReadLine();

            return new TransfertMovement(importo, bancaOrigine, bancaDestinazione);

        }

        private static CreditCardMovement NewCreditCardMovement(decimal importo)
        {
            string numCarta = "";
            Console.WriteLine("\nInserisci il tipo di carta");
            Console.WriteLine("a. AMEX");
            Console.WriteLine("b. MASTERCARD");
            Console.WriteLine("c. VISA");
            Console.WriteLine("d. OTHER");

            CreditCardMovement.Tipo tipo = CreditCardMovement.Tipo.OTHER;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    tipo = CreditCardMovement.Tipo.AMEX;
                    break;
                case ConsoleKey.B:
                    tipo = CreditCardMovement.Tipo.MASTERCARD;
                    break;
                case ConsoleKey.C:
                    tipo = CreditCardMovement.Tipo.VISA;
                    break;
                case ConsoleKey.D:
                    tipo = CreditCardMovement.Tipo.OTHER;
                    break;
                default:
                    break;
            }
           
                Console.Write("Inserisci numero carta: ");
             numCarta = Console.ReadLine();

            return new CreditCardMovement(importo, tipo, numCarta);
        }

        #endregion
        #endregion
    }
}
