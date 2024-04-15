using Amazon.DynamoDBv2.DataModel;

namespace DynamoDBCrud.Entity
{
    [DynamoDBTable("erp-table")]
    public class UsuarioEntity
    {
        [DynamoDBHashKey("pk")]
        public string Site { get; set; }

        [DynamoDBRangeKey("sk")]
        public string Email { get; set; }
        
        [DynamoDBProperty]
        public string Cidade { get; set; }
        
        [DynamoDBProperty]
        public string Nome { get; set; }
        
        [DynamoDBProperty]
        public string Senha { get; set; }
    }
}
