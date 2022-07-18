using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {                               //logic = kural
        public static IResult Run(params IResult[] logics)//params ile IResult türünde istenilenen kadar method gönderilebilir
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//Kurala uymayını business gönderir
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
