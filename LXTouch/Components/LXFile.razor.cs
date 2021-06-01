using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXFile
    {
        [Inject]
        public LXLayoutService Layout { get; set; }
    }
}
