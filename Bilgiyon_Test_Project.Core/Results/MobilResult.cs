using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.Core.Results
{
    public class MobilResult
    {
        public MobilResult()
        {
            this.IsSucceeded = false;
            this.ErrorMessage = string.Empty;
            this.UserMessage = string.Empty;
        }
        public string ErrorMessage { get; set; }
        public bool IsSucceeded { get; set; }
        public string UserMessage { get; set; }
        public int ID { get; set; }
        public string Value { get; set; }
        public string MessageNo { get; set; }
        public string LogNo { get; set; }       

    }

    public class MobilResult<T> : MobilResult
    {
        public T TransactionResult { get; set; }
    }
}
