using Microsoft.Extensions.DependencyInjection;
using RobotBLL.Abstraction;
using RobotBLL.Implementation;
using RobotBLL.Implementation.Services;
using RobotWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RobotWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow, MainWindow>();
            services.AddTransient<GameWindow, GameWindow>();
            services.AddTransient<IModel, Model>();
            services.AddTransient<ViewModel, ViewModel>();
            services.AddTransient<GameViewModel, GameViewModel>();
            services.AddTransient<ICommandController, CommandController>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IGameController, GameController>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModel viewModel = serviceProvider.GetService<ViewModel>();
            new MainWindow { DataContext = viewModel };
            MainWindow.Show();

            GameViewModel gameViewModel = serviceProvider.GetService<GameViewModel>();
            new GameWindow() {DataContext = gameViewModel};
        }
    }
}
