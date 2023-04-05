using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleWcfService
{
    public class Service1 : IService1
    {
        public string ConvertAmountData(string amount)
        {
            return Convert.ToString(DecimalToWords.convertCurrencyToWords(Convert.ToDouble(amount)));
        }
    }
}
