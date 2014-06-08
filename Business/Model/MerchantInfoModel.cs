using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public sealed class ProductInfo
    {
        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        [JsonProperty("product_base")]
        public Product ProductBase { get; set; }
    }

    public class Product
    {
        [JsonProperty("category_id")]
        public string[] Categories { get; set; }

        [JsonProperty("property")]
        public IEnumerable<ProductProperty> Properties { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sku_info")]
        public IEnumerable<SkuInfo> SkuInfos { get; set; }

        [JsonProperty("ori_price")]
        public float OriPrice { get; set; }

        [JsonProperty("main_img")]
        public string MainImage { get; set; }

        [JsonProperty("img")]
        public string[] Images { get; set; }

        [JsonProperty("detail")]
        public IEnumerable<ProductDetail> Detail { get; set; }

        [JsonProperty("buy_limit")]
        public int BuyLimit { get; set; }

        [JsonProperty("sku_list")]
        public IEnumerable<Sku> SkuList { get; set; }

        [JsonProperty("attrext")]
        public Attrext Attrext { get; set; }

        [JsonProperty("delivery_info")]
        public Delivery DeliveryInfo { get; set; }
    }

    public sealed class Delivery
    {
        [JsonProperty("delivery_type")]
        public int DeliveryType { get; set; }

        [JsonProperty("template_id")]
        public int TemplateID { get; set; }

        [JsonProperty("express")]
        public IEnumerable<Express> Expresses { get; set; }
    }

    public sealed class Express
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }
    }

    public sealed class Attrext
    {
        [JsonProperty("isPostFree")]
        public bool IsPostFree { get; set; }

        [JsonProperty("isHasReceipt")]
        public bool IsHasReceipt { get; set; }

        [JsonProperty("isUnderGuaranty")]
        public bool IsUnderGuaranty { get; set; }

        [JsonProperty("isSupportReplace")]
        public bool IsSupportReplace { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public sealed class Location
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public sealed class Sku
    {
        [JsonProperty("sku_id")]
        public string SkuID { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("ori_price")]
        public float OriPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    public sealed class ProductDetail
    {
        [JsonProperty("text", NullValueHandling= NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("img", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }
    }

    public sealed class SkuInfo
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("vid")]
        public string[] VID { get; set; }
    }

    public sealed class ProductProperty
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("vid")]
        public string VID { get; set; }
    }
}
