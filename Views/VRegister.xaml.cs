namespace BVallejoT2.Views;

public partial class VRegister : ContentPage
{
	public VRegister()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VLogin());

    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        string user=txtUser.Text;
        string pass = txtPassword.Text;
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            DisplayAlert("Error", "Usuario o contraseña vacíos", "Ok");
            return;
        }
        if (user.Length<3 || pass.Length < 3)
        {
            DisplayAlert("Error", "Formulario incompleto", "Ok");
            return;
        }
        else {
            Navigation.PushAsync(new VLogin(user, pass));
        }

    }
}