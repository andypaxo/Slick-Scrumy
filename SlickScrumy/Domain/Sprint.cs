using System.Collections.Generic;

namespace SlickScrumy.Domain
{
    public class Sprint
    {
        public IEnumerable<Story> Stories { get; set; }
    }
}