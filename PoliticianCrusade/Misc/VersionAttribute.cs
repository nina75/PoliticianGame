using System;

namespace PoliticianCrusade
{
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(string version)
        {
            this.Version = version;
        }

        public string Version 
        { 
            get; 
            set; 
        }

        public override string ToString()
        {
            return this.Version;
        }
    }
}
