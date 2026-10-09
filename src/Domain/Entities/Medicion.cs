namespace Domain.Entities
{
    public class Medicion
    {
        public string Nombre { get; }
        public double Porcentaje { get; }

        public Medicion(string nombre, double porcentaje) {
            if (String.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
            }

            if (porcentaje < 0 || porcentaje > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(porcentaje), "El porcentaje debe estar entre 0 y 100.");
            }

            Nombre = nombre.Trim();
            Porcentaje = porcentaje;
        }
    }
}
