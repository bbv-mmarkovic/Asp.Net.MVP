// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Orders.aspx.cs" company="bbv Software Services AG">
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

// ReSharper disable InconsistentNaming

namespace bbv.MvpSimple
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using bbv.MvpSimple.Repositories;

    public interface ICustomersView
    {
        IReadOnlyList<Customer> CustomersData { get; set; }

        void ShowCustomersData();
    }

    public partial class Customers : Page, ICustomersView
    {
        private CustomersPresenter presenter;

        public GridView CustomersGridView
        {
            get { return this.gvCustomers; }
        }

        public IReadOnlyList<Customer> CustomersData
        {
            get { return this.gvCustomers.DataSource as IReadOnlyList<Customer>; }

            set { this.gvCustomers.DataSource = value; }
        }

        public void Initialize()
        {
            var searchCustomerPresenter = new SearchCustomerPresenter();

            this.presenter = new CustomersPresenter();
            this.presenter.Initialize(this, searchCustomerPresenter, new CustomerRepository());

            this.SearchCustomerControl1.Initialize(searchCustomerPresenter);
        }

        public void ShowCustomersData()
        {
            this.gvCustomers.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initialize();

            this.presenter.LoadAndShowAllCustomers();
        }

        protected void gvCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.presenter.DeleteCustomerRow(e.RowIndex);
        }
    }
}