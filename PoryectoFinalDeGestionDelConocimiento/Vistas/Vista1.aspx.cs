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
    public partial class Vista1 : System.Web.UI.Page
    {
        Consulta1 ontologia = new Consulta1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void searchOntology(object sender, EventArgs e)
        {

            DataTable p = ontologia.ConsultarDatosGenerales(search.Text);


            for (int i = 0; i < p.Rows.Count; i++)
            {
                string k = p.Rows[i]["CURSO"].ToString();
                string[] Arr = k.Split('#');
                p.Rows[i]["CURSO"] = Arr[1];


                string k2 = p.Rows[i]["ESTUDIANTE"].ToString();
                string[] Arr2 = k2.Split('#');
                p.Rows[i]["ESTUDIANTE"] = Arr2[1];


                string k3 = p.Rows[i]["JEFECURSO"].ToString();
                string[] Arr3 = k3.Split('#');
                p.Rows[i]["JEFECURSO"] = Arr3[1];

            }

            ListViewResult.DataSource = p;

            ListViewResult.DataBind();

        }

    }
}