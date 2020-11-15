using System;
using Loja.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Loja.Data
{
    public class MongoDB
    {
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["DatabaseName"]);
                MapClasses();
            }
            catch (Exception ex)
            { 
                throw new MongoException("Não foi possível conectar ao banco de dados", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };

            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Produtos)))
            {
                BsonClassMap.RegisterClassMap<Produtos>(i => 
                {
                    i.AutoMap(); // Mapeia todas as propriedades automáticamente poderia fazer uma a uma
                    // i.MapProperty(f => f.DataNascimento);
                    // i.MapProperty(f => f.Localizacao);
                    // i.MapProperty(f => f.Sexo);
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
        public IMongoDatabase DB { get; set; }
    }
}