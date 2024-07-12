using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCsharp.Ejemplos.Herencia
{

    public class EmpleadoPorHora : Empleado
    {
        public int HorasTrabajadas { get; set; }
        public decimal TarifaPorHora { get; set; }
        public EmpleadoPorHora(string Nombre, int Id, decimal SalarioBase, int HorasTrabajadas, decimal TarifaPorHoras) : base(Nombre, Id, SalarioBase)
        {
            this.HorasTrabajadas = HorasTrabajadas;
            this.TarifaPorHora = TarifaPorHoras;

        }

        public override decimal CalcularSalario()
        {
            return SalarioBase + (HorasTrabajadas * TarifaPorHora);
        }

    }
}
