using System.Data.Entity;

namespace DAL
{
    public class Inicializador : DropCreateDatabaseAlways<ModeloGastronomiaContainer>
    {
        protected override void Seed(ModeloGastronomiaContainer context)
        {
            context.Mesas.Add(new Mesa()
            {
                EstadoMesa = EstadoMesa.Libre,
                Numero = 1,
                Descripcion = "Mesa 1",
            });
            //
            context.Mesas.Add(new Mesa()
            {
                EstadoMesa = EstadoMesa.Libre,
                Numero = 2,
                Descripcion = "Mesa 2",
            });

            context.Mesas.Add(new Mesa()
            {
                EstadoMesa = EstadoMesa.Libre,
                Numero = 3,
                Descripcion = "Mesa 3",
            });

            context.Mesas.Add(new Mesa()
            {
                EstadoMesa = EstadoMesa.Libre,
                Numero = 4,
                Descripcion = "Mesa 4",
            });
            context.Usuarios.Add(new Usuario()
            {
                Nombre = "Admin",
                Password = "1234",
                EstaBloqueado = false
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
