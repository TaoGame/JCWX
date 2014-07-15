using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Common;

namespace WX.Model
{
    public sealed class ProductInfo
    {
        [JsonProperty("product_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductID { get; set; }

        /// <summary>
        /// 商品基本属性
        /// </summary>
        [JsonProperty("product_base", NullValueHandling = NullValueHandling.Ignore)]
        public Product ProductBase { get; set; }

        /// <summary>
        /// sku信息列表
        /// </summary>
        [JsonProperty("sku_list", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Sku> SkuList { get; set; }

        /// <summary>
        /// 商品其他属性
        /// </summary>
        [JsonProperty("attrext", NullValueHandling = NullValueHandling.Ignore)]
        public Attrext Attrext { get; set; }

        /// <summary>
        /// 运费信息
        /// </summary>
        [JsonProperty("delivery_info", NullValueHandling = NullValueHandling.Ignore)]
        public Delivery DeliveryInfo { get; set; }

        /// <summary>
        /// 修改操作 0：删除 1：增加
        /// </summary>
        [JsonProperty("mod_action", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public byte ModAction { get; set; }
    }

    public class Product
    {
        /// <summary>
        /// 商品分类ID，通过获取【指定分类所有子分类】获取
        /// </summary>
        [JsonProperty("category_id")]
        public string[] Categories { get; set; }

        /// <summary>
        /// 商品属性列表
        /// </summary>
        [JsonProperty("property")]
        public IEnumerable<ProductProperty> Properties { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 商品SKU定义
        /// </summary>
        [JsonProperty("sku_info")]
        public IEnumerable<SkuInfo> SkuInfos { get; set; }

        /// <summary>
        /// 商品原价
        /// </summary>
        [JsonProperty("ori_price")]
        public float OriPrice { get; set; }

        /// <summary>
        /// 商品主图
        /// </summary>
        [JsonProperty("main_img")]
        public string MainImage { get; set; }

        /// <summary>
        /// 商品图片列表
        /// </summary>
        [JsonProperty("img")]
        public string[] Images { get; set; }

        /// <summary>
        /// 商品详情列表
        /// </summary>
        [JsonProperty("detail")]
        public IEnumerable<ProductDetail> Detail { get; set; }

        /// <summary>
        /// 用户限购数量
        /// </summary>
        [JsonProperty("buy_limit")]
        public int BuyLimit { get; set; }
    }

    public sealed class Delivery
    {
        [JsonProperty("delivery_type")]
        public int DeliveryType { get; set; }

        [JsonProperty("template_id")]
        public int TemplateID { get; set; }

        [JsonProperty("express", NullValueHandling = NullValueHandling.Ignore)]
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
        /// <summary>
        /// 是否包邮
        /// </summary>
        [JsonIgnore]
        public bool IsPostFree { get; set; }

        [JsonProperty("isPostFree")]
        internal int IntIsPostFree
        {
            get
            {
                return IsPostFree ? 1 : 0;
            }
            set
            {
                IsPostFree = value == 1;
            }
        }

        /// <summary>
        /// 是否提供发票
        /// </summary>
        [JsonIgnore]
        public bool IsHasReceipt { get; set; }

        [JsonProperty("isHasReceipt")]
        internal int IntIsHasReceipt
        {
            get
            {
                return IsHasReceipt ? 1 : 0;
            }
            set
            {
                IsHasReceipt = value == 1;
            }
        }

        /// <summary>
        /// 是否保修
        /// </summary>
        [JsonIgnore]
        public bool IsUnderGuaranty { get; set; }

        [JsonProperty("isUnderGuaranty")]
        internal int IntIsUnderGuaranty
        {
            get
            {
                return IsUnderGuaranty ? 1 : 0;
            }
            set
            {
                IsUnderGuaranty = value == 1;
            }
        }

        /// <summary>
        /// 是否支持退换货
        /// </summary>
        [JsonIgnore]
        public bool IsSupportReplace { get; set; }

        [JsonProperty("isSupportReplace")]
        internal int IntIsSupportReplace
        {
            get
            {
                return IsSupportReplace ? 1 : 0;
            }
            set
            {
                IsSupportReplace = value == 1;
            }
        }

        /// <summary>
        /// 商品所在地地址
        /// </summary>
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
        /// <summary>
        /// skuid 格式为：id1:vid1;id2:vid2
        /// </summary>
        [JsonProperty("sku_id")]
        public string SkuID { get; set; }

        /// <summary>
        /// sku微信价
        /// </summary>
        [JsonProperty("price")]
        public float Price { get; set; }

        /// <summary>
        /// sku 图片地址
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        /// <summary>
        /// 商家商品编码
        /// </summary>
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// sku原价格
        /// </summary>
        [JsonProperty("ori_price")]
        public float OriPrice { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    public sealed class ProductDetail
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
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

    public class Cate
    {
        [JsonProperty("id")]
        /// <summary>
        /// 分类ID
        /// </summary>
        public string Id { get; set; }

        [JsonProperty("name")]
        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { get; set; }
    }

    public sealed class SkuTable
    {
        [JsonProperty("id")]
        public string SkuTableID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value_list")]
        public IEnumerable<SkuValue> ValueList { get; set; }
    }

    public sealed class SkuValue : Cate
    {

    }

    public sealed class Property
    {
        [JsonProperty("id")]
        public string PropertyID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("property_value")]
        public IEnumerable<PropertyValue> PropertyValues { get; set; }
    }

    public sealed class PropertyValue : Cate
    {

    }

    public sealed class DeliveryTemplate
    {
        [JsonProperty("id",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ID { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 支付方式 0：买家承担运费 1：卖家承担运费
        /// </summary>
        public int Assumer { get; set; }

        /// <summary>
        /// 计费单位 0：按件计费 1：按重量计费 2：按体积计费（目前只支持0）
        /// </summary>
        public int Valuation { get; set; }

        [JsonProperty("TopFee")]
        public IEnumerable<TopFee> TopFees { get; set; }
    }

    public class TopFee
    {
        /// <summary>
        /// 快递类型ID 参见快递列表
        /// </summary>
        [JsonProperty("Type")]
        public int FeeType { get; set; }

        /// <summary>
        /// 默认邮费计费方式
        /// </summary>
        public NormalFee Normal { get; set; }

        /// <summary>
        /// 指定地区邮费计费方式
        /// </summary>
        [JsonProperty("Custom")]
        public IEnumerable<CustomFee> Customs { get; set; }
    }

    public class CustomFee : NormalFee
    {
        /// <summary>
        /// 指定国家 
        /// </summary>
        public string DestCountry { get; set; }

        /// <summary>
        /// 指定省份
        /// </summary>
        public string DestProvince { get; set; }

        /// <summary>
        /// 指定地区
        /// </summary>
        public string DestCity { get; set; }
    }

    public class NormalFee
    {
        /// <summary>
        /// 起始计费数量
        /// </summary>
        public int StartStandards { get; set; }

        /// <summary>
        /// 起始计费金额（单位：分）
        /// </summary>
        public int StartFees { get; set; }

        /// <summary>
        /// 递增计费数量
        /// </summary>
        public int AddStandards { get; set; }

        /// <summary>
        /// 递增计费金额 （单位：分）
        /// </summary>
        public int AddFees { get; set; }

    }

    public class MerchantGroupDetail
    {
        [JsonProperty("group_id",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long GroupId { get; set; }

        [JsonProperty("group_name",
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("product",
            NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ProductInfo> Product { get; set; }

        [JsonProperty("product_list",
            NullValueHandling = NullValueHandling.Ignore)]
        public string[] ProductList { get; set; }
    }

    [JsonConverter(typeof(ShelfModuleConverter))]
    public abstract class ShelfModule
    {
        [JsonProperty("eid")]
        public abstract int EID { get; }
    }

    internal class ShelfModuleFactory
    {
        [JsonProperty("eid")]
        public int EID { get; set; }       

        [JsonProperty("group_info")]
        public ShelfGroupInfo GroupInfo { get; set; }

        [JsonProperty("group_infos")]
        public ShelfGroupInfos GroupInfos { get; set; }

        internal ShelfModule BuildModule()
        {
            ShelfModule module = null;
            switch (EID)
            {
                case 1:
                    module = new ShelfModuleOne() { GroupInfo = GroupInfo };
                    break;
                case 2:
                    module = new ShelfModuleTwo() { GroupInfos = GroupInfos };
                    break;
                case 3:
                    module = new ShelfModuleThree() { GroupInfo = GroupInfo };
                    break;
                case 4:
                    module = new ShelfModuleFour() { GroupInfos = GroupInfos };
                    break;
                case 5:
                    module = new ShelfModuleFive { GroupInfos = GroupInfos };
                    break;
            }

            if (module == null)
                throw new ArgumentException();

            return module;
        }
    }


    /// <summary>
    /// 控件1
    /// </summary>
    public class ShelfModuleOne : ShelfModule
    {
        public ShelfModuleOne() { }
        public ShelfModuleOne(long groupId, int count)
        {
            GroupInfo = new ShelfGroupInfo()
            {
                Count = count,
                GroupID = groupId
            };
        }

        [JsonProperty("eid")]
        public override int EID
        {
            get { return 1; }
        }

        [JsonProperty("group_info")]
        public ShelfGroupInfo GroupInfo { get; set; }
    }

    /// <summary>
    /// 控件2
    /// </summary>
    public class ShelfModuleTwo : ShelfModule
    {
        public ShelfModuleTwo() { }
        public ShelfModuleTwo(long[] groupIds)
        {
            GroupInfos = new ShelfGroupInfos(4);
            GroupInfos.Groups = groupIds.Select(g => new ShelfGroupInfo() { GroupID = g });
        }

        [JsonProperty("eid")]
        public override int EID
        {
            get { return 2; }
        }

        [JsonProperty("group_infos")]
        public ShelfGroupInfos GroupInfos { get; set; }
    }

    /// <summary>
    /// 控件3
    /// </summary>
    public class ShelfModuleThree : ShelfModule
    {

        public ShelfModuleThree() { }
        public ShelfModuleThree(long groupId, string img)
        {
            GroupInfo = new ShelfGroupInfo { GroupID = groupId, Img = img };
        }

        [JsonProperty("eid")]
        public override int EID
        {
            get { return 3; }
        }

        [JsonProperty("group_info")]
        public ShelfGroupInfo GroupInfo { get; set; }
    }

    /// <summary>
    /// 控件4
    /// </summary>
    public class ShelfModuleFour : ShelfModule
    {
        public ShelfModuleFour() { }
        public ShelfModuleFour(IEnumerable<ShelfGroupInfo> groupInfos)
        {
            var groups = groupInfos.Take(3)
                .Select(g => new ShelfGroupInfo()
                {
                    GroupID = g.GroupID,
                    Img = g.Img
                });

            GroupInfos = new ShelfGroupInfos(3)
            {
                Groups = groups
            };
        }

        [JsonProperty("eid")]
        public override int EID
        {
            get { return 4; }
        }

        [JsonProperty("group_infos")]
        public ShelfGroupInfos GroupInfos { get; set; }
    }

    /// <summary>
    /// 控件5
    /// </summary>
    public class ShelfModuleFive : ShelfModule
    {
        public ShelfModuleFive() { }
        public ShelfModuleFive(long[] groupId, string imgbackupground)
        {
            GroupInfos = new ShelfGroupInfos(10)
            {
                Groups = groupId.Take(10)
                .Select(s => new ShelfGroupInfo { GroupID = s }),
                ImgBackground = imgbackupground
            };
        }

        [JsonProperty("group_infos")]
        public ShelfGroupInfos GroupInfos { get; set; }


        [JsonProperty("eid", Order=5)]
        public override int EID
        {
            get { return 5; }
        }
    }


    public class ShelfGroupInfos
    {
        public ShelfGroupInfos(int size)
        {
            Groups = new ShelfGroupInfo[size];
        }

        [JsonProperty("groups")]
        public IEnumerable<ShelfGroupInfo> Groups { get; set; }

        [JsonProperty("img_background", NullValueHandling = NullValueHandling.Ignore)]
        public string ImgBackground { get; set; }
    }

   
    public class ShelfGroupInfo
    {
         [JsonConstructor]
        public ShelfGroupInfo()
        {

        }

        [JsonProperty("group_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long GroupID { get; set; }

        [JsonIgnore]
        public int Count
        {
            get { return Filter.Count; }
            set
            {
                if (Filter == null)
                {
                    Filter = new GroupFilter(value);
                }
            }
        }

        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        internal GroupFilter Filter { get; set; }
        internal class GroupFilter
        {
            [JsonConstructor]
            internal GroupFilter() { }
            internal GroupFilter(int count)
            {
                Count = count;
            }
            [JsonProperty("count")]
            public int Count { get; set; }
        }

        [JsonProperty("img", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Img { get; set; }
    }

    public class ShelfModulesInfo
    {
        public ShelfModulesInfo()
        {

        }

        public ShelfModulesInfo(IEnumerable<ShelfModule> modules)
        {
            Modules = modules;
        }

        [JsonProperty("module_infos")]
        public IEnumerable<ShelfModule> Modules { get; set; }
    }

    public class ShelfInfo
    {
        [JsonProperty("shelf_name", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("shelf_id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ShelfID { get; set; }

        [JsonProperty("shelf_banner", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Banner { get; set; }

        [JsonProperty("shelf_info", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ShelfModulesInfo ShelfInfos { get; set; }
    }
}
