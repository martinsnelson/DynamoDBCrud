using DynamoDBCrud.Entity;

namespace DynamoDBCrud.Repositories
{
    public interface IUsuarioRepository
    {
        Task Adicionar(UsuarioEntity usuario);
        Task Atualizar(UsuarioEntity usuario);
        Task<IEnumerable<UsuarioEntity>> Buscar(string site);
        Task<UsuarioEntity?> Buscar(string site, string email);
        Task Deletar(string site, string email);

    }
}
