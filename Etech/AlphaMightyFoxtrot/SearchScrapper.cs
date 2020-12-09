using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Etech.AlphaMightyFoxtrot
{
    class SearchScrapper
    {

        public (List<string>, List<string>,List<string>) Download(string _url,string searchKey)
        {
            //var resultProducts = new List<object>();            
            List<string> name = new List<string>();
            List<string> priceProd = new List<string>();
            List<string> img = new List<string>();

            var htmlresult = DownloadPageAsync(_url).Result;


            var body = getBody(htmlresult.ToString());

            var products = body
                    .Descendants("div")
                    .Where(d => d.Attributes.Contains("class")
                                && d.Attributes["class"].Value.Equals("product-inner")
                               )
                    .Select(z => z)
                    .ToList();

            products.ForEach(x =>
            {
                var returnUrl = "";
                var productName = "";

                var divs = x.Descendants("div");
                var imageDiv = divs.Where(d => d.Attributes.Contains("class")
                                    && d.Attributes["class"].Value.Equals("image")).LastOrDefault();

                if (imageDiv != null)
                {

                    var imagesInDiv = imageDiv.Descendants("img").Where(d => d.Attributes.Contains("src"));
                    var firstImageInDiv = imagesInDiv.FirstOrDefault();
                    var imageurl = firstImageInDiv.Attributes["src"];
                    if (imageurl != null)
                    {
                        returnUrl = "https://www.evetech.co.za/" + imageurl.Value;
                    }
                }
                divs = x.Descendants("div");
                var priceDiv = divs.Where(d => d.Attributes.Contains("class")
                                    && d.Attributes["class"].Value.Equals("price")).FirstOrDefault().InnerText;

                var nameDiv = divs.Where(d => d.Attributes.Contains("class")
                                    && d.Attributes["class"].Value.Equals("myProductName")).FirstOrDefault();


                productName = nameDiv.Descendants("span").FirstOrDefault().InnerText;


                var price = priceDiv.Replace("\t", "").Replace("\n","").Replace("\r","");

                AlphaMightyFoxtrot.MongoDB mongoDB = new AlphaMightyFoxtrot.MongoDB();
                mongoDB.popm(new BsonDocument {
                    { "name" , productName },
                    { "price" , price },
                    { "img" , returnUrl },
                    { "search_key" , searchKey },
                });
                //resultProducts.Add(new {  name = productName,price = price,img = returnUrl, });

                name.Add(productName);
                priceProd.Add(price);
                img.Add(returnUrl);
            });




            return (name,priceProd,img);
        }

        public async Task<string> DownloadPageAsync(string url)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            HttpContent content = response.Content;
            {
                string result = await content.ReadAsStringAsync();
                if (result != null)
                {
                    return result;
                }

            }
            return "error";
        }

        public HtmlNode getBody(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.LoadHtml(html);

            if (htmlDoc.DocumentNode != null)
            {
                HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                if (bodyNode != null)
                {
                    return bodyNode;
                }
            }
            return null;

        }
    }
}
