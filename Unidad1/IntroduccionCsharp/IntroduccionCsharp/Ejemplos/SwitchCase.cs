

namespace IntroduccionCsharp.Ejemplos
{
    public class SwitchCase
    {
        public SwitchCase()
        {
            int opc = 0;

            Console.WriteLine("Hola Elija una Opción \n1. Iniciar \n2. Detener \n3. Reiniciar \n4. Estado  \n (Elija una opcion:)");
            opc = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                //opc = int.Parse(Console.ReadLine());


                switch (opc)
                {
                    case 1:
                        Console.WriteLine("Iniciando Proceso...");
                        break;
                    case 2:
                        Console.WriteLine("Deteniendo Proceso..");
                        break;
                    case 3:
                        Console.WriteLine("Reinciciando Proceso...");
                        break;
                    case 4:
                        Console.WriteLine("Actualmente esta...");
                        break;
                    default:
                        Console.WriteLine("No existe la opción");
                        break;

                }
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine("Ha ocurrido un error" + ex.Message);
                }


            }
        }

        public void SwitchCaseSinTryCatch()
        {
            int opc = 0;

            Console.WriteLine("Hola Elija una Opción \n1. Iniciar \n2. Detener \n3. Reiniciar \n4. Estado  \n (Elija una opcion:)");

            opc = int.Parse(Console.ReadLine() ?? "0");
            switch (opc)
            {
                case 1:
                    Console.WriteLine("Iniciando Proceso...");
                    break;
                case 2:
                    Console.WriteLine("Deteniendo Proceso..");
                    break;
                case 3:
                    Console.WriteLine("Reinciciando Proceso...");
                    break;
                case 4:
                    Console.WriteLine("Actualmente esta...");
                    break;
                default:
                    Console.WriteLine("No existe la opción");
                    break;
            }
        }
    }
}
