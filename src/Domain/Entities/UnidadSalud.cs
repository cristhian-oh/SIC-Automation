namespace Domain.Entities
{
    public class UnidadSalud
    {
        public string Clave { get; }

        public string Descripcion
        {
            get;

            private set;
        }

        public UnidadSalud(string clave, string descripcion)
        {
            if (String.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException("Se debe proporcionar la clave de la unidad.", nameof(clave));
            }

            if (String.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción de la unidad es obligatoria.", nameof(descripcion));
            }

            Clave = clave.Trim();
            Descripcion = descripcion.Trim();
        }

        public void ActualizarDescripcion(string descripcion)
        {
            if (String.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La nueva descripción de la unidad no puede estar vacía.", nameof(descripcion));
            }

            Descripcion = descripcion.Trim();
        }
    }
}
