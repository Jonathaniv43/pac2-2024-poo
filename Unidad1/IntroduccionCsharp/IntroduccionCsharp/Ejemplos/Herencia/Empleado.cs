
namespace IntroduccionCsharp.Ejemplos.Herencia
{
    public class Empleado
    {
        public string? Nombre { get; set; }

        public int Id { get; set; }
        public decimal SalarioBase { get; set; }

        public Empleado()
        {
            
        }

        public Empleado(string nombre, int id, decimal salarioBase)
        {
            this.Nombre = nombre;
            this.Id = id;  
            this.SalarioBase = salarioBase;
        }

        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }
    }

    
}
