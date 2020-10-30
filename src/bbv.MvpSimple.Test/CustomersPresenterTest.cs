// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersPresenterTest.cs" company="bbv Software Services AG">
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
    using System;
    using System.Collections.Generic;

    using bbv.MvpSimple.Repositories;

    using FakeItEasy;

    using NUnit.Framework;

    [TestFixture]
    public class CustomersPresenterTest
    {
        private CustomersPresenter testee;

        private ICustomersView customersView;
        private ISearchCustomerPresenter searchCustomerPresenter;
        private ICustomerRepository customerRepository;

        [SetUp]
        public void SetUp()
        {
            this.customersView = A.Fake<ICustomersView>();
            this.searchCustomerPresenter = A.Fake<ISearchCustomerPresenter>();
            this.customerRepository = A.Fake<ICustomerRepository>();

            this.testee = new CustomersPresenter();
            this.testee.Initialize(customersView, searchCustomerPresenter, customerRepository);
        }

        [Test]
        public void LoadsAndShowsAllCustomers()
        {
            IReadOnlyList<Customer> customers = new[] { new Customer(), new Customer() };

            A.CallTo(() => this.customerRepository.GetAll()).Returns(customers);

            this.testee.LoadAndShowAllCustomers();

            A.CallTo(() => this.customersView.ShowCustomers(customers)).MustHaveHappened();
        }

        [Test]
        public void DeletesCustomerRow()
        {
            const string SecondCustomerId = "second";
            const int SecondCustomerRowIndex = 1;

            IReadOnlyList<Customer> customers = new[]
            {
                new Customer { Customer_ID = "first" },
                new Customer { Customer_ID = SecondCustomerId },
                new Customer { Customer_ID = "third" }
            };

            A.CallTo(() => this.customersView.GetCustomers()).Returns(customers);

            this.testee.DeleteCustomerRow(SecondCustomerRowIndex);

            A.CallTo(() => this.customerRepository.Delete(SecondCustomerId)).MustHaveHappened();
        }

        [Test]
        public void SearchesAndShowsCustomersOnSearchEvent()
        {
            const string SearchTerm = "company name";
            IReadOnlyList<Customer> searchedCustomers = new[] { new Customer(), new Customer() };

            A.CallTo(() => this.customerRepository.GetMatching(SearchTerm)).Returns(searchedCustomers);

            this.searchCustomerPresenter.SearchPerformed += Raise.With(null, new PerformSearchByCompanyEventArgs(SearchTerm)).Now;

            A.CallTo(() => this.customersView.ShowCustomers(searchedCustomers)).MustHaveHappened();
        }

        [Test]
        public void LoadsAndShowsAllCusotmersOnClearEvent()
        {
            IReadOnlyList<Customer> customers = new[] { new Customer(), new Customer() };

            A.CallTo(() => this.customerRepository.GetAll()).Returns(customers);

            this.searchCustomerPresenter.SearchCleared += Raise.WithEmpty().Now;

            A.CallTo(() => this.customersView.ShowCustomers(customers)).MustHaveHappened();
        }
    }
}