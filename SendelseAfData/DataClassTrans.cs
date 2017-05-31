using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendeOgModtagesAfData
{
    [Serializable]
    public class DataClassTrans
    {
        public string data { get; set; }

        public DataClassTrans(string s)
        {
            data = s;
        }
    }
}
