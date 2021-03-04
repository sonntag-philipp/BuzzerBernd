using BuzzerBernd.Models;
using BuzzerBernd.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuzzerBernd.Pages
{
    public partial class Buzzer : IDisposable
    {

        [Inject]
        public UserService UserService { get; init; }

        [Inject]
        public BuzzerService BuzzerService { get; init; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        private bool _disposedValue;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnInitialized();
            if (UserService.User == null)
                NavigationManager.NavigateTo("/", false);

            BuzzerService.ResultsChanged += BuzzerService_ResultsChanged;
        }

        private void BuzzerService_ResultsChanged(object sender, List<Buzz> e)
        {
            InvokeAsync(StateHasChanged);
        }

        private bool HasBuzzered()
        {
            return BuzzerService.Results.Any(result => result.User.Id == UserService.User.Id);
        }

        private void ResetResults()
        {
            BuzzerService.Results = new List<Buzz>();
        }

        private void Buzz()
        {
            if (!HasBuzzered())
            {
                BuzzerService.AddResult(new Buzz
                {
                    Timestamp = DateTime.Now,
                    User = UserService.User
                });
            }
        }

        private IEnumerable<Buzz> GetSortedResults()
        {
            var sortedList = BuzzerService.Results.OrderBy(buzz => buzz.Timestamp);
            return sortedList;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    BuzzerService.ResultsChanged -= BuzzerService_ResultsChanged;
                    BuzzerService.Users.Remove(UserService.User);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
