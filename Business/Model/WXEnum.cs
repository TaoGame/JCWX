using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public enum MsgType
    {
        Text,
        Image,
        Voice,
        Video,
        Location,
        Link,
        Event,
        News,
        Music,
        transfer_customer_service
    }

    public enum Event
    {
        Subscribe,
        Unsubscribe,
        Scan,
        Location,
        Click,
        MASSSENDJOBFINISH,
        View,
        Merchant_Order,
        TEMPLATESENDJOBFINISH //模板消息 2014-09-23
    }

    public enum MediaType
    {
        Image,
        Voice,
        Video,
        Thumb
    }

    public enum OAuthScope
    {
        Base,
        UserInfo
    }

    public enum Language
    {
        CN,
        TW,
        EN
    }

    /// <summary>
    /// 行业模板
    /// </summary>
    public enum TemplateIndustry
    {
        /// <summary>
        /// 互联网/电子商务	
        /// </summary>
        ITNetAndBusiness = 1,
        /// <summary>
        /// IT软件与服务	
        /// </summary>
        ITSoftAndServices = 2,
        /// <summary>
        /// IT硬件与设备	
        /// </summary>
        ITHardware = 3,
        /// <summary>
        /// 电子技术	
        /// </summary>
        ITElectronicTech = 4,
        /// <summary>
        /// 通信运营商
        /// </summary>
        ITOperators =5,
        /// <summary>
        /// 网络游戏
        /// </summary>
        ITGames = 6,
        /// <summary>
        /// 银行
        /// </summary>
        FBank = 7,
        /// <summary>
        /// 基金|理财|信托
        /// </summary>
        FInvestment = 8,
        /// <summary>
        /// 保险
        /// </summary>
        FInsurance = 9,
        /// <summary>
        /// 餐饮
        /// </summary>
        Catering = 10,
        /// <summary>
        /// 酒店
        /// </summary>
        Hotel = 11,
        /// <summary>
        /// 旅游
        /// </summary>
        Travel = 12,
        /// <summary>
        /// 快递
        /// </summary>
        Express = 13,
        /// <summary>
        /// 物流
        /// </summary>
        Logistics = 14,
        /// <summary>
        /// 仓储
        /// </summary>
        Store = 15,
        /// <summary>
        /// 培训
        /// </summary>
        Cultivate = 16,
        /// <summary>
        /// 院校
        /// </summary>
        School = 17,
        /// <summary>
        /// 学术和科研
        /// </summary>
        AcademicResearch  = 18,
        /// <summary>
        /// 交警
        /// </summary>
        TrafficPolice = 19,
        /// <summary>
        /// 博物馆
        /// </summary>
        Museum = 20,
        /// <summary>
        /// 公共事业
        /// </summary>
        PublicUtilities = 21,
        /// <summary>
        /// 医药医疗	
        /// </summary>
        Medical = 22,
        /// <summary>
        /// 美容
        /// </summary>
        Cosmetology = 23,
        /// <summary>
        /// 保健与卫生
        /// </summary>
        HealthCare = 24,
        /// <summary>
        /// 汽车业
        /// </summary>
        Auto = 25,
        /// <summary>
        /// 摩托车
        /// </summary>
        Motor = 26,
        /// <summary>
        /// 火车
        /// </summary>
        Train = 27,
        /// <summary>
        /// 飞机业
        /// </summary>
        Plane = 28,
        /// <summary>
        /// 建筑业
        /// </summary>
        Building = 29,
        /// <summary>
        /// 物业
        /// </summary>
        Property = 30,
        /// <summary>
        /// 消费品
        /// </summary>
        ConsumerGoods = 31,
        /// <summary>
        /// 法律
        /// </summary>
        Law = 32,
        /// <summary>
        /// 会展
        /// </summary>
        Exhibition = 33,
        /// <summary>
        /// 中介服务
        /// </summary>
        Intermediary = 34,
        /// <summary>
        /// 认证
        /// </summary>
        Authentication = 35,
        /// <summary>
        /// 审计
        /// </summary>
        Audit = 36,
        /// <summary>
        /// 传媒
        /// </summary>
        Media = 37,
        /// <summary>
        /// 体育
        /// </summary>
        Sports = 38,
        /// <summary>
        /// 娱乐和休闲
        /// </summary>
        Entertainment  = 39,
        /// <summary>
        /// 印刷
        /// </summary>
        Printing = 40,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 41
    }
}
