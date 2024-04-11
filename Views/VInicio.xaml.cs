using System.Windows.Input;

namespace BVallejoT2.Views;

public partial class VInicio : ContentPage
{

    public VInicio()
	{
		InitializeComponent();

    }
    private void ValidateEntry(object sender, TextChangedEventArgs e){

        var entry = (Entry)sender;        
        double value;
        
        if (double.TryParse(entry.Text, out value))
        {
            if (value < 0.1 || value > 10)
            {
                entry.Text = entry.Text.Substring(0, entry.Text.Length - 1);
                DisplayAlert("Error", "El valor debe estar entre 0.01 y 10", "OK");
            }else 
            if(entry.Text.Substring(entry.Text.IndexOf(".")+ 1).Length>2)
            {
                
                entry.Text = e.OldTextValue;
            }
        }
        else if(entry.Text.Length>0)
        {
            DisplayAlert("Error", "Solo se permiten números", "OK");
            entry.Text = e.OldTextValue;
        }
    }

    private void btnSave(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            DisplayAlert("Error", "Formulario Incompleto", "Ok");
            return;
        }
        decimal n1 = Decimal.Parse(txtNota1.Text);
        decimal ne1 = Decimal.Parse(txtNotaExamen.Text);
        decimal par1 = (n1 * 0.3m)+(ne1*0.2m);
        decimal n2 = Decimal.Parse(txtNota12p.Text);
        decimal ne2 = Decimal.Parse(txtNotaExamen2.Text);
        decimal par2 = (n2 * 0.3m) + (ne2 * 0.2m);
        decimal nf = par1 + par2;
        string estudiante = pkEstudiante.SelectedItem.ToString()!;
        LP1.Text = par1.ToString();
        NotaFinal1.Text=par1.ToString();
        LP2.Text = par2.ToString();
        NotaFinal2.Text= par2.ToString();
        lNF.Text = nf.ToString();
        LEstudiante.Text = estudiante;
        string msg = "";
        switch (nf)
        {
            case decimal n when (n >= 0 && n < 5):
                FResultados.BackgroundColor = Colors.Red;
                msg = "-Reprovado-";
                break;
            case decimal n when (n >= 6 && n < 7):
                FResultados.BackgroundColor = Colors.Orange;
                msg = "-Complementario-";
                break;
            case decimal n when (n >= 7 && n <= 10):
                FResultados.BackgroundColor = Colors.Green;
                msg = "-Aprovado-";
                break;
        }
        LMsg.Text= msg;
        showAlert(estudiante, par1,par2,msg);
    }
     
    private bool ValidateForm()
    {

        if (
            string.IsNullOrEmpty(txtNota1.Text) ||
            string.IsNullOrEmpty(txtNotaExamen.Text) ||
            string.IsNullOrEmpty(txtNota12p.Text) ||
            string.IsNullOrEmpty(txtNotaExamen2.Text) ||
            pkEstudiante.SelectedItem==null
            )
        {
            return true;
        }
        return false;
    }

    async public void showAlert(string estudiante,decimal par1, decimal par2,string msg)
    {
        await DisplayAlert("Notas Finales", $"Estudiante: {estudiante}\n"+
            $"Parcial 1: {par1}\n"+
            $"Parcial 2: {par2}\n" +
            $"Nota Final: {par1+par2}\n" +
            $"{msg.ToUpper()}" 
            , "OK");
    }
    
}