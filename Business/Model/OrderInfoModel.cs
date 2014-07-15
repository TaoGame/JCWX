using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class OrderInfo
    {
        [JsonProperty("order_id")]
        public string OrderID { get; set; }
        [JsonProperty("order_status")]
        public int Status { get; set; }

        [JsonProperty("order_total_price")]
        public float TotalPrice { get; set; }

        [JsonProperty("order_express_price")]
        public float ExpressPrice { get; set; }

        [JsonProperty("order_create_time")]
        public long CreateTime { get; set; }

        [JsonProperty("buyer_openid")]
        public string BuyerOpenId { get; set; }

        [JsonProperty("buyer_nick")]
        public string  BuyerNick { get; set; }

        [JsonProperty("receiver_name")]
        public string ReceiverName { get; set; }

        [JsonProperty("receiver_province")]
        public string ReceiverProvince { get; set; }

        [JsonProperty("receiver_city")]
        public string ReceiverCity { get; set; }

        [JsonProperty("receiver_address")]
        public string ReceiverAddress { get; set; }

        [JsonProperty("receiver_mobile")]
        public string ReceiverMobile { get; set; }

        [JsonProperty("receiver_phone")]
        public string ReceiverPhone { get; set; }

        [JsonProperty("product_id")]
        public string ProductID { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("product_price")]
        public float ProductPrice { get; set; }

        [JsonProperty("product_sku")]
        public string ProductSku { get; set; }

        [JsonProperty("product_count")]
        public int ProductCount { get; set; }

        [JsonProperty("product_img")]
        public string ProductImg { get; set; }

        [JsonProperty("delivery_id")]
        public string DeliveryID { get; set; }

        [JsonProperty("delivery_company")]
        public string DeliveryCompany { get; set; }

        [JsonProperty("trans_id")]
        public string TransID { get; set; }

    }

    public enum OrderStatus
    {
        All = 0,
        WaitSend = 2,
        Delivered = 3,
        Finish = 5,
        AfterService = 8
    }

    public class DeliveryCompany
    {
        public const string EMS = "Fsearch_code";

        public const string STO = "002shentong";

        public const string ZTO = "066zhongtong";

        public const string YTO = "056yuantong";

        public const string TIANTIAN = "042tiantian";

        public const string YUNDA = "059Yunda";

        public const string SHUNFENG = "003shunfeng";

        public const string ZHAIJISONG = "064zhaijisong";

        public const string HUITONG = "020huitong";

        public const string YIXUN = "zj001yixun";
    }
}
