using Amazon.DynamoDBv2.DataModel;
using DynamoDBCrud.Entity;

namespace DynamoDBCrud.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDynamoDBContext _context;

        public UsuarioRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task Adicionar(UsuarioEntity usuario)
        {
            await _context.SaveAsync(usuario);
        }

        public async Task Atualizar(UsuarioEntity usuario)
        {
            await _context.SaveAsync(usuario);
        }

        public async Task<IEnumerable<UsuarioEntity>> Buscar(string site)
        {
            return await _context.QueryAsync<UsuarioEntity>(site).GetRemainingAsync();
        }

        public async Task<UsuarioEntity?> Buscar(string site, string email)
        {
            var lista = await _context.QueryAsync<UsuarioEntity>(site, Amazon.DynamoDBv2.DocumentModel.QueryOperator.Equal, new object[] {email})
                .GetRemainingAsync();

            return lista.FirstOrDefault();  
        }

        public async Task Deletar(string site, string email)
        {
            await _context.DeleteAsync<UsuarioEntity>(site, email);
        }
    }
}
