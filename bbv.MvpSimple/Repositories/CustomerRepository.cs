// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerRepository.cs" company="bbv Software Services AG">
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

namespace bbv.MvpSimple.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerRepository
    {
        public IReadOnlyList<Customer> GetAll()
        {
            using (var context = new NorthwindEntities())
            {
                var query = from customer in context.Customers
                            select customer;

                return query.ToList();
            }
        }

        public IReadOnlyList<Customer> GetMatching(string company)
        {
            string searchTerm = company.Trim();

            using (var context = new NorthwindEntities())
            {
                var query = from customer in context.Customers
                            where customer.Company_Name.Contains(searchTerm)
                            select customer;

                return query.ToList();
            }
        }

        public Customer Get(string id)
        {
            using (var context = new NorthwindEntities())
            {
                var query = from customer in context.Customers
                            where customer.Customer_ID == id
                            select customer;

                return query.FirstOrDefault();
            }
        }

        public void Delete(string id)
        {
            using (var context = new NorthwindEntities())
            {
                Customer customerToDelete = context.Customers.First(x => x.Customer_ID == id);
                context.Customers.Remove(customerToDelete);
                context.SaveChanges();
            }
        }
    }
}