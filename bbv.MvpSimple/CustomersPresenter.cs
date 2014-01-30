// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersPresenter.cs" company="officeatwork AG">
//   2009-2014
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
            this.view.CustomersData = this.customerRepository.GetAll();
            this.view.ShowCustomersData();
        }

        public void DeleteCustomerRow(int rowIndex)
        {
            IReadOnlyList<Customer> customerList = this.view.CustomersData;
            Customer customerToDelete = customerList[rowIndex];

            this.customerRepository.Delete(customerToDelete.Customer_ID);
        }

        private void SearchCustomersAndShow(string searchTerm)
        {
            this.view.CustomersData = this.customerRepository.GetMatching(searchTerm);
            this.view.ShowCustomersData();
        }
    }
}