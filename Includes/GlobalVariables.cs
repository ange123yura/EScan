using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using System.Text;
using System.Threading.Tasks;

namespace EScan.Includes
{
    internal class GlobalVariables
    {
        public static FirebaseClient client = new("https://e-scan-e33b0-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static string _id,_fn, _username, _password, _userfname, _userlname, userkey,_ec,_en,_es,_ee,_ed,_ek;
    }
}
