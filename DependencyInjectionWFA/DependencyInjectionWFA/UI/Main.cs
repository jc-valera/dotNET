using DependencyInjectionWFA.Services;

namespace DependencyInjectionWFA.UI
{
    public partial class Main : Form
    {
        public IMessageServiceBLL MessageService;

        public Main(IMessageServiceBLL messageService)
        {
            MessageService = messageService;

            InitializeComponent();

            lblMessage.Text = MessageService.GetSuccessMessage();
        }
    }
}
