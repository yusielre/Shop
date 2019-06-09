namespace Shop.Web.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        //bool WasDeleted { get; set; }   Esto pudiera usarse para que el usuario elimine un dato de un Entities y realmete no se elimina,
        //sino solo se escondería tras este campo, para darle después la opcion al usuario de recuperar esa información
    }
}
