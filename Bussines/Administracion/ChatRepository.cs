using Bussines.DB;
using Db.Schemas;
using Microsoft.Extensions.Configuration;
using Objects.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Administracion
{
    public class ChatRepository : ConnectionDB
    {
        public ChatRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }

        private new readonly IConfiguration configuration;


        public async Task<IEnumerable<ChatMensajes>> GetMensajes(int idChat)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{ChatMensajesSchema.IntIdChat} = {idChat}",

                    "1=1"
                };

                return await db.Query<ChatMensajes>($"SELECT * FROM { ChatMensajesSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {ChatMensajesSchema.IntIdMensajeChat}", idChat
                );
            }
        }
        public async Task<ChatMensajes> CreateMesaje(ChatMensajes model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }

        public async Task<Chat> CrearChat(Chat model) {
            using (var db = Connection)
            {
                if (model.IntIdChat == 0)
                {
                    db.Add(model);
                    await db.SaveChangesAsync();
                }
                return model;
            }
        }
    }
}
