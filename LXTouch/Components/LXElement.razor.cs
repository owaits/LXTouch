using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXElement
    {
        [Parameter]
        public LXLayoutElement Layout { get; set; }
    }
}
