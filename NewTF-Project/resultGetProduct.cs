
using System.Collections.Generic;

public class RootProduct
{
    public List<getProduct> getProducts { get; set; }
}

public class getProduct
{
    public Systemuser systemUser { get; set; }
    public int idx { get; set; }
    public string productid { get; set; }
    public int shopid { get; set; }
    public string productname { get; set; }
    public string productdetail { get; set; }
    public int productprice { get; set; }
    public string productimgurl { get; set; }
}

public class Systemuser
{
    public List<Product> products { get; set; }
    public int idx { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string shopname { get; set; }
    public string shopdetail { get; set; }
}

public class Product
{
    public int idx { get; set; }
    public string productid { get; set; }
    public int shopid { get; set; }
    public string productname { get; set; }
    public string productdetail { get; set; }
    public int productprice { get; set; }
    public string productimgurl { get; set; }
}
