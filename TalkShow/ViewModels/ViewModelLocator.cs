using Autofac;
using TalkShow.Common;

namespace TalkShow.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IContainer container;

        public ViewModelLocator()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MessageService>().As<IMessageService>();
            containerBuilder.RegisterType<MainViewModel>();

            this.container = containerBuilder.Build();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return this.container.Resolve<MainViewModel>();
            }
        }
    }
}
