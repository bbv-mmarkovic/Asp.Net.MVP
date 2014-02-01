// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersPresenter.cs" company="bbv Software Services AG">
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
namespace bbv.MvpSimple
{
    using System.Collections.Generic;

    using bbv.MvpSimple.Repositories;

    public class CustomersPresenter
    {
        private ICustomerRepository customerRepository;

        private ISearchCustomerPresenter searchCustomerPresenter;

        private ICustomersView view;

        public void Initialize(ICustomersView view, ISearchCustomerPresenter searchCustomerPresenter, ICustomerRepository customerRepository)
        {
            this.view = view;
            this.searchCustomerPresenter = searchCustomerPresenter;
            this.customerRepository = customerRepository;

            this.searchCustomerPresenter.SearchPerformed += (sender, eventArgs) => this.SearchCustomersAndShow(eventArgs.SearchTerm);
            this.searchCustomerPresenter.SearchCleared += (sender1, eventArgs1) => this.LoadAndShowAllCustomers();
        }

        public void LoadAndShowAllCustomers()
        {
            IReadOnlyList<Customer> customers = this.customerRepository.GetAll();
            this.view.ShowCustomers(customers);
        }

        public void DeleteCustomerRow(int rowIndex)
        {
            IReadOnlyList<Customer> customerList = this.view.GetCustomers();
            Customer customerToDelete = customerList[rowIndex];

            this.customerRepository.Delete(customerToDelete.Customer_ID);
        }

        private void SearchCustomersAndShow(string searchTerm)
        {
            IReadOnlyList<Customer> customers = this.customerRepository.GetMatching(searchTerm);
            this.view.ShowCustomers(customers);
        }
    }
}