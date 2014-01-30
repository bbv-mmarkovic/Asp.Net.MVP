// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchCustomerPresenter.cs" company="officeatwork AG">
//   2009-2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace bbv.MvpSimple
{
    using System;

    public interface ISearchCustomerPresenter
    {
        event SearchCustomerPresenter.PerformSearchByCompanyHandler SearchPerformed;

        event SearchCustomerPresenter.ClearSearchHandler SearchCleared;

        void Search();

        void Clear();

        void Initialize(ISearchCustomerView view);
    }

    public class SearchCustomerPresenter : ISearchCustomerPresenter
    {
        private ISearchCustomerView view;

        public delegate void PerformSearchByCompanyHandler(object sender, PerformSearchByCompanyEventArgs eventArgs);

        public delegate void ClearSearchHandler(object sender, EventArgs eventArgs);

        public event PerformSearchByCompanyHandler SearchPerformed;

        public event ClearSearchHandler SearchCleared;

        public void Initialize(ISearchCustomerView view)
        {
            this.view = view;
        }

        public void Search()
        {
            this.view.ClearSearchButtonEnabled = !string.IsNullOrWhiteSpace(this.view.SearchTerm);

            if (this.SearchPerformed != null)
            {
                this.SearchPerformed(this, new PerformSearchByCompanyEventArgs(this.view.SearchTerm));
            }
        }

        public void Clear()
        {
            this.view.SearchTerm = string.Empty;
            this.view.ClearSearchButtonEnabled = false;

            if (this.SearchCleared != null)
            {
                this.SearchCleared(this, new EventArgs());
            }
        }
    }
}