using Business.Abstract;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        ICardDal _cardDal;

        public PaymentManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        [TransactionScopeAspect]
        public IResult PayWithCreditCard(int price ,CreditCard creditCard)
        {
            var result = _cardDal.Get(c => c.CardNumber == creditCard.CardNumber);
            if (result!= null &&result.Limit>=price)
            {
                result.Limit -= price;
                _cardDal.Update(result);
                return new SuccessResult("Ödeme Yapıldı");

            }
            return new ErrorResult("Ödeme Yapılamadı ");
        }
    }
}
