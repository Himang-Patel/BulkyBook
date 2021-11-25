using Braintree;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class BrainTreeGate : IBrainTreeGate
    {
        public  BrainTreeSettings Options { get; set; }
        private IBraintreeGateway BraintreeGateway { get; set; }
        public BrainTreeGate(IOptions<BrainTreeSettings> options)
        {
            Options = options.Value;
        }
        public IBraintreeGateway CreateGateWay()
        {
            return new BraintreeGateway(Options.Envirenment, Options.MerchantId, Options.PublicKey, Options.PrivateKey);
        }

        public IBraintreeGateway GetGateWay()
        {
            if (BraintreeGateway==null)
            {
                BraintreeGateway = CreateGateWay();
            }
            return BraintreeGateway;
        }
    }
}
