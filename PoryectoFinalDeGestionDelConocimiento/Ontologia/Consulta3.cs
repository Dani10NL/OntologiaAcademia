using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VDS.RDF.Query;

namespace PoryectoFinalDeGestionDelConocimiento.Ontologia
{
    public class Consulta3
    {
        private static string baseURL = @"http://localhost:3030/dss/sparql";

        public Consulta3()
        {
        }


        public static bool EsNumero(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public DataTable ConsultarDatosGenerales(string value)
        {

            String filtro;
            if ("".Equals(value))
            {
                filtro = "?codigo > 1000";
            }
            else if (EsNumero(value))
            {
                filtro = "?codigo = " + value;
            }
            else
            {
                // Si el valor no es un número válido, hacer lo mismo que cuando no se proporciona ningún valor
                filtro = "?codigo > 1000";
            }

            
            string query = @" PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                              PREFIX academia: <http://www.semanticweb.org/danielanuñez/ontologies/2024/ACADEMIA#>
                              PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                              PREFIX owl: <http://www.w3.org/2002/07/owl#>
                              PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>

                            SELECT ?NIVEL ?CURSO ?ESTUDIANTE ?Numeroestudiantes ?codigo
                            WHERE { ?CURSO academia:CONTIENE_UN ?NIVEL.

                            ?NIVEL academia:ES_TOMADO_POR ?ESTUDIANTE.
                            ?NIVEL academia:Numeroestudiantes ?Numeroestudiantes.
                            ?NIVEL academia:codigo ?codigo.
                            filter (" + filtro + ")}";

            return excuteQuery(query);
        }


        public DataTable excuteQuery(string query)
        {
            try
            {
                SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri(baseURL));
                SparqlResultSet srs = endpoint.QueryWithResultSet(query);

                DataTable dataTable = new DataTable();
                var columns = srs.Variables;
                foreach (string s in columns)
                {
                    dataTable.Columns.Add(new DataColumn(s, typeof(string)));
                }

                foreach (var item in srs.Results)
                {
                    DataRow dr = dataTable.NewRow();
                    foreach (var result in item)
                    {
                        dr[result.Key] = result.Value;
                    }
                    dataTable.Rows.Add(dr);
                }

                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}

