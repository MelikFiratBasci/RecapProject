﻿using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult PayWithCreditCard(int price,CreditCard creditCard);
    }
}