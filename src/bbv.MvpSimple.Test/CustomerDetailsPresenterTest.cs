// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDetailsPresenterTest.cs" company="bbv Software Services AG">
//   Copyright (c) 2014
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace bbv.MvpSimple.Test
{
    using bbv.MvpSimple.Repositories;

    using FakeItEasy;

    using NUnit.Framework;

    [TestFixture]
    public class CustomerDetailsPresenterTest
    {
        private CustomerDetailsPresenter testee;

        private ICustomerDetailsView customerDetailsView;
        private ICustomerRepository customerRepository;

        [SetUp]
        public void SetUp()
        {
            this.customerDetailsView = A.Fake<ICustomerDetailsView>();
            this.customerRepository = A.Fake<ICustomerRepository>();

            this.testee = new CustomerDetailsPresenter(customerDetailsView, customerRepository);
        }

        [Test]
        public void LoadsAndShowsCustomerDetails()
        {
            const string CustomerId = "cust id";

            var customer = new Customer { Customer_ID = CustomerId };

            A.CallTo(() => this.customerRepository.Get(CustomerId)).Returns(customer);

            this.testee.LoadAndShowCustomerDetails(CustomerId);

            A.CallTo(() => this.customerDetailsView.ShowDetails(customer)).MustHaveHappened();
        }
    }
}