using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _120101;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal.Commands;

namespace _120101
{
    [TestClass]
    public class CloseBet
    {
        [TestMethod]
        public void First()
        {
            Bet bet = new Bet()
            {
                Id = 123,
                Stake = 1.5M,
                CreatedDate = new DateTime(2018,12,01)
            };

            var betDto = new BetDto();
            var actual = betDto.BetDtoConvert(bet, p => new BetDto()
            {
                Amount = (int)Math.Round(p.Stake),
                BetId = p.Id,
                Date = p.CreatedDate.ToString("yyyy MM dd")
            });
            Assert.AreEqual(actual.BetId, 123);
            Assert.AreEqual(actual.Amount, 2);
            Assert.AreEqual(actual.Date, "2018 12 01");
        }
    }
}

public class Bet
{
    public int Id { get; set; }
    public decimal Stake { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class BetDto
{
    public int BetId { get; set; }
    public string Date { get; set; }
    public int Amount { get; set; }

    public BetDto BetDtoConvert(Bet bet, Func<Bet, BetDto> mapper)
    {
        return mapper(bet);
    }
}