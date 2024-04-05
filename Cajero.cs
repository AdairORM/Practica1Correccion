using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1Correccion
{
    internal class Cajero
    {
        #region Atributos
        private int nip;
        private double saldo;
        private bool nipCorrecto;
        #endregion

        #region Propiedades

        public double Saldo 
        {
            get => saldo;
            set
            {
                if (value > 0 || value < 1)
                {
                    saldo = 0;
                }
                else
                {
                    saldo = value;
                }
                saldo = value;
            }
        }

        public bool NipCorrecto 
        { 
            get => nipCorrecto;
            set => nipCorrecto = value; 
        }


        #endregion

        #region Constructor

        public Cajero()
        {
            Console.WriteLine("Ingrese su tarjeta");
            SolicitarNip();
            Saldo = 40000;
            if (NipCorrecto)
            {
                DesplegarMenu();
            }
            else
            {
                Console.WriteLine("NIP incorrecto. Vuelva a intentar.");
                nip = SolicitarNip();
                NipCorrecto = ValidarNip(nip);
                if (NipCorrecto)
                {
                    DesplegarMenu();
                }
                else
                {
                    Console.WriteLine("NIP incorrecto. Tarjeta bloqueada.");
                }
            }
        }

        #endregion


        #region Métodos

        public bool ValidarNip(int nip)
        {
            if (this.nip == nip)
            {
                Console.WriteLine("Nip correcto, Sea bienvenido a su cuenta");
                return true;
            }
            else
            {
                Console.WriteLine("Nip incorrecto, vuelva a itentarlo por favor");
                return false;
            }
        }

        public int SolicitarNip()
        {
            Console.WriteLine("Bienvenido al Cajero Automatico de confianza");
            Console.WriteLine("Por favor Ingresa el NIP de tu tarjeta: ");
            int nip = int.Parse(Console.ReadLine());
            return nip;
        }

        public void DesplegarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Bienvenido a su Cajero Automatico");
                Console.WriteLine("Seleccione la transaccion a realizar");
                Console.WriteLine("1. Consulta de saldo");
                Console.WriteLine("2. Retiro de efectivo");
                opcion = int.Parse(Console.ReadLine());
            } while (opcion < 1 || opcion > 2);

            switch (opcion)
            {
                case 1:
                    ConsultaSaldo(saldo);
                    break;
                case 2:
                    OpcionesRetiroEfectivo(saldo);
                    break;
                default:
                    Console.WriteLine("Opcion no disponible");
                    break;
            }
        }

        public void ConsultaSaldo(double saldo)
        {
            Console.WriteLine("Tu saldo disponible es: " + saldo);
            OtraTransaccion();
        }

        public void OpcionesRetiroEfectivo(double saldo)
        {
            Console.WriteLine("Tu saldo disponible es: " + saldo);
            Console.WriteLine("Cuanto deseas retirar? (ingrese la cantidad requerida)");
            double retiro = double.Parse(Console.ReadLine());

            if (retiro <= saldo)
            {
                this.saldo -= retiro;
                Console.WriteLine("Reciba su dinero, cuentelo bien");
                Console.WriteLine("Su nuevo saldo es " + this.saldo);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para el retiro");
            }
            OtraTransaccion();
        }


        public void OtraTransaccion()
        {
            int opcion;
            do
            {
                Console.WriteLine("Quiere realizar otra transacción? : ");
                Console.WriteLine("1. Si         2. No");
                opcion = int.Parse(Console.ReadLine());
            } while (opcion < 1 || opcion > 2);

            if (opcion == 1)
            {
                DesplegarMenu();
            }
            else
            {
                Console.WriteLine("Gracias por tu preferencia!");
                Console.WriteLine("Retire su tarjeta");
            }
        }

        #endregion
    }
}
