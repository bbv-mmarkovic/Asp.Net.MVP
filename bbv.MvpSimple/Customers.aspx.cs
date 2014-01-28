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

    public partial class Customers : Page
    {
        private readonly CustomerRepository repository;

        public Customers()
        {
            this.repository = new CustomerRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SearchCustomerControl1.SearchPerformed += this.SearchCustomerControl_OnSearchPerformed;
            this.SearchCustomerControl1.SearchCleared += this.SearchCustomerControl_OnSearchCleared;

            this.gvCustomers.DataSource = this.repository.GetAll();
            this.gvCustomers.DataBind();
        }

        protected void gvCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var customerList = (IReadOnlyList<Customer>)this.gvCustomers.DataSource;
            Customer customerToDelete = customerList[e.RowIndex];

            this.repository.Delete(customerToDelete.Customer_ID);
        }

        private void SearchCustomerControl_OnSearchPerformed(object sender, PerformSearchByCompanyEventArgs eventArgs)
        {
            this.gvCustomers.DataSource = this.repository.GetMatching(eventArgs.SearchTerm);
            this.gvCustomers.DataBind();
        }

        private void SearchCustomerControl_OnSearchCleared(object sender, EventArgs eventArgs)
        {
            this.gvCustomers.DataSource = this.repository.GetAll();
            this.gvCustomers.DataBind();
        }
    }
}