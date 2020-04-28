using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.VirkAPI
{
    public class VirkResponse
    {
        public VirkResponse()
        {
            this.hits = new hits();
            this._shards = new _shards();
        }
        public int took { get; set; }
        public bool timed_out { get; set; }

        public _shards _shards { get; set; }
        public hits hits { get; set; }
    }

    public class _shards
    {
        public int total { get; set; }

        public int successful { get; set; }
        public int skipped { get; set; }

        public int failed { get; set; }
    }
    public class hits
    {
        public hits()
        {
            this.hits_property = new List<vedIkke>();
        }
        public int total { get; set; }
        public double max_score { get; set; }

        [JsonProperty("hits")]
        public  List<vedIkke> hits_property { get; set; }    
    }
}

public class vedIkke
{
    public vedIkke()
    {
        this._source = new _source();
    }
    public string _index { get; set; }
    public string _type { get; set; }

    public string _id { get; set; }

    public string _score { get; set; }

    public _source _source { get; set; }
}

public class _source
{
    public _source()
    {
        this.Vrvirksomhed = new Vrvirksomhed();
    }
    public Vrvirksomhed Vrvirksomhed { get; set; }
}
public class Vrvirksomhed
{
    public Vrvirksomhed()
    {
        this.virksomhedMetadata = new virksomhedMetadata();
        this.telefonNummer = new List<telefonNummer>();
        this.hjemmeside = new List<hjemmeside>();
    }
    public int cvrNummer { get; set; }
    public virksomhedMetadata virksomhedMetadata { get; set; }

    public  List<telefonNummer> telefonNummer { get; set; }
    public List<hjemmeside> hjemmeside { get; set; }
    

}
public class virksomhedMetadata
{
    public virksomhedMetadata()
    {
        this.nyesteNavn = new nyesteNavn();
        this.nyesteBeliggenhedsadresse = new nyesteBeliggenhedsadresse();
    }
    public nyesteNavn nyesteNavn { get; set; }

    public nyesteBeliggenhedsadresse nyesteBeliggenhedsadresse { get; set; }
}

public class nyesteNavn
{
    public string navn { get; set; }
}

public class nyesteBeliggenhedsadresse
{
    public int? husnummerFra { get; set; }
    public int postnummer { get; set; }
    public string postdistrikt { get; set; }
    
    public string vejnavn { get; set; }

}

public class noName
{
    public string kontaktoplysning { get; set; }
}

public class telefonNummer
{
    public telefonNummer()
    {
        this.noName = new noName();
    }

    public noName noName { get; set; }

}

public class hjemmeside
{
    public hjemmeside()
    {
        this.noName1 = new noName1();
    }

    public noName1 noName1 { get; set; }

}

public class noName1
{
    public string kontaktoplysning { get; set; }
}