using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using UamTTA.GUI.Contracts;
using UamTTA.GUI.Models;

namespace UamTTA.GUI.Services
{
    public class BudgetService : IBudgetService
    {
        public async Task<IEnumerable<Budget>> GetBudgetsAsync()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/budgets");
                var budgets = await response.Content.ReadAsAsync<IEnumerable<Budget>>();
                return budgets;
            }
        }

        private HttpClient CreateClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiAddress"])
            };
        }
    }
}