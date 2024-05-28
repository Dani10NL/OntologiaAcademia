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
    public partial class Vista3 : System.Web.UI.Page
    {
        Consulta3 ontologia = new Consulta3();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void searchOntology(object sender, EventArgs e)
        {

            DataTable p = ontologia.ConsultarDatosGenerales(search.Text);

            for (int i = 0; i < p.Rows.Count; i++)
            {
                string k = p.Rows[i]["NIVEL"].ToString();
                string[] Arr = k.Split('#');
                p.Rows[i]["NIVEL"] = Arr[1];


                string k2 = p.Rows[i]["CURSO"].ToString();
                string[] Arr2 = k2.Split('#');
                p.Rows[i]["CURSO"] = Arr2[1];


                string k3 = p.Rows[i]["ESTUDIANTE"].ToString();
                string[] Arr3 = k3.Split('#');
                p.Rows[i]["ESTUDIANTE"] = Arr3[1];

                string k4 = p.Rows[i]["Numeroestudiantes"].ToString().Substring(0, 1);
                p.Rows[i]["Numeroestudiantes"] = k4;

                string k5 = p.Rows[i]["codigo"].ToString().Substring(0,4);
                p.Rows[i]["codigo"] = k5;

            }

            ListViewResult.DataSource = p;

            ListViewResult.DataBind();

        }
    }
}