using BuzzerBernd.Models;
using BuzzerBernd.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuzzerBernd.Pages
{
    public partial class Buzzer
    {
        [Inject]
        public UserService UserService { get; init; }

        [Inject]
        public BuzzerService BuzzerService { get; init; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnInitialized();
            if (UserService.User == null)
                NavigationManager.NavigateTo("/", false);
        }

        private void ResetResults()
        {
            BuzzerService.Results = new List<Buzz>();
        }

        private void Buzz()
        {
            BuzzerService.Results.Add(new Buzz
            {
                Timestamp = DateTime.Now,
                User = UserService.User
            });
        }

        private IEnumerable<Buzz> GetSortedResults()
        {
            var sortedList = BuzzerService.Results.OrderBy(buzz => buzz.Timestamp);
            return sortedList;
        }

        private string GetFormattedBuzzTime(DateTime dateTime)
        {
            return dateTime.ToString();
        }
    }
}
