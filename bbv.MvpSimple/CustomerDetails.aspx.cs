// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerDetails.aspx.cs" company="bbv Software Services AG">
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
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using bbv.MvpSimple.Repositories;

    public interface ICustomerDetailsView
    {
        DetailsView CustomerDetailsView { get; }
    }

    public partial class CustomerDetails : Page, ICustomerDetailsView
    {
        private readonly CustomerDetailsPresenter presenter;

        public CustomerDetails()
        {
            this.presenter = new CustomerDetailsPresenter(this, new CustomerRepository());
        }

        public DetailsView CustomerDetailsView
        {
            get { return this.dvDetails; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter.LoadAndShowCustomerDetails(Request.Params["id"]);
        }
    }
}