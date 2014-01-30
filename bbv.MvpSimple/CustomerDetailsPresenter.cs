// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDetailsPresenter.cs" company="officeatwork AG">
//   2009-2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace bbv.MvpSimple
{
    using bbv.MvpSimple.Repositories;

    public class CustomerDetailsPresenter
    {
        private readonly ICustomerDetailsView view;
        private readonly ICustomerRepository customerRepository;

        public CustomerDetailsPresenter(ICustomerDetailsView view, ICustomerRepository customerRepository)
        {
            this.view = view;
            this.customerRepository = customerRepository;
        }

        public void LoadAndShowCustomerDetails(string customerId)
        {
            this.view.CustomerDetailsView.DataSource = new[] { this.customerRepository.Get(customerId) };
            this.view.CustomerDetailsView.DataBind();
        }
    }
}