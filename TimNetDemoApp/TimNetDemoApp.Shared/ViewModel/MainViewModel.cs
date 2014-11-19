using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Pixer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TimNetDemoApp.Interfaces;

namespace TimNetDemoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private PixerClient pixerClient;
        private IStatusNotificationService statusNotificationService;
        public MainViewModel(IStatusNotificationService statusNotificationService)
        {
            Photos = new ObservableCollection<Photo>();
            GetImagesCommand = new RelayCommand(async () => await GetImagesAsync());

            this.pixerClient = new PixerClient();
            this.statusNotificationService = statusNotificationService;
            IsBusy = false;
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                Set<bool>(() => IsBusy, ref _IsBusy, value);
            }
        }

        public ICommand GetImagesCommand { get; private set; }
        public IList<Photo> Photos { get; private set; }

        private async Task GetImagesAsync()
        {
#if WINDOWS_PHONE_APP
            await statusNotificationService.SetStatusAsync("Getting images");
            var noOfImages = 35;
#endif
#if WINDOWS_APP
            var noOfImages = 50;
            IsBusy = true;
#endif
            var photos = await pixerClient.GetPhotosAsync(noOfImages);
            foreach (var photo in photos)
            {
                Photos.Add(photo);
            }

#if WINDOWS_PHONE_APP
            await statusNotificationService.SetStatusAsync(null);
#endif
#if WINDOWS_APP
            IsBusy = false;
#endif
            ToastService.ShowToast("Done!");
        }

//#if WINDOWS_PHONE_APP
//        private async Task GetImagesAsync()
//        {
//            await statusNotificationService.SetStatusAsync("Getting images");
//            var noOfImages = 35;
//            var photos = await pixerClient.GetPhotosAsync(noOfImages);
//            foreach (var photo in photos)
//            {
//                Photos.Add(photo);
//            }
//            await statusNotificationService.SetStatusAsync(null);
//        }
//#endif

//#if WINDOWS_APP
//        private async Task GetImagesAsync()
//        {
//            var noOfImages = 50;
//            IsBusy = true;
//            var photos = await pixerClient.GetPhotosAsync(noOfImages);
//            foreach (var photo in photos)
//            {
//                Photos.Add(photo);
//            }
//            IsBusy = false;
//        }
//#endif
    }
}