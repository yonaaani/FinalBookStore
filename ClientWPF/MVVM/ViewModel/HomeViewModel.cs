using ClientWPF.Core;
using ClientWPF.Repositories.Implementation;
using ClientWPF.Repositories.Interfaces;
using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientWPF.MVVM.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        private readonly ProducersRepository _producersRepository;
        private readonly ProductsRepository _productsRepository;
        private readonly UsersRepository _usersRepository;
        public ObservableCollection<User> Users { get; set; }
        public HomeViewModel(ProductsRepository productsRepository, ProducersRepository producersRepository, UsersRepository usersRepository)
        {
            _producersRepository = producersRepository;
            _productsRepository = productsRepository;
            LoadProducersByRate();
            _usersRepository = usersRepository;

        }

        #region Accessors
        private int _productCounter;
        private User _currentUser;
        public int ProductCounter
        {
            get { return _productCounter; }
            set 
            {
                _productCounter = value;
                OnPropertyChanged(nameof(ProductCounter));
            }
        }
        private string _topProducers;
        public string TopProducers
        {
            get { return _topProducers; }
            set
            {
                _topProducers = value; 
                OnPropertyChanged(nameof(TopProducers));
            }
        }

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        #endregion

        #region Load data adapter
        private void LoadProducersByRate()
        {
            TopProducers = String.Empty;
            var producers = _producersRepository.GetProducersByRateAsc();
            if(producers.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                    TopProducers += $"{i + 1}. {producers[i].Name} \r\n";
            }
        }
        private void LoadCurrentUserData()
        {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            var user = _usersRepository.GetByUsername(userName);

            if (user != null)
            {
                // Присвоюємо ім'я користувача у властивість CurrentUser.Name
                CurrentUser.Name = $"Hello, {user.Name}";
            }
            else
            {
                CurrentUser.Name = "Invalid user";
                // Приховати дочірні вигляди.
            }
        }
        #endregion
    }
}
