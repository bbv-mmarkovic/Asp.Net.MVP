// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchCustomerPresenterTest.cs" company="bbv Software Services AG">
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

namespace bbv.MvpSimple.Test
{
    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class SearchCustomerPresenterTest
    {
        private SearchCustomerPresenter testee;

        private ISearchCustomerView searchCustomerView;

        [SetUp]
        public void SetUp()
        {
            this.searchCustomerView = A.Fake<ISearchCustomerView>();

            this.testee = new SearchCustomerPresenter();
            this.testee.Initialize(this.searchCustomerView);
        }

        [Test]
        public void RaisesEventOnPerformedSearchWithSearchTermInEventArgs()
        {
            const string SearchTerm = "search term";
            PerformSearchByCompanyEventArgs searchByCompanyEventArgs = null;

            A.CallTo(() => this.searchCustomerView.SearchTerm).Returns(SearchTerm);
            this.testee.SearchPerformed += (sender, args) => searchByCompanyEventArgs = args;

            this.testee.Search();

            searchByCompanyEventArgs.Should().NotBeNull("event should be raised");
            searchByCompanyEventArgs.SearchTerm.Should().Be(SearchTerm);
        }

        [Test]
        public void RaisesEventOnClearedSearch()
        {
            bool eventRaised = false;

            this.testee.SearchCleared += (sender, args) => eventRaised = true;

            this.testee.Clear();

            eventRaised.Should().BeTrue("event should be raise");
        }
    }
}