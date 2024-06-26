﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsuarioNuevo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Image img = (Image)Master.FindControl("imgPerfil");
            try
            {
                if (!IsPostBack)
                {
                    if (Session["usutemporal"] != null)
                    {
                        Usuario usutemp = (Usuario)Session["usutemporal"];

                        txtId.Text = usutemp.Id.ToString();
                        txtEmail.Text = usutemp.Email;
                        txtNombre.Text = usutemp.Nombre;
                        txtApellido.Text = usutemp.Apellido;
                        chkAdmin.Checked = usutemp.Admin;
                        chkAdmin.Visible = false;
                        txtPasword.Text = "************";
                        txtPasword.ReadOnly = true;

                        // Verificar si es null
                        if (string.IsNullOrEmpty(usutemp.UrlImagenPerfil))
                        {
                            //  imagen predeterminada
                            imgPerfil.ImageUrl = ResolveUrl("~/img/imagen_predeterminada.jpg");
                        }
                        else
                        {
                            // Cargar la imagen del usuario temporal
                            imgPerfil.ImageUrl = usutemp.UrlImagenPerfil;
                            txtUrlImagen.Text = usutemp.UrlImagenPerfil;
                            img.ImageUrl = usutemp.UrlImagenPerfil;
                        }

                    }
                    else
                        if (Session["usuarioActivo"] != null)
                    {

                        if (Request.QueryString["Id"] != null && ((Usuario)Session["usuarioActivo"]).Admin)
                        {
                            UsuarioNegocio negousu = new UsuarioNegocio();
                            Usuario usu1 = negousu.traerUsuario(int.Parse(Request.QueryString["Id"]));

                            txtId.Text = usu1.Id.ToString();
                            txtId.ReadOnly = true;

                            txtEmail.Text = usu1.Email.ToString();
                            txtEmail.ReadOnly = true;

                            txtPasword.Text = "************";
                            btnPassNueva.Visible = false;
                            txtPasword.ReadOnly = true;

                            txtNombre.Text = usu1.Nombre;
                            txtNombre.ReadOnly = true;

                            txtApellido.Text = usu1.Apellido;
                            txtApellido.ReadOnly = true;
                            lbladmin.Text = "administrador";
                            chkAdmin.Checked = usu1.Admin;

                            txtUrlImagen.ReadOnly = true;

                        }
                        else
                        {
                            Usuario usu = (Usuario)Session["usuarioActivo"];

                            txtId.Text = usu.Id.ToString();
                            txtId.ReadOnly = true;
                            txtEmail.Text = usu.Email.ToString();
                            txtEmail.ReadOnly = true;
                            txtPasword.Text = "************";
                            txtPasword.ReadOnly = true;
                            txtNombre.Text = usu.Nombre.ToString();
                            txtApellido.Text = usu.Apellido.ToString();
                            lbladmin.Text = " ";                          
                            chkAdmin.Checked = usu.Admin;

                            chkAdmin.Visible = false;
                            btnEliminar.Visible = false;

                            imgPerfil.ImageUrl = !string.IsNullOrEmpty(usu.UrlImagenPerfil) ? usu.UrlImagenPerfil.ToString() : ResolveUrl("~/img/imagen_no_encontrada.jpg");

                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }


        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {

            imgPerfil.ImageUrl = (!string.IsNullOrEmpty(txtUrlImagen.Text)) ? imgPerfil.ImageUrl = txtUrlImagen.Text : imgPerfil.ImageUrl = ResolveUrl("~/img/imagen_predeterminada.jpg");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar.aspx", false);
        }

        UsuarioNegocio usuNego = new UsuarioNegocio();
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usu = new Usuario();
                usu.Id = int.Parse(txtId.Text);
                usu.Nombre = txtNombre.Text;
                usu.Apellido = txtApellido.Text;
                usu.Email = txtEmail.Text;

                //validar la url 

                usu.UrlImagenPerfil = (!string.IsNullOrEmpty(txtUrlImagen.Text)) ? usu.UrlImagenPerfil = txtUrlImagen.Text : usu.UrlImagenPerfil = ((Usuario)Session["usuarioActivo"]).UrlImagenPerfil;



                usu.Admin = chkAdmin.Checked;

                if (Session["temporalpass"] as string != null)
                {
                    usu.Pass = Session["temporalpass"] as string;
                }
                else if (Session["usutemporal"] != null)
                {
                    usu.Pass = ((Usuario)Session["usutemporal"]).Pass;
                }
                else
                {
                    usu.Pass = ((Usuario)Session["usuarioActivo"]).Pass;
                }

                //guardamos modificacion en la bd
                usuNego.modificarUsuario(usu);

                // actualiza usuarioActivo
                Session["usuarioActivo"] = usu;

                //eliminamos las sessiones temporales si es que hay alguno
                if (Session["usutemporal"] != null)
                {
                    Session.Remove("usutemporal");
                }
                if (Session["temporalpass"] != null)
                {
                    Session.Remove("temporalpass");
                }

                //mensaje y redireccion

                ScriptManager.RegisterStartupScript(this, this.GetType(), "guardarAlerta", "alert('Se han registrado los cambios con exito.'); window.location.href = 'Default.aspx';", true);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnPassNueva_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuTemp = new Usuario();
                usuTemp.Id = int.Parse(txtId.Text);
                usuTemp.Email = txtEmail.Text;
                usuTemp.Nombre = txtNombre.Text;
                usuTemp.Apellido = txtApellido.Text;
                usuTemp.Pass = ((Usuario)Session["usuarioActivo"]).Pass;


                usuTemp.UrlImagenPerfil = (!string.IsNullOrEmpty(txtUrlImagen.Text)) ? usuTemp.UrlImagenPerfil = txtUrlImagen.Text : usuTemp.UrlImagenPerfil = ((Usuario)Session["usuarioActivo"]).UrlImagenPerfil;


                usuTemp.Admin = checked(usuTemp.Admin);

                Session.Add("usutemporal", usuTemp);
                Response.Redirect("NuevoPass.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                usuNego.eliminarUsuario(int.Parse(txtId.Text));

                Response.Redirect("Administrar.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}