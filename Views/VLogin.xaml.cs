namespace BVallejoT2.Views;

public class Usuario
{
    public string user { get; set; }
    public string pass { get; set; }
}

public partial class VLogin : ContentPage
{

    List<Usuario> usuarios = new List<Usuario>();


    public VLogin()
	{

        loadUsers();
       InitializeComponent();
	}
    public VLogin(string user, string pass)
    {
        loadUsers();
        usuarios.Add(new Usuario { user=user, pass=pass});
        InitializeComponent();
    }
    public void loadUsers()
    {
        usuarios.Add(new Usuario { user = "Carlos", pass = "carlos123" });
        usuarios.Add(new Usuario { user = "Ana", pass = "ana123" });
        usuarios.Add(new Usuario { user = "Jose", pass = "jose123" });

    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VRegister());
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        string user = txtUser.Text;
        string pass = txtPassword.Text;
        foreach (var usuario in usuarios)
        {
            
            if (usuario.user == user && usuario.pass == pass)
            {
                Navigation.PushAsync(new VInicio(user));
                return;
            }
        }
        DisplayAlert("Error", "Usuario incorrecto", "OK");

    }
}