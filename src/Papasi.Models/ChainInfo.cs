namespace Papasi.Models;

public class ChainInfo
{
	public Chain Chain { get; set; }
	public Network Network { get; set; }
	public Indexer Indexer { get; set; }
	public Explorer Explorer { get; set; }
}


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Chain
{
	public string Name { get; set; }
	public string Symbol { get; set; }
	public string Description { get; set; }
	public string Url { get; set; }
	public string Logo { get; set; }
	public string Icon { get; set; }
	public string Color { get; set; }
}

public class Currency
{
	public string ApiUrl { get; set; }
	public bool AutoConvert { get; set; }
}

public class Explorer
{
	public Indexer Indexer { get; set; }
	public Currency Currency { get; set; }
	public Ticker Ticker { get; set; }
}



public class Indexer
{
	public bool StoreRawTransactions { get; set; }
	public string ApiUrl { get; set; }
	public string DocUrl { get; set; }
}


public class Link
{
	public string icon { get; set; }
	public string url { get; set; }
}

public class Network
{
	public string NetworkConsensusFactoryType { get; set; }
	public string NetworkType { get; set; }
	public int NetworkPubkeyAddressPrefix { get; set; }
	public int NetworkScriptAddressPrefix { get; set; }
	public string NetworkWitnessPrefix { get; set; }
	public int P2PPort { get; set; }
	public int RPCPort { get; set; }
	public int APIPort { get; set; }
}





public class Ticker
{
	public string WebUrl { get; set; }
	public string ApiUrl { get; set; }
	public string PricePath { get; set; }
	public string PricePathBTC { get; set; }
	public string PricePathUSD { get; set; }
	public string PercentagePath { get; set; }
	public bool IsBitcoinPrice { get; set; }
}



