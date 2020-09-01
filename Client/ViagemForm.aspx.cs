﻿using System;
using System.Drawing;
using System.Linq;

namespace Client
{
    public partial class ViagemForm : System.Web.UI.Page
    {
        ViagemDBEntities context = new ViagemDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDescricao.Focus();
                LoadDataPage();
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    int id = int.Parse(txtId.Text);
                    viagem viagemResult = context.viagem.First(x => x.id == id);
                    viagemResult.descricao = txtDescricao.Text;
                    viagemResult.data = DateTime.Parse(txtData.Text);
                    SendMessage("Registro alterado com sucesso.", Color.Green);
                }
                else
                {
                    viagem viagem = new viagem()
                    {
                        descricao = txtDescricao.Text,
                        data = DateTime.Parse(txtData.Text)
                    };
                    context.viagem.Add(viagem);
                    SendMessage("Registro criado com sucesso.", Color.Green);
                }
                context.SaveChanges();
                ResetForm(true);
            }
            catch (Exception ex)
            {
                SendMessage($"Ocorreu um erro inesperado: {ex.Message}", Color.Red);
            }

        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = String.Empty;
            ResetForm(false);
        }
        private void ResetForm(bool clearId)
        {
            if (clearId)
            {
                txtId.Text = String.Empty;
            }
            txtDescricao.Text = String.Empty;
            txtData.Text = String.Empty;
        }
        private void LoadDataPage()
        {
            string id = Request.QueryString["id"];
            if (!String.IsNullOrEmpty(id))
            {
                int newId = Convert.ToInt32(id);
                var viagemResult = context.viagem.First(x => x.id == newId);
                txtId.Text = viagemResult.id.ToString();
                txtDescricao.Text = viagemResult.descricao;
                txtData.Text = viagemResult.data.ToString();
            }
        }
        private void SendMessage(string message, Color color)
        {
            lblMensagem.Text = message;
            lblMensagem.ForeColor = color;
            lblMensagem.Font.Bold = true;
        }
    }
}