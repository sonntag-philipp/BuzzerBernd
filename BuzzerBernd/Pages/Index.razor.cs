using BuzzerBernd.Models;
using BuzzerBernd.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace BuzzerBernd.Pages
{
    public partial class Index
    {
        [Inject]
        public BuzzerService BuzzerService { get; init; }

        [Inject]
        public UserService UserService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string userName;

        private void Join()
        {
            if (string.IsNullOrWhiteSpace(userName) || userName.Length > 20)
                throw new ArgumentException("Ungültiger Name. Bitte maximal 20 Zeichen verwenden.");

            if (BuzzerService.Users.Any(user => user.Name == userName))
                throw new ArgumentException("Der Name wird bereits verwendet.");

            User user = new User(userName, Guid.NewGuid());
            UserService.User = user;
            BuzzerService.Users.Add(user);
            NavigationManager.NavigateTo("/buzzer");
        }
    }
}
