using PoryectoFinalDeGestionDelConocimiento.Ontologia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoryectoFinalDeGestionDelConocimiento.Vistas
{
    public partial class Vista2 : System.Web.UI.Page
    {
        Consulta2 ontologia = new Consulta2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchOntology(object sender, EventArgs e)
        {

            DataTable p = ontologia.ConsultarDatosGenerales(search.Text);

            for (int i = 0; i < p.Rows.Count; i++)
            {
                string k = p.Rows[i]["subject"].ToString();
                string[] Arr = k.Split('#');
                p.Rows[i]["subject"] = Arr[1];


                string k2 = p.Rows[i]["object"].ToString();
                string[] Arr2 = k2.Split('#');
                p.Rows[i]["object"] = Arr2[1];



            }

            ListViewResult.DataSource = p;

            ListViewResult.DataBind();

        }
    }
}