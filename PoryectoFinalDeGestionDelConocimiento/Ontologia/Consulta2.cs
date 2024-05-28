using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VDS.RDF.Query;

namespace PoryectoFinalDeGestionDelConocimiento.Ontologia
{
    public class Consulta2
    {
        private static string baseURL = @"http://localhost:3030/dss/sparql";

        public Consulta2()
        {
        }
        public DataTable ConsultarDatosGenerales(string value)
        {
            string query = @" PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                              PREFIX academia: <http://www.semanticweb.org/danielanuñez/ontologies/2024/ACADEMIA#>
                              PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                              PREFIX owl: <http://www.w3.org/2002/07/owl#>
                              PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>

                  SELECT DISTINCT ?subject ?object
         WHERE {
         ?object rdf:type ?subclass.
         ?object rdfs:subClassOf academia:PROFESOR.
         ?subject rdf:type ?object.
         FILTER (REGEX(str(?object),'" + value + "','i') )}";

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

