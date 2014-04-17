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
        Music
    }

    public enum Event
    {
        Subscribe,
        Unsubscribe,
        Scan,
        Location,
        Click,
        MASSSENDJOBFINISH
    }
}
