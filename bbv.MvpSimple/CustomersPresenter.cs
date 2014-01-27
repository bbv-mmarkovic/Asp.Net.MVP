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
    using bbv.MvpSimple.Repositories;

    public class CustomersPresenter
    {
        private readonly ICustomersView view;

        public CustomersPresenter(ICustomersView view)
        {
            this.view = view;
        }

        public void LoadCustomers()
        {
            var repository = new CustomerRepository();

            this.view.CustomersGridView.DataSource = repository.GetAll();
            this.view.CustomersGridView.DataBind();
        }
    }
}