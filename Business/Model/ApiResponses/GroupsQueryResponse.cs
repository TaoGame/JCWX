using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class GroupsQueryResponse : ApiResponse
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}
