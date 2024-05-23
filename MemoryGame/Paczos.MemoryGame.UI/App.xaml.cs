using System.Configuration;
using System.Data;
using System.Windows;
using Paczos.MemoryGame.DAO;
using Paczos.MemoryGame.DAO.DO;
using Paczos.MemoryGame.DAO.Entities;

namespace Paczos.MemoryGame.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UserRepository UserRepository { get; private set; }
        public static User FirstUser { get; set; }
        public static ImageManager ImageManager { get; private set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var context = new DAOContext();
            UserRepository = new UserRepository(context);
            UserRepository.TestUsers();
            ImageManager = new ImageManager();
            ImageManager.LoadImages("images");
        }
    }

}
