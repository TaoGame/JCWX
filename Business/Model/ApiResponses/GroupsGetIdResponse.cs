using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class GroupsGetIdResponse : ApiResponse
    {
        public int GroupId { get; set; }

        public override string ToString()
        {
            if (IsError)
                return base.ToString();

            return String.Format("groupId:{0}", GroupId);
        }
    }
}
