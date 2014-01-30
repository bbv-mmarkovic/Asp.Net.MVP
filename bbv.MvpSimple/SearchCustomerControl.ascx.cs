// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchCustomerControl1.ascx.cs" company="bbv Software Services AG">
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
    using System.Web.UI;

    public interface ISearchCustomerView
    {
        string SearchTerm { get; set; }

        bool ClearSearchButtonEnabled { get; set; }
    }

    public partial class SearchCustomerControl : UserControl, ISearchCustomerView
    {
        private ISearchCustomerPresenter presenter;

        public string SearchTerm
        {
            get { return this.txtSearchTerm.Text; }
            
            set { this.txtSearchTerm.Text = value; }
        }

        public bool ClearSearchButtonEnabled
        {
            get { return this.btnClearSearch.Enabled; }

            set { this.btnClearSearch.Enabled = value; }
        }

        public void Initialize(ISearchCustomerPresenter presenter)
        {
            this.presenter = presenter;
            this.presenter.Initialize(this);
        }

        protected void btnSearchByCompany_Click(object sender, EventArgs e)
        {
            this.presenter.Search();
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            this.presenter.Clear();
        }
    }
}