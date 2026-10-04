using Domain.Enums;

namespace Domain.Entities
{
    public class Diagnostico
    {
        public TipoDiagnostico Tipo { get; }
        public int Pacientes { get; }
        public Medicion Medicion { get; }
        public Resultado Resultado { get; }

        public Diagnostico(TipoDiagnostico tipo, int pacientes, Medicion medicion, Resultado resultado)
        {
            if (!Enum.IsDefined(tipo))
            {
                throw new ArgumentException("Valor no válido.", nameof(tipo));
            }

            if (pacientes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pacientes), "La cantidad de pacientes no puede ser menor a 0.");
            }

            if (medicion == null)
            {
                throw new ArgumentNullException(nameof(medicion), "Los valores de medición no pueden ser vacíos.");
            }

            if (resultado == null)
            {
                throw new ArgumentNullException(nameof(resultado), "Los valores de resultado no pueden ser vacíos.");
            }

            Tipo = tipo;
            Pacientes = pacientes;
            Medicion = medicion;
            Resultado = resultado;
        }
    }
}
