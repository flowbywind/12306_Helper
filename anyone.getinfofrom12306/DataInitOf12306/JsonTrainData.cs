using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aNyoNe.GetInfoFrom12306
{
    [Serializable]
    public class JsonTrainData
    {
        private QueryLeftNewDTO queryLeftNewDto = null;
        private string secretStr="";//MjAxMy0xMi0zMSMwMCNLMTE4OSMxMToxOSMxNjowNSMyNDAwMEsxMTg5MDQjQkpQI05NRCMwMzoyNCPljJfkuqwj5aWI5pu8IzAxIzEwIzEwMDkxMDMyMTg0MDI1MzAwMDAwMTAwOTEwMDE4NDMwMTY0MDAwMDAjUDEjMTM4ODM5NzYyNzg5NCNEQTc3MTU0NEJCQjFBMDUwRkY3ODhGNUIzNkFFRThCNDYwQjI4MDVBNjBEMDRFQTlDRTFEQjgzQQ%3D%3D","
        private string buttonTextInfo="";//预订"}

        public JsonTrainData(){}

        public QueryLeftNewDTO QueryLeftNewDto
        {
            get { return queryLeftNewDto; }
            set { queryLeftNewDto = value; }
        }

        public string SecretStr
        {
            get { return secretStr; }
            set { secretStr = value; }
        }

        public string ButtonTextInfo
        {
            get { return buttonTextInfo; }
            set { buttonTextInfo = value; }
        }

        public JsonTrainData CloneJsonTrainData()
        {
            var _data = new JsonTrainData();
            _data.ButtonTextInfo = buttonTextInfo;
            _data.QueryLeftNewDto = queryLeftNewDto;
            _data.SecretStr = secretStr;
            return _data;
        }
    }
}
