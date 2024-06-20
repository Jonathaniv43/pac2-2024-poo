using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCsharp.Ejemplos.Herencia
{
    public class EmpleadoTiempoCompleto : Empleado
    { 
        public decimal Bono { get; set; }

        public EmpleadoTiempoCompleto(string nombre, int id, decimal SalarioBase, decimal bono) : base(nombre, id, SalarioBase)
        {
            this.Bono = bono; 
        }

        public override decimal CalcularSalario()
        {
            return SalarioBase + Bono;
        }
    }
}
