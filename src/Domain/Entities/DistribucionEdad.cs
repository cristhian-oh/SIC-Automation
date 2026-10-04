using System.Collections.Immutable;

namespace Domain.Entities
{
    public class DistribucionEdad
    {
        public IReadOnlyList<int> Valores { get; }

        public DistribucionEdad(IReadOnlyList<int> valores)
        {
            if (valores == null)
            {
                throw new ArgumentNullException(nameof(valores), "La lista de distribuciones de edades no puede estar vacía.");
            }

            if (valores.Count == 0)
            {
                throw new ArgumentException("La lista de distribuciones de edades debe contener al menos un elemento.", nameof(valores));
            }

            if (valores.Any(valor => valor < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(valores), "La lista de distribuciones de edades contiene un valor menor a 0.");
            }

            ImmutableList<int> valoresCopia = valores.ToImmutableList();

            Valores = valoresCopia;
        }
    }
}
