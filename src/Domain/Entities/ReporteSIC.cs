using Domain.Enums;
using System.Collections.Immutable;

namespace Domain.Entities
{
    public class ReporteSIC
    {
        public UnidadSalud Unidad { get; }
        public DatosGenerales DatosGenerales { get; }
        public IReadOnlyList<Diagnostico> Diagnosticos { get; }
        public DistribucionEdad DistribucionEdad { get; }
        public DateTime FechaActualizacion { get; }

        public ReporteSIC(UnidadSalud unidad, DatosGenerales datosGenerales, IReadOnlyList<Diagnostico> diagnosticos, DistribucionEdad distribucionEdad, DateTime fechaActualizacion)
        {
            if (unidad == null)
            {
                throw new ArgumentNullException(nameof(unidad), "Se debe recibir la información de la unidad de salud.");
            }

            if (datosGenerales == null)
            {
                throw new ArgumentNullException(nameof(datosGenerales), "Se deben recibir los datos generales del reporte.");
            }

            if (diagnosticos == null)
            {
                throw new ArgumentNullException(nameof(diagnosticos), "Se deben recibir los diagnósticos.");
            }

            if (diagnosticos.Count == 0)
            {
                throw new ArgumentException("La lista de diagnósticos debe contener al menos un elemento.", nameof(diagnosticos));
            }

            if (diagnosticos.Any(diagnostico => diagnostico == null))
            {
                throw new ArgumentNullException(nameof(diagnosticos), "Los diagnósticos no pueden estar vacíos.");
            }

            bool existenDuplicados = diagnosticos.GroupBy(d => d.Tipo).Any(x => x.Count() > 1);
            if (existenDuplicados)
            {
                throw new ArgumentException("La lista de diagnósticos tiene diagnósticos duplicados.", nameof(diagnosticos));
            }

            if (diagnosticos.Count != Enum.GetValues<TipoDiagnostico>().Length)
            {
                throw new ArgumentException("La lista de diagnósticos debe contener uno de cada tipo de diagnóstico.", nameof(diagnosticos));
            }

            if (distribucionEdad == null)
            {
                throw new ArgumentNullException(nameof(distribucionEdad), "Se debe recibir la lista de distribución de edades.");
            }

            if (fechaActualizacion == DateTime.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(fechaActualizacion), "Fecha no válida.");
            }

            Unidad = unidad;
            DatosGenerales = datosGenerales;
            ImmutableList<Diagnostico> diagnosticosCopia = diagnosticos.ToImmutableList();
            Diagnosticos = diagnosticosCopia;
            DistribucionEdad = distribucionEdad;
            FechaActualizacion = fechaActualizacion;
        }
    }
}
