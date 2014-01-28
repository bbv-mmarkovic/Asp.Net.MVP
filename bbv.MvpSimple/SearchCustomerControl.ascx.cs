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

    public partial class SearchCustomerControl : UserControl
    {
        public delegate void PerformSearchByCompanyHandler(object sender, PerformSearchByCompanyEventArgs eventArgs);
        
        public delegate void ClearSearchHandler(object sender, EventArgs eventArgs);

        public event PerformSearchByCompanyHandler SearchPerformed;

        public event ClearSearchHandler SearchCleared;

        protected void btnSearchByCompany_Click(object sender, EventArgs e)
        {
            if (this.SearchPerformed != null)
            {
                this.SearchPerformed(this, new PerformSearchByCompanyEventArgs(this.txtSearchTerm.Text));
            }
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            this.txtSearchTerm.Text = string.Empty;

            if (this.SearchCleared != null)
            {
                this.SearchCleared(this, new EventArgs());
            }
        }
    }
}