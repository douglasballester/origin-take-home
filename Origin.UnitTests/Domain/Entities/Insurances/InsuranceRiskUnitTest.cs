using Origin.Domain.Entities;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Insurances
{
    public class InsuranceRiskUnitTest
    {
        [Theory, MemberData(nameof(Data))]
        public void Should_Run_InsuranceRisk_Validations_Correctly(User user, 
                                                                   InsuranceUnitTestHelper autoHelper, 
                                                                   InsuranceUnitTestHelper homeHelper, 
                                                                   InsuranceUnitTestHelper disabilityHelper,
                                                                   InsuranceUnitTestHelper lifeHelper)
        {
            //Arrange
            var insurance = new InsuranceRisk(user);

            //Act
            insurance.RunInsuranceValidations();

            //Assert
            var autoInsurance = insurance.Insurances.First(x => x.Name == "Auto");
            var disabilityInsurance = insurance.Insurances.First(x => x.Name == "Disability");
            var homeInsurance = insurance.Insurances.First(x => x.Name == "Home");
            var lifeInsurance = insurance.Insurances.First(x => x.Name == "Life");

            Assert.Equal(4, insurance.Insurances.Count);

            Assert.Equal(autoHelper.Score, autoInsurance.Score);
            Assert.Equal(autoHelper.Ineligible, autoInsurance.Ineligible);
            Assert.Equal(autoHelper.Risk , autoInsurance.Risk);


            Assert.Equal(homeHelper.Score, homeInsurance.Score);
            Assert.Equal(homeHelper.Ineligible, homeInsurance.Ineligible);
            Assert.Equal(homeHelper.Risk, homeInsurance.Risk);

            Assert.Equal(disabilityHelper.Score, disabilityInsurance.Score);
            Assert.Equal(disabilityHelper.Ineligible, disabilityInsurance.Ineligible);
            Assert.Equal(disabilityHelper.Risk, disabilityInsurance.Risk);

            Assert.Equal(lifeHelper.Score, lifeInsurance.Score);
            Assert.Equal(lifeHelper.Ineligible, lifeInsurance.Ineligible);
            Assert.Equal(lifeHelper.Risk, lifeInsurance.Risk);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new User(58, 0, 50000, MaritalStatus.Single, new List<byte> { 1, 1, 1 }, new House(OwnershipStatus.Mortgaged), new Vehicle(2000)),
                    new InsuranceUnitTestHelper { Score = 3, Risk = "responsible", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 4, Risk = "responsible", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 4, Risk = "responsible", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 3, Risk = "responsible", Ineligible = false },
                },
                new object[]
                {
                    new User(35, 2, 350000, MaritalStatus.Married, new List<byte> { 0, 1, 1 }, new House(OwnershipStatus.Owned), new Vehicle(2000)),
                    new InsuranceUnitTestHelper { Score = 0, Risk = "economic", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 0, Risk = "economic", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 0, Risk = "economic", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 2, Risk = "regular", Ineligible = false },
                },
                new object[]
                {
                    new User(35, 2, 50000, MaritalStatus.Single, new List<byte> { 1, 0, 0 }, new House(OwnershipStatus.Mortgaged), new Vehicle(DateTime.Now.Year - 2)),
                    new InsuranceUnitTestHelper { Score = 1, Risk = "regular", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 1, Risk = "regular", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 2, Risk = "regular", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 1, Risk = "regular", Ineligible = false },
                },
                new object[]
                {
                    new User(61, 0, 0, MaritalStatus.Single, new List<byte> { 0, 0, 0 }, new House(OwnershipStatus.Owned), new Vehicle(2000)),
                    new InsuranceUnitTestHelper { Score = 0, Risk = "economic", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 0, Risk = "economic", Ineligible = false },
                    new InsuranceUnitTestHelper { Score = 0, Risk = "ineligible", Ineligible = true },
                    new InsuranceUnitTestHelper { Score = 0, Risk = "ineligible", Ineligible = true },
                },
            };

        public class InsuranceUnitTestHelper
        {
            public int Score { get; set; }
            public bool Ineligible { get; set; }
            public string Risk { get; set; }
        }
    }    
}
