using System;
namespace ReleaseTest
{
    public class District
    {
        public string Abbrev { get; }
        public string Name { get; }

        public District(string abbrev, string name)
        {
            Abbrev = abbrev;
            Name = name;
        }
    }
}

