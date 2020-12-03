namespace DIA_BANCO_V1 {
    using Core;
    using System;
    
    public class ConsoleUI
    {
        public static int Menu()
        {
            int toret = 0;
            
            Console.WriteLine("\nPrestamos");
            Console.WriteLine("1. Lista de Prestamos");
            Console.WriteLine("2. Inserta nuevo Prestamo");
            Console.WriteLine("3. Edita un Prestamo");
            Console.WriteLine("4. Elimina un Prestamo");
            Console.WriteLine("0. Fin");
            
            do
            {
                Console.WriteLine("\nSelecciona (0-4): ");

                if (!int.TryParse(Console.ReadLine(), out toret))
                {
                    toret = -1;
                }

            } while (toret < 0 && toret > 4);

            return toret;
        }

        public static Prestamo PideDatos()
        {
            string idP;
            string cccOri;
            string cccDes;
            double amount;
            string date;
            
            Console.WriteLine("ID del Prestamo: ");
            idP = Console.ReadLine();

            Console.WriteLine("Cuenta corriente Origen: ");
            cccOri = Console.ReadLine();
            
            Console.WriteLine("Cuenta corriente Destino: ");
            cccDes = Console.ReadLine();
            
            Console.WriteLine("Importe del Prestamo: ");
            amount = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Fecha del Prestamo (dd-MM-yyyy): ");
            date = Console.ReadLine();
        
            return new Prestamo(idP,cccOri,cccDes,amount,date);
        }

        public static string PideIDBorrado()
        {
            string idP;
            
            Console.WriteLine("ID del Prestamo: ");
            idP = Console.ReadLine();

            return idP;
        }

        public static void MainLoop(string[] args)
        {
            int op;
            RegistroPrestamos prestamos = RegistroPrestamos.RecuperaXml();

            op = Menu();
            while (op != 0)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine(prestamos.ToString());
                        break;
                    case 2:
                        try
                        {
                            prestamos.Add(PideDatos());
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("\nYa existe un Prestamo con ese Identificador");
                        }
                        break;
                    case 3:
                        try
                        {
                            prestamos.Edit(PideDatos());
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("\nNo existe un Prestamo con ese Identificador");
                        }
                        break;
                    case 4:
                        try
                        {
                            prestamos.Remove(PideIDBorrado());
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("\nNo existe un Prestamo con ese Identificador");
                        }
                        break;
                        
                        
                }

                op = Menu();
            }
            
            prestamos.GuardaXml();
            return;
        }
    }
}