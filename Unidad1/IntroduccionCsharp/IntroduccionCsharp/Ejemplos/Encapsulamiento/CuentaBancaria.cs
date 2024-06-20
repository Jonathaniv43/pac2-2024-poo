using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCsharp.Ejemplos.Encapsulamiento
{
    public class CuentaBancaria
    {
        private decimal Saldo { get; set; }

        public CuentaBancaria(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Depositar(decimal cantidad)
        {
            if (cantidad > 0)
            {
                Saldo += cantidad;
            }
            else
            {
                Console.WriteLine("La Cantidad a deposiar debe ser positiva");
            }
        }

        public void Retirar(decimal cantidad)
        {
            if (cantidad > 0 && cantidad <= Saldo)
            {
                Saldo -= cantidad;
                
            }
            else
            {
                Console.WriteLine("Cantidad Invalida para Retirar");
            }
        }

        public decimal ObtenerSaldo()
        {
            return Saldo; 
        }
    }
}
