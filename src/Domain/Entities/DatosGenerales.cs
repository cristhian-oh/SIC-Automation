namespace Domain.Entities
{
    public class DatosGenerales
    {
        public int CentrosSalud { get; }
        public int PacientesDiagnostico { get; }
        public double PorcentajeMujeres { get; }
        public double PorcentajeHombres { get; }

        public DatosGenerales(int centrosSalud, int pacientesDiagnostico, double porcentajeMujeres, double porcentajeHombres)
        {
            if (centrosSalud < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(centrosSalud), "El número de centros de salud no puede ser menor a 0.");
            }

            if (pacientesDiagnostico < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pacientesDiagnostico), "El número de pacientes con diagnóstico no puede ser menor a 0.");
            }

            if (porcentajeMujeres < 0 || porcentajeMujeres > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(porcentajeMujeres), "El porcentaje de pacientes mujeres debe estar entre 0 y 100.");
            }

            if (porcentajeHombres < 0 || porcentajeHombres > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(porcentajeHombres), "El porcentaje de pacientes hombres debe estar entre 0 y 100.");
            }

            CentrosSalud = centrosSalud;
            PacientesDiagnostico = pacientesDiagnostico;
            PorcentajeMujeres = porcentajeMujeres;
            PorcentajeHombres = porcentajeHombres;
        }
    }
}
