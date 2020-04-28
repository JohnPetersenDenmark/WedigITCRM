using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.VirkAPI
{
    public class VirkQuery
    {

        public VirkQuery()
        {
            this._source = new List<string>();
            this._source.Add("Vrvirksomhed.cvrNummer");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn");
            this._source.Add("Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postdistrikt");
            this._source.Add("Vrvirksomhed.telefonNummer");
            this._source.Add("Vrvirksomhed.hjemmeside");

            this.size = 200;

            this.query = new Query();
        }

        public List<string> _source { get; set; }

        public int size { get; set; }

        public Query query { get; set; }
    }

    public class Query
    {
        public Query()
        {
            this.query_string = new QueryString();
        }
        public QueryString query_string { get; set; }
    }

    public class QueryString
    {
        public QueryString()
        {
            this.default_field = "Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn";
        }
        public string default_field { get; set; }

        public string query { get; set; }
    }

    public class CompanyData
    {
        public string label { get; set; }
        public string value { get; set; }

        public string cvrNumber { get; set; }

        public string zip { get; set; }

        public string zipId { get; set; }

        public string city { get; set; }

        public string street { get; set; }
        public string houseNumber { get; set; }


        public string homePage { get; set; }

        public string phoneNumber { get; set; }
    }


}



