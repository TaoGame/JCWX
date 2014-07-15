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
        Merchant_Order
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
}
