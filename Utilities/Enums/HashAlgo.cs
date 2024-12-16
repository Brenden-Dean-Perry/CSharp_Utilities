using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Utilities.Enums
{
    public enum HashAlgo
    {
        [Description(nameof(SHA256))]
        Shannon256,
        [Description(nameof(SHA384))]
        Shannon384,
        [Description(nameof(SHA512))]
        Shannon512 
    }
}
