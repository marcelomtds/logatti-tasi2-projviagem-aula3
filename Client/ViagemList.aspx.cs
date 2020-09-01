using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class ViagemList : System.Web.UI.Page
    {
        ViagemDBEntities context = new ViagemDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
        protected void GVResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = int.Parse(e.CommandArgument.ToString());
            lblSelectedId.Text = idItem.ToString();
            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("ViagemForm.aspx?id=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                DisplayModal(this);
            }
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lblSelectedId.Text);
                context.viagem.Remove(context.viagem.First(x => x.id == id));
                context.SaveChanges();
                SendMessage("Registro excluído com sucesso.", Color.Green);
                LoadGridView();
            }
            catch (Exception ex)
            {
                SendMessage($"Ocorreu um erro inesperado: {ex.Message}", Color.Red);
            }
        }
        private void LoadGridView()
        {
            gvResult.DataSource = context.viagem.ToList();
            gvResult.DataBind();
        }
        private void DisplayModal(Page page)
        {
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), "openModalConfirmation();", true);
        }
        private void SendMessage(string message, Color color)
        {
            lblMensagem.Text = message;
            lblMensagem.ForeColor = color;
            lblMensagem.Font.Bold = true;
        }
    }
}