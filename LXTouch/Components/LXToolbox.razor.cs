using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXToolbox
    {
        [CascadingParameter]
        public LXEditor Editor { get; set; }
    }
}
