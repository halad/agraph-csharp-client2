﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Allegro_Graph_CSharp_Client.AGClient.Mini
{
    public class AGCatalog : IAGUrl
    {
        private string CatalogUrl;
        private AGServerInfo Server;
        private string Name;

        public AGCatalog(AGServerInfo Server, string Name)
        {
            CatalogUrl = Server.Url + "/catalogs/" + Name;
            this.Name = Name;
            this.Server = Server;
        }

        public string Url { get { return CatalogUrl; } }
        public string Username { get { return Server.Username; } }
        public string Password { get { return Server.Password; } }

        public void DeleteRepository(string Name)
        {
            AGRequestService.DoReq(Server, "DELETE", "/repositories/" + Name);
        }

        public AGRepository OpenRepository(string Name)
        {
            return new AGRepository(Server, Name);
        }
    }
}