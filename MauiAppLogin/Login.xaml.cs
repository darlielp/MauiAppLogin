namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<UsuarioCadastrados> lista_usuario = new List<UsuarioCadastrados>()
			{ 
				new UsuarioCadastrados()
				{
					Usuario = "jose",
					Senha = "123"
				},
				new UsuarioCadastrados()
				{
					Usuario = "maria",
					Senha = "321"
				}
			};

			UsuarioCadastrados dados_digitados = new UsuarioCadastrados()
			{
				Usuario = usuario.Text,
				Senha = senha.Text
			};

			if (lista_usuario.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
				App.Current.MainPage = new Protegida();
			} else
			{
				throw new Exception("Senha ou Usuario Invalidos");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}